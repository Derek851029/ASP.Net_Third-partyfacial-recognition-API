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
using System.Reflection;
using System.Web.Services;
using Newtonsoft.Json;

public partial class Report_PrintingView : System.Web.UI.Page
{
    private int m_currentPageIndex;
    private IList<Stream> m_streams;
    protected string strSYSID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                var mail_session = Session["Mail_SYSID"].ToString();
                if (mail_session != "" && mail_session != null)
                {
                    strSYSID = mail_session.Trim();
                    var dtTimeBegin = DateTime.Now;
                    var DB = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["fg080"].ToString();
                    var strSql = @"select * from SENDDOC where SYSID=@SYSID ";
                    using (SqlConnection sqlcon = new SqlConnection(DB))
                    {
                        using (SqlDataAdapter myAdp = new SqlDataAdapter(strSql, sqlcon))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                myAdp.SelectCommand.Parameters.Clear();
                                myAdp.SelectCommand.Parameters.Add("@SYSID", SqlDbType.BigInt).Value = strSYSID;
                                myAdp.Fill(ds, "SENDDOC");
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                                    ReportViewer1.PageCountMode = PageCountMode.Actual;

                                    ReportDataSource rtpDs = new ReportDataSource("DataSet1", ds.Tables[0]);
                                    ReportViewer1.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/Report/") + "PrintingService.rdlc";

                                    ReportViewer1.LocalReport.DataSources.Clear();
                                    ReportViewer1.LocalReport.DataSources.Add(rtpDs);
                                    ReportViewer1.Visible = true;
                                    ReportViewer1.LocalReport.Refresh();
                                }
                                else
                                {
                                    WebClassFunc.ShowMessage("查無資料");
                                }
                            }
                        }
                    }
                }
                else
                {
                    WebClassFunc.ShowMessage("沒有帶入索引編號,無法預覽");
                }
            }
            DisableUnwantedExportFormat(ReportViewer1, "Excel");
            DisableUnwantedExportFormat(ReportViewer1, "PDF");
        }
        catch (Exception ex)
        {
            //ex.WriteErrorLog();
        }
    }

    public void DisableUnwantedExportFormat(ReportViewer ReportViewerID, string strFormatName)
    {
        FieldInfo info;

        foreach (RenderingExtension extension in ReportViewerID.LocalReport.ListRenderingExtensions())
        {
            if (extension.Name == strFormatName)
            {
                info = extension.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
                info.SetValue(extension, false);
            }
        }
    }
}