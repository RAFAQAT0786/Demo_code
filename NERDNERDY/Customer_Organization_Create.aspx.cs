using System;
using System.Data;
using System.Collections;
using System.IO;

public partial class Customer_Organization_Create : BasePage
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
        String vID = vATSession.Login;

        if (!IsPostBack)
        {
            try
            {
                Label2.Text = "<b>Please note:</b> This application is a property of NerdNerdy Technologies Pvt Ltd. The system and content related to this software is under the Patent and Copy right protection." + "<br></br>";
                ValidateUserAccess();
                ATCommon.FillDrpDown(CUST_COUNTRY_DDL, DBManager.Get(new Hashtable(), "CMB_COUNTRY_MASTER"), "Select Country Name", "COUNTRY_NAME", "COUNTRY_ID", "0");
                //Hashtable vHashtable1 = new Hashtable();
                //vHashtable1.Add("STATE_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                //Hashtable vHashta = new Hashtable();
                //vHashta.Add("STATE_ID", RegioanlHQ_DDL.SelectedValue);
                //ATCommon.FillDrpDown(RegioanlHQ_DDL, DBManager.Get(vHashta, "CMB_State"), "Select State Name", "STATE_NAME", "STATE_ID", "");
                if (vID != null)
                {
                    if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                    {
                        Hashtable vHT = new Hashtable();
                        vHT.Add("USR_LOGIN", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHT, "GETUSR"));
                        if (vDR != null)
                        {
                            TXTID.Value = "1";
                            DDL_USER_TYPE.SelectedValue = vDR["USR_TYPE"].ToString();
                            TXT_LOGIN.Text = vDR["USR_LOGIN"].ToString();
                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["USR_COUNTRY"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);
                           
                            RegioanlHQ_DDL.SelectedIndex = RegioanlHQ_DDL.Items.IndexOf(RegioanlHQ_DDL.Items.FindByValue(vDR["USR_REGHQ_ID"].ToString()));
                            RegioanlHQ_DDL_SelectedIndexChanged(sender, e);
                            
                            AreaHQ_DDL.SelectedIndex = AreaHQ_DDL.Items.IndexOf(AreaHQ_DDL.Items.FindByValue(vDR["USR_ARHQ_ID"].ToString()));
                            RegioanlHQ_DDL.SelectedValue = vDR["USR_REGHQ_ID"].ToString();
                            CUST_COUNTRY_DDL.SelectedValue = vDR["USR_COUNTRY"].ToString();
                            TXT_CONT_NAME.Text = vDR["USR_CONT_NAME"].ToString();
                            //TXT_PHONE_NO.Text = vDR["USR_PHONE"].ToString();
                            TXT_MOBILE_NO.Text = vDR["USR_MOBILE"].ToString();
                            //TXT_FAX_NO.Text = vDR["USR_FAX"].ToString();
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
                            TXT_PATIENT.Enabled = false;
                            TXT_ORGANIZATION.Enabled = false;
                        }
                    }
                    else
                    {
                        DDL_USER_TYPE.SelectedValue = "";
                        Hashtable vHT = new Hashtable();
                        vHT.Add("USR_LOGIN", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHT, "GETUSR"));
                        if (vDR != null)
                        {
                            TXTID.Value = "1";
                            DDL_USER_TYPE.SelectedValue = vDR["USR_TYPE"].ToString();
                            TXT_LOGIN.Text = vDR["USR_LOGIN"].ToString();
                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["USR_COUNTRY"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);

                            RegioanlHQ_DDL.SelectedIndex = RegioanlHQ_DDL.Items.IndexOf(RegioanlHQ_DDL.Items.FindByValue(vDR["USR_REGHQ_ID"].ToString()));
                            RegioanlHQ_DDL_SelectedIndexChanged(sender, e);

                            AreaHQ_DDL.SelectedIndex = AreaHQ_DDL.Items.IndexOf(AreaHQ_DDL.Items.FindByValue(vDR["USR_ARHQ_ID"].ToString()));
                            CUST_COUNTRY_DDL.SelectedValue = vDR["USR_COUNTRY"].ToString();
                            TXT_CONT_NAME.Text = vDR["USR_CONT_NAME"].ToString();
                            //TXT_PHONE_NO.Text = vDR["USR_PHONE"].ToString();
                            TXT_MOBILE_NO.Text = vDR["USR_MOBILE"].ToString();
                            //TXT_FAX_NO.Text = vDR["USR_FAX"].ToString();
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
                if (TXT_PASSWORD.Text != null)
                {
                    Hashtable vHT = new Hashtable();
                    vHT.Add("ID", TXTID.Value);
                    vHT.Add("USR_LOGIN", TXT_MOBILE_NO.Text);
                    vHT.Add("USR_PASSWORD", TXT_PASSWORD.Text);
                    vHT.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                    vHT.Add("USR_COMPANY", vATSession.Company.ToString());
                    vHT.Add("USR_ZONE_ID", "0");
                    vHT.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                    vHT.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue.ToString());
                    vHT.Add("USR_VSOHQ_ID", "0");
                    vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue.ToString());
                    vHT.Add("USR_CONT_NAME", TXT_CONT_NAME.Text);
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

                    //ATApp vATApp = (ATApp)Application["Config"];
                    //String vBody = "Dear " + TXT_CONT_NAME.Text + "\n\nLogin Details for NerdNerdy Application.\n\n";
                    //vBody += "URL is: <a href='www.demo.areeva.in'>www.nerdnerdy.in</a>\n";
                    //vBody += "Login: " + TXT_LOGIN.Text + "\nPassword:" + TXT_PASSWORD.Text + "\n\n";
                    //vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
                    //ShowMsg(int.Parse(TXTID.Value));
                    Response.Redirect("Customer_Organization_Create.aspx");
                    Clear();
                }
                else
                {
                    string pwd = Create_Password();
                    Hashtable vHT = new Hashtable();
                    vHT.Add("ID", TXTID.Value);
                    vHT.Add("USR_LOGIN", TXT_MOBILE_NO.Text);
                    vHT.Add("USR_PASSWORD", pwd);
                    vHT.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                    vHT.Add("USR_COMPANY", vATSession.Company.ToString());
                    vHT.Add("USR_ZONE_ID", "0");
                    vHT.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                    vHT.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue.ToString());
                    vHT.Add("USR_VSOHQ_ID", "0");
                    vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue.ToString());
                    vHT.Add("USR_CONT_NAME", TXT_CONT_NAME.Text);
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

                    //ATApp vATApp = (ATApp)Application["Config"];
                    //String vBody = "Dear " + TXT_CONT_NAME.Text + "\n\nLogin Details for NerdNerdy Application.\n\n";
                    //vBody += "URL is: <a href='www.demo.areeva.in'>www.nerdnerdy.in</a>\n";
                    //vBody += "Login: " + TXT_LOGIN.Text + "\nPassword:" + pwd + "\n\n";
                    //vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
                    //ShowMsg(int.Parse(TXTID.Value));
                    Response.Redirect("Customer_Organization_Create.aspx");
                    Clear();

                }
            }
            catch (Exception xe) { ShowMsg(xe); }
           
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
        Hashtable vHashta = new Hashtable();
        vHashta.Add("COUNTRY_ID", CUST_COUNTRY_DDL.SelectedValue);
        ATCommon.FillDrpDown(RegioanlHQ_DDL, DBManager.Get(vHashta, "CMB_State"), "Select State Name", "STATE_NAME", "STATE_ID", "");
        UP_COUNTRY.Update();
        UP_RegioanlHQ.Update();
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
                if (DR[0].ToString().Equals(TXT_LOGIN.Text))
                {
                    args.IsValid = false;
                    break;
                }
            }

        }
    }
}
