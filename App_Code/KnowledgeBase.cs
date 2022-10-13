using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// KnowledgeBase 的摘要描述
/// </summary>
public class KnowledgeBase
{
    //knowledgebase
    public string KID { get; set; }
    public string txtTitle { get; set; }
    public string txtContent { get; set; }
    public string Click { get; set; }
    public string UserID { get; set; }
    public DateTime createDate { get; set; }
    public string updateUser { get; set; }
    public DateTime updateDate { get; set; }
    public string flag { get; set; }

    //mainclass
    public string KMID { get; set; }
    public string KMTXT { get; set; }

    //mainclass
    public string KSID { get; set; }
    public string KSTXT { get; set; }

    //file
    public string KFID { get; set; }
    public string FilePath { get; set; }
    public string FilesName { get; set; }

    //Other
    public string Agent_Name { get; set; }


    public static List<KnowledgeBase> ClassSearch(string flag = "0", string ID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspKnowledgeClassSearch ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@ID = @i ");

        return DBTool.Query<KnowledgeBase>(sqlcmd.ToString(), new { 
            f = flag,
            i = ID
        }).ToList();
    }

    public static void ClassEdit(string flag = "0", string UserID = "", string ID = "0", string TXT = "", string SID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspKnowledgeClassEdit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@UserID = @u ");
        sqlcmd.Append(" ,@ID = @i ");
        sqlcmd.Append(" ,@TXT = @t ");
        sqlcmd.Append(" ,@SID = @s ");

        DBTool.Query<KnowledgeBase>(sqlcmd.ToString(), new { 
            f = flag,
            u = UserID,
            i = ID,
            t = TXT,
            s = SID
        });
    }

    public static List<KnowledgeBase> KnowledgeSearch(string flag = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspKnowledgeSearch ");
        sqlcmd.Append(" @flag = @f ");

        return DBTool.Query<KnowledgeBase>(sqlcmd.ToString(), new { 
            f = flag
        }).ToList();
    }

    public static List<KnowledgeBase> KnowledgeEdit(string flag = "0", string SID = "0", string Title = "", string Content = "", string UserID = "", string ID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspKnowledgeBaseEdit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@KSID = @sid ");
        sqlcmd.Append(" ,@Title = @t ");
        sqlcmd.Append(" ,@Content = @c ");
        sqlcmd.Append(" ,@UserID = @u ");
        sqlcmd.Append(" ,@ID = @i ");

        return DBTool.Query<KnowledgeBase>(sqlcmd.ToString(), new { 
            f = flag,
            sid = SID,
            t = Title,
            c = Content,
            u = UserID,
            i = ID
        }).ToList();
    }



}