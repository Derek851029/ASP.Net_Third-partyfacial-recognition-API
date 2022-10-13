<%@ WebHandler Language="C#" Class="UploadImage" %>

using System;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Web.SessionState;
using System.Drawing;
using System.Drawing.Imaging;

public class UploadImage : IHttpHandler,IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {
        string sql;
        string ImagePath = HttpContext.Current.Server.MapPath("/MemberImage/");
        TimeSpan epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
        TimeSpan unixTicks = new TimeSpan(DateTime.Now.Ticks) - epochTicks;
        Int32 unixTimestamp = (Int32)unixTicks.TotalSeconds;
        string FileTime = unixTimestamp.ToString();
        string imgName;
        try
        {
            string MemberNum = context.Request.Form.Get("MemberNum");
            string Size = context.Request.Form.Get("SizeKB");
            double SizeKB = Convert.ToDouble(Size);

            HttpFileCollection httpFile = context.Request.Files;
            HttpPostedFile files = httpFile[0];

            if (Math.Floor(SizeKB) > 200)
            {
                imgName = FileTime + ".png";
                files.SaveAs(ImagePath + imgName);

                System.Drawing.Image g = System.Drawing.Image.FromFile(ImagePath + imgName);
                ImageFormat format = g.RawFormat;
                int width = 640; //寬度
                int heigt = 480; //高度

                string NewName = MemberNum + ".jpg";
                Bitmap imgoutput = new Bitmap(g, width, heigt); //輸出一個新圖片
                imgoutput.Save(ImagePath + NewName, format); //存檔路徑,格式

                g.Dispose();
                imgoutput.Dispose();

                File.Delete(ImagePath + imgName);
            }
            else
            {
                imgName = MemberNum + ".jpg";
                files.SaveAs(ImagePath + imgName);
            }

            string IP = context.Request.Url.Host;
            string ImageURL = "http://192.168.2.14:7017/MemberImage/" + imgName;
            sql = @"update MemberData set ImageURL = @ImageURL, flag = @flag where MemberNum = @MemberNum";
            DBTool.Query(sql,new { ImageURL = ImageURL, flag = 1, MemberNum = MemberNum });

            context.Response.Write(JsonConvert.SerializeObject( new {
            Status = ImageURL ,
            }));
        }
        catch (Exception e)
        {
            sql = @" INSERT INTO SystemLog (PageName,PageFunc,EX) 
                            VALUES ('Users','SaveImage',@e) ";
            DBTool.Query(sql, new
            {
                e = e.ToString()
            });
            context.Response.Write(JsonConvert.SerializeObject( new {
            Status = "error" ,
            }));
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}