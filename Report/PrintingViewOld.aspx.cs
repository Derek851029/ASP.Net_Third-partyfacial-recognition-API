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

public partial class Report_PrintingViewOld : System.Web.UI.Page
{
    private int m_currentPageIndex;
    private IList<Stream> m_streams;
    protected string ApplyNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                var oldMail_Session = Session["oldMailApplyNo"].ToString();
                if (oldMail_Session != "" && oldMail_Session != null)
                {
                    ApplyNo = oldMail_Session.Trim();
                    var dtTimeBegin = DateTime.Now;
                    var DB = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["fg080"].ToString();
                    var strSql = @"SELECT [ApplyDoc_ApplyNo]
                        ,[ApplyDoc_ChangeItem]
                        ,[ApplyDoc_Doc]
                        ,[ApplyDoc_DocAppend]
                        ,[ApplyDoc_Notice]
                        ,[ApplyDoc_Noticetxt]
                        ,(SUBSTRING([ApplyDoc_CreateDate],1,3) + N'/' + SUBSTRING([ApplyDoc_CreateDate],4,2) + N'/' +SUBSTRING([ApplyDoc_CreateDate],6,2)) AS ApplyDoc_CreateDate
                        ,[Emp_AccountModify]
                        ,[dbo].[fnParamValue]([ApplyDoc_Send]) AS [ApplyDoc_Send]
	                    ,(SUBSTRING(ApplyDoc_CreateDate,1,3) + N'/' + SUBSTRING(ApplyDoc_CreateDate,4,2) + N'/' +SUBSTRING(ApplyDoc_CreateDate,6,2)) AS ApplyDoc_SendDate
                        ,[Policy_Address]
                        ,[Recipients]
                        ,[Address_ZIP]
                    FROM [ApplyDoc]
                    WHERE ApplyDoc_ApplyNo = @ApplyNo";
                    using (SqlConnection sqlcon = new SqlConnection(DB))
                    {
                        using (SqlDataAdapter myAdp = new SqlDataAdapter(strSql, sqlcon))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                myAdp.SelectCommand.Parameters.Clear();
                                myAdp.SelectCommand.Parameters.Add("@ApplyNo", SqlDbType.NVarChar).Value = ApplyNo;
                                myAdp.Fill(ds, "ApplyDoc");
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                                    ReportViewer1.PageCountMode = PageCountMode.Actual;
                                    ReportDataSource rtpDs = new ReportDataSource("DataSet1", ds.Tables[0]);
                                    ReportViewer1.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/Report/") + "PrintingServiceOld.rdlc";
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