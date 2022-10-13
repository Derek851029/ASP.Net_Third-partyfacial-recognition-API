using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// ExtnConfig 的摘要描述
/// </summary>
public class ExtnConfig
{
    public string _Extn { get; set; }

    /// <summary>
    /// 讀取設定檔案的分機號碼。
    /// </summary>
    public ExtnConfig()
    {
        // TODO: 讀取設定檔案的分機號碼
        string ExtnConfigPath = System.Configuration.ConfigurationManager.AppSettings["Extn_Path"].ToString().Trim();
        _Extn = "";
        using (StreamReader str = new StreamReader(ExtnConfigPath, Encoding.UTF8))
        {
            _Extn = str.ReadLine();
        }
        _Extn = _Extn.Substring(_Extn.IndexOf('^') + 1, _Extn.Length - (_Extn.IndexOf('^') + 1));
    }

    public string getExtnNum() {
        return _Extn;
    }
}