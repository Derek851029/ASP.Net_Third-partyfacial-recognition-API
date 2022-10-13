using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserChart : System.Web.UI.Page
{
    public string labels = "";
    public string datas = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string type = Request.QueryString["type"].ToString();
            StringBuilder Items = new StringBuilder();
            var now = DateTime.Now;
            var sdate = now.AddDays(-10);
            for(int i = 0; i<10; i++)
            {
                sdate = sdate.AddDays(1);
                Items.Append(sdate.ToString("yyyy-MM-dd"));
                Items.Append(",");
            }
            Items.Remove(Items.Length-1,1);
            labels = Items.ToString();
            Items.Clear();
            Random r = new Random();
            for(int i = 0; i<10; i++)
            {
                switch (type)
                {
                    case "心臟":
                        Items.Append(r.Next(100, 130));
                        Items.Append(",");
                        break;
                    default:
                        Items.Append(r.Next(0, 30));
                        Items.Append(",");
                        break;
                }
            }
            Items.Remove(Items.Length - 1, 1);
            datas = Items.ToString();
        }
    }
}