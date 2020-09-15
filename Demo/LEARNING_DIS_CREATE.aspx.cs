using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class LEARNING_DIS_CREATE : BasePage
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
                    vHashtable.Add("LEAR_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_LEARNING_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["LEAR_ID"].ToString();
                        DISA_TXT.Text = vDR["LEAR_NAME"].ToString();
                        TRAIT_TXT.Text = vDR["LEAR_TRAIT"].ToString();
                    }
                    else
                        ShowMsg("Invalid Learning ID");
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
                    vHashtable.Add("LEAR_ID", TXTID.Value);
                    vHashtable.Add("LEAR_NAME", DISA_TXT.Text);
                    vHashtable.Add("LEAR_TRAIT", TRAIT_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_LEARNING_MASTER");
                    Response.Redirect("LEARNING_DIS_LIST.aspx");
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
                    vHashtable.Add("LEAR_ID", TXTID.Value);
                    vHashtable.Add("LEAR_NAME", DISA_TXT.Text);
                    vHashtable.Add("LEAR_TRAIT", TRAIT_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_LEARNING_MASTER");
                    Response.Redirect("LEARNING_DIS_LIST.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTLEARNING");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["LEAR_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}