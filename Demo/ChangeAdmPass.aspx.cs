using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ChangeAdmPass : BasePage
{
    ATSession vATSession;
    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession=(ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            ValidateUserAccess();
        }
     }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("USR_LOGIN", vATSession.Login);
            vHashtable.Add("USR_PASSWORD", TXT_NEW_PASS.Text);
            DBManager.ExecInsUps(vHashtable, "UPD_USR_PASS", (ATSession)Session["User"]);
            Response.Redirect("SessionTimeout.aspx");
        }
        catch (Exception xe) { ShowMsg(xe); }


        string pass = null;
        string userid = null;
        try
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("USR_LOGIN", vATSession.Login);
            DataTable dt = DBManager.Get(vHashtable, "USER_PASS_CHECK");
            if (dt.Rows.Count > 0)
            {
                pass = dt.Rows[0]["USR_PASSWORD"].ToString();
                userid = dt.Rows[0]["USR_LOGIN"].ToString();
                if (pass.Equals(TXT_OLD_PASS.Text))
                {
                    Hashtable ht = new Hashtable();

                    ht.Add("USR_LOGIN", vATSession.Login);
                    ht.Add("USR_PASSWORD", TXT_NEW_PASS.Text);
                    DBManager.ExecInsUps(ht, "UPD_USR_PASS", (ATSession)Session["User"]);
                    ShowMsg("Your Password Has Been Changed");
                    ShowMsg(int.Parse(TXTID.Value));
                    Response.Redirect("SessionTimeout.aspx");
                }
                else
                {
                    ShowMsg("Your Old Password Incorrect");
                }
            }
            else
            {
                ShowMsg("Your Old Password Incorrect");
            }
        }
        catch (Exception xe) { ShowMsg(xe); }
    }
}
