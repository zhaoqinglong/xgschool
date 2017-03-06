<%@ WebHandler Language="C#" Class="logout" %>

using System;
using System.Web;
using System.Web.SessionState;

public class logout : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Session.Abandon();
        System.Web.Security.FormsAuthentication.SignOut();
        context.Response.Redirect("index.ashx");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}