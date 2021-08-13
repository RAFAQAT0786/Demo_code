using System;
using System.Collections;
using System.Data;

public partial class Patient : System.Web.UI.MasterPage
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (!IsPostBack)
        {
            imglogo.ImageUrl = "~/Logos/logo.png";
            username.Text = vATSession.UserName;
            lblUserType.Text = vATSession.UserType;
        }
    }
    protected DataRow RetDR(DataTable vDataTable)
    {
        if (vDataTable.Rows.Count > 0)
            return vDataTable.Rows[0];
        else
            return null;
    }
}