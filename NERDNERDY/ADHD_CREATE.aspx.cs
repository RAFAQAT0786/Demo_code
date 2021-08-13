using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class ADHD_CREATE : BasePage
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];

        string strPreviousPage = string.Empty;
        if (Request.UrlReferrer != null)
        {
            strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
        }
        if (strPreviousPage == "")
        {
            Response.Redirect("~/Default.aspx");
        }

        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("ADHD_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_ADHD_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["ADHD_ID"].ToString();
                        ADHD_TXT.Text = vDR["ADHD_NAME"].ToString();
                        TRAIT_TXT.Text = vDR["ADHD_TRAIT"].ToString();
                    }
                    else
                        ShowMsg("Invalid ADHD ID");
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
                    vHashtable.Add("ADHD_ID", TXTID.Value);
                    vHashtable.Add("ADHD_NAME", ADHD_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("ADHD_TRAIT", TRAIT_TXT.Text);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_ADHD_MASTER");
                    Response.Redirect("ADHD_LIST.aspx");
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
                    vHashtable.Add("ADHD_ID", TXTID.Value);
                    vHashtable.Add("ADHD_NAME", ADHD_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("ADHD_TRAIT", TRAIT_TXT.Text);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_ADHD_MASTER");
                    Response.Redirect("ADHD_LIST.aspx");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTADHD");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["ADHD_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}