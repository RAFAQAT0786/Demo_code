using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class Screening_Template : BasePage
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];

        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(DDLDAGECAT, DBManager.Get(new Hashtable(), "GET_AGE_GRP_ID"), "Select Category", "AGRP_GROUP", "AGRP_ID", "0");

                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("SCTP_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_SCREEN_TEMPLATE"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["SCTP_ID"].ToString();
                        DDLDAGECAT.SelectedValue = vDR["SCTP_AGDISID"].ToString();
                        SCREEN_TXT.Text = vDR["SCTP_NAME"].ToString();
                    }
                    else
                        ShowMsg("Invalid Screen ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (TXTID.Value != "0")
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("SCTP_ID", TXTID.Value);
                    vHashtable.Add("SCTP_AGDISID", DDLDAGECAT.SelectedValue);
                    vHashtable.Add("SCTP_NAME", SCREEN_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_SCREEN_TEMPLATE");
                    Response.Redirect("Screening_Template_List.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            else
            {
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("SCTP_ID", TXTID.Value);
                    vHashtable.Add("SCTP_AGDISID", DDLDAGECAT.SelectedValue);
                    vHashtable.Add("SCTP_NAME", SCREEN_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_SCREEN_TEMPLATE");
                    Response.Redirect("Screening_Template_List.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            }
        }
    }

    public void Clear()
    {
    }
}