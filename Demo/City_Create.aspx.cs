using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class City_Create : BasePage
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
                ATCommon.FillDrpDown(STATE_DDL, DBManager.Get(new Hashtable(), "CMB_STATE_MASTER"), "Select State Name", "STATE_NAME", "STATE_ID", "0");
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("CITY_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_CITY_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["CITY_ID"].ToString();
                        CITY_TXT.Text = vDR["CITY_NAME"].ToString();
                        STATE_DDL.SelectedItem.Text = vDR["STATE_NAME"].ToString();
                        HiddenField1.Value = vDR["STATE_ID"].ToString();
                    }
                    else
                        ShowMsg("Invalid City Name");
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
                    vHashtable.Add("CITY_ID", TXTID.Value);
                    vHashtable.Add("CITY_NAME", CITY_TXT.Text);
                    vHashtable.Add("CITY_STATEID", HiddenField1.Value);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_CITY_MASTER");
                    Response.Redirect("City.aspx");
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
                    vHashtable.Add("CITY_ID", TXTID.Value);
                    vHashtable.Add("CITY_NAME", CITY_TXT.Text);
                    vHashtable.Add("CITY_STATEID", STATE_DDL.SelectedValue);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_CITY_MASTER");
                    Response.Redirect("City.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTCITY");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["CITY_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}