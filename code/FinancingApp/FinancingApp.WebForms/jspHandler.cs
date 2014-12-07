using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;


public class jspHandler : IHttpHandler, IRequiresSessionState
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/rss";
        
        if (context.Request.RawUrl.Contains(".jsp"))
        {
            context.Server.Transfer(context.Request.RawUrl.Replace(".jsp", ".aspx").ToString());
        }
    }
}
