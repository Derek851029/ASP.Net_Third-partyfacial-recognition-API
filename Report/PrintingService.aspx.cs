using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Drawing; //直接輸出印表
using System.Text;  // Encoding

public partial class Report_PrintingService : System.Web.UI.Page
{
    private int m_currentPageIndex;
    private IList<Stream> m_streams;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                var strSql = @" select SYSID from SENDDOC_TRUNCATE where printYN='N' order by SYSID ";
                var dtTimeBegin = DateTime.Now;
                var DB = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["fg080"].ToString();
                using (SqlConnection sqlCon = new SqlConnection(DB))
                {
                    using (SqlDataAdapter myAdp = new SqlDataAdapter(strSql, sqlCon))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            myAdp.SelectCommand.Parameters.Clear();
                            myAdp.SelectCommand.Parameters.Add("@TimeBegin", SqlDbType.DateTime).Value = dtTimeBegin;
                            myAdp.Fill(ds, "test");
                            foreach (DataRow itm in ds.Tables[0].Rows)
                            {
                                var sysid = itm["SYSID"].ToString();
                                var strSqlPRN = @" select SYSID from SENDDOC_TRUNCATE where SYSID=@SYSID ";
                                using (SqlConnection sqlConPRN = new SqlConnection(DB))
                                {
                                    using (SqlDataAdapter myAdpPRN = new SqlDataAdapter(strSqlPRN, sqlConPRN))
                                    {
                                        //有必要的話DataSet必須換成rdlc定義的DataSet名稱
                                        //using(SmarTel_T5DataSet dsPRN = new SmarTel_T5DataSet())
                                        using (DataSet dsPRN = new DataSet())
                                        {
                                            myAdpPRN.SelectCommand.Parameters.Clear();
                                            myAdpPRN.SelectCommand.Parameters.Add("@SYSID", SqlDbType.BigInt).Value = sysid;
                                            myAdpPRN.Fill(dsPRN, "SENDDOC_TRUNCATE");

                                            ReportDataSource rtpDs = new ReportDataSource("DataSet1", ds.Tables[0]);

                                            //直接輸出到印表機
                                            Microsoft.Reporting.WebForms.LocalReport localReport = new Microsoft.Reporting.WebForms.LocalReport();
                                            localReport.ReportPath = HttpContext.Current.Server.MapPath("~/Report/") + "PrintingService.rdlc";
                                            // 結繫資料時必須指定RDLC裡面資料集名稱
                                            // 且傳遞的資料必須是以 List<T> 的集合存在
                                            localReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", rtpDs));

                                            Export(localReport);
                                            // 指定使用 印表機 『Microsoft XPS Document Writer』
                                            Print("2F-C4504-201");
                                            localReport.Dispose();
                                        }
                                    }
                                }

                                var strSqlFinish = @" Update SENDDOC_TRUNCATE set printYN='Y' where SYSID=@SYSID ";
                                using (SqlConnection sqlConFinsh = new SqlConnection(DB))
                                {
                                    using (SqlCommand sqlComFinsh = new SqlCommand(strSqlFinish, sqlConFinsh))
                                    {
                                        sqlComFinsh.CommandText = strSqlFinish;
                                        sqlComFinsh.Parameters.Clear();
                                        sqlComFinsh.Parameters.Add("@SYSID", SqlDbType.BigInt).Value = sysid;
                                        sqlConFinsh.Open();
                                        sqlComFinsh.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //ex.WriteErrorLog();
            }
        }
    }

    private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
    {
        Stream stream = new MemoryStream();
        m_streams.Add(stream);
        return stream;
    }

    private void Export(Microsoft.Reporting.WebForms.LocalReport report)
    {
        //這裡是決定列印的紙張大小，RDLC只是用來排版的
        string deviceInfo =
          @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
        Microsoft.Reporting.WebForms.Warning[] warnings;
        m_streams = new List<Stream>();
        // 此處就是把 LocalReport 顯示的內容 轉成 Stream 資料
        report.Render("Image", deviceInfo, CreateStream, out warnings);
        foreach (Stream stream in m_streams)
            stream.Position = 0;
    }

    private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
    {
        //建立影像 Meta 同時把 Image Stream 倒入
        System.Drawing.Imaging.Metafile pageImage = new System.Drawing.Imaging.Metafile(m_streams[m_currentPageIndex]);

        // 調整繪製方塊大小同等印表機可列印空間
        System.Drawing.Rectangle adjustedRect = new System.Drawing.Rectangle(
            ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
            ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
            ev.PageBounds.Width,
            ev.PageBounds.Height);

        // 報表背景以白色塗刷
        ev.Graphics.FillRectangle(System.Drawing.Brushes.White, adjustedRect);

        // 繪製報表內容
        ev.Graphics.DrawImage(pageImage, adjustedRect);

        // 準備到下一頁繪製. 確保將資料繪製完畢
        m_currentPageIndex++;
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
    }

    private void Print(string printerName)
    {
        if (m_streams == null || m_streams.Count == 0)
            throw new Exception("Error: no stream to print.");
        System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
        // 可以設定要使用的印表機
        printDoc.PrinterSettings.PrinterName = printerName;
        if (!printDoc.PrinterSettings.IsValid)
        {
            throw new Exception("Error: cannot find the printer [" + printerName + "] .");
        }
        else
        {
            printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintPage);
            m_currentPageIndex = 0;
            printDoc.Print();
        }
    }
}