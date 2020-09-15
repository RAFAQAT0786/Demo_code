using System;

public partial class DOCTOR : System.Web.UI.MasterPage
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (!IsPostBack)
        {
            //EMP_Img.ImageUrl = "~/Logos/logo.png";
            lblUserType.Text = vATSession.UserType;
            imglogo.ImageUrl = "~/Logos/logo.png";
            username.Text = vATSession.UserName;
        }
    }
}