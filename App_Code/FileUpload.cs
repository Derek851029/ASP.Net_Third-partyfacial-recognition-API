using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// FileUpload 的摘要描述
/// </summary>
public class FileUpload
{
    public string SYSID { get; set; }
    public string cusCaseID { get; set; }
    public string cusCaseFileName { get; set; }
    public string cusCaseFileRemark { get; set; }
    public DateTime createDate { get; set; }
    public string UserID { get; set; }
    public DateTime updateDate { get; set; }
    public string updateUserID { get; set; }
    public string Flag { get; set; }

    //KNOWLEDGE
    public string KFID { get; set; }
    public string KID { get; set; }
    public string FilePath { get; set; }
    public string FilesName { get; set; }


    public string Agent_Name { get; set; }


    public static void CusCaseFileUpload(string cusCaseID, string cusCaseFileName, string cusCaseFilePath, string cusCaseFileRemark, string UserID)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("INSERT INTO CusCase_File ");
        sqlcmd.Append(@"(cusCaseID, cusCaseFileName, cusCaseFilePath, cusCaseFileRemark, UserID) ");
        sqlcmd.Append("VALUES ");
        sqlcmd.Append("(@cusCaseID,@cusCaseFileName,@cusCaseFilePath,@cusCaseFileRemark,@UserID) ");

        DBTool.Query<FileUpload>(sqlcmd.ToString(), new { cusCaseID = cusCaseID, cusCaseFileName = cusCaseFileName, cusCaseFilePath = cusCaseFilePath, cusCaseFileRemark = cusCaseFileRemark, UserID = UserID });

    }

    public static List<FileUpload> CusCaseFileList(string ID)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("SELECT a.*, b.Agent_Name FROM CusCase_File a ");
        sqlcmd.Append("LEFT JOIN DispatchSystem b ON a.UserID = b.UserID ");
        sqlcmd.Append("WHERE Flag != 1 AND a.cusCaseID = @ID ");

        var result = DBTool.Query<FileUpload>(sqlcmd.ToString(), new { ID = ID}).ToList();
        return result;
    }

    public static void CusCaseFileEdit(string ID, string Flag, string Remark, string UserID)
    {
        StringBuilder sqlcmd = new StringBuilder();
        if(Flag == "1")
        {
            sqlcmd.Append("UPDATE CusCase_File SET Flag = @Flag,");
        }
        else
        {
            sqlcmd.Append("UPDATE CusCase_File SET cusCaseFileRemark = @Remark,");
        }
        sqlcmd.Append("updateUserID = @UserID, ");
        sqlcmd.Append("updateDate = @updateDate ");
        sqlcmd.Append("WHERE SYSID = @ID ");

        DBTool.Query<FileUpload>(sqlcmd.ToString(), new { 
            Flag = Flag, 
            Remark = Remark, 
            UserID = UserID,
            updateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            ID = ID
        });
    }


    public static void KnowledgeFileEdit(string flag = "0", string filepath = "", string name = "", string UserID ="",string ID="0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspKnowledgeFileEdit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@filepath = @fp ");
        sqlcmd.Append(" ,@name = @n ");
        sqlcmd.Append(" ,@ID = @i ");
        sqlcmd.Append(" ,@UserID = @u ");

        DBTool.Query<FileUpload>(sqlcmd.ToString(), new { 
            f = flag,
            fp = filepath,
            n = name,
            i = ID,
            u = UserID
        });
    }

    public static List<FileUpload> KnowledgeFileList(string flag = "0", string ID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspKnowledgeFileSearch ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@ID = @i ");

        return DBTool.Query<FileUpload>(sqlcmd.ToString(), new { 
            f = flag,
            i = ID
        }).ToList();
    }


}