using System;

public partial class DOCTOR : System.Web.UI.MasterPage
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (!IsPostBack)
        {
            //EMP_Img.ImageUrl = "~/Logos/NerdNerdy_logo.png";
            imglogo.ImageUrl = "~/Logos/logo.png";
            username.Text = vATSession.UserName;
            lblUserType.Text = vATSession.UserType;
        }
    }
}