using System;
using System.Collections;

public partial class RSM_SessionTimeout : System.Web.UI.Page
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];

        Hashtable vloght = new Hashtable();
        if (vATSession != null)
        {
            vloght.Add("LOG_ID", vATSession.LOG_ID);
            vloght.Add("LOG_EMP_ID", vATSession.EMP_ID);
            vloght.Add("LOG_LOGIN", vATSession.Login);
            DBManager.ExecInsUps(vloght, "UPDATE_LOGSESSION", (ATSession)Session["User"]);
        }

        Session["User"] = null;
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
    }
}