using iTextSharp.text;
using System;
using System.Collections;
using System.Data.SqlClient;
using Utilities;

public partial class Admin_Welcome : BasePage
{
    private Util util = new Util();
    private Font HeadingFont;
    private Font SubHeadingFont;
    private Font RecordFont;
    private Font NormalFont;
    private Font NormalFont1;
    private Font HeadingBlackFont;
    private ATSession vATSession;
   

    public int Count { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];

        if (vATSession == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            ValidateUserAccess();
            lblUser.Text = vATSession.UserName;
            Hashtable HT = new Hashtable();
        }
    }
}