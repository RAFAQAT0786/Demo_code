using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class Video_Create : BasePage
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
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "");

                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("ID", vID);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_VIDEO_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["VIDEO_ID"].ToString();
                        DDLCAT.SelectedItem.Text = vDR["DCAT_NAME"].ToString();
                        DDLSUBCAT.SelectedItem.Text = vDR["DSCAT_DESC"].ToString();
                        HiddenField1.Value = vDR["DCAT_ID"].ToString();
                        HiddenField2.Value = vDR["DSCAT_ID"].ToString();
                        HiddenField3.Value = vDR["DCAT_NAME"].ToString();
                        HiddenField4.Value = vDR["DSCAT_DESC"].ToString();
                        VIDEO_LINK.Text = vDR["VIDEO_LINK"].ToString();
                    }
                    else
                        ShowMsg("Invalid Video ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void DDLCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DCAT_ID", DDLCAT.SelectedValue.ToString());
        ATCommon.FillDrpDown(DDLSUBCAT, DBManager.Get(vHashtable, "CMB_CATEGORY_ID"), "Select Sub Category Name", "DSCAT_DESC", "DSCAT_ID", "");
        DDLSUBCAT.Items.Add(new ListItem("Select All Sub Categories", "1", true));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (TXTID.Value != "0")
                try
                {
                    if (DDLCAT.SelectedValue != "" && DDLSUBCAT.SelectedValue != "0")
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("VIDEO_ID", TXTID.Value);
                        vHashtable.Add("VIDEO_DCATID", DDLCAT.SelectedValue);
                        vHashtable.Add("VIDEO_DSCATID", DDLSUBCAT.SelectedValue);
                        vHashtable.Add("VIDEO_LINK", VIDEO_LINK.Text);
                        vHashtable.Add("LAST_USER", vATSession.Login);
                        vHashtable.Add("TYPE", "UPD");
                        DBManager.Get(vHashtable, "INS_VIDEO_MASTER");
                        Response.Redirect("Video_List.aspx");
                        Clear();
                    }
                    else
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("VIDEO_ID", TXTID.Value);
                        vHashtable.Add("VIDEO_DCATID", HiddenField1.Value);
                        vHashtable.Add("VIDEO_DSCATID", HiddenField2.Value);
                        vHashtable.Add("VIDEO_LINK", VIDEO_LINK.Text);
                        vHashtable.Add("LAST_USER", vATSession.Login);
                        vHashtable.Add("TYPE", "UPD");
                        DBManager.Get(vHashtable, "INS_VIDEO_MASTER");
                        Response.Redirect("Video_List.aspx");
                        Clear();
                    }
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            else
            {
                try
                {
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("DCAT_ID", DDLCAT.SelectedValue.ToString());
                    DataTable dt = DBManager.Get(vHashtable1, "CMB_CATEGORY_ID");
                   if (DDLCAT.SelectedValue != "0" && DDLSUBCAT.SelectedValue == "1")
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            DSCATID.Value = dr["DSCAT_ID"].ToString();

                            Hashtable vHashtable = new Hashtable();
                            vHashtable.Add("VIDEO_ID", TXTID.Value);
                            vHashtable.Add("VIDEO_DCATID", DDLCAT.SelectedValue);
                            vHashtable.Add("VIDEO_DSCATID", DSCATID.Value);
                            vHashtable.Add("VIDEO_LINK", VIDEO_LINK.Text);
                            vHashtable.Add("LAST_USER", vATSession.Login);
                            vHashtable.Add("TYPE", "INS");
                            DBManager.Get(vHashtable, "INS_VIDEO_MASTER");
                        }
                        Response.Redirect("Video_List.aspx");
                        Clear();
                    }
                    else if (DDLCAT.SelectedValue != "0"  && (DDLSUBCAT.SelectedValue != "1" || DDLSUBCAT.SelectedValue != "0"))
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("VIDEO_ID", TXTID.Value);
                        vHashtable.Add("VIDEO_DCATID", DDLCAT.SelectedValue);
                        vHashtable.Add("VIDEO_DSCATID", DDLSUBCAT.SelectedValue);
                        vHashtable.Add("VIDEO_LINK", VIDEO_LINK.Text);
                        vHashtable.Add("LAST_USER", vATSession.Login);
                        vHashtable.Add("TYPE", "INS");
                        DBManager.Get(vHashtable, "INS_VIDEO_MASTER");
                        Response.Redirect("Video_List.aspx");
                        Clear();
                    }
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
        
    }
}