using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class SPEECH_LANG_CREATE : BasePage
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
                    vHashtable.Add("SPEC_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_SPEECH_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["SPEC_ID"].ToString();
                        SPEC_TXT.Text = vDR["SPEC_NAME"].ToString();
                        TRAIT_TXT.Text = vDR["SPEC_TRAIT"].ToString();
                    }
                    else
                        ShowMsg("Invalid Speech And Language ID");
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
                    vHashtable.Add("SPEC_ID", TXTID.Value);
                    vHashtable.Add("SPEC_NAME", SPEC_TXT.Text);
                    vHashtable.Add("SPEC_TRAIT", TRAIT_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_SPEECH_MASTER");
                    Response.Redirect("SPEECH_LANG_LIST.aspx");
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
                    vHashtable.Add("SPEC_ID", TXTID.Value);
                    vHashtable.Add("SPEC_NAME", SPEC_TXT.Text);
                    vHashtable.Add("SPEC_TRAIT", TRAIT_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_SPEECH_MASTER");
                    Response.Redirect("SPEECH_LANG_LIST.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTSPEECH");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["SPEC_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}