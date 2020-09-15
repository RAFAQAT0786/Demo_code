using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class IEPSKILLACTIVITY_CREATE : BasePage
{
    private ATSession vATSession;
    private DataTable dt;

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
                    vHashtable.Add("IEPA_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEP_SKILL_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["IEPA_ID"].ToString();
                        Textarea3.InnerText = vDR["IEPA_DESC"].ToString();
                        IEP_SKILL_TXT.Text = vDR["IEPA_NAME"].ToString();
                    }
                    else
                        ShowMsg("Invalid Activity ID");
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
                    vHashtable.Add("IEPA_ID", TXTID.Value);
                    vHashtable.Add("IEPA_NAME", IEP_SKILL_TXT.Text);
                    vHashtable.Add("IEPA_DESC", Textarea3.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_IEP_SKILL_ACTIVITY");
                    Response.Redirect("IEPSKILLACTIVITY_LIST.aspx");
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
                    vHashtable.Add("IEPA_ID", TXTID.Value);
                    vHashtable.Add("IEPA_NAME", IEP_SKILL_TXT.Text);
                    vHashtable.Add("IEPA_DESC", Textarea3.InnerText);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.ExecInsUps(vHashtable, "INS_IEP_SKILL_ACTIVITY", (ATSession)Session["User"]);
                    Response.Redirect("IEPSKILLACTIVITY_LIST.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTIEPSKILLACTIVITY");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["IEPA_DESC"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}