using System;
using System.Collections;
using System.Data;

public partial class PInfo : BasePage
{
    private ATSession vATSession;

    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            ValidateUserAccess();
            ShowUserInfo();
            TXT_COMP_NAME.Text = "NERDNERDY Pvt. Ltd.";
        }
    }

    public void ShowUserInfo()
    {
        try
        {
            Hashtable vHT = new Hashtable();
            vHT.Add("USR_LOGIN", vATSession.Login);
            DataRow vDR = RetDR(DBManager.Get(vHT, "GET_USR_INFO"));
            if (vDR != null)
            {
                if (vDR["USR_TYPE"].Equals("SR"))
                    hideinfo();
                TXT_COMP_NAME.Text = "NERDNERDY Pvt. Ltd.";
                TXT_COMP_NAME.Enabled = false;
                TXT_CONT_NAME.Text = vDR["USR_CONT_NAME"].ToString();
                TXT_PHONE_NO.Text = vDR["USR_PHONE"].ToString();
                TXT_MOBILE_NO.Text = vDR["USR_MOBILE"].ToString();
                TXT_FAX_NO.Text = vDR["USR_FAX"].ToString();
                TXT_EMAIL.Text = vDR["USR_EMAIL"].ToString();
                TXT_ADDRESS.Text = vDR["USR_ADDRESS"].ToString();
                TXT_CITY.Text = vDR["USR_CITY"].ToString();
                TXT_STATE.Text = vDR["USR_STATE"].ToString();
                TXT_PIN.Text = vDR["USR_PIN"].ToString();
            }
        }
        catch (Exception xe) { ShowMsg(xe); }
    }

    protected void hideinfo()
    {
        TXT_EMAIL.Enabled = false;
        TXT_CONT_NAME.Enabled = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("USR_LOGIN", vATSession.Login);
            vHashtable.Add("USR_PHONE", TXT_PHONE_NO.Text);
            vHashtable.Add("USR_MOBILE", TXT_MOBILE_NO.Text);
            vHashtable.Add("USR_FAX", TXT_FAX_NO.Text);
            vHashtable.Add("USR_EMAIL", TXT_EMAIL.Text);
            vHashtable.Add("USR_ADDRESS", TXT_ADDRESS.Text);
            vHashtable.Add("USR_CITY", TXT_CITY.Text);
            vHashtable.Add("USR_STATE", TXT_STATE.Text);
            vHashtable.Add("USR_PIN", TXT_PIN.Text);
            DBManager.ExecInsUps(vHashtable, "UPD_USR_INFO", (ATSession)Session["User"]);
            ShowMsg(int.Parse(TXTID.Value));
            ShowUserInfo();
        }
        catch (Exception xe) { ShowMsg(xe); }
    }
}