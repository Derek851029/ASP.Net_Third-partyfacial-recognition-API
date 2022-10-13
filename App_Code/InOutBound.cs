using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Windows.Forms;

/// <summary>
/// InOutBound 的摘要描述
/// </summary>
public class InOutBound
{
    public int _RequestType { get; set; }
    public string _ExtNO { get; set; }
    public string _PhoneNumber { get; set; }

    /// <summary>
    /// 初始化設定Extno,PhoneNumber
    /// </summary>
    /// <param name="Extno">分機號碼</param>
    /// <param name="PhoneNumber">電話號碼</param>
    public InOutBound(int RequestType, string Extno,string PhoneNumber)
    {
        _RequestType = RequestType;
        _ExtNO = Extno;
        _PhoneNumber = !string.IsNullOrEmpty(PhoneNumber) ? PhoneNumber : "";
    }

    /// <summary>
    /// 判斷_RequestType，並回傳結果。
    /// </summary>
    public string ExtnGo()
    {
        string result = "";
        try
        {
            switch (_RequestType)
            {
                //0:取狀態
                case 0:
                    result = Status();
                    break;
                //1:外撥
                case 1:
                    result = Dialled();
                    break;
                //2:掛斷
                case 2:
                    result = HandUp();
                    break;
            }
        }
        catch (Exception ex)
        {
            result = ex.Message.Trim();
        }
        return result;
    }


    /// <summary>
    /// 取得分機狀態，並回傳狀態。
    /// </summary>
    /// <returns>回傳狀態</returns>
    public string Status()
    {
        try
        {
            Socket s;
            string ClientIP = "";
            string d = "";
            byte[] bs = null;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            ClientIP = context.Request.ServerVariables["REMOTE_ADDR"];
            if (!string.IsNullOrEmpty(ClientIP))
                ClientIP = context.Request.ServerVariables["REMOTE_ADDR"];
            if (ClientIP == "::1")
                ClientIP = "127.0.0.1";
            var strSPort = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["SocketPort"]);
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ClientIP, strSPort);
            d = string.Format(@"STATUS;{0}", _ExtNO);
            bs = System.Text.Encoding.ASCII.GetBytes(d);
            s.Send(bs, bs.Length, 0);
            byte[] bytes = new byte[1024];
            s.Receive(bytes);

            var s2 = Encoding.ASCII.GetString(bytes);
            MessageBox.Show(s2.ToString().Trim());

            //todo 將狀態寫入INBOUND_SHOW資料庫
            StringBuilder sb = new StringBuilder("UPDATE INBOUND_SHOW ");
            sb.Append(string.Format("SET [ExtnStatus] = N'{0}' ", s2.ToString()));
            sb.Append(string.Format("WHERE EXTNO = N'{0}'", _ExtNO));
            DBTool.Query<Inbound_Show>(sb.ToString(), new { });
            s.Close();

            return s2.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.Trim());
            return ex.Message.Trim();
        }
    }
    /// <summary>
    /// 外撥，並回傳狀態。
    /// </summary>
    /// <returns></returns>
    public string Dialled()
    {
        try
        {
            var replacePhoneNumber = _PhoneNumber.Replace("-", "").Replace("(", "").Replace(")", "");
            //TODO 目前環境為台北所以先設定成02
            if (replacePhoneNumber.Substring(0, 2) == "02")
                replacePhoneNumber = replacePhoneNumber.Substring(2, (replacePhoneNumber.Length - 2));
            string ClientIP = "";
            string d = "";          //傳送的字串
            byte[] bs = null;       //傳送的字串轉成byte
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            ClientIP = context.Request.ServerVariables["REMOTE_ADDR"];
            //todo 192.168.2.117
            ClientIP = context.Request.ServerVariables["REMOTE_ADDR"];
            if (!string.IsNullOrEmpty(ClientIP))
                ClientIP = context.Request.ServerVariables["REMOTE_ADDR"];
            if (ClientIP == "::1")
                ClientIP = "127.0.0.1";

            var strSPort = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["SocketPort"]);
            Socket s;
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ClientIP, strSPort);
            d = string.Format(@"DIAL;{0};{1};{1};{1};", replacePhoneNumber, _ExtNO);
            bs = System.Text.Encoding.ASCII.GetBytes(d);
            s.Send(bs, bs.Length, 0);
            s.Close();

            //todo 將狀態寫入INBOUND_SHOW資料庫
            StringBuilder sb = new StringBuilder("UPDATE INBOUND_SHOW ");
            sb.Append(string.Format("SET [ExtnStatus] = N'撥號給：{0}'", replacePhoneNumber));
            sb.Append(string.Format("WHERE EXTNO = N'{0}'", _ExtNO));
            DBTool.Query<Inbound_Show>(sb.ToString(), new { });

            return Status();
        }
        catch (Exception ex)
        {
            return ex.Message.Trim();
        }
    }

    public string HandUp()
    {
        try
        {
            Socket s;
            string ClientIP = "";
            string d = "";
            byte[] bs = null;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            //todo 192.168.2.117
            ClientIP = context.Request.ServerVariables["REMOTE_ADDR"];
            if (!string.IsNullOrEmpty(ClientIP))
                ClientIP = context.Request.ServerVariables["REMOTE_ADDR"];
            if (ClientIP == "::1")
                ClientIP = "127.0.0.1";

            var strSPort = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["SocketPort"]);
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ClientIP, strSPort);
            d = string.Format("HANGUP;{0};", _ExtNO);
            bs = System.Text.Encoding.ASCII.GetBytes(d);
            s.Send(bs, bs.Length, 0);
            s.Close();

            //todo 將狀態寫入INBOUND_SHOW資料庫
            StringBuilder sb = new StringBuilder("UPDATE INBOUND_SHOW ");
            sb.Append(string.Format("SET [ExtnStatus] = N'分機：{0}已掛斷電話'", _ExtNO));
            sb.Append(string.Format("WHERE EXTNO = N'{0}'", _ExtNO));
            DBTool.Query<Inbound_Show>(sb.ToString(), new { });
            Status();

            return "";
        }
        catch (Exception ex)
        {
            return ex.Message.Trim();
        }
    }
}