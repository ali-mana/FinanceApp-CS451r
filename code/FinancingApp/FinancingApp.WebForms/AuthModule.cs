using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class AuthModule : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += context_AuthenticateRequest;
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            if(application.Request.QueryString["username"] != null && application.Request.QueryString["password"] != null)
            {
                if(application.Request.QueryString["username"] == "Test" && application.Request.QueryString["password"] == "Pass")
                {
                    application.Response.Write("U r authencticated");
                }
                else
                {
                    application.Response.Write("U r not authencticated");
                }
            }

        }
    }
