using System;

public partial class Admin : System.Web.UI.MasterPage
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (!IsPostBack)
            lblUserType.Text = vATSession.UserType;
        imglogo.ImageUrl = "~/Logos/logo.png";
        username.Text = vATSession.UserName;
    }
}