using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Data;
using System.IO;
using Utilities;

public partial class Parent_Welcome : BasePage
{
    private Util util = new Util();
    private Font HeadingFont;
    private Font SubHeadingFont;
    private Font RecordFont;
    private Font NormalFont;
    private Font NormalFont1;
    private Font HeadingBlackFont;
    private ATSession vATSession;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("~/Default.aspx");
        if (!IsPostBack)
        {
            ValidateUserAccess();
            lblUser.Text = vATSession.UserName;
        }
    }
}