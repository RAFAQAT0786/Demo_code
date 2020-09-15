using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class State_Create : BasePage
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
                ATCommon.FillDrpDown(COUNTRY_DDL, DBManager.Get(new Hashtable(), "CMB_COUNTRY_MASTER"), "Select Country Name", "COUNTRY_NAME", "COUNTRY_ID", "0");
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("STATE_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_STATE_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["STATE_ID"].ToString();
                        STATE_TXT.Text = vDR["STATE_NAME"].ToString();
                        COUNTRY_DDL.SelectedItem.Text = vDR["COUNTRY_NAME"].ToString();
                        HiddenField1.Value = vDR["COUNTRY_ID"].ToString();
                    }
                    else
                        ShowMsg("Invalid State Name");
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
                    vHashtable.Add("STATE_ID", TXTID.Value);
                    vHashtable.Add("STATE_NAME", STATE_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("STATE_COUNTRYID", HiddenField1.Value);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_STATE");
                    Response.Redirect("State.aspx");
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
                    vHashtable.Add("STATE_ID", TXTID.Value);
                    vHashtable.Add("STATE_NAME", STATE_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("STATE_COUNTRYID", COUNTRY_DDL.SelectedValue);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_STATE");
                    Response.Redirect("State.aspx");
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

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTSTATE");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["STATE_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}