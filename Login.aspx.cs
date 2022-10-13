using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Web.Services;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }



    protected void UserLogin_Click(object sender, EventArgs e)
    {
        var account = act.Text;
        var password = pwd.Text;


        string Login_Status = "";
        string extn = "";
        try
        {
            Dispatchsystem Dispatchsystem_Serch_Session
                = new Dispatchsystem(account, password, out Login_Status, out extn);
            Dispatchsystem_Serch_Session.SessionSet();

            if(Login_Status == "false")
            {
                Response.Write(@"
                    <script>
                    alert('帳密輸入錯誤');
                    </script>
                ");
            }
            else
            {
                Response.Redirect("Dashboard.aspx");
            }
            
        }
        catch (Exception ex)
        {
            Response.Write(@"
                <script>
                alert('帳密輸入錯誤');
                </script>
            ");

        }
    }



}
