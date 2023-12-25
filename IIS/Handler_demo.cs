using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TimeClock
{
    public class TimeClock : IHttpHandler
    {
        public bool IsReusable { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse resp = context.Response;

            DateTime time;
            time = DateTime.Now;
            resp.Write(String.Format("<div>{0}</div>",time.ToLongTimeString()));
        }
    }
}

