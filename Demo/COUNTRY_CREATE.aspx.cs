using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class COUNTRY_CREATE : BasePage
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
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("COUNTRY_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_COUNTRY_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["COUNTRY_ID"].ToString();
                        COUNTRY_TXT.Text = vDR["COUNTRY_NAME"].ToString();
                    }
                    else
                        ShowMsg("Invalid Country Name");
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
                    vHashtable.Add("COUNTRY_ID", TXTID.Value);
                    vHashtable.Add("COUNTRY_NAME", COUNTRY_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_COUNTRY_MASTER");
                    Response.Redirect("Country.aspx");
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
                    vHashtable.Add("COUNTRY_ID", TXTID.Value);
                    vHashtable.Add("COUNTRY_NAME", COUNTRY_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_COUNTRY_MASTER");
                    Response.Redirect("Country.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTCOUNTRY");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["COUNTRY_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}