using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod(EnableSession = true)]
    public static List<MenuNode> getMenu()
    {
        List<MenuNode> list = new List<MenuNode>();
        string userid = HttpContext.Current.Session["UserID"].ToString();
        if (userid == null)
        {
            return list;
        }

        //declare @Agent_Num nvarchar(10)='admin'
        string sql_txt = @";With ChildTable(TREE_ID,TREE_NAME,IMAGE_FILE,NAVIGATE_URL,PARENT_ID,LEVEL_ID,SORT_ID,IS_OPEN)
                            AS
                            (
                                --Recursive CTE分為兩個部分, 第一部分為Anchor Member
                                --指不會被遞迴呼叫到的部分

                                SELECT *
                                FROM PROGLIST P WHERE exists(select TREE_ID from ROLEPROG R where R.TREE_ID=P.TREE_ID AND P.IS_OPEN='Y' 
	                             AND exists(select Role_ID from DispatchSystem D where D.UserID=@Agent_Num AND D.Role_ID=R.Role_ID))
                                UNION ALL
                                --UNION ALL後方的部分稱為Recursive Member, 會在遞迴過程中反覆執行,直到無任何查詢結果為止
                                SELECT P.*
                                FROM PROGLIST P, ChildTable B
                                WHERE P.TREE_ID=B.PARENT_ID
                            )
                            SELECT DISTINCT  *
                            FROM ChildTable 
                            where PARENT_ID is not null
                            Order by TREE_ID, LEVEL_ID, SORT_ID ";

        var param = new { Agent_Num = userid };
        
        list = DBTool.Query<MenuNode>(sql_txt, param).ToList();
        return list;
    }


    [WebMethod(EnableSession =true)]
    public static string bindMenu()
    {
        return "";
    }
}