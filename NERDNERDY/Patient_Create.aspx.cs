using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class Patient_Create : BasePage
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
                ATCommon.FillDrpDown(CUST_COUNTRY_DDL, DBManager.Get(new Hashtable(), "CMB_COUNTRY_MASTER"), "Select Country Name", "COUNTRY_NAME", "COUNTRY_ID", "0");
                Hashtable vHashtable1 = new Hashtable();
                ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_MASTER_NEW"), "Select Age Group Name", "AGRP_GROUP", "AGRP_ID", "0");
                //vHashtable1.Add("STATE_ID", RegioanlHQ_DDL.SelectedValue.ToString());
                //Hashtable vHashta = new Hashtable();
                //vHashta.Add("STATE_ID", CUST_COUNTRY_DDL.SelectedValue);
                //ATCommon.FillDrpDown(CUST_COUNTRY_DDL, DBManager.Get(vHashta, "CMB_State"), "Select State Name", "STATE_NAME", "STATE_ID", "");

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
                        vHashtable.Add("PTP_ID", vID);
                        vHashtable.Add("TYPE", "GET");
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_DETAIL"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["PTP_ID"].ToString();
                            PTP_NAME_TXT.Text = vDR["PTP_NAME"].ToString();
                            DDLAGE.SelectedValue = vDR["PTP_AGRPID"].ToString();
                            PTP_GENDER.SelectedValue = vDR["PTP_GENDER"].ToString();
                            PTP_THERAPIST_TXT.Text = vDR["PTP_THERAPIST_NAME"].ToString();
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            PTP_ADD_TXT.Text = vDR["PTP_ADD"].ToString();
                            PTP_REMARK_TXT.Text = vDR["PTP_REMARKS"].ToString();
                            PRIMARY_TXT.Text = vDR["PTP_PRI_LANG"].ToString();
                            string dt3 = Convert.ToDateTime(vDR["PTP_TEST_DATE"]).ToString("dd/MMM/yyyy");
                            TEST_DATE_TXT.Text = dt3.ToString();
                            PARENT_TXT.Text = vDR["PTP_PARENT_NAME"].ToString();
                            FATHER_TXT.Text = vDR["PTP_FATHER_OCCUPATION"].ToString();
                            MOTHER_TXT.Text = vDR["PTP_MOTHER_OCCUPATION"].ToString();
                            PRIOR_TXT.Text = vDR["PTP_PRIOR_DIAGNOSIS"].ToString();
                            string dt4 = Convert.ToDateTime(vDR["PTP_YEAR_DIAGNOSIS"]).ToString("dd/MMM/yyyy");
                            //YEAR_DIAG_TXT.Text = dt4.ToString();
                            REFERRED_TXT.Text = vDR["PTP_REFERRED"].ToString();
                            THERAPY_TXT.Text = vDR["PTP_PRIOR_THERAPY"].ToString();
                            PINCODE_TXT.Text = vDR["PTP_PINCODE"].ToString();
                            PTP_EMAIL_TXT.Text = vDR["PTP_EMAIL"].ToString();

                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["PTP_COUNTRYID"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);

                            CUST_COUNTRY_DDL.SelectedValue = vDR["PTP_COUNTRYID"].ToString();

                            RegioanlHQ_DDL.SelectedIndex = RegioanlHQ_DDL.Items.IndexOf(RegioanlHQ_DDL.Items.FindByValue(vDR["PTP_REGHQID"].ToString()));
                            RegioanlHQ_DDL_SelectedIndexChanged(sender, e);

                            AreaHQ_DDL.SelectedIndex = AreaHQ_DDL.Items.IndexOf(AreaHQ_DDL.Items.FindByValue(vDR["PTP_ARHQID"].ToString()));

                            string dt8 = Convert.ToDateTime(vDR["PTP_DOB"]).ToString("dd/MMM/yyyy");
                            PTP_CDOB_TXT.Text = dt8.ToString();
                            PTP_QUA_TXT.Text = vDR["PTP_QUALIFICATION"].ToString();

                            
                        }
                        else
                            ShowMsg("Invalid Patient ID");
                    }
                }

                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        vHashtable.Add("TYPE", "GET");
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_DETAIL"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["PTP_ID"].ToString();
                            PTP_NAME_TXT.Text = vDR["PTP_NAME"].ToString();
                            DDLAGE.SelectedValue = vDR["PTP_AGRPID"].ToString();
                            PTP_GENDER.SelectedValue = vDR["PTP_GENDER"].ToString();
                            PTP_THERAPIST_TXT.Text = vDR["PTP_THERAPIST_NAME"].ToString();
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            PTP_ADD_TXT.Text = vDR["PTP_ADD"].ToString();
                            PTP_REMARK_TXT.Text = vDR["PTP_REMARKS"].ToString();
                            PRIMARY_TXT.Text = vDR["PTP_PRI_LANG"].ToString();
                            string dt3 = Convert.ToDateTime(vDR["PTP_TEST_DATE"]).ToString("dd/MMM/yyyy");
                            TEST_DATE_TXT.Text = dt3.ToString();
                            PARENT_TXT.Text = vDR["PTP_PARENT_NAME"].ToString();
                            FATHER_TXT.Text = vDR["PTP_FATHER_OCCUPATION"].ToString();
                            MOTHER_TXT.Text = vDR["PTP_MOTHER_OCCUPATION"].ToString();
                            PRIOR_TXT.Text = vDR["PTP_PRIOR_DIAGNOSIS"].ToString();
                            string dt4 = Convert.ToDateTime(vDR["PTP_YEAR_DIAGNOSIS"]).ToString("dd/MMM/yyyy");
                            //YEAR_DIAG_TXT.Text = dt4.ToString();
                            REFERRED_TXT.Text = vDR["PTP_REFERRED"].ToString();
                            THERAPY_TXT.Text = vDR["PTP_PRIOR_THERAPY"].ToString();
                            PINCODE_TXT.Text = vDR["PTP_PINCODE"].ToString();
                            PTP_EMAIL_TXT.Text = vDR["PTP_EMAIL"].ToString();

                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["PTP_COUNTRYID"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);

                            CUST_COUNTRY_DDL.SelectedValue = vDR["PTP_COUNTRYID"].ToString();
                            RegioanlHQ_DDL.SelectedIndex = RegioanlHQ_DDL.Items.IndexOf(RegioanlHQ_DDL.Items.FindByValue(vDR["PTP_REGHQID"].ToString()));
                            RegioanlHQ_DDL_SelectedIndexChanged(sender, e);
                            AreaHQ_DDL.SelectedIndex = AreaHQ_DDL.Items.IndexOf(AreaHQ_DDL.Items.FindByValue(vDR["PTP_ARHQID"].ToString()));
                            string dt8 = Convert.ToDateTime(vDR["PTP_DOB"]).ToString("dd/MMM/yyyy");
                            PTP_CDOB_TXT.Text = dt8.ToString();
                            PTP_QUA_TXT.Text = vDR["PTP_QUALIFICATION"].ToString();

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
                    vHashtable.Add("PTP_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_DETAIL"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["PTP_ID"].ToString();
                        PTP_NAME_TXT.Text = vDR["PTP_NAME"].ToString();
                        DDLAGE.SelectedValue = vDR["PTP_AGRPID"].ToString();
                        PTP_GENDER.SelectedValue = vDR["PTP_GENDER"].ToString();
                        PTP_THERAPIST_TXT.Text = vDR["PTP_THERAPIST_NAME"].ToString();
                        PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                        PTP_ADD_TXT.Text = vDR["PTP_ADD"].ToString();
                        PTP_REMARK_TXT.Text = vDR["PTP_REMARKS"].ToString();
                        PRIMARY_TXT.Text = vDR["PTP_PRI_LANG"].ToString();
                        string dt3 = Convert.ToDateTime(vDR["PTP_TEST_DATE"]).ToString("dd/MMM/yyyy");
                        TEST_DATE_TXT.Text = dt3.ToString();
                        PARENT_TXT.Text = vDR["PTP_PARENT_NAME"].ToString();
                        FATHER_TXT.Text = vDR["PTP_FATHER_OCCUPATION"].ToString();
                        MOTHER_TXT.Text = vDR["PTP_MOTHER_OCCUPATION"].ToString();
                        PRIOR_TXT.Text = vDR["PTP_PRIOR_DIAGNOSIS"].ToString();
                        string dt4 = Convert.ToDateTime(vDR["PTP_YEAR_DIAGNOSIS"]).ToString("dd/MMM/yyyy");
                        //YEAR_DIAG_TXT.Text = dt4.ToString();
                        REFERRED_TXT.Text = vDR["PTP_REFERRED"].ToString();
                        THERAPY_TXT.Text = vDR["PTP_PRIOR_THERAPY"].ToString();
                        PINCODE_TXT.Text = vDR["PTP_PINCODE"].ToString();
                        PTP_EMAIL_TXT.Text = vDR["PTP_EMAIL"].ToString();

                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["PTP_COUNTRYID"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);

                            CUST_COUNTRY_DDL.SelectedValue = vDR["PTP_COUNTRYID"].ToString();
                        RegioanlHQ_DDL.SelectedIndex = RegioanlHQ_DDL.Items.IndexOf(RegioanlHQ_DDL.Items.FindByValue(vDR["PTP_REGHQID"].ToString()));
                        RegioanlHQ_DDL_SelectedIndexChanged(sender, e);
                        AreaHQ_DDL.SelectedIndex = AreaHQ_DDL.Items.IndexOf(AreaHQ_DDL.Items.FindByValue(vDR["PTP_ARHQID"].ToString()));
                        string dt8 = Convert.ToDateTime(vDR["PTP_DOB"]).ToString("dd/MMM/yyyy");
                        PTP_CDOB_TXT.Text = dt8.ToString();
                        PTP_QUA_TXT.Text = vDR["PTP_QUALIFICATION"].ToString();
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
            if (TXTID.Value != "0")
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTP_ID", TXTID.Value);
                    vHashtable.Add("PTP_AGRPID", DDLAGE.SelectedValue);
                    vHashtable.Add("PTP_REGHQID", RegioanlHQ_DDL.SelectedValue);
                    vHashtable.Add("PTP_ARHQID", AreaHQ_DDL.SelectedValue);
                    vHashtable.Add("PTP_VSOHQID", "");
                    vHashtable.Add("PTP_STAID", "");
                    vHashtable.Add("PTP_NAME", PTP_NAME_TXT.Text);
                    vHashtable.Add("PTP_GENDER", PTP_GENDER.SelectedValue);
                    vHashtable.Add("PTP_DOB", PTP_CDOB_TXT.Text);
                    vHashtable.Add("PTP_MOBILE", PTP_MOB_TXT.Text);
                    vHashtable.Add("PTP_ADD", PTP_ADD_TXT.Text);
                    vHashtable.Add("PTP_REMARKS", PTP_REMARK_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("PTP_EMAIL", PTP_EMAIL_TXT.Text);
                    vHashtable.Add("PTP_PRI_LANG", PRIMARY_TXT.Text);
                    vHashtable.Add("PTP_TEST_DATE", TEST_DATE_TXT.Text);
                    vHashtable.Add("PTP_PARENT_NAME", PARENT_TXT.Text);
                    vHashtable.Add("PTP_FATHER_OCCUPATION", FATHER_TXT.Text);
                    vHashtable.Add("PTP_MOTHER_OCCUPATION", MOTHER_TXT.Text);
                    vHashtable.Add("PTP_PRIOR_DIAGNOSIS", PRIOR_TXT.Text);
                    //vHashtable.Add("PTP_YEAR_DIAGNOSIS", YEAR_DIAG_TXT.Text);
                    vHashtable.Add("PTP_YEAR_DIAGNOSIS", "");
                    vHashtable.Add("PTP_REFERRED", REFERRED_TXT.Text);
                    vHashtable.Add("PTP_PRIOR_THERAPY", THERAPY_TXT.Text);
                    vHashtable.Add("PTP_PINCODE", PINCODE_TXT.Text);
                    vHashtable.Add("PTP_COUNTRYID", CUST_COUNTRY_DDL.SelectedValue);
                    vHashtable.Add("PTP_THERAPIST_NAME", PTP_THERAPIST_TXT.Text);
                    vHashtable.Add("PTP_QUALIFICATION", PTP_QUA_TXT.Text);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_PATIENT_DETAIL_UPDATE");
                    {
                        if (TXTID.Value.Equals("0"))
                        {
                            try
                            {
                                string pwd = Create_Password();
                                Hashtable vHT = new Hashtable();
                                vHT.Add("ID", TXTID.Value);

                                if (TXTID.Value == "0")
                                    vHT.Add("USR_LOGIN", PTP_MOB_TXT.Text);
                                else
                                    vHT.Add("USR_LOGIN", PTP_MOB_TXT.Text.Trim());
                                vHT.Add("USR_ZONE_ID", "");
                                vHT.Add("USR_TYPE", "Patient");
                                vHT.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue);
                                vHT.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue);
                                vHT.Add("USR_VSOHQ_ID", "");
                                vHT.Add("USR_COMPANY", " ");
                                vHT.Add("USR_CONT_NAME", PTP_NAME_TXT.Text);
                                vHT.Add("USR_ADDRESS", PTP_ADD_TXT.Text);
                                vHT.Add("USR_PIN", "");
                                vHT.Add("USR_PHONE", "");
                                vHT.Add("USR_MOBILE", PTP_MOB_TXT.Text);
                                vHT.Add("USR_FAX", "");
                                vHT.Add("USR_EMAIL", PTP_EMAIL_TXT.Text);
                                vHT.Add("USR_PASSWORD", pwd);
                                vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue);
                                vHT.Add("USR_ORGANIZATION_NAME", "");
                                vHT.Add("USR_FROM_DATE", "");
                                vHT.Add("USR_TO_DATE", "");
                                vHT.Add("USR_SUBSCRIPTION_NUMBER", "");
                                vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", "");
                                vHT.Add("USR_CLINICAL_HEAD", "");
                                DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);
                                //ATApp vATApp = (ATApp)Application["Config"];

                                //String vBody = "Dear " + PTP_MOB_TXT.Text + "\n\nLogin Details for Nerdnerdy Web Application.\n\n";
                                //vBody += "URL is: nerdnerdy.in\n";
                                //if (TXTID.Value == "0")
                                //    vBody += "Login: " + PTP_MOB_TXT + "\nPassword:" + pwd + "\n\n";
                                //else
                                //    vBody += "Login: " + PTP_MOB_TXT.Text + "\nPassword:" + pwd + "\n\n";
                                //vBody += "For any query, please revert us back.\n\nThanks and Regards\n";

                                //ATCommon.SendMail(PTP_MOB_TXT.Text, "Login Details for Nerdnerdy Web Application.", vBody, vATApp);
                                //ShowMsg(int.Parse(TXTID.Value));
                                Clear();
                            }
                            catch (Exception xe) { ShowMsg(xe); }
                        }
                        else
                        {
                            Hashtable vHT1 = new Hashtable();
                            vHT1.Add("USR_LOGIN", PTP_MOB_TXT.Text.Trim());
                            vHT1.Add("USR_ZONE_ID", "");
                            vHT1.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue);
                            vHT1.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue);
                            vHT1.Add("USR_VSOHQ_ID", "");
                            vHT1.Add("USR_CONT_NAME", PTP_NAME_TXT.Text);
                            vHT1.Add("USR_TYPE", "Patient");
                            vHT1.Add("USR_EMAIL", PTP_EMAIL_TXT.Text);
                            vHT1.Add("USR_MOBILE", PTP_MOB_TXT.Text);
                            vHT1.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", "");
                            DBManager.ExecInsUps(vHT1, "UPDATE_USER", (ATSession)Session["User"]);
                        }
                    }
                    Response.Redirect("Patient.aspx");
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
                    vHashtable.Add("PTP_ID", TXTID.Value);
                    vHashtable.Add("PTP_AGRPID", DDLAGE.SelectedValue);
                    vHashtable.Add("PTP_REGHQID", RegioanlHQ_DDL.SelectedValue);
                    vHashtable.Add("PTP_ARHQID", AreaHQ_DDL.SelectedValue);
                    vHashtable.Add("PTP_VSOHQID", "");
                    vHashtable.Add("PTP_STAID", "");
                    vHashtable.Add("PTP_NAME", PTP_NAME_TXT.Text);
                    vHashtable.Add("PTP_GENDER", PTP_GENDER.SelectedValue);
                    vHashtable.Add("PTP_DOB", PTP_CDOB_TXT.Text);
                    vHashtable.Add("PTP_MOBILE", PTP_MOB_TXT.Text);
                    vHashtable.Add("PTP_ADD", PTP_ADD_TXT.Text);
                    vHashtable.Add("PTP_REMARKS", PTP_REMARK_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("PTP_EMAIL", PTP_EMAIL_TXT.Text);
                    vHashtable.Add("PTP_PRI_LANG", PRIMARY_TXT.Text);
                    vHashtable.Add("PTP_TEST_DATE", TEST_DATE_TXT.Text);
                    vHashtable.Add("PTP_PARENT_NAME", PARENT_TXT.Text);
                    vHashtable.Add("PTP_FATHER_OCCUPATION", FATHER_TXT.Text);
                    vHashtable.Add("PTP_MOTHER_OCCUPATION", MOTHER_TXT.Text);
                    vHashtable.Add("PTP_PRIOR_DIAGNOSIS", PRIOR_TXT.Text);
                    //vHashtable.Add("PTP_YEAR_DIAGNOSIS", YEAR_DIAG_TXT.Text);
                    vHashtable.Add("PTP_YEAR_DIAGNOSIS", "");
                    vHashtable.Add("PTP_REFERRED", REFERRED_TXT.Text);
                    vHashtable.Add("PTP_PRIOR_THERAPY", THERAPY_TXT.Text);
                    vHashtable.Add("PTP_PINCODE", PINCODE_TXT.Text);
                    vHashtable.Add("PTP_COUNTRYID", CUST_COUNTRY_DDL.SelectedValue);
                    vHashtable.Add("PTP_CUSTID", HiddenField1.Value);
                    vHashtable.Add("TYPE", "INS");
                    vHashtable.Add("PTP_THERAPIST_NAME", PTP_THERAPIST_TXT.Text);
                    vHashtable.Add("PTP_QUALIFICATION", PTP_QUA_TXT.Text);
                    DBManager.Get(vHashtable, "INS_PATIENT_DETAIL");
                    {
                        if (TXTID.Value.Equals("0"))
                        {
                            try
                            {
                                string pwd = Create_Password();
                                Hashtable vHT = new Hashtable();
                                vHT.Add("ID", TXTID.Value);

                                if (TXTID.Value == "0")
                                    vHT.Add("USR_LOGIN", PTP_MOB_TXT.Text);
                                else
                                    vHT.Add("USR_LOGIN", PTP_MOB_TXT.Text.Trim());
                                vHT.Add("USR_ZONE_ID", "");
                                vHT.Add("USR_TYPE", "Patient");
                                vHT.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue);
                                vHT.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue);
                                vHT.Add("USR_VSOHQ_ID", "");
                                vHT.Add("USR_COMPANY", " ");
                                vHT.Add("USR_CONT_NAME", PTP_NAME_TXT.Text);
                                vHT.Add("USR_ADDRESS", PTP_ADD_TXT.Text);
                                vHT.Add("USR_PIN", "");
                                vHT.Add("USR_PHONE", "");
                                vHT.Add("USR_MOBILE", PTP_MOB_TXT.Text);
                                vHT.Add("USR_FAX", "");
                                vHT.Add("USR_EMAIL", PTP_EMAIL_TXT.Text);
                                vHT.Add("USR_PASSWORD", pwd);
                                vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue);
                                vHT.Add("USR_ORGANIZATION_NAME", "");
                                vHT.Add("USR_FROM_DATE", "");
                                vHT.Add("USR_TO_DATE", "");
                                vHT.Add("USR_SUBSCRIPTION_NUMBER", "");
                                vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", "");
                                vHT.Add("USR_CLINICAL_HEAD", "");
                                DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);
                                //ATApp vATApp = (ATApp)Application["Config"];

                                //String vBody = "Dear " + PTP_NAME_TXT.Text + "\n\nLogin Detaials for Nerdnerdy Web Application.\n\n";
                                //vBody += "URL is: nerdnerdy.in\n";
                                //if (TXTID.Value == "0")
                                //    vBody += "Login: " + PTP_MOB_TXT + "\nPassword:" + pwd + "\n\n";
                                //else
                                //    vBody += "Login: " + PTP_MOB_TXT.Text + "\nPassword:" + pwd + "\n\n";
                                //vBody += "For any query, please revert us back.\n\nThanks and Regards\n";

                                //ATCommon.SendMail(PTP_MOB_TXT.Text, "Login Detaials for Nerdnerdy Web Application.", vBody, vATApp);
                                //ShowMsg(int.Parse(TXTID.Value));
                                Clear();
                            }
                            catch (Exception xe) { ShowMsg(xe); }
                        }
                        else
                        {
                            Hashtable vHT1 = new Hashtable();
                            vHT1.Add("USR_LOGIN", PTP_MOB_TXT.Text.Trim());
                            vHT1.Add("USR_ZONE_ID", "");
                            vHT1.Add("USR_REGHQ_ID", RegioanlHQ_DDL.SelectedValue);
                            vHT1.Add("USR_ARHQ_ID", AreaHQ_DDL.SelectedValue);
                            vHT1.Add("USR_VSOHQ_ID", "");
                            vHT1.Add("USR_CONT_NAME", PTP_NAME_TXT.Text);
                            vHT1.Add("USR_TYPE", "Patient");
                            vHT1.Add("USR_EMAIL", PTP_EMAIL_TXT.Text);
                            vHT1.Add("USR_MOBILE", PTP_MOB_TXT.Text);
                            vHT1.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", "");
                            DBManager.ExecInsUps(vHT1, "UPDATE_USER", (ATSession)Session["User"]);
                        }
                    }
                    Response.Redirect("Patient.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
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

    protected void DDLLOCATION_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}