using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class Template_Video_Create : BasePage
{
    private ATSession vATSession;
    private string image_path;

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
                ATCommon.FillDrpDown(DDLANAL, DBManager.Get(new Hashtable(), "CMB_ANALYSIS_MASTER"), "Select Analysis Name", "ANM_NAME", "ANM_ID", "0");
                ATCommon.FillDrpDown(DDLORDER, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_MASTER_NEW"), "Select Age Group Name", "AGRP_GROUP", "AGRP_ID", "0");
                if (vATSession.UserType == "ADMIN")
                {
                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("VD_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_TEMPLATE_VIDEO"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["VD_ID"].ToString();
                            DDLANAL.SelectedValue = vDR["VD_ANMID"].ToString();
                            DDLAGE.SelectedValue = vDR["VD_AGRPID"].ToString();
                            DDLORDER.SelectedValue = vDR["VD_DISID"].ToString();
                            VIDEO_LINK.Text = vDR["VD_VIDEO_LINK"].ToString();
                        }
                        else
                            ShowMsg("Invalid Video ID");
                    }
                }

               else
                {
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
                    string[] parts = VIDEO_LINK.Text.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    string idWithPotentialQueryParams = parts[parts.Length - 1].ToString().Replace("?t=", "?start=");
                    string[] part = idWithPotentialQueryParams.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string id = part[part.Length - 1].ToString();
                    string abc = "https://www.youtube.com/embed/" + id;

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("VD_ID", TXTID.Value);
                    vHashtable.Add("VD_ANMID", DDLANAL.SelectedValue);
                    vHashtable.Add("VD_AGRPID", DDLAGE.SelectedValue);
                    vHashtable.Add("VD_DISID", DDLORDER.SelectedValue);
                    vHashtable.Add("VD_VIDEO_LINK", abc);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_TEMPLATE_VIDEO");
                    Response.Redirect("Template_Video_List.aspx");
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
                    //ConvertYouTubeToEmbed();

                    string[] parts = VIDEO_LINK.Text.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    string idWithPotentialQueryParams = parts[parts.Length - 1].ToString().Replace("?t=", "?start=");
                    string[] part = idWithPotentialQueryParams.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string id = part[part.Length - 1].ToString();
                    string abc = "https://www.youtube.com/embed/" + id;

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("VD_ID", TXTID.Value);
                    vHashtable.Add("VD_ANMID", DDLANAL.SelectedValue);
                    vHashtable.Add("VD_AGRPID", DDLAGE.SelectedValue);
                    vHashtable.Add("VD_DISID", DDLORDER.SelectedValue);
                    //vHashtable.Add("VD_VIDEO_LINK", VIDEO_LINK.Text);
                    vHashtable.Add("VD_VIDEO_LINK", abc);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_TEMPLATE_VIDEO");
                    Response.Redirect("Template_Video_List.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            }
        }
    }

    //private void ConvertYouTubeToEmbed()
    //{
    //    string[] parts = VIDEO_LINK.Text.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
    //    string idWithPotentialQueryParams = parts[parts.Length - 1].ToString().Replace("?t=", "?start=");
    //    string[] part = idWithPotentialQueryParams.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
    //    string id = part[part.Length - 1].ToString();
    //    string abc= "https://www.youtube.com/embed/" + id;

    //}

    public void Clear()
    {
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTTEMPLATEVIDEO");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["VD_ANMID"].ToString().Equals(DDLANAL.SelectedValue) && DR["VD_AGRPID"].ToString().Equals(DDLAGE.SelectedValue)
                    && DR["VD_DISID"].ToString().Equals(DDLORDER.SelectedValue))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }

}