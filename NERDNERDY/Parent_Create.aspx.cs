using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class Parent_Create : BasePage
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
                ATCommon.FillDrpDown(DDLORDER, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
               
                ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_MASTER_NEW"), "Select Age Group Name", "AGRP_GROUP", "AGRP_ID", "0");
                
                Hashtable vHT = new Hashtable();
                vHT.Add("USR_LOGIN", vATSession.Login);
                DataRow vDR2 = RetDR(DBManager.Get(vHT, "GET_USR_CUST_ID"));
                if (vDR2 != null)
                {
                    HiddenField1.Value = vDR2["CUST_ID"].ToString();
                }
                if (vATSession.UserType == "ADMIN")
                {
                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTPP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PARENT"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["PTPP_ID"].ToString();
                            PTP_NAME_TXT.Text = vDR["PTPP_NAME"].ToString();
                            DDLAGE.SelectedValue = vDR["PTPP_AGRPID"].ToString();
                            DDLORDER.SelectedValue = vDR["PTPP_DISID"].ToString();
                        }
                        else
                            ShowMsg("Invalid Patient ID");
                    }
                }


               else
                {
                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTPP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PARENT"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["PTPP_ID"].ToString();
                            PTP_NAME_TXT.Text = vDR["PTPP_NAME"].ToString();
                            DDLAGE.SelectedValue = vDR["PTPP_AGRPID"].ToString();
                            DDLORDER.SelectedValue = vDR["PTPP_DISID"].ToString();
                        }
                        else
                        ShowMsg("Invalid Patient ID");
                    }
                }


            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
           
            Hashtable vHashtable1 = new Hashtable();
            vHashtable1.Add("PTPP_ID", TXTID.Value);
            vHashtable1.Add("PTPP_NAME", PTP_NAME_TXT.Text);
            vHashtable1.Add("PTPP_AGRPID", DDLAGE.SelectedValue);
            vHashtable1.Add("PTPP_DISID", DDLORDER.SelectedValue);
            vHashtable1.Add("PTPP_CUSTID", HiddenField1.Value);
            vHashtable1.Add("TYPE", "INS");
            vHashtable1.Add("PTPP_SUBSCRIPTION_NUMBER", "1");
            vHashtable1.Add("PTPP_PATIENT_SUBSCRIPTION_NUMBER", "1");
            //DBManager.Get(vHashtable, "INS_PARENT");
            DBManager.ExecInsUpsReturn(vHashtable1, "INS_PARENT", (ATSession)Session["User"]);

            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", TXTID.Value);
            vHashtable.Add("PTP_AGRPID", DDLAGE.SelectedValue);
            vHashtable.Add("PTP_REGHQID", "0");
            vHashtable.Add("PTP_ARHQID", "0");
            vHashtable.Add("PTP_VSOHQID", "");
            vHashtable.Add("PTP_STAID", "");
            vHashtable.Add("PTP_NAME", PTP_NAME_TXT.Text);
            vHashtable.Add("PTP_GENDER", "");
            vHashtable.Add("PTP_DOB", "");
            vHashtable.Add("PTP_MOBILE", "");
            vHashtable.Add("PTP_ADD", "");
            vHashtable.Add("PTP_REMARKS", "");
            vHashtable.Add("LAST_USER", vATSession.Login);
            vHashtable.Add("PTP_EMAIL", "");
            vHashtable.Add("PTP_PRI_LANG", "");
            vHashtable.Add("PTP_TEST_DATE", "");
            vHashtable.Add("PTP_PARENT_NAME", "");
            vHashtable.Add("PTP_FATHER_OCCUPATION", "");
            vHashtable.Add("PTP_MOTHER_OCCUPATION", "");
            vHashtable.Add("PTP_PRIOR_DIAGNOSIS", "");
            vHashtable.Add("PTP_YEAR_DIAGNOSIS", "");
            vHashtable.Add("PTP_REFERRED", "");
            vHashtable.Add("PTP_PRIOR_THERAPY", "");
            vHashtable.Add("PTP_PINCODE", "");
            vHashtable.Add("PTP_COUNTRYID", "");
            vHashtable.Add("PTP_CUSTID", HiddenField1.Value);
            vHashtable.Add("TYPE", "INS");
            vHashtable.Add("PTP_THERAPIST_NAME", "");
            vHashtable.Add("PTP_QUALIFICATION", "");
            DBManager.Get(vHashtable, "INS_PATIENT_DETAIL");

            Response.Redirect("Patient.aspx");


        }
    }
    public void Clear()
    {
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTPTPERSONAL");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["PTP_MOBILE"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }

    protected void DDLLOCATION_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}