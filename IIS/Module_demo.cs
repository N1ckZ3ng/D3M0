using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace ModuleTest
{
    public class Class1 : IHttpModule
    {
        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(OnEndReueqst);
        }
        public void OnEndReueqst(object sender, EventArgs e)
        {
            string End = "<div> OH my Genius</div>";
            HttpApplication app = sender as HttpApplication;
            app.Response.Write(End);

        }
    }
}

