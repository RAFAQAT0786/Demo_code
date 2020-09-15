using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

public partial class Registration : BasePage
{
    private ATSession vATSession;
    private DataRow vDR;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            //Response.Redirect("Registration.aspx");
        //String vID = Request.QueryString["ID"];

        if (!IsPostBack)
        {
            try
            {
                //ATCommon.FillDrpDown(DDLIEA, DBManager.Get(new Hashtable(), "CMB_IEP_SKILL_ACTIVITY"), "Select IEA Name", "IEPA_DESC", "IEPA_ID", "0");
                //ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER_PATIENT_NEW"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");

                //if (vATSession.UserType == "ADMIN")
                //{
                //    if (vID != null)
                //    {
                //        Hashtable vHashtable = new Hashtable();
                //        vHashtable.Add("IEPAT_ID", vID);
                //        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_NEW"));
                //        if (vDR != null)
                //        {
                //            TXTID.Value = vDR["IEPAT_ID"].ToString();
                //            IEPAT_REMARK.Text = vDR["IEPAT_REMARK"].ToString();
                //            PTP_DATE_TXT.Text = vDR["IEPAT_DATE"].ToString();
                //            DDLCAT.SelectedItem.Text = vDR["DCAT_NAME"].ToString();
                //            DDLSUBCAT.SelectedItem.Text = vDR["DSCAT_DESC"].ToString();
                //            DDLIEA.SelectedItem.Text = vDR["IEPA_DESC"].ToString();
                //            TXTVALUE.Value = vDR["IEPAT_DISID"].ToString();
                //            PTP_DATE_TXT.Enabled = false;
                //            DDLIEA.Enabled = false;
                //            DDLCAT.Enabled = false;
                //            DDLSUBCAT.Enabled = false;
                //            if (vDR["IEPAT_PRESENT"].ToString() == "1")
                //            {
                //                chkSelect1.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect1.Checked = false;
                //            }
                //            if (vDR["IEPAT_ABSENT"].ToString() == "1")
                //            {
                //                chkSelect.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect.Checked = false;
                //            }
                //            if (vDR["IEPAT_REG"].ToString() == "1")
                //            {
                //                chkSelect2.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect2.Checked = false;
                //            }
                //            if (IEPAT_REMARK.Text != "")
                //            {
                //                btnupdate.Visible = false;
                //            }
                //        }
                //        else
                //            ShowMsg("Invalid IEP ID");
                //    }
                //}
                //else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                //{
                //    if (vID != null)
                //    {
                //        Hashtable vHashtable = new Hashtable();
                //        vHashtable.Add("IEPAT_ID", vID);
                //        DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_NEW"));
                //        if (vDR1 != null)
                //        {
                //            TXTID.Value = vDR1["IEPAT_ID"].ToString();
                //            IEPAT_REMARK.Text = vDR1["IEPAT_REMARK"].ToString();
                //            PTP_DATE_TXT.Text = vDR1["IEPAT_DATE"].ToString();
                //            DDLCAT.SelectedItem.Text = vDR1["DCAT_NAME"].ToString();
                //            DDLSUBCAT.SelectedItem.Text = vDR1["DSCAT_DESC"].ToString();
                //            DDLIEA.SelectedItem.Text = vDR1["IEPA_DESC"].ToString();
                //            TXTVALUE.Value = vDR1["IEPAT_DISID"].ToString();
                //            PTP_DATE_TXT.Enabled = false;
                //            DDLIEA.Enabled = false;
                //            DDLCAT.Enabled = false;
                //            DDLSUBCAT.Enabled = false;
                //            if (vDR1["IEPAT_PRESENT"].ToString() == "1")
                //            {
                //                chkSelect1.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect1.Checked = false;
                //            }
                //            if (vDR1["IEPAT_ABSENT"].ToString() == "1")
                //            {
                //                chkSelect.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect.Checked = false;
                //            }
                //            if (vDR1["IEPAT_REG"].ToString() == "1")
                //            {
                //                chkSelect2.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect2.Checked = false;
                //            }
                //            if (IEPAT_REMARK.Text != "")
                //            {
                //                 btnupdate.Visible = false;
                //            }
                //        }
                //        else
                //            ShowMsg("Invalid IEP ID");

                //    }
                //  }
                //else
                //{
                //    if (vID != null)
                //    {
                //        Hashtable vHashtable = new Hashtable();
                //        vHashtable.Add("IEPAT_ID", vID);
                //        DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_NEW"));
                //        if (vDR1 != null)
                //        {
                //            TXTID.Value = vDR1["IEPAT_ID"].ToString();
                //            IEPAT_REMARK.Text = vDR1["IEPAT_REMARK"].ToString();
                //            PTP_DATE_TXT.Text = vDR1["IEPAT_DATE"].ToString();
                //            DDLCAT.SelectedItem.Text = vDR1["DCAT_NAME"].ToString();
                //            DDLSUBCAT.SelectedItem.Text = vDR1["DSCAT_DESC"].ToString();
                //            DDLIEA.SelectedItem.Text = vDR1["IEPA_DESC"].ToString();
                //            TXTVALUE.Value = vDR1["IEPAT_DISID"].ToString();
                //            PTP_DATE_TXT.Enabled = false;
                //            DDLIEA.Enabled = false;
                //            DDLCAT.Enabled = false;
                //            DDLSUBCAT.Enabled = false;
                //            if (vDR1["IEPAT_PRESENT"].ToString() == "1")
                //            {
                //                chkSelect1.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect1.Checked = false;
                //            }
                //            if (vDR1["IEPAT_ABSENT"].ToString() == "1")
                //            {
                //                chkSelect.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect.Checked = false;
                //            }
                //            if (vDR1["IEPAT_REG"].ToString() == "1")
                //            {
                //                chkSelect2.Checked = true;
                //            }
                //            else
                //            {
                //                chkSelect2.Checked = false;
                //            }
                //            if (IEPAT_REMARK.Text != "")
                //            {
                //                btnupdate.Visible = false;
                //            }
                //        }
                //        else
                //            ShowMsg("Invalid IEP ID");
                //    }
                //}
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void Savebtn_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source=182.18.187.118;Initial Catalog=DEMO_NERDNERDY;User ID=sa;Password=GTAalm6FPML4n6t$;");
        SqlCommand cmd = new SqlCommand("INS_CUSTOMER_NEW", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlTransaction tran = con.BeginTransaction();
            
            cmd.Parameters.AddWithValue("CUST_ID", TXTID.Value);
        cmd.Parameters.AddWithValue("CUST_VSOHQ_ID", "0");
        cmd.Parameters.AddWithValue("CUST_STA_ID", "0");
        cmd.Parameters.AddWithValue("CUST_NAME", TXT_ORGANIZATION.Text);
        cmd.Parameters.AddWithValue("CUST_PROSPECTIVE", "");
        cmd.Parameters.AddWithValue("CUST_PREFIX", "");
        cmd.Parameters.AddWithValue("CUST_ADDRESS", "");
        cmd.Parameters.AddWithValue("CUST_COMP_NAME", TXT_ORGANIZATION.Text);
        cmd.Parameters.AddWithValue("CUST_DISTRICT", "0");
        cmd.Parameters.AddWithValue("CUST_VILLAGE_TWN_CITY", "");
        cmd.Parameters.AddWithValue("CUST_POST_OFFICE", "");
        cmd.Parameters.AddWithValue("CUST_STATE", "0");
        cmd.Parameters.AddWithValue("CUST_CATRGORY_ID", "");
        cmd.Parameters.AddWithValue("CUST_CONSULT_NAME", "");
        cmd.Parameters.AddWithValue("CUST_CONSULT_MOB", TXT_MOBILE_NO.Text);
        cmd.Parameters.AddWithValue("CUST_PIN", "000");
        cmd.Parameters.AddWithValue("CUST_PHONE", TXT_MOBILE_NO.Text);
        cmd.Parameters.AddWithValue("CUST_EMAIL", TXT_EMAIL.Text);
        cmd.Parameters.AddWithValue("CUST_MOBILE", TXT_MOBILE_NO.Text);
        cmd.Parameters.AddWithValue("CUST_DEALER", "0");
        cmd.Parameters.AddWithValue("CUST_DESIGNATION", "");
        cmd.Parameters.AddWithValue("CUST_COUNTRY_ID", "0");
        cmd.Parameters.AddWithValue("CUST_ARHQ_ID", "0");
        cmd.Parameters.AddWithValue("CUST_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
        cmd.Parameters.AddWithValue("CUST_FROM_DATE", "2020-08-01 00:00:00.000");
        cmd.Parameters.AddWithValue("CUST_TO_DATE", "2021-08-01 00:00:00.000");
        cmd.Parameters.AddWithValue("CUST_VALUE", "1");
        cmd.Parameters.AddWithValue("last_user", "Therapist");
            

            SqlCommand cmd1 = new SqlCommand("INS_USER", con);
            string pwd = Create_Password();
            cmd1.Parameters.AddWithValue("ID", HiddenField1.Value);
            cmd1.Parameters.AddWithValue("USR_LOGIN", TXT_MOBILE_NO.Text);
            cmd1.Parameters.AddWithValue("USR_PASSWORD", pwd);
            cmd1.Parameters.AddWithValue("USR_TYPE", DDL_USER_TYPE.SelectedValue);
            cmd1.Parameters.AddWithValue("USR_COMPANY", "NERDNERDY");
            cmd1.Parameters.AddWithValue("USR_ZONE_ID", "0");
            cmd1.Parameters.AddWithValue("USR_REGHQ_ID", "0");
            cmd1.Parameters.AddWithValue("USR_ARHQ_ID", "0");
            cmd1.Parameters.AddWithValue("USR_VSOHQ_ID", "0");
            cmd1.Parameters.AddWithValue("USR_COUNTRY", "0");
            cmd1.Parameters.AddWithValue("USR_CONT_NAME", "");
            cmd1.Parameters.AddWithValue("USR_ADDRESS", "");
            cmd1.Parameters.AddWithValue("USR_PIN", "");
            cmd1.Parameters.AddWithValue("USR_PHONE", TXT_MOBILE_NO.Text);
            cmd1.Parameters.AddWithValue("USR_MOBILE", TXT_MOBILE_NO.Text);
            cmd1.Parameters.AddWithValue("USR_FAX", "");
            cmd1.Parameters.AddWithValue("USR_EMAIL", TXT_EMAIL.Text);
            cmd1.Parameters.AddWithValue("USR_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
            cmd1.Parameters.AddWithValue("USR_FROM_DATE", "");
            cmd1.Parameters.AddWithValue("USR_TO_DATE", "");
            cmd1.Parameters.AddWithValue("USR_SUBSCRIPTION_NUMBER", "1");
            cmd1.Parameters.AddWithValue("USR_PATIENT_SUBSCRIPTION_NUMBER", "1");
            cmd1.Parameters.AddWithValue("USR_CLINICAL_HEAD", "");

            ATApp vATApp = (ATApp)Application["Config"];
            String vBody = "Dear " + "" + "\n\nLogin Details for NerdNerdy Web Application.\n\n";
            vBody += "URL is: www.nerdnerdy.in\n";
            vBody += "Login: " + TXT_MOBILE_NO.Text + "\nPassword:" + pwd + "\n\n";
            vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
            ATCommon.SendMail(TXT_EMAIL.Text, "Login Details for NerdNerdy Application.", vBody, vATApp);
            ShowMsg(int.Parse(TXTID.Value));

            int k = cmd.ExecuteNonQuery();
            int k1 = cmd1.ExecuteNonQuery();
            //tran.commit();
            cmd1.Parameters.Clear();
            tran.Commit();
            lblmsg.Text = "Record Inserted Succesfully into the Database";
            ///frmload();
        }
        catch (Exception exRollback)
        {
            Console.WriteLine(exRollback.Message);
        }
      //}
        //int k = cmd.ExecuteNonQuery();
        //if (k != 0)
        //{
        //    lblmsg.Text = "Record Inserted Succesfully into the Database";
        //    lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
        //}
        //con.Close();


        //if (Page.IsValid)
        //{
        //    try
        //    {
        //        if (TXTID.Value == "0")
        //        {
        //            Hashtable vHashtable = new Hashtable();
        //            vHashtable.Add("CUST_ID", TXTID.Value);
        //            vHashtable.Add("CUST_VSOHQ_ID", "0");
        //            vHashtable.Add("CUST_STA_ID", "0");
        //            vHashtable.Add("CUST_NAME", TXT_ORGANIZATION.Text);
        //            vHashtable.Add("CUST_PROSPECTIVE", "");
        //            vHashtable.Add("CUST_PREFIX", "");
        //            vHashtable.Add("CUST_ADDRESS", TXT_ADDRESS.Text);
        //            vHashtable.Add("CUST_COMP_NAME", TXT_ORGANIZATION.Text);
        //            vHashtable.Add("CUST_DISTRICT", "0");
        //            vHashtable.Add("CUST_VILLAGE_TWN_CITY", "");
        //            vHashtable.Add("CUST_POST_OFFICE", "");
        //            vHashtable.Add("CUST_STATE", "0");
        //            vHashtable.Add("CUST_CATRGORY_ID", "");
        //            vHashtable.Add("CUST_CONSULT_NAME", "");
        //            vHashtable.Add("CUST_CONSULT_MOB", TXT_MOBILE_NO.Text);
        //            vHashtable.Add("CUST_PIN", "000");
        //            vHashtable.Add("CUST_PHONE", TXT_MOBILE_NO.Text);
        //            vHashtable.Add("CUST_EMAIL", TXT_EMAIL.Text);
        //            vHashtable.Add("CUST_MOBILE", TXT_MOBILE_NO.Text);
        //            vHashtable.Add("CUST_DEALER", "0");
        //            vHashtable.Add("CUST_DESIGNATION", "");
        //            vHashtable.Add("CUST_COUNTRY_ID", "0");
        //            vHashtable.Add("CUST_ARHQ_ID", "0");
        //            vHashtable.Add("CUST_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
        //            vHashtable.Add("CUST_FROM_DATE", "2020-08-01 00:00:00.000");
        //            vHashtable.Add("CUST_TO_DATE", "2021-08-01 00:00:00.000");
        //            vHashtable.Add("CUST_VALUE", "1");
        //            //if (DBManager.ExecInsUpsReturn(vHashtable, "INS_CUSTOMER_NEW", (ATSession)Session["User"]))
        //            {
        //                if (HiddenField1.Value.Equals("0"))
        //                {
        //                    try
        //                    {
        //                        string pwd = Create_Password();
        //                        Hashtable vHT = new Hashtable();
        //                        vHT.Add("ID", HiddenField1.Value);
        //                        vHT.Add("USR_LOGIN", TXT_MOBILE_NO.Text);
        //                        vHT.Add("USR_PASSWORD", pwd);
        //                        vHT.Add("USR_TYPE", "Therapist");
        //                        vHT.Add("USR_COMPANY", "NERDNERDY");
        //                        vHT.Add("USR_ZONE_ID", "0");
        //                        vHT.Add("USR_REGHQ_ID", "0");
        //                        vHT.Add("USR_ARHQ_ID", "0");
        //                        vHT.Add("USR_VSOHQ_ID", "0");
        //                        vHT.Add("USR_COUNTRY", "0");
        //                        vHT.Add("USR_CONT_NAME", "");
        //                        vHT.Add("USR_ADDRESS", TXT_ADDRESS.Text);
        //                        vHT.Add("USR_PIN", "");
        //                        vHT.Add("USR_PHONE", TXT_MOBILE_NO.Text);
        //                        vHT.Add("USR_MOBILE", TXT_MOBILE_NO.Text);
        //                        vHT.Add("USR_FAX", "");
        //                        vHT.Add("USR_EMAIL", TXT_EMAIL.Text);
        //                        vHT.Add("USR_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
        //                        vHT.Add("USR_FROM_DATE", "");
        //                        vHT.Add("USR_TO_DATE", "");
        //                        vHT.Add("USR_SUBSCRIPTION_NUMBER", "1");
        //                        vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", "1");
        //                        vHT.Add("USR_CLINICAL_HEAD", "");
        //                        DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);

        //                        ATApp vATApp = (ATApp)Application["Config"];
        //                        String vBody = "Dear " + "" + "\n\nLogin Details for NerdNerdy Web Application.\n\n";
        //                        vBody += "URL is: www.demo.nerdnerdy.in\n";
        //                        vBody += "Login: " + TXT_MOBILE_NO.Text + "\nPassword:" + pwd + "\n\n";
        //                        vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
        //                        ATCommon.SendMail(TXT_EMAIL.Text, "Login Details for NerdNerdy Application.", vBody, vATApp);
        //                        ShowMsg(int.Parse(TXTID.Value));

        //                    }
        //                    catch (Exception xe)
        //                    {
        //                        ShowMsg(xe);
        //                    }
        //                }
        //                ShowMsg(int.Parse(TXTID.Value));

        //               // Response.Redirect("Default.aspx");
        //            }
        //        }
        //        else
        //        {
        //            Hashtable vHashtable = new Hashtable();
        //            vHashtable.Add("CUST_ID", TXTID.Value);
        //            vHashtable.Add("CUST_VSOHQ_ID", "0");
        //            vHashtable.Add("CUST_STA_ID", "0");
        //            vHashtable.Add("CUST_NAME", TXT_ORGANIZATION.Text);
        //            vHashtable.Add("CUST_PROSPECTIVE", "");
        //            vHashtable.Add("CUST_PREFIX", "");
        //            vHashtable.Add("CUST_ADDRESS", TXT_ADDRESS.Text);
        //            vHashtable.Add("CUST_COMP_NAME", TXT_ORGANIZATION.Text);
        //            vHashtable.Add("CUST_DISTRICT", "");
        //            vHashtable.Add("CUST_VILLAGE_TWN_CITY", "");
        //            vHashtable.Add("CUST_POST_OFFICE", "");
        //            vHashtable.Add("CUST_STATE", "0");
        //            vHashtable.Add("CUST_CATRGORY_ID", "");
        //            vHashtable.Add("CUST_CONSULT_NAME", "");
        //            vHashtable.Add("CUST_CONSULT_MOB", TXT_MOBILE_NO.Text);
        //            vHashtable.Add("CUST_PIN", "00");
        //            vHashtable.Add("CUST_PHONE", TXT_MOBILE_NO.Text);
        //            vHashtable.Add("CUST_EMAIL", TXT_EMAIL.Text);
        //            vHashtable.Add("CUST_MOBILE", TXT_MOBILE_NO.Text);
        //            vHashtable.Add("CUST_DEALER", "");
        //            vHashtable.Add("CUST_DESIGNATION", "");
        //            vHashtable.Add("CUST_COUNTRY_ID", "0");
        //            vHashtable.Add("CUST_ARHQ_ID", "0");
        //            vHashtable.Add("CUST_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
        //            vHashtable.Add("CUST_FROM_DATE", "");
        //            vHashtable.Add("CUST_TO_DATE", "");
        //            vHashtable.Add("CUST_VALUE", "1");
        //            if (DBManager.ExecInsUpsReturn(vHashtable, "INS_CUSTOMER_NEW", (ATSession)Session["User"]))
        //            {
        //                if (HiddenField1.Value.Equals("0"))
        //                {
        //                    try
        //                    {
        //                        string pwd = Create_Password();
        //                        Hashtable vHT = new Hashtable();
        //                        vHT.Add("ID", HiddenField1.Value);
        //                        vHT.Add("USR_LOGIN", TXT_MOBILE_NO.Text);
        //                        vHT.Add("USR_PASSWORD", pwd);
        //                        vHT.Add("USR_TYPE", "Therapist");
        //                        vHT.Add("USR_COMPANY", vATSession.Company.ToString());
        //                        vHT.Add("USR_ZONE_ID", "0");
        //                        vHT.Add("USR_REGHQ_ID", "0");
        //                        vHT.Add("USR_ARHQ_ID", "0");
        //                        vHT.Add("USR_VSOHQ_ID", "0");
        //                        vHT.Add("USR_COUNTRY", "0");
        //                        vHT.Add("USR_CONT_NAME", "");
        //                        vHT.Add("USR_ADDRESS", TXT_ADDRESS.Text);
        //                        vHT.Add("USR_PIN", "");
        //                        vHT.Add("USR_PHONE", TXT_MOBILE_NO.Text);
        //                        vHT.Add("USR_MOBILE", TXT_MOBILE_NO.Text);
        //                        vHT.Add("USR_FAX", "");
        //                        vHT.Add("USR_EMAIL", TXT_EMAIL.Text);
        //                        vHT.Add("USR_ORGANIZATION_NAME", TXT_ORGANIZATION.Text);
        //                        vHT.Add("USR_FROM_DATE", "");
        //                        vHT.Add("USR_TO_DATE", "");
        //                        vHT.Add("USR_SUBSCRIPTION_NUMBER", "1");
        //                        vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", "1");
        //                        vHT.Add("USR_CLINICAL_HEAD", "");
        //                        DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);

        //                        ATApp vATApp = (ATApp)Application["Config"];
        //                        String vBody = "Dear " + "" + "\n\nLogin Details for NerdNerdy Web Application.\n\n";
        //                        vBody += "URL is: www.demo.nerdnerdy.in\n";
        //                        vBody += "Login: " + TXT_MOBILE_NO.Text + "\nPassword:" + pwd + "\n\n";
        //                        vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
        //                        ATCommon.SendMail(TXT_EMAIL.Text, "Login Details for NerdNerdy Application.", vBody, vATApp);
        //                        ShowMsg(int.Parse(TXTID.Value));

        //                    }
        //                    catch (Exception xe)
        //                    {
        //                        ShowMsg(xe);
        //                    }
        //                }
        //                ShowMsg(int.Parse(TXTID.Value));

        //                Response.Redirect("Default.aspx");
        //        }
        //        }
        //    }
        //    catch (Exception xe)
        //    {
        //        ShowMsg(xe);
        //    }
        //}
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

}