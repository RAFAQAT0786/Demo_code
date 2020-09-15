using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class SEVERITY_GROUP_CREATE : BasePage
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
                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("SGM_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_SEVERITY_GROUP_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["SGM_ID"].ToString();
                        DDLDIS.SelectedValue = vDR["DIS_ID"].ToString();
                        DESCRIPTION_TXT.Text = vDR["SGM_DISC"].ToString();
                        FROM_TXT.Text = vDR["SGM_FROMVALUE"].ToString();
                        TO_TXT.Text = vDR["SGM_TOVALUE"].ToString();
                    }
                    else
                        ShowMsg("Invalid Severity ID");
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
                    vHashtable.Add("SGM_ID", TXTID.Value);
                    vHashtable.Add("SGM_DISID", DDLDIS.SelectedValue);
                    vHashtable.Add("SGM_DISC", DESCRIPTION_TXT.Text);
                    vHashtable.Add("SGM_FROMVALUE", FROM_TXT.Text.ToString());
                    vHashtable.Add("SGM_TOVALUE", TO_TXT.Text.ToString());
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_SEVERITY_GROUP_MASTER");
                    Response.Redirect("SEVERITY_GROUP.aspx");
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
                    vHashtable.Add("SGM_ID", TXTID.Value);
                    vHashtable.Add("SGM_DISID", DDLDIS.SelectedValue);
                    vHashtable.Add("SGM_DISC", DESCRIPTION_TXT.Text);
                    vHashtable.Add("SGM_FROMVALUE", FROM_TXT.Text);
                    vHashtable.Add("SGM_TOVALUE", TO_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_SEVERITY_GROUP_MASTER");
                    Response.Redirect("SEVERITY_GROUP.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTSEVERITY");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["SGM_DISC"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}