using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class DOWN_SYNDROME_CREATE : BasePage
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
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("DOWN_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_DOWN_SYNDROME_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["DOWN_ID"].ToString();
                        DOWN_TXT.Text = vDR["DOWN_NAME"].ToString();
                        TRAIT_TXT.Text = vDR["DOWN_TRAIT"].ToString();
                    }
                    else
                        ShowMsg("Invalid Down Syndrome ID");
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
                    vHashtable.Add("DOWN_ID", TXTID.Value);
                    vHashtable.Add("DOWN_NAME", DOWN_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("DOWN_TRAIT", TRAIT_TXT.Text);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_DOWN_SYNDROME_MASTER");
                    Response.Redirect("DOWN_SYNDROME_LIST.aspx");
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
                    vHashtable.Add("DOWN_ID", TXTID.Value);
                    vHashtable.Add("DOWN_NAME", DOWN_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("DOWN_TRAIT", TRAIT_TXT.Text);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_DOWN_SYNDROME_MASTER");
                    Response.Redirect("DOWN_SYNDROME_LIST.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTDOWN_SYNDROME");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["DOWN_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}