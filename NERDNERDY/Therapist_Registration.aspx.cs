using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Therapist_Registration : BasePage
{
    private ATSession vATSession;
    private DataRow vDR;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)

            //btnPay.Visible = false;
            //btnsave.Visible = false;
        if (!IsPostBack)
        {
            try
            {
                    //Paybtn_Click(btnPay, new EventArgs());
                    Paybtn_Click();
                    Page.ClientScript.RegisterStartupScript(GetType(), "none", "<script>pay();</script>", false);

                    String vID = Request.QueryString["id"];
                if (vID != null)
                {
                    Hashtable vHT = new Hashtable();
                    vHT.Add("USR_LOGIN", vID);
                    DataRow vDR = RetDR(DBManager.Get(vHT, "GETUSR"));
                    if (vDR != null)
                    {
                        TXT_SUBSCRIPTION.Text = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                        TXT_MOBILE_NO.Text = vDR["USR_MOBILE"].ToString();
                        TXT_EMAIL.Text = vDR["USR_EMAIL"].ToString();
                        TXT_ORGANIZATION.Text = vDR["USR_ORGANIZATION_NAME"].ToString();
                        //btnsave.Visible = false;
                        ///btnPay.Visible = true;
                    }
                }

            }
            catch (Exception xe)
            {
                //ShowMsg(xe); 
            }
        }
    }

    protected void Savebtn_Click(object sender, EventArgs e)
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
                    vHashtable.Add("CUST_STA_ID", "0");
                    vHashtable.Add("CUST_NAME", TXT_ORGANIZATION.Text);
                    vHashtable.Add("CUST_PROSPECTIVE", "");
                    vHashtable.Add("CUST_PREFIX", "");
                    vHashtable.Add("CUST_ADDRESS", "");
                    vHashtable.Add("CUST_COMP_NAME", TXT_ORGANIZATION.Text);
                    vHashtable.Add("CUST_DISTRICT", "0");
                    vHashtable.Add("CUST_VILLAGE_TWN_CITY", "");
                    vHashtable.Add("CUST_POST_OFFICE", "");
                    vHashtable.Add("CUST_STATE", "0");
                    vHashtable.Add("CUST_CATRGORY_ID", "");
                    vHashtable.Add("CUST_CONSULT_NAME", "");
                    vHashtable.Add("CUST_CONSULT_MOB", TXT_MOBILE_NO.Text);
                    vHashtable.Add("CUST_PIN", "000");
                    vHashtable.Add("CUST_PHONE", TXT_MOBILE_NO.Text);
                    vHashtable.Add("CUST_EMAIL", TXT_EMAIL.Text);
                    vHashtable.Add("CUST_MOBILE", TXT_MOBILE_NO.Text);
                    vHashtable.Add("CUST_DEALER", "0");
                    vHashtable.Add("CUST_DESIGNATION", "");
                    vHashtable.Add("CUST_COUNTRY_ID", "0");
                    vHashtable.Add("CUST_ARHQ_ID", "0");
                    vHashtable.Add("CUST_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
                    vHashtable.Add("CUST_FROM_DATE", "2020-08-01 00:00:00.000");
                    vHashtable.Add("CUST_TO_DATE", "2021-08-01 00:00:00.000");
                    vHashtable.Add("CUST_VALUE", "1");
                    vHashtable.Add("last_user", "Therapist");
                    DataRow vDR15 = RetDR(DBManager.Get(vHashtable, "INS_CUSTOMER_NEW"));
                    //if (DBManager.ExecInsUpsReturn(vHashtable, "INS_CUSTOMER_NEW", (ATSession)Session["User"]))
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
                                vHT.Add("USR_TYPE", "Therapist");
                                vHT.Add("USR_COMPANY", "NERDNERDY");
                                vHT.Add("USR_ZONE_ID", "0");
                                vHT.Add("USR_REGHQ_ID", "0");
                                vHT.Add("USR_ARHQ_ID", "0");
                                vHT.Add("USR_VSOHQ_ID", "0");
                                vHT.Add("USR_COUNTRY", "0");
                                vHT.Add("USR_CONT_NAME", "");
                                vHT.Add("USR_ADDRESS", "");
                                vHT.Add("USR_PIN", "");
                                vHT.Add("USR_PHONE", TXT_MOBILE_NO.Text);
                                vHT.Add("USR_MOBILE", TXT_MOBILE_NO.Text);
                                vHT.Add("USR_FAX", "");
                                vHT.Add("USR_EMAIL", TXT_EMAIL.Text);
                                vHT.Add("USR_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
                                vHT.Add("USR_FROM_DATE", "");
                                vHT.Add("USR_TO_DATE", "");
                                vHT.Add("USR_SUBSCRIPTION_NUMBER", "1");
                                vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", TXT_SUBSCRIPTION.Text);
                                vHT.Add("USR_CLINICAL_HEAD", "");
                                vHT.Add("LAST_USER", "Therapist");
                                DataRow vDR1 = RetDR(DBManager.Get(vHT, "INS_USER"));
                                //btnsave.Visible = false;
                                Response.Redirect("Therapist_Registration.aspx?id=" + TXT_MOBILE_NO.Text);
                                //DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);
                                //Response.Write("<script language='javascript'>window.alert('You will receive a message or call for login options.');window.location='Default.aspx';</script>");
                                ///btnsave.Visible = false;
                                //Response.Redirect("Default.aspx");
                            }
                            catch (Exception xe)
                            {
                                // ShowMsg(xe);
                            }
                        }
                    }
                }

            }
            catch (Exception exRollback)
            {
                Console.WriteLine(exRollback.Message);
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

    public static class Checker
    {
        public static int stopper = 0;
    }
    protected void existence_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Checker.stopper == 0)
        {
            if (HiddenField1.Value == "0")
            {
                DataTable Dt = DBManager.Get(new Hashtable(), "EXISTMOBILENUMBER");
                foreach (DataRow DR in Dt.Rows)
                {
                    if (DR["CUST_MOBILE"].ToString().Equals(args.Value) || DR["USR_LOGIN"].ToString().Equals(args.Value))
                    {
                        args.IsValid = false;
                        break;
                    }
                }
            }
            Checker.stopper = 1;
        }
    }

    protected void Paybtn_Click()
    {
        string absoluteurl = HttpContext.Current.Request.Url.AbsoluteUri;

        if (absoluteurl.Contains("SendEmail"))
        {
            // then find phone number in url

            String vID = Request.QueryString["id"];
            string phone_num = vID.Substring(0, 10);

            Hashtable vHT = new Hashtable();
            vHT.Add("USR_LOGIN", phone_num);
            DataRow vDR = RetDR(DBManager.Get(vHT, "GETUSR"));
            if (vDR != null)
            {
                TXT_SUBSCRIPTION.Text = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                TXT_MOBILE_NO.Text = vDR["USR_MOBILE"].ToString();
                TXT_EMAIL.Text = vDR["USR_EMAIL"].ToString();
                TXT_ORGANIZATION.Text = vDR["USR_ORGANIZATION_NAME"].ToString();
                HiddenField2.Value = vDR["USR_PASSWORD"].ToString();

                ATApp vATApp = (ATApp)Application["Config"];
                String vBody = "Dear " + "" + "\n\nLogin Details for NerdNerdy Web Application.\n\n";
                vBody += "URL is: nerdnerdy.in\n";
                vBody += "Login: " + TXT_MOBILE_NO.Text + "\nPassword:" + HiddenField2.Value + "\n\n";
                vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
                ATCommon.SendMail(TXT_EMAIL.Text, "Login Details for NerdNerdy Application.", vBody, vATApp);
                //Response.Write("<script language='javascript'>window.alert('Email is sent to registered Email.');window.location='Default.aspx';</script>");
                Response.Write("<script language='javascript'>window.alert('Login-id & Password sent on your Email.');window.location='Default.aspx';</script>");
            }
        }

    }
}