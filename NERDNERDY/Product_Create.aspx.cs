using System;
using System.Collections;
using System.Data;

public partial class Product_Create : BasePage
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
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");

                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("ID", vID);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PRODUCT_ID"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["PRODM_ID"].ToString();
                        PROD_NAME_TXT.Text = vDR["PRODM_NAME"].ToString();
                        TXT_LINK.Text = vDR["PRODM_LINK"].ToString();
                        DDLCAT.SelectedItem.Text = vDR["DCAT_NAME"].ToString();
                        DDLSUBCAT.SelectedItem.Text = vDR["DSCAT_DESC"].ToString();
                        HiddenField1.Value = vDR["DCAT_ID"].ToString();
                        HiddenField2.Value = vDR["DSCAT_ID"].ToString();
                        HiddenField3.Value = vDR["DCAT_NAME"].ToString();
                        HiddenField4.Value = vDR["DSCAT_DESC"].ToString();
                        VIDEO_LINK.Text = vDR["PRODM_VIDEO_LINK"].ToString();
                        PROD_IMAGE_LINK.Text = vDR["PRODM_IMAGE_LINK"].ToString();
                    }
                    else
                        ShowMsg("Invalid Product ID");
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
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (TXTID.Value != "0")
            try
            {
                if (DDLCAT.SelectedItem.Text == HiddenField3.Value && DDLSUBCAT.SelectedItem.Text == HiddenField4.Value)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PRODM_ID", TXTID.Value);
                    vHashtable.Add("PRODM_NAME", PROD_NAME_TXT.Text);
                    vHashtable.Add("PRODM_MRP", "0");
                    vHashtable.Add("PRODM_RET_PRICE", "0");
                    vHashtable.Add("PRODM_SYNP", "NO");
                    vHashtable.Add("PRODM_STK_PRICE", "0");
                    vHashtable.Add("PRODM_LINK", TXT_LINK.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("PRODM_DCATID", HiddenField1.Value);
                    vHashtable.Add("PRODM_DSCATID", HiddenField2.Value);
                    vHashtable.Add("PRODM_VIDEO_LINK", VIDEO_LINK.Text);
                    vHashtable.Add("PRODM_IMAGE_LINK", PROD_IMAGE_LINK.Text);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "INS_PRODUCT"));
                    Response.Redirect("Product.aspx");
                    Clear();
                }
                else
                {
                    Insertdata();
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
                Insertdata();
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        }
    }

    // this function is used for inserting the data using save buuton Start
    protected void Insertdata()
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PRODM_ID", TXTID.Value);
        vHashtable.Add("PRODM_NAME", PROD_NAME_TXT.Text);
        vHashtable.Add("PRODM_MRP", "0");
        vHashtable.Add("PRODM_RET_PRICE", "0");
        vHashtable.Add("PRODM_SYNP", "NO");
        vHashtable.Add("PRODM_STK_PRICE", "0");
        vHashtable.Add("PRODM_LINK", TXT_LINK.Text);
        vHashtable.Add("LAST_USER", vATSession.Login);
        vHashtable.Add("PRODM_DCATID", DDLCAT.SelectedValue);
        vHashtable.Add("PRODM_DSCATID", DDLSUBCAT.SelectedValue);
        vHashtable.Add("PRODM_VIDEO_LINK", VIDEO_LINK.Text);
        vHashtable.Add("PRODM_IMAGE_LINK", PROD_IMAGE_LINK.Text);
        DataRow vDR = RetDR(DBManager.Get(vHashtable, "INS_PRODUCT"));
        Response.Redirect("Product.aspx");
        Clear();
    }
    // this function is used for inserting the data using save buuton End
    public void Clear()
    {
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTPRODUCT");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["PRODM_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}