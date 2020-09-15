using System;
using System.Data;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;

public partial class User_Admin : BasePage
{
    ATSession vATSession;
    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession=(ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
       
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(CUST_COUNTRY_DDL, DBManager.Get(new Hashtable(), "CMB_COUNTRY_MASTER"), "Select Country Name", "COUNTRY_NAME", "COUNTRY_ID", "0");
                Hashtable vHashtable1 = new Hashtable();
                vHashtable1.Add("STATE_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                Hashtable vHashta = new Hashtable();
                vHashta.Add("STATE_ID", RegioanlHQ_DDL.SelectedValue);
                ATCommon.FillDrpDown(RegioanlHQ_DDL, DBManager.Get(vHashta, "CMB_State"), "Select State Name", "STATE_NAME", "STATE_ID", "");
                if (vID != null)
                {
                    if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("CUST_MOBILE", vID);
                        DataRow vDR2 = RetDR(DBManager.Get(vHashtable, "GET_CUSTOMER_MOBILENO"));
                        if (vDR2 != null)
                        {
                            TXTID.Value = vDR2["CUST_ID"].ToString();
                        }

                        Hashtable vHT = new Hashtable();
                        vHT.Add("USR_LOGIN", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHT, "GETUSR"));
                        if (vDR != null)
                        {
                            DDL_USER_TYPE.SelectedValue = vDR["USR_TYPE"].ToString();
                            TXT_LOGIN.Text = vDR["USR_LOGIN"].ToString();
                            RegioanlHQ_DDL.SelectedIndex = RegioanlHQ_DDL.Items.IndexOf(RegioanlHQ_DDL.Items.FindByValue(vDR["USR_REGHQ_ID"].ToString()));
                            RegioanlHQ_DDL_SelectedIndexChanged(sender, e);
                            AreaHQ_DDL.SelectedIndex = AreaHQ_DDL.Items.IndexOf(AreaHQ_DDL.Items.FindByValue(vDR["USR_ARHQ_ID"].ToString()));
                            CUST_COUNTRY_DDL.SelectedValue = vDR["USR_COUNTRY"].ToString();
                            TXT_MOBILE_NO.Text = vDR["USR_MOBILE"].ToString();
                            TXT_EMAIL.Text = vDR["USR_EMAIL"].ToString();
                            TXT_ADDRESS.Text = vDR["USR_ADDRESS"].ToString();
                            TXT_PIN.Text = vDR["USR_PIN"].ToString();
                            TXT_ORGANIZATION.Text = vDR["USR_ORGANIZATION_NAME"].ToString();
                            DDL_USER_TYPE.Enabled = false;
                            TXT_LOGIN.Enabled = false;
                            TXT_PASSWORD.Text = vDR["USR_PASSWORD"].ToString();
                            TXT_PASSWORD.Enabled = false;
                            TXT_START.Text = vDR["USR_FROM_DATE"].ToString();
                            TXT_END.Text = vDR["USR_TO_DATE"].ToString();
                            TXT_Sub.Text = vDR["USR_SUBSCRIPTION_NUMBER"].ToString();
                            TXT_PATIENT.Text = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                            TXT_Sub.Enabled = false;
                        }
                    }
                    else
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("CUST_MOBILE", vID);
                        DataRow vDR2 = RetDR(DBManager.Get(vHashtable, "GET_CUSTOMER_MOBILENO"));
                        if (vDR2 != null)
                        {
                            TXTID.Value = vDR2["CUST_ID"].ToString();
                        }

                        DDL_USER_TYPE.SelectedValue = "";
                        Hashtable vHT = new Hashtable();
                        vHT.Add("USR_LOGIN", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHT, "GETUSR"));
                        if (vDR != null)
                        {
                            DDL_USER_TYPE.SelectedValue = vDR["USR_TYPE"].ToString();
                            TXT_LOGIN.Text = vDR["USR_LOGIN"].ToString();
                            RegioanlHQ_DDL.SelectedIndex = RegioanlHQ_DDL.Items.IndexOf(RegioanlHQ_DDL.Items.FindByValue(vDR["USR_REGHQ_ID"].ToString()));
                            RegioanlHQ_DDL_SelectedIndexChanged(sender, e);
                            AreaHQ_DDL.SelectedIndex = AreaHQ_DDL.Items.IndexOf(AreaHQ_DDL.Items.FindByValue(vDR["USR_ARHQ_ID"].ToString()));
                            CUST_COUNTRY_DDL.SelectedValue = vDR["USR_COUNTRY"].ToString();
                            TXT_MOBILE_NO.Text = vDR["USR_MOBILE"].ToString();
                            TXT_EMAIL.Text = vDR["USR_EMAIL"].ToString();
                            TXT_ADDRESS.Text = vDR["USR_ADDRESS"].ToString();
                            TXT_PIN.Text = vDR["USR_PIN"].ToString();
                            TXT_ORGANIZATION.Text = vDR["USR_ORGANIZATION_NAME"].ToString();
                            DDL_USER_TYPE.Enabled = false;
                            TXT_LOGIN.Enabled = false;
                            TXT_PASSWORD.Text = vDR["USR_PASSWORD"].ToString();
                            TXT_PASSWORD.Enabled = false;
                            TXT_START.Text = vDR["USR_FROM_DATE"].ToString();
                            TXT_END.Text = vDR["USR_TO_DATE"].ToString();
                            TXT_Sub.Text = vDR["USR_SUBSCRIPTION_NUMBER"].ToString();
                            TXT_PATIENT.Text = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                        }
                    }
                }
                else
                {
                    if (TXTID.Value == "0")
                    {
                        DDL_USER_TYPE.SelectedValue = "ADMIN";
                        TXT_PASSWORD.Enabled = false;
                        TXT_LOGIN.Enabled = false;
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
        try
        {
            if (TXTID.Value == "0")
            {
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("CUST_ID", TXTID.Value);
                vHashtable.Add("CUST_VSOHQ_ID", "0");
                vHashtable.Add("CUST_STA_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                vHashtable.Add("CUST_NAME", TXT_ORGANIZATION.Text);
                vHashtable.Add("CUST_PROSPECTIVE", "");
                vHashtable.Add("CUST_PREFIX", "");
                vHashtable.Add("CUST_ADDRESS", TXT_ADDRESS.Text);
                vHashtable.Add("CUST_COMP_NAME", TXT_ORGANIZATION.Text);
                vHashtable.Add("CUST_DISTRICT", "0");
                vHashtable.Add("CUST_VILLAGE_TWN_CITY", "");
                vHashtable.Add("CUST_POST_OFFICE", "");
                vHashtable.Add("CUST_STATE", "0");
                vHashtable.Add("CUST_CATRGORY_ID", "");
                vHashtable.Add("CUST_CONSULT_NAME", "");
                vHashtable.Add("CUST_CONSULT_MOB", TXT_MOBILE_NO.Text);
                vHashtable.Add("CUST_PIN", TXT_PIN.Text);
                vHashtable.Add("CUST_PHONE", TXT_MOBILE_NO.Text);
                vHashtable.Add("CUST_EMAIL", TXT_EMAIL.Text);
                vHashtable.Add("CUST_MOBILE", TXT_MOBILE_NO.Text);
                vHashtable.Add("CUST_DEALER", vATSession.CUST_ID);
                vHashtable.Add("CUST_DESIGNATION", "");
                vHashtable.Add("CUST_COUNTRY_ID", CUST_COUNTRY_DDL.SelectedValue);
                vHashtable.Add("CUST_ARHQ_ID", AreaHQ_DDL.SelectedValue.ToString());
                vHashtable.Add("CUST_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
                vHashtable.Add("CUST_FROM_DATE", TXT_START.Text);
                vHashtable.Add("CUST_TO_DATE", TXT_END.Text);
                vHashtable.Add("CUST_VALUE", TXT_PATIENT.Text);
                if (DBManager.ExecInsUpsReturn(vHashtable, "INS_CUSTOMER_NEW", (ATSession)Session["User"]))
                {
                    if (HiddenField1.Value.Equals("0"))
                    {
                        try
                        {
                            string pwd = Create_Password();
                            Hashtable vHT = new Hashtable();
                            vHT.Add("ID", HiddenField1.Value);
                            vHT.Add("USR_LOGIN", TXT_MOBILE_NO.Text);
                            vHT.Add("USR_PASSWORD", pwd);
                            vHT.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                            vHT.Add("USR_COMPANY", vATSession.Company.ToString());
                            vHT.Add("USR_ZONE_ID", "0");
                            vHT.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                            vHT.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue.ToString());
                            vHT.Add("USR_VSOHQ_ID", "0");
                            vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue.ToString());
                            vHT.Add("USR_CONT_NAME", "");
                            vHT.Add("USR_ADDRESS", TXT_ADDRESS.Text);
                            vHT.Add("USR_PIN", TXT_PIN.Text);
                            vHT.Add("USR_PHONE", TXT_MOBILE_NO.Text);
                            vHT.Add("USR_MOBILE", TXT_MOBILE_NO.Text);
                            vHT.Add("USR_FAX", "");
                            vHT.Add("USR_EMAIL", TXT_EMAIL.Text);
                            vHT.Add("USR_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
                            vHT.Add("USR_FROM_DATE", TXT_START.Text);
                            vHT.Add("USR_TO_DATE", TXT_END.Text);
                            vHT.Add("USR_SUBSCRIPTION_NUMBER", TXT_Sub.Text);
                            vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", TXT_PATIENT.Text);
                            vHT.Add("USR_CLINICAL_HEAD", "");
                            DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);

                            ATApp vATApp = (ATApp)Application["Config"];
                            String vBody = "Dear " + "" + "\n\nLogin Details for NerdNerdy Web Application.\n\n";
                            vBody += "URL is: www.nerdnerdy.in\n";
                            vBody += "Login: " + TXT_MOBILE_NO.Text + "\nPassword:" + pwd + "\n\n";
                            vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
                            ATCommon.SendMail(TXT_EMAIL.Text, "Login Details for NerdNerdy Application.", vBody,vATApp);
                            ShowMsg(int.Parse(TXTID.Value));
                            Clear();
                        }
                        catch (Exception xe)
                        {
                            ShowMsg(xe);
                        }
                    }
                    else
                    {
                        Hashtable vHT1 = new Hashtable();
                        vHT1.Add("USR_LOGIN", TXT_MOBILE_NO.Text.Trim());
                        vHT1.Add("USR_ZONE_ID", "");
                        vHT1.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                        vHT1.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue.ToString());
                        vHT1.Add("USR_VSOHQ_ID", "0");
                        vHT1.Add("USR_CONT_NAME", TXT_ORGANIZATION.Text);
                        vHT1.Add("USR_TYPE", "ORGANIZATION");
                        vHT1.Add("USR_EMAIL", TXT_EMAIL.Text);
                        vHT1.Add("USR_MOBILE", TXT_MOBILE_NO.Text);
                        DBManager.ExecInsUps(vHT1, "UPDATE_USER", (ATSession)Session["User"]);
                    }
                    ShowMsg(int.Parse(TXTID.Value));
                    Clear();
                    Response.Redirect("User_AdminList.aspx");
                }
            }
            else
            {
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("CUST_ID", TXTID.Value);
                vHashtable.Add("CUST_VSOHQ_ID", "0");
                vHashtable.Add("CUST_STA_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                vHashtable.Add("CUST_NAME", TXT_ORGANIZATION.Text);
                vHashtable.Add("CUST_PROSPECTIVE", "");
                vHashtable.Add("CUST_PREFIX", "");
                vHashtable.Add("CUST_ADDRESS", TXT_ADDRESS.Text);
                vHashtable.Add("CUST_COMP_NAME", TXT_ORGANIZATION.Text);
                vHashtable.Add("CUST_DISTRICT", "0");
                vHashtable.Add("CUST_VILLAGE_TWN_CITY", "");
                vHashtable.Add("CUST_POST_OFFICE", "");
                vHashtable.Add("CUST_STATE", "0");
                vHashtable.Add("CUST_CATRGORY_ID", "");
                vHashtable.Add("CUST_CONSULT_NAME", "");
                vHashtable.Add("CUST_CONSULT_MOB", TXT_MOBILE_NO.Text);
                vHashtable.Add("CUST_PIN", TXT_PIN.Text);
                vHashtable.Add("CUST_PHONE", TXT_MOBILE_NO.Text);
                vHashtable.Add("CUST_EMAIL", TXT_EMAIL.Text);
                vHashtable.Add("CUST_MOBILE", TXT_MOBILE_NO.Text);
                vHashtable.Add("CUST_DEALER", vATSession.CUST_ID);
                vHashtable.Add("CUST_DESIGNATION", "");
                vHashtable.Add("CUST_COUNTRY_ID", CUST_COUNTRY_DDL.SelectedValue);
                vHashtable.Add("CUST_ARHQ_ID", AreaHQ_DDL.SelectedValue.ToString());
                vHashtable.Add("CUST_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
                vHashtable.Add("CUST_FROM_DATE", TXT_START.Text);
                vHashtable.Add("CUST_TO_DATE", TXT_END.Text);
                vHashtable.Add("CUST_VALUE", TXT_PATIENT.Text);
                if (DBManager.ExecInsUpsReturn(vHashtable, "INS_CUSTOMER_NEW", (ATSession)Session["User"]))
                {
                    if (HiddenField1.Value.Equals("0"))
                    {
                        try
                        {
                            Hashtable vHT = new Hashtable();
                            vHT.Add("ID", HiddenField1.Value);
                            vHT.Add("USR_LOGIN", TXT_MOBILE_NO.Text);
                            vHT.Add("USR_PASSWORD", TXT_PASSWORD.Text);
                            vHT.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                            vHT.Add("USR_COMPANY", vATSession.Company.ToString());
                            vHT.Add("USR_ZONE_ID", "0");
                            vHT.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                            vHT.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue.ToString());
                            vHT.Add("USR_VSOHQ_ID", "0");
                            vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue.ToString());
                            vHT.Add("USR_CONT_NAME", "");
                            vHT.Add("USR_ADDRESS", TXT_ADDRESS.Text);
                            vHT.Add("USR_PIN", TXT_PIN.Text);
                            vHT.Add("USR_PHONE", TXT_MOBILE_NO.Text);
                            vHT.Add("USR_MOBILE", TXT_MOBILE_NO.Text);
                            vHT.Add("USR_FAX", "");
                            vHT.Add("USR_EMAIL", TXT_EMAIL.Text);
                            vHT.Add("USR_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
                            vHT.Add("USR_FROM_DATE", TXT_START.Text);
                            vHT.Add("USR_TO_DATE", TXT_END.Text);
                            vHT.Add("USR_SUBSCRIPTION_NUMBER", TXT_Sub.Text);
                            vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", TXT_PATIENT.Text);
                            vHT.Add("USR_CLINICAL_HEAD", "");
                            DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);

                            ATApp vATApp = (ATApp)Application["Config"];
                            String vBody = "Dear " + "" + "\n\nLogin Details for NerdNerdy Web Application.\n\n";
                            vBody += "URL is: www.nerdnerdy.in\n";
                            vBody += "Login: " + TXT_MOBILE_NO.Text + "\nPassword:" + TXT_PASSWORD.Text + "\n\n";
                            vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
                            ATCommon.SendMail(TXT_EMAIL.Text, "Login Details for NerdNerdy Application.", vBody, vATApp);
                            ShowMsg(int.Parse(TXTID.Value));
                            Clear();
                        }
                        catch (Exception xe)
                        {
                            ShowMsg(xe);
                        }
                    }
                    else
                    {
                        Hashtable vHT1 = new Hashtable();
                        vHT1.Add("USR_LOGIN", TXT_MOBILE_NO.Text.Trim());
                        vHT1.Add("USR_ZONE_ID", "");
                        vHT1.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                        vHT1.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue.ToString());
                        vHT1.Add("USR_VSOHQ_ID", "0");
                        vHT1.Add("USR_CONT_NAME", TXT_ORGANIZATION.Text);
                        vHT1.Add("USR_TYPE", "ORGANIZATION");
                        vHT1.Add("USR_EMAIL", TXT_EMAIL.Text);
                        vHT1.Add("USR_MOBILE", TXT_MOBILE_NO.Text);
                        DBManager.ExecInsUps(vHT1, "UPDATE_USER", (ATSession)Session["User"]);
                    }
                    ShowMsg(int.Parse(TXTID.Value));
                    Clear();
                    Response.Redirect("User_AdminList.aspx");
                }
            }
        }
        catch (Exception xe)
        {
            ShowMsg(xe);
        }
    }
    }
    protected string Create_Password()
    {
        string pwd = "";
        Random Rand = new Random();
        for (int i = 0; i < 4; i++)
        {
            if (i < 3)
                pwd += Convert.ToChar(Rand.Next(65, 90));
            else
                pwd += Rand.Next(0, 100).ToString();
        }
        return pwd;
    }
    public void Clear()
    {
    }
    protected void CUST_COUNTRY_DDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        UP_COUNTRY.Update();
    }

    protected void RegioanlHQ_DDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("STATE_ID", RegioanlHQ_DDL.SelectedValue.ToString());
        ATCommon.FillDrpDown(AreaHQ_DDL, DBManager.Get(vHashtable, "CMB_City"), "Select City Name", "CITY_NAME", "CITY_ID", "");
        AreaHQ_DDL.Enabled = true;
        UP_AreaHQ.Update();
        UP_RegioanlHQ.Update();
    }

    protected void existuser_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "GET_USER_INFO");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["USR_ORGANIZATION_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }

        }
    }
    protected void existence_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTMOBILEEMAIL");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["CUST_MOBILE"].ToString().Equals(args.Value) || DR["USR_LOGIN"].ToString().Equals(args.Value)
                    || DR["CUST_EMAIL"].ToString().Equals(args.Value) || DR["USR_EMAIL"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}
