using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// ContextType 的摘要描述
/// </summary>
public class ContextType
{
	public int TypeID { get; set; }
	public string UserID { get; set; }
	public string TypeName { get; set; }
	public DateTime createDate { get; set; }
	public DateTime updateDate { get; set; }
	public int del_flag { get; set; }
    public string Agent_Name { get; set; }

    public static void Add(string name, string userid)
    {
        DBTool.Query<ContextType>(
            string.Format(@"uspContextType @name = N'{0}',@UserID = N'{1}'", name, userid), new { });
    }
    public static string Serch()
    {
        var result = DBTool.Query<ContextType>(string.Format(@"uspContextType @flag = 2"), new { });
        return JsonConvert.SerializeObject(result);
    }
    public static void Delete(int ID, string userid)
    {
        var result = DBTool.Query<ContextType>(
            string.Format(@"uspContextType @flag = 1, @ID = N'{0}', @UserID = N'{1}'", ID, userid), new { });
    }
    
    public static void Update(string ID = "0", string UserID = "", string text = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspContextType ");
        sqlcmd.Append(" @flag = 3 ");
        sqlcmd.Append(" ,@ID = @i ");
        sqlcmd.Append(" ,@name = @n ");
        sqlcmd.Append(" ,@UserID = @u ");

        DBTool.Query<ContextType>(sqlcmd.ToString(), new { 
            i = ID,
            n = text,
            u = UserID
        });

    }

}