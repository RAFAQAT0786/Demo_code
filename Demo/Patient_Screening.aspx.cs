using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class Patient_Screening : BasePage
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
        String vID = Request.QueryString["ID"];
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();

                ATCommon.FillDrpDown(DDLDOCTER, DBManager.Get(new Hashtable(), "CMB_CUST_MASTER"), "Select Docter Name", "CUST_NAME", "CUST_ID", "0");
                ATCommon.FillDrpDown(DDLSCREEN, DBManager.Get(new Hashtable(), "CMB_SCREEN_TEMPLATE"), "Select Screen Name", "SCTP_NAME", "SCTP_ID", "0");

                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTS_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PT_SCREEN"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["PTS_ID"].ToString();
                        DDLDOCTER.SelectedValue = vDR["PTS_CUSTID"].ToString();
                        DDLSCREEN.SelectedValue = vDR["PTS_SCTPID"].ToString();
                        INPUT_TXT.Text = vDR["PTS_INPUT"].ToString();
                        Textarea1.Value = vDR["PTS_REMARKS"].ToString();
                    }
                    else
                        ShowMsg("Invalid Patient ID");
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
                    vHashtable.Add("PTS_ID", TXTID.Value);
                    vHashtable.Add("PTS_CUSTID", DDLDOCTER.SelectedValue);
                    vHashtable.Add("PTS_SCTPID", DDLSCREEN.SelectedValue);
                    vHashtable.Add("PTS_INPUT", INPUT_TXT.Text);
                    vHashtable.Add("PTS_REMARKS", Textarea1.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_PT_SCREEN");
                    Response.Redirect("Patient_Screening_List.aspx");
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
                    vHashtable.Add("PTS_ID", TXTID.Value);
                    vHashtable.Add("PTS_CUSTID", DDLDOCTER.SelectedValue);
                    vHashtable.Add("PTS_SCTPID", DDLSCREEN.SelectedValue);
                    vHashtable.Add("PTS_INPUT", INPUT_TXT.Text);
                    vHashtable.Add("PTS_REMARKS", Textarea1.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_PT_SCREEN");
                    Response.Redirect("Patient_Screening_List.aspx");
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