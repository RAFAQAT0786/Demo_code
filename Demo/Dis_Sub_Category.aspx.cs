using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class Dis_Sub_Category : BasePage
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
                ATCommon.FillDrpDown(DDLDCAT, DBManager.Get(new Hashtable(), "GET_DCAT_ID"), "Select Category", "DCAT_NAME", "DCAT_ID", "0");

                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("DSCAT_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_DIS_SUBCAT_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["DSCAT_ID"].ToString();
                        DSCAT_DESC_TXT.Text = vDR["DSCAT_DESC"].ToString();
                        DDLDCAT.SelectedValue = vDR["DSCAT_DCATID"].ToString();
                    }
                    else
                        ShowMsg("Invalid Category ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void DDLDCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (TXTID.Value != "0")
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("DSCAT_ID", TXTID.Value);
                    vHashtable.Add("DSCAT_DESC", DSCAT_DESC_TXT.Text);
                    vHashtable.Add("DSCAT_DCATID", DDLDCAT.SelectedValue);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_DIS_SUBCAT_MASTER");
                    Response.Redirect("Dis_SUB_Category_List.aspx");
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
                    vHashtable.Add("DSCAT_ID", TXTID.Value);
                    vHashtable.Add("DSCAT_DESC", DSCAT_DESC_TXT.Text);
                    vHashtable.Add("DSCAT_DCATID", DDLDCAT.SelectedValue);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_DIS_SUBCAT_MASTER");
                    Response.Redirect("Dis_SUB_Category_List.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTDISSUBCAT");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["DSCAT_DESC"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}