using System;
using System.Collections;
using System.Configuration;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public partial class Patient_Doctor_Report : BasePage
{
    ATSession vATSession;
    BLLReport vReport = new BLLReport();
    DataRow vDR;
    Document document;
    PdfWriter pdfw;
    Font HeadingFontbold;
    BLLAGE vAGE = new BLLAGE();
    Font Headingbold;
    Font NormalFont;
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
                if (vATSession.UserType == "ADMIN")
                {
                    if (vID != null)
                    {
                        //Label2.Text = "<b>NerdNerdy</b> report template assists the organizations and therapists to develop and genertae customized reports for your Patients. Kindly follow the steps given below." +
                        //"<br><b>Step 1- Basic Information</b>-In a given text box fill the basic information of your patient like <b>Medical, Developmental and Family history, Symptoms and Clinical observations</b> (Suggested template in text box is given for your reference, you may modify, add or delete text per your patient)</br>" +
                        //"<br><b>Step 2- Test administered</b>-To Compile the scores of the tests in the report,Go to patient detail and click Test adminstered tab.</br>" +
                        //"<br><b>Step 3- Recommendation</b>- Go to <b>Patient detail</b>…....click <b>Recommendations</b>….. Recommendations you have added and saved for your patient will be shown in your patients PDF report.</br>" +
                        //"<br><b>Step 4- Save & Generate Report</b>-Please fill all the enteries given on the Report template page.  You can save report for your Patient. At this stage you can make changes in any section of the report and save it again. After you confirm the disclaimer, you can genertae the PDF report of your patient. The changes cannot be made after you have generated the PDF report.</br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                        if (vDR != null)
                        {
                            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                            PTP_NAME_TXT.Text = vDR["PTP_NAME"].ToString();
                            TXTVEHID.Value = vDR["AGRP_ID"].ToString();
                            HiddenField1.Value = vID;
                            HiddenField2.Value = vID;
                            HiddenField3.Value = vID;
                            HiddenField4.Value = vID;
                            HiddenField5.Value = vID;
                            HiddenField6.Value = vID;
                            HiddenField7.Value = vID;
                            HiddenField8.Value = vID;
                            HiddenField9.Value = vID;
                            TXTID2.Value = vDR["AGRP_ID"].ToString();
                            PTP_AGE_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            PTP_NAME_TXT.Enabled = false;
                            SAVEBTN.Visible = false;
                            TXT_DOC_NAME.Text = vDR["CUST_NAME"].ToString();
                            TXT_DOC_DESIG.Text = vDR["CUST_DESIGNATION"].ToString();

                            Textarea2.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "mother was " +
                            "------------ " + "years old and father- was " + "------------- " + "years old at the time of the birth of" + "&nbsp;" +
                            vDR["PTP_NAME"].ToString() + "&nbsp;" + "There were" + "&nbsp;" + "complications / no complications" + "&nbsp;" +
                            "during pregnancy reported by the mother and" + "&nbsp;" + "he / she" + "&nbsp;" + "was born with no apparent  medical complications/ issues like" +
                            "------------------------------------" + vDR["PTP_NAME"].ToString() + "&nbsp;" +
                            "was full term / pre-term" + "and was born through C-section / normal delivery." +
                            "The mother" + "&nbsp;" + "----------" + "did not face complications/ faced complications during delivery." +
                            "------------------------------------" + vDR["PTP_NAME"].ToString() + "&nbsp;"
                              + "birth weight was " + "----------.";

                            Textarea3.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "did/did not reach all the major developmental milestones on time. The developmental " +
                            "milestones were reported as within the normal range for ------------" + "<br />" +
                            "a)	Physical development" + "<br />" +
                            "b)	Speech and language development" + "<br />" +
                            "c)	Cognitive development" + "<br />" +
                            "d)	Fine Motor development" + "<br />" +
                            "e)	Gross Motor Development." + "<br />" + "However, he/she has poor----------" + "<br />" + "a)	Physical development" + "<br />" + "b)	Speech and language development" + "<br />" +
                            "c)	Cognitive development" + "<br />" + "d)	Fine Motor development"
                              + "<br />" + "e)	Gross Motor Development.";

                            Textarea4.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "lives with his/her " + "&nbsp;" +
                            "parents/Institution." + "<br />" +
                            "He/she" + "&nbsp;" +
                            "has younger/older " + "&nbsp;" +
                            "sibling." + "&nbsp;" +
                            "As reported by the mother/father/caregiver" + "&nbsp;" +
                            "there is a /No " + "<br />" + "history of developmental problem within the immediate family....." + "<br />";
                        }
                        Hashtable vHashtable44 = new Hashtable();
                        vHashtable44.Add("AGRP_ID", TXTID2.Value);
                        DataRow vDR44 = RetDR(DBManager.Get(vHashtable44, "GET_RPT_ID"));
                        if (vDR44 != null)
                        {
                            TXTID.Value = vDR44["RPT_ID"].ToString();
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("RPT_ID", TXTID.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        DataTable dt = DBManager.Get(vHashtable1, "GET_RPT_ID_NEW");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_RPT_ID_NEW"));
                        if (vDR1 != null)
                        {
                            if (dt.Rows[0]["RPTD_EVAID"].ToString() != null)
                            {
                                Textarea1.InnerText = vDR1["RPTD_REPREASON"].ToString();
                               // Textarea2.InnerText = vDR1["RPTD_MED"].ToString();
                               // Textarea3.InnerText = vDR1["RPTD_PTMID"].ToString();
                               // Textarea4.InnerText = vDR1["RPTD_PTFHID"].ToString();
                                Textarea5.InnerText = vDR1["RPTD_DOBSID"].ToString();
                            }

                            //Hashtable vHashtable18 = new Hashtable();
                            //vHashtable18.Add("PTP_ID", vID);
                            //DataRow vDR18 = RetDR(DBManager.Get(vHashtable18, "GET_FMD"));
                            //if (vDR18 != null)
                            //{
                            //    Textarea2.InnerText = vDR18["PTM_DESC"].ToString();
                            //    Textarea3.InnerText = vDR18["PTDEV_DESC"].ToString();
                            //    Textarea4.InnerText = vDR18["PTFH_DESC"].ToString();
                            //}

                            Hashtable vHashtable4 = new Hashtable();
                           // vHashtable4.Add("PTR_ID", TXTVALUE.Value);
                            vHashtable4.Add("PTP_ID", vID);
                            DataTable dt1 = DBManager.Get(vHashtable4, "GET_PT_REPORT");
                            DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_PT_REPORT"));
                            if (dt1.Rows.Count > 0)
                            {
                                HiddenField10.Value   = vDR3["PTR_ID"].ToString();
                                Textarea1.InnerText   =  vDR3["PTR_REPREASON"].ToString();
                                Textarea2.InnerText   =  vDR3["PTR_MED"].ToString();
                                Textarea11.InnerText  =  vDR3["PTR_DST"].ToString();
                                Textarea4.InnerText   =  vDR3["PTR_PTFHID"].ToString();
                                Textarea5.InnerText   =  vDR3["PTR_DOBSID"].ToString();
                                TXT_DOC_NAME.Text     =  vDR3["PTR_DOCTOR_NAME"].ToString();
                                TXT_DOC_DESIG.Text    =  vDR3["PTR_DESIGNATION"].ToString();
                                TXT_DOC_REG.Text      =  vDR3["PTR_REGISTRATION"].ToString();
                                TXT_DISCLAIMER.Text   =  vDR3["PTR_DISCLAIMER"].ToString();
                                Textarea6.InnerText = vDR3["PTR_SYMPTOMS"].ToString();
                                GRADE_TXT.Text = vDR3["PTR_GRADE"].ToString();
                                SAVEBTN.Visible       =  false;
                                PDFBTN.Visible        =  true;
                                Textarea2.InnerText = vDR3["PTR_MED"].ToString();
                                Textarea3.InnerText = vDR3["PTR_PTDEVID"].ToString();
                                Textarea4.InnerText = vDR3["PTR_PTFHID"].ToString();
                                ORG_TXT.Text = vDR3["PTR_ORGANIZATION_NAME"].ToString();
                                EMAIL_TXT.Text = vDR3["PTR_EMAIL"].ToString();
                                PHONE_TXT.Text = vDR3["PTR_PHONE_NUMBER"].ToString();
                                ADDRESS_TXT.Text = vDR3["PTR_ADDRESS"].ToString();
                                if (vDR3["PTR_DISCLAIMER"].ToString() == "1")
                                {
                                    CheckBox1.Checked = true;
                                    this.PDFBTN.Enabled = true;
                                }
                                else
                                {
                                    CheckBox1.Checked = false;
                                    this.PDFBTN.Enabled = false;
                                }
                            }

                            //Hashtable vHashtable14 = new Hashtable();
                            //vHashtable14.Add("PTP_ID", vID);
                            //DataTable dt14 = DBManager.Get(vHashtable14, "GET_RECOMMENDATION_NEW");
                            //DataRow vDR14 = RetDR(DBManager.Get(vHashtable14, "GET_RECOMMENDATION_NEW"));
                            //if (dt14.Rows.Count > 0)
                            //{
                            //    foreach (DataRow dtRow in dt14.Rows)
                            //    {
                            //        // On all tables' columns
                            //        foreach (DataColumn dc in dt14.Columns)
                            //        {
                            //            Textarea17.InnerText += dtRow[dc].ToString();
                            //        }
                            //    }
                            //}
                            //if (vDR14 != null)
                            //{
                            //    Textarea17.InnerText = vDR14["RECOM_TEXT"].ToString();
                            //}
                            //else
                            //{
                            //    string message = "Please Fill Recommendation First!!";
                            //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            //    sb.Append("<script type = 'text/javascript'>");
                            //    sb.Append("window.onload=function(){");
                            //    sb.Append("alert('");
                            //    sb.Append(message);
                            //    sb.Append("')};");
                            //    sb.Append("</script>");
                            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                            //    SAVEBTN.Visible = false;
                            //    PDFBTN.Visible = false;
                            //}
                        }
                        else
                        {
                            string message = "This Age Group Template Does Not Be Created!!";
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                        }
                      }
                    }
                    else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                    {

                    //Label2.Text = "<b>NerdNerdy</b> report template assists the organizations and therapists to develop and genertae customized reports for your Patients. Kindly follow the steps given below." +
                    //    "<br><b>Step 1- Basic Information</b>-In a given text box fill the basic information of your patient like <b>Medical, Developmental and Family history, Symptoms and Clinical observations</b> (Suggested template in text box is given for your reference, you may modify, add or delete text per your patient)</br>" +
                    //    "<br><b>Step 2- Test administered</b>-To Compile the scores of the tests in the report,Go to patient detail and click Test adminstered tab.</br>" +
                    //    "<br><b>Step 3- Recommendation</b>- Go to <b>Patient detail</b>…....click <b>Recommendations</b>….. Recommendations you have added and saved for your patient will be shown in your patients PDF report.</br>" +
                    //    "<br><b>Step 4- Save & Generate Report</b>-Please fill all the enteries given on the Report template page.  You can save report for your Patient. At this stage you can make changes in any section of the report and save it again. After you confirm the disclaimer, you can genertae the PDF report of your patient. The changes cannot be made after you have generated the PDF report.</br>";
                   
                    Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                        if (vDR != null)
                        {
                            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                            PTP_NAME_TXT.Text = vDR["PTP_NAME"].ToString();
                            HiddenField1.Value = vID;
                            HiddenField2.Value = vID;
                            HiddenField3.Value = vID;
                            HiddenField4.Value = vID;
                            HiddenField5.Value = vID;
                            HiddenField6.Value = vID;
                            HiddenField7.Value = vID;
                            HiddenField8.Value = vID;
                            HiddenField9.Value = vID;
                            TXTID2.Value = vDR["AGRP_ID"].ToString();
                            PTP_AGE_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            PTP_NAME_TXT.Enabled = false;
                            TXT_DOC_NAME.Text = vDR["CUST_NAME"].ToString();
                            TXT_DOC_DESIG.Text = vDR["CUST_DESIGNATION"].ToString();
                            PDFBTN.Visible = false;

                        Textarea2.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "mother was " +
                        "------------ " + "years old and father- was " + "------------- " + "years old at the time of the birth of" + "&nbsp;" +
                        vDR["PTP_NAME"].ToString() + "&nbsp;" + "There were" + "&nbsp;" + "complications / no complications" + "&nbsp;" +
                        "during pregnancy reported by the mother and" + "&nbsp;" + "he / she" + "&nbsp;" + "was born with no apparent  medical complications/ issues like " +
                        "------------------------------------" + vDR["PTP_NAME"].ToString() + "&nbsp;" +
                        "was full term / pre-term" + "and was born through C-section / normal delivery." +
                        "The mother" + "&nbsp;" + "----------" + "did not face complications/ faced complications during delivery." +
                        "------------------------------------" + vDR["PTP_NAME"].ToString() + "&nbsp;"
                          + "birth weight was " + "----------.";

                        Textarea3.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "did/did not reach all the major developmental milestones on time. The developmental " +
                        "milestones were reported as within the normal range for ------------" + "<br />" +
                        "a)	Physical development" + "<br />" +
                        "b)	Speech and language development" + "<br />" +
                        "c)	Cognitive development" + "<br />" +
                        "d)	Fine Motor development" + "<br />" +
                        "e)	Gross Motor Development." + "<br />" + "However, he/she has poor----------" + "<br />" + "a)	Physical development" + "<br />" + "b)	Speech and language development" + "<br />" +
                        "c)	Cognitive development" + "<br />" + "d)	Fine Motor development"
                          + "<br />" + "e)	Gross Motor Development.";

                        Textarea4.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "lives with his/her " + "&nbsp;" +
                        "parents/Institution." + "<br />" +
                        "He/she" + "&nbsp;" +
                        "has younger/older " + "&nbsp;" +
                        "sibling." + "&nbsp;" +
                        "As reported by the mother/father/caregiver" + "&nbsp;" +
                        "there is a /No " + "<br />" + "history of developmental problem within the immediate family....." + "<br />";
                    }

                            Hashtable vHashtable44 = new Hashtable();
                            vHashtable44.Add("AGRP_ID", TXTID2.Value);
                            DataRow vDR44 = RetDR(DBManager.Get(vHashtable44, "GET_RPT_ID"));
                            if (vDR44 != null)
                            {
                                TXTID.Value = vDR44["RPT_ID"].ToString();
                            }

                            Hashtable vHashtable1 = new Hashtable();
                            vHashtable1.Add("RPT_ID", TXTID.Value);
                            vHashtable1.Add("PTP_ID", vID);
                            DataTable dt = DBManager.Get(vHashtable1, "GET_RPT_ID_NEW");
                            DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_RPT_ID_NEW"));
                        if (vDR1 != null)
                        {
                        if (dt.Rows[0]["RPTD_EVAID"].ToString() != null)
                        {
                            Textarea1.InnerText = vDR1["RPTD_REPREASON"].ToString();
                            //Textarea2.InnerText = vDR1["RPTD_MED"].ToString();
                            //Textarea3.InnerText = vDR1["RPTD_PTMID"].ToString();
                            //Textarea4.InnerText = vDR1["RPTD_PTFHID"].ToString();
                            Textarea5.InnerText = vDR1["RPTD_DOBSID"].ToString();
                        }
                        //Hashtable vHashtable18 = new Hashtable();
                        //vHashtable18.Add("PTP_ID", vID);
                        //DataRow vDR18 = RetDR(DBManager.Get(vHashtable18, "GET_FMD"));
                        //if (vDR18 != null)
                        //{
                        //    Textarea2.InnerText = vDR18["PTM_DESC"].ToString();
                        //    Textarea3.InnerText = vDR18["PTDEV_DESC"].ToString();
                        //    Textarea4.InnerText = vDR18["PTFH_DESC"].ToString();
                        //}
                        Hashtable vHashtable4 = new Hashtable();
                        //vHashtable4.Add("PTR_ID", TXTVALUE.Value);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_PT_REPORT");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_PT_REPORT"));
                        if (dt1.Rows.Count > 0)
                        {
                            HiddenField10.Value = vDR3["PTR_ID"].ToString();
                            Textarea1.InnerText = vDR3["PTR_REPREASON"].ToString();
                            Textarea2.InnerText = vDR3["PTR_MED"].ToString();
                            Textarea11.InnerText = vDR3["PTR_DST"].ToString();
                            Textarea4.InnerText = vDR3["PTR_PTFHID"].ToString();
                            Textarea5.InnerText = vDR3["PTR_DOBSID"].ToString();
                            TXT_DOC_NAME.Text = vDR3["PTR_DOCTOR_NAME"].ToString();
                            TXT_DOC_DESIG.Text = vDR3["PTR_DESIGNATION"].ToString();
                            TXT_DOC_REG.Text = vDR3["PTR_REGISTRATION"].ToString();
                            //TXT_DISCLAIMER.Text = vDR3["PTR_DISCLAIMER"].ToString();
                            Textarea6.InnerText = vDR3["PTR_SYMPTOMS"].ToString();
                            GRADE_TXT.Text = vDR3["PTR_GRADE"].ToString();
                            // SAVEBTN.Visible = false;
                            PDFBTN.Visible = true;
                            //this.PDFBTN.Enabled = false;
                            Textarea2.InnerText = vDR3["PTR_MED"].ToString();
                            Textarea3.InnerText = vDR3["PTR_PTDEVID"].ToString();
                            Textarea4.InnerText = vDR3["PTR_PTFHID"].ToString();
                            ORG_TXT.Text = vDR3["PTR_ORGANIZATION_NAME"].ToString();
                            ADDRESS_TXT.Text = vDR3["PTR_ADDRESS"].ToString();
                            EMAIL_TXT.Text = vDR3["PTR_EMAIL"].ToString();
                            PHONE_TXT.Text = vDR3["PTR_PHONE_NUMBER"].ToString();
                            //Textarea17.InnerText = vDR3["PTR_RECOM"].ToString();
                            if (vDR3["PTR_DISCLAIMER"].ToString() == "1")
                            {
                                CheckBox1.Checked = true;
                                this.PDFBTN.Enabled = true;
                            }
                            else
                            {
                                CheckBox1.Checked = false;
                                this.PDFBTN.Enabled = false;
                            }
                        }
                        
                            //Hashtable vHashtable14 = new Hashtable();
                            //vHashtable14.Add("PTP_ID", vID);
                            //DataTable dt14 = DBManager.Get(vHashtable14, "GET_RECOMMENDATION_NEW");
                            //DataRow vDR14 = RetDR(DBManager.Get(vHashtable14, "GET_RECOMMENDATION_NEW"));
                            //if (dt14.Rows.Count > 0)
                            //{
                            //    foreach (DataRow dtRow in dt14.Rows)
                            //    {
                            //        // On all tables' columns
                            //        foreach (DataColumn dc in dt14.Columns)
                            //        {
                            //            Textarea17.InnerText += dtRow[dc].ToString();
                            //        }
                            //    }
                            //}
                    }
                    else
                    {
                        string message = "This Age Group Template Does Not Be Created!!";
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    }
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {

                    //Label2.Text = "<b>NerdNerdy</b> report template assists the organizations and therapists to develop and genertae customized reports for your Patients. Kindly follow the steps given below." +
                    //    "<br><b>Step 1- Basic Information</b>-In a given text box fill the basic information of your patient like <b>Medical, Developmental and Family history, Symptoms and Clinical observations</b> (Suggested template in text box is given for your reference, you may modify, add or delete text per your patient)</br>" +
                    //    "<br><b>Step 2- Test administered</b>-To Compile the scores of the tests in the report,Go to patient detail and click Test adminstered tab.</br>" +
                    //    "<br><b>Step 3- Recommendation</b>- Go to <b>Patient detail</b>…....click <b>Recommendations</b>….. Recommendations you have added and saved for your patient will be shown in your patients PDF report.</br>" +
                    //    "<br><b>Step 4- Save & Generate Report</b>-Please fill all the enteries given on the Report template page.  You can save report for your Patient. At this stage you can make changes in any section of the report and save it again. After you confirm the disclaimer, you can genertae the PDF report of your patient. The changes cannot be made after you have generated the PDF report.</br>";
                    
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTP_ID", vID);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                    if (vDR != null)
                    {
                        PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                        PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                        PTP_NAME_TXT.Text = vDR["PTP_NAME"].ToString();
                        HiddenField1.Value = vID;
                        HiddenField2.Value = vID;
                        HiddenField3.Value = vID;
                        HiddenField4.Value = vID;
                        HiddenField5.Value = vID;
                        HiddenField6.Value = vID;
                        HiddenField7.Value = vID;
                        HiddenField8.Value = vID;
                        HiddenField9.Value = vID;
                        TXTID2.Value = vDR["AGRP_ID"].ToString();
                        PTP_AGE_TXT.Enabled = false;
                        PTP_GENDER_TXT.Enabled = false;
                        PTP_NAME_TXT.Enabled = false;
                        TXT_DOC_NAME.Text = vDR["CUST_NAME"].ToString();
                        TXT_DOC_DESIG.Text = vDR["CUST_DESIGNATION"].ToString();
                        PDFBTN.Visible = false;

                        Textarea2.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "mother was " +
                        "------------ " + "years old and father- was " + "------------- " + "years old at the time of the birth of" + "&nbsp;" +
                        vDR["PTP_NAME"].ToString() + "&nbsp;" + "There were" + "&nbsp;" + "complications / no complications" + "&nbsp;" +
                        "during pregnancy reported by the mother and" + "&nbsp;" + "he / she" + "&nbsp;" + "was born with no apparent  medical complications/ issues like " +
                        "------------------------------------" + vDR["PTP_NAME"].ToString() + "&nbsp;" +
                        "was full term / pre-term" + "and was born through C-section / normal delivery." +
                        "The mother" + "&nbsp;" + "----------" + "did not face complications/ faced complications during delivery." +
                        "------------------------------------" + vDR["PTP_NAME"].ToString() + "&nbsp;"
                          + "birth weight was " + "----------.";

                        Textarea3.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "did/did not reach all the major developmental milestones on time. The developmental " +
                        "milestones were reported as within the normal range for ------------" + "<br />" +
                        "a)	Physical development" + "<br />" +
                        "b)	Speech and language development" + "<br />" +
                        "c)	Cognitive development" + "<br />" +
                        "d)	Fine Motor development" + "<br />" +
                        "e)	Gross Motor Development." + "<br />" + "However, he/she has poor----------" + "<br />" + "a)	Physical development" + "<br />" + "b)	Speech and language development" + "<br />" +
                        "c)	Cognitive development" + "<br />" + "d)	Fine Motor development"
                          + "<br />" + "e)	Gross Motor Development.";

                        Textarea4.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "lives with his/her " + "&nbsp;" +
                        "parents/Institution." + "<br />" +
                        "He/she" + "&nbsp;" +
                        "has younger/older " + "&nbsp;" +
                        "sibling." + "&nbsp;" +
                        "As reported by the mother/father/caregiver" + "&nbsp;" +
                        "there is a /No " + "<br />" + "history of developmental problem within the immediate family....." + "<br />";
                    }

                    Hashtable vHashtable44 = new Hashtable();
                    vHashtable44.Add("AGRP_ID", TXTID2.Value);
                    DataRow vDR44 = RetDR(DBManager.Get(vHashtable44, "GET_RPT_ID"));
                    if (vDR44 != null)
                    {
                        TXTID.Value = vDR44["RPT_ID"].ToString();
                    }

                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("RPT_ID", TXTID.Value);
                    vHashtable1.Add("PTP_ID", vID);
                    DataTable dt = DBManager.Get(vHashtable1, "GET_RPT_ID_NEW");
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_RPT_ID_NEW"));
                    if (vDR1 != null)
                    {
                        if (dt.Rows[0]["RPTD_EVAID"].ToString() != null)
                        {
                            Textarea1.InnerText = vDR1["RPTD_REPREASON"].ToString();
                            //Textarea2.InnerText = vDR1["RPTD_MED"].ToString();
                            //Textarea3.InnerText = vDR1["RPTD_PTMID"].ToString();
                            //Textarea4.InnerText = vDR1["RPTD_PTFHID"].ToString();
                            Textarea5.InnerText = vDR1["RPTD_DOBSID"].ToString();
                        }
                        //Hashtable vHashtable18 = new Hashtable();
                        //vHashtable18.Add("PTP_ID", vID);
                        //DataRow vDR18 = RetDR(DBManager.Get(vHashtable18, "GET_FMD"));
                        //if (vDR18 != null)
                        //{
                        //    Textarea2.InnerText = vDR18["PTM_DESC"].ToString();
                        //    Textarea3.InnerText = vDR18["PTDEV_DESC"].ToString();
                        //    Textarea4.InnerText = vDR18["PTFH_DESC"].ToString();
                        //}
                        Hashtable vHashtable4 = new Hashtable();
                       // vHashtable4.Add("PTR_ID", TXTVALUE.Value);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_PT_REPORT");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_PT_REPORT"));
                        if (dt1.Rows.Count > 0)
                        {
                            HiddenField10.Value = vDR3["PTR_ID"].ToString();
                            Textarea1.InnerText = vDR3["PTR_REPREASON"].ToString();
                            Textarea2.InnerText = vDR3["PTR_MED"].ToString();
                            Textarea11.InnerText = vDR3["PTR_DST"].ToString();
                            Textarea4.InnerText = vDR3["PTR_PTFHID"].ToString();
                            Textarea5.InnerText = vDR3["PTR_DOBSID"].ToString();
                            TXT_DOC_NAME.Text = vDR3["PTR_DOCTOR_NAME"].ToString();
                            TXT_DOC_DESIG.Text = vDR3["PTR_DESIGNATION"].ToString();
                            TXT_DOC_REG.Text = vDR3["PTR_REGISTRATION"].ToString();
                            //TXT_DISCLAIMER.Text = vDR3["PTR_DISCLAIMER"].ToString();
                            Textarea6.InnerText = vDR3["PTR_SYMPTOMS"].ToString();
                            GRADE_TXT.Text = vDR3["PTR_GRADE"].ToString();
                            // SAVEBTN.Visible = false;
                            PDFBTN.Visible = true;
                            //this.PDFBTN.Enabled = false;
                            Textarea2.InnerText = vDR3["PTR_MED"].ToString();
                            Textarea3.InnerText = vDR3["PTR_PTDEVID"].ToString();
                            Textarea4.InnerText = vDR3["PTR_PTFHID"].ToString();
                            ORG_TXT.Text = vDR3["PTR_ORGANIZATION_NAME"].ToString();
                            ADDRESS_TXT.Text = vDR3["PTR_ADDRESS"].ToString();
                            EMAIL_TXT.Text = vDR3["PTR_EMAIL"].ToString();
                            PHONE_TXT.Text = vDR3["PTR_PHONE_NUMBER"].ToString();
                            if (vDR3["PTR_DISCLAIMER"].ToString() == "1")
                            {
                                CheckBox1.Checked = true;
                                this.PDFBTN.Enabled = true;
                            }
                            else
                            {
                                CheckBox1.Checked = false;
                                this.PDFBTN.Enabled = false;
                            }
                        }

                        //Hashtable vHashtable14 = new Hashtable();
                        //vHashtable14.Add("PTP_ID", vID);
                        //DataTable dt14 = DBManager.Get(vHashtable14, "GET_RECOMMENDATION_NEW");
                        //DataRow vDR14 = RetDR(DBManager.Get(vHashtable14, "GET_RECOMMENDATION_NEW"));
                        //if (dt14.Rows.Count > 0)
                        //{
                        //    foreach (DataRow dtRow in dt14.Rows)
                        //    {
                        //        // On all tables' columns
                        //        foreach (DataColumn dc in dt14.Columns)
                        //        {
                        //            Textarea17.InnerText += dtRow[dc].ToString();
                        //        }
                        //    }
                        //}
                        // }
                        //else
                        //{
                        //    string message = "Please Fill Recommendation First!!";
                        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        //    sb.Append("<script type = 'text/javascript'>");
                        //    sb.Append("window.onload=function(){");
                        //    sb.Append("alert('");
                        //    sb.Append(message);
                        //    sb.Append("')};");
                        //    sb.Append("</script>");
                        //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                        //   // SAVEBTN.Visible = false;
                        //    PDFBTN.Visible = false;
                        //}
                    }
                    else
                    {
                        string message = "This Age Group Template Does Not Be Created!!";
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {

                    //Label2.Text = "<b>NerdNerdy</b> report template assists the organizations and therapists to develop and genertae customized reports for your Patients. Kindly follow the steps given below." +
                    //    "<br><b>Step 1- Basic Information</b>-In a given text box fill the basic information of your patient like <b>Medical, Developmental and Family history, Symptoms and Clinical observations</b> (Suggested template in text box is given for your reference, you may modify, add or delete text per your patient)</br>" +
                    //    "<br><b>Step 2- Test administered</b>-To Compile the scores of the tests in the report,Go to patient detail and click Test adminstered tab.</br>" +
                    //    "<br><b>Step 3- Recommendation</b>- Go to <b>Patient detail</b>…....click <b>Recommendations</b>….. Recommendations you have added and saved for your patient will be shown in your patients PDF report.</br>" +
                    //    "<br><b>Step 4- Save & Generate Report</b>-Please fill all the enteries given on the Report template page.  You can save report for your Patient. At this stage you can make changes in any section of the report and save it again. After you confirm the disclaimer, you can genertae the PDF report of your patient. The changes cannot be made after you have generated the PDF report.</br>";
                    
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTP_ID", vID);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                    if (vDR != null)
                    {
                        PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                        PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                        PTP_NAME_TXT.Text = vDR["PTP_NAME"].ToString();
                        HiddenField1.Value = vID;
                        HiddenField2.Value = vID;
                        HiddenField3.Value = vID;
                        HiddenField4.Value = vID;
                        HiddenField5.Value = vID;
                        HiddenField6.Value = vID;
                        HiddenField7.Value = vID;
                        HiddenField8.Value = vID;
                        HiddenField9.Value = vID;
                        TXTID2.Value = vDR["AGRP_ID"].ToString();
                        PTP_AGE_TXT.Enabled = false;
                        PTP_GENDER_TXT.Enabled = false;
                        PTP_NAME_TXT.Enabled = false;
                        TXT_DOC_NAME.Text = vDR["CUST_NAME"].ToString();
                        TXT_DOC_DESIG.Text = vDR["CUST_DESIGNATION"].ToString();
                        PDFBTN.Visible = false;

                        Textarea2.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "mother was " +
                        "------------ " + "years old and father- was " + "------------- " + "years old at the time of the birth of" + "&nbsp;" +
                        vDR["PTP_NAME"].ToString() + "&nbsp;" + "There were" + "&nbsp;" + "complications / no complications" + "&nbsp;" +
                        "during pregnancy reported by the mother and" + "&nbsp;" + "he / she" + "&nbsp;" + "was born with no apparent  medical complications/ issues like " +
                        "------------------------------------" + vDR["PTP_NAME"].ToString() + "&nbsp;" +
                        "was full term / pre-term" + "and was born through C-section / normal delivery." +
                        "The mother" + "&nbsp;" + "----------" + "did not face complications/ faced complications during delivery." +
                        "------------------------------------" + vDR["PTP_NAME"].ToString() + "&nbsp;"
                          + "birth weight was " + "----------.";

                        Textarea3.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "did/did not reach all the major developmental milestones on time. The developmental " +
                        "milestones were reported as within the normal range for ------------" + "<br />" +
                        "a)	Physical development" + "<br />" +
                        "b)	Speech and language development" + "<br />" +
                        "c)	Cognitive development" + "<br />" +
                        "d)	Fine Motor development" + "<br />" +
                        "e)	Gross Motor Development." + "<br />" + "However, he/she has poor----------" + "<br />" + "a)	Physical development" + "<br />" + "b)	Speech and language development" + "<br />" +
                        "c)	Cognitive development" + "<br />" + "d)	Fine Motor development"
                          + "<br />" + "e)	Gross Motor Development.";

                        Textarea4.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "lives with his/her " + "&nbsp;" +
                        "parents/Institution." + "<br />" +
                        "He/she" + "&nbsp;" +
                        "has younger/older " + "&nbsp;" +
                        "sibling." + "&nbsp;" +
                        "As reported by the mother/father/caregiver" + "&nbsp;" +
                        "there is a /No " + "<br />" + "history of developmental problem within the immediate family....." + "<br />";
                    }

                    Hashtable vHashtable44 = new Hashtable();
                    vHashtable44.Add("AGRP_ID", TXTID2.Value);
                    DataRow vDR44 = RetDR(DBManager.Get(vHashtable44, "GET_RPT_ID"));
                    if (vDR44 != null)
                    {
                        TXTID.Value = vDR44["RPT_ID"].ToString();
                    }

                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("RPT_ID", TXTID.Value);
                    vHashtable1.Add("PTP_ID", vID);
                    DataTable dt = DBManager.Get(vHashtable1, "GET_RPT_ID_NEW");
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_RPT_ID_NEW"));
                    if (vDR1 != null)
                    {
                        if (dt.Rows[0]["RPTD_EVAID"].ToString() != null)
                        {
                            Textarea1.InnerText = vDR1["RPTD_REPREASON"].ToString();
                            //Textarea2.InnerText = vDR1["RPTD_MED"].ToString();
                            //Textarea3.InnerText = vDR1["RPTD_PTMID"].ToString();
                            //Textarea4.InnerText = vDR1["RPTD_PTFHID"].ToString();
                            Textarea5.InnerText = vDR1["RPTD_DOBSID"].ToString();
                        }
                        //Hashtable vHashtable18 = new Hashtable();
                        //vHashtable18.Add("PTP_ID", vID);
                        //DataRow vDR18 = RetDR(DBManager.Get(vHashtable18, "GET_FMD"));
                        //if (vDR18 != null)
                        //{
                        //    Textarea2.InnerText = vDR18["PTM_DESC"].ToString();
                        //    Textarea3.InnerText = vDR18["PTDEV_DESC"].ToString();
                        //    Textarea4.InnerText = vDR18["PTFH_DESC"].ToString();
                        //}
                        Hashtable vHashtable4 = new Hashtable();
                        // vHashtable4.Add("PTR_ID", TXTVALUE.Value);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_PT_REPORT");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_PT_REPORT"));
                        if (dt1.Rows.Count > 0)
                        {
                            HiddenField10.Value = vDR3["PTR_ID"].ToString();
                            Textarea1.InnerText = vDR3["PTR_REPREASON"].ToString();
                            Textarea2.InnerText = vDR3["PTR_MED"].ToString();
                            Textarea11.InnerText = vDR3["PTR_DST"].ToString();
                            Textarea4.InnerText = vDR3["PTR_PTFHID"].ToString();
                            Textarea5.InnerText = vDR3["PTR_DOBSID"].ToString();
                            TXT_DOC_NAME.Text = vDR3["PTR_DOCTOR_NAME"].ToString();
                            TXT_DOC_DESIG.Text = vDR3["PTR_DESIGNATION"].ToString();
                            TXT_DOC_REG.Text = vDR3["PTR_REGISTRATION"].ToString();
                            //TXT_DISCLAIMER.Text = vDR3["PTR_DISCLAIMER"].ToString();
                            Textarea6.InnerText = vDR3["PTR_SYMPTOMS"].ToString();
                            GRADE_TXT.Text = vDR3["PTR_GRADE"].ToString();
                            // SAVEBTN.Visible = false;
                            PDFBTN.Visible = true;
                            //this.PDFBTN.Enabled = false;
                            Textarea2.InnerText = vDR3["PTR_MED"].ToString();
                            Textarea3.InnerText = vDR3["PTR_PTDEVID"].ToString();
                            Textarea4.InnerText = vDR3["PTR_PTFHID"].ToString();
                            ORG_TXT.Text = vDR3["PTR_ORGANIZATION_NAME"].ToString();
                            ADDRESS_TXT.Text = vDR3["PTR_ADDRESS"].ToString();
                            EMAIL_TXT.Text = vDR3["PTR_EMAIL"].ToString();
                            PHONE_TXT.Text = vDR3["PTR_PHONE_NUMBER"].ToString();
                            if (vDR3["PTR_DISCLAIMER"].ToString() == "1")
                            {
                                CheckBox1.Checked = true;
                                this.PDFBTN.Enabled = true;
                            }
                            else
                            {
                                CheckBox1.Checked = false;
                                this.PDFBTN.Enabled = false;
                            }
                        }

                        //Hashtable vHashtable14 = new Hashtable();
                        //vHashtable14.Add("PTP_ID", vID);
                        //DataTable dt14 = DBManager.Get(vHashtable14, "GET_RECOMMENDATION_NEW");
                        //DataRow vDR14 = RetDR(DBManager.Get(vHashtable14, "GET_RECOMMENDATION_NEW"));
                        //if (dt14.Rows.Count > 0)
                        //{
                        //    foreach (DataRow dtRow in dt14.Rows)
                        //    {
                        //        // On all tables' columns
                        //        foreach (DataColumn dc in dt14.Columns)
                        //        {
                        //            Textarea17.InnerText += dtRow[dc].ToString();
                        //        }
                        //    }
                        //}
                        // }
                        //else
                        //{
                        //    string message = "Please Fill Recommendation First!!";
                        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        //    sb.Append("<script type = 'text/javascript'>");
                        //    sb.Append("window.onload=function(){");
                        //    sb.Append("alert('");
                        //    sb.Append(message);
                        //    sb.Append("')};");
                        //    sb.Append("</script>");
                        //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                        //   // SAVEBTN.Visible = false;
                        //    PDFBTN.Visible = false;
                        //}
                    }
                    else
                    {
                        string message = "This Age Group Template Does Not Be Created!!";
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    }
                }
            }
            catch (Exception xe)
            {
                //ShowMsg(xe);
            }
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;

        SetButton(checkBox.Checked);
    }

    private void SetButton(bool enabled)
    {
        if (enabled)
        {
            this.PDFBTN.Enabled = true;
            PDFBTN.Visible = true;
        }
        else
        {
            this.PDFBTN.Enabled = false;
            PDFBTN.Visible = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String vID = Request.QueryString["ID"];

            try
            {
                if (HiddenField10.Value != "0")
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTR_ID", HiddenField10.Value);
                    vHashtable.Add("PTR_PTPID", vID);
                    vHashtable.Add("PTR_REPREASON", Textarea1.InnerText);
                    vHashtable.Add("PTR_EVAID", "");
                    vHashtable.Add("PTR_MED", Textarea2.InnerText);
                    vHashtable.Add("PTR_PTMID", "");
                    vHashtable.Add("PTR_PTFHID", Textarea4.InnerText);
                    vHashtable.Add("PTR_DOBSID", Textarea5.InnerText);
                    vHashtable.Add("PTR_PTDEVID", Textarea3.InnerText);
                    vHashtable.Add("PTR_DST", Textarea11.InnerText);
                    vHashtable.Add("PTR_AGRPID", TXTID2.Value);
                    vHashtable.Add("PTR_RECOM", "");
                    vHashtable.Add("TYPE", "UPD");
                    vHashtable.Add("PTR_DOCTOR_NAME", TXT_DOC_NAME.Text);
                    vHashtable.Add("PTR_DESIGNATION", TXT_DOC_DESIG.Text);
                    vHashtable.Add("PTR_REGISTRATION", TXT_DOC_REG.Text);
                    vHashtable.Add("PTR_DISCLAIMER", "1");
                    vHashtable.Add("PTR_SYMPTOMS", Textarea6.InnerText);
                    vHashtable.Add("PTR_GRADE", GRADE_TXT.Text);
                    vHashtable.Add("PTR_ORGANIZATION_NAME", ORG_TXT.Text);
                    vHashtable.Add("PTR_ADDRESS", ADDRESS_TXT.Text);
                    vHashtable.Add("PTR_EMAIL", EMAIL_TXT.Text);
                    vHashtable.Add("PTR_PHONE_NUMBER", PHONE_TXT.Text);
                    DBManager.ExecInsUps(vHashtable, "INS_PT_REPORT", (ATSession)Session["User"]);
                    Response.Redirect("Patient.aspx");
                }
                else
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTR_ID", HiddenField10.Value);
                    vHashtable.Add("PTR_PTPID", vID);
                    vHashtable.Add("PTR_REPREASON", Textarea1.InnerText);
                    vHashtable.Add("PTR_EVAID", "");
                    vHashtable.Add("PTR_MED", Textarea2.InnerText);
                    vHashtable.Add("PTR_PTMID", "");
                    vHashtable.Add("PTR_PTFHID", Textarea4.InnerText);
                    vHashtable.Add("PTR_DOBSID", Textarea5.InnerText);
                    vHashtable.Add("PTR_PTDEVID", Textarea3.InnerText);
                    vHashtable.Add("PTR_DST", Textarea11.InnerText);
                    vHashtable.Add("PTR_AGRPID", TXTID2.Value);
                    vHashtable.Add("PTR_RECOM", "");
                    vHashtable.Add("TYPE", "INS");
                    vHashtable.Add("PTR_DOCTOR_NAME", TXT_DOC_NAME.Text);
                    vHashtable.Add("PTR_DESIGNATION", TXT_DOC_DESIG.Text);
                    vHashtable.Add("PTR_REGISTRATION", TXT_DOC_REG.Text);
                    vHashtable.Add("PTR_DISCLAIMER", "1");
                    vHashtable.Add("PTR_SYMPTOMS", Textarea6.InnerText);
                    vHashtable.Add("PTR_GRADE", GRADE_TXT.Text);
                    vHashtable.Add("PTR_ORGANIZATION_NAME", ORG_TXT.Text);
                    vHashtable.Add("PTR_ADDRESS", ADDRESS_TXT.Text);
                    vHashtable.Add("PTR_EMAIL", EMAIL_TXT.Text);
                    vHashtable.Add("PTR_PHONE_NUMBER", PHONE_TXT.Text);
                    DBManager.ExecInsUps(vHashtable, "INS_PT_REPORT", (ATSession)Session["User"]);
                    Response.Redirect("Patient.aspx");
                }
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }

        }
    }

    protected void DDLPATIENT_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", vID);
        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
        if (vDR != null)
        {
            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
            PTP_AGE_TXT.Enabled = false;
            PTP_GENDER_TXT.Enabled = false;
        }

    }

    protected void btnPdf_Click(object sender, EventArgs e)
    {
        Headingbold = new Font(Font.HELVETICA, 12f, Font.BOLD);
        HeadingFontbold = new Font(Font.HELVETICA, 8f, Font.BOLD);
        NormalFont = new Font(Font.HELVETICA, 7f, Font.NORMAL);
       // document = new Document(PageSize.A4.Rotate(), 5, 5, 10, 10);
        document = new Document(PageSize.A4, 5, 5, 10, 10); /*vertical*/
        string Filename = "Patient_Report" + DateTime.Now.Date.ToString("dd_MM_yyyy") + ".pdf";
        try
        {
            pdfw = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            PdfPTable BaseTable = new PdfPTable(5);
            BaseTable.TotalWidth = 520f; /*vertical*/
            BaseTable.LockedWidth = true;
            BaseTable.HorizontalAlignment = 100;

            String vID = Request.QueryString["ID"];

            Hashtable vHashTable55 = new Hashtable();
            vHashTable55.Add("PTR_PTPID", vID);
            DataRow vdr55 = RetDR(DBManager.Get(vHashTable55, "GET_REPORT_ID"));
            PdfPCell HeaderRow = new PdfPCell(new Phrase(vdr55["PTR_ORGANIZATION_NAME"].ToString(), Headingbold));
            HeaderRow.Colspan = 13;
            HeaderRow.FixedHeight = 18f;
            HeaderRow.NoWrap = false;
            HeaderRow.Border = 0;
            HeaderRow.HorizontalAlignment = 1;
            HeaderRow.PaddingBottom = 4f;
            HeaderRow.PaddingTop = 2f;
            BaseTable.AddCell(HeaderRow);
            PdfPTable customertable11 = new PdfPTable(1);
            PdfPTable customertable12 = new PdfPTable(1);
            PdfPCell StationCol1 = new PdfPCell(new Phrase(vdr55["PTR_ADDRESS"].ToString(), HeadingFontbold));
            //PdfPCell StationCol2 = new PdfPCell(new Phrase(".......................................................", HeadingFontbold));
            //StationCol2.FixedHeight = 18f;
            StationCol1.NoWrap = false;
            //StationCol2.NoWrap = false;
            StationCol1.Border = 0;
            //StationCol2.Border = 0;
            StationCol1.HorizontalAlignment = 1;
            //StationCol2.HorizontalAlignment = 1;
            customertable12.AddCell(StationCol1);
            //customertable12.AddCell(StationCol2);
            PdfPCell cust_table1 = new PdfPCell(customertable12);
            cust_table1.Colspan = 13;
            cust_table1.Border = 0;
            BaseTable.AddCell(cust_table1);

            PdfPCell HeaderRownew = new PdfPCell(new Phrase("PATIENT REPORT FROM:", HeadingFontbold));

            Hashtable vHashTable = new Hashtable();
            vHashTable.Add("PTP_ID", vID);
            DataRow vdr = RetDR(DBManager.Get(vHashTable, "GETPTP_PROFILE"));   /*18-09-2018*/

            if (vdr != null)
            {
                PdfPCell patient = new PdfPCell(new Phrase("Patient Name :" + " " + vdr["PTP_NAME"].ToString()));
                patient.Colspan = 2;
                patient.NoWrap = false;
                patient.Border = 0;
                patient.HorizontalAlignment = 3;
                patient.PaddingBottom = 4f;
                patient.PaddingTop = 2f;
                BaseTable.AddCell(patient);

                PdfPCell PTP_GENDER_TXT = new PdfPCell(new Phrase(" " + " " + " " + " " +
                    " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +
                    " " + " " + "Gender " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " : " + vdr["PTP_GENDER"].ToString()));
                PTP_GENDER_TXT.Colspan = 4;
                PTP_GENDER_TXT.NoWrap = false;
                PTP_GENDER_TXT.Border = 0;
                PTP_GENDER_TXT.HorizontalAlignment = 3;
                PTP_GENDER_TXT.PaddingBottom = 4f;
                PTP_GENDER_TXT.PaddingTop = 2f;
                BaseTable.AddCell(PTP_GENDER_TXT);

                PdfPCell DDLAGE2 = new PdfPCell(new Phrase("D.O.B "  + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " : " + vdr["DOB"].ToString()));
                DDLAGE2.Colspan = 2;
                DDLAGE2.NoWrap = false;
                DDLAGE2.Border = 0;
                DDLAGE2.HorizontalAlignment = 3;
                DDLAGE2.PaddingBottom = 4f;
                DDLAGE2.PaddingTop = 2f;
                BaseTable.AddCell(DDLAGE2);

                PdfPCell EVALUATION = new PdfPCell(new Phrase(" " + " " + " " + " " + " " + " " + " " + " " +
                    " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + "Grade " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                     + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " : " + vdr55["PTR_GRADE"].ToString() + "\n" + "\n" + "\n" + "\n"+ "\n"));
                EVALUATION.Colspan = 4;
                EVALUATION.NoWrap = false;
                EVALUATION.Border = 0;
                EVALUATION.HorizontalAlignment = 3;
                EVALUATION.PaddingBottom = 4f;
                EVALUATION.PaddingTop = 2f;
                BaseTable.AddCell(EVALUATION);

                PdfPCell ClinicalReport = new PdfPCell(new Phrase(" " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +
                    " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +
                    " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + "CLINICAL EVALUATION REPORT" + " " + "\n" + "\n", Headingbold));
                ClinicalReport.Colspan = 15;
                ClinicalReport.NoWrap = false;
                ClinicalReport.Border = 0;
                ClinicalReport.HorizontalAlignment = 3;
                BaseTable.AddCell(ClinicalReport);

                Hashtable vHashTable14 = new Hashtable();
                vHashTable14.Add("PTP_ID", vID);
                DataRow vdr4 = RetDR(DBManager.Get(vHashTable14, "GET_REPORT"));

                PdfPCell DDLAGE1 = new PdfPCell(new Phrase("\n" + "Reason For Referral :" + " " + vdr4["PTR_REPREASON"] + "\n"));
                DDLAGE1.Colspan = 5;
                DDLAGE1.NoWrap = false;
                DDLAGE1.Border = 0;
                DDLAGE1.HorizontalAlignment = 3;
                BaseTable.AddCell(DDLAGE1);

                PdfPCell Medical = new PdfPCell(new Phrase("Medical History :" + " " + vdr4["PTM_DESC"] + "\n"));
                Medical.Colspan = 15;
                Medical.NoWrap = false;
                Medical.Border = 0;
                Medical.HorizontalAlignment = 3;
                BaseTable.AddCell(Medical);

                PdfPCell Developmental = new PdfPCell(new Phrase("Developmental History :" + " " + vdr4["PTDEV_DESC"] + "\n"));
                Developmental.Colspan = 15;
                Developmental.NoWrap = false;
                Developmental.Border = 0;
                Developmental.HorizontalAlignment = 3;
                BaseTable.AddCell(Developmental);

                PdfPCell Family = new PdfPCell(new Phrase("Family History :" + " " + vdr4["PTFH_DESC"] + "\n"));
                Family.Colspan = 15;
                Family.NoWrap = false;
                Family.Border = 0;
                Family.HorizontalAlignment = 3;
                BaseTable.AddCell(Family);

                PdfPCell Narrated = new PdfPCell(new Phrase("Symptoms Narrated :" + vdr4["PTR_SYMPTOMS"] + "\n"));
                Narrated.Colspan = 15;
                Narrated.NoWrap = false;
                Narrated.Border = 0;
                Narrated.HorizontalAlignment = 3;
                BaseTable.AddCell(Narrated);

                PdfPCell Observation = new PdfPCell(new Phrase("Clinical Observation :" + " " + vdr4["DOBS_DESC"] + "\n"));
                Observation.Colspan = 15;
                Observation.NoWrap = false;
                Observation.Border = 0;
                Observation.HorizontalAlignment = 3;
                BaseTable.AddCell(Observation);

                Hashtable vHashTable3 = new Hashtable();
                vHashTable3.Add("PTC_PTPID", vID);
                DataTable DT = DBManager.Get(vHashTable3, "GETPTP_CAR_NEW");

                if (DT.Rows.Count > 0)
                {
                    PdfPCell Test = new PdfPCell(new Phrase("Test Administered :" + " " + "\n" + "\n"));
                    Test.Colspan = 15;
                    Test.NoWrap = false;
                    Test.Border = 0;
                    Test.HorizontalAlignment = 3;
                    BaseTable.AddCell(Test);

                    PdfPCell Category = new PdfPCell(new Phrase("CARS-2 Rating :" + " " + "\n" + "\n", Headingbold));
                    Category.Colspan = 5;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    PdfPCell Category1 = new PdfPCell(new Phrase("Childhood Autism Rating Scale-2 (CARS-2) is used as a screening tool to identify children with autism and help identify possible signs of autism (or autism spectrum disorder). The CARS-2 ratings are comprised of behavioural observations and parental reports.  Scores as per our observation are as follows:" + " " + "\n" + "\n"));
                    Category1.Colspan = 5;
                    Category1.NoWrap = false;
                    Category1.Border = 0;
                    Category1.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category1);

                    BaseTable.WidthPercentage = 100;
                    PdfPCell cell = new PdfPCell(new Phrase("Cars Rating" , Headingbold));

                    cell.Colspan = DT.Columns.Count;
                    foreach (DataColumn c in DT.Columns)
                    {
                        cell = new PdfPCell(new Phrase(c.ColumnName, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                        cell.Colspan = 2;
                        BaseTable.AddCell(cell);
                    }
                    foreach (DataRow r in DT.Rows)
                    {
                        if (DT.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[0].ToString()));
                            cell.Colspan = 2;
                            BaseTable.AddCell(cell);
                            cell = new PdfPCell(new Phrase(r[1].ToString()));
                            cell.Colspan = 2;
                            BaseTable.AddCell(cell);
                            BaseTable.AddCell(new Phrase(r[2].ToString()));
                        }
                    }
                }
              
                Hashtable vHashTable33 = new Hashtable();
                vHashTable33.Add("PTP_ID", vID);
                DataRow vdr33 = RetDR(DBManager.Get(vHashTable33, "GET_PT_DEVELOPMENTAL_SCREENING"));

                if (vdr33 != null)
                {
                    PdfPCell Screening = new PdfPCell(new Phrase("\n" + "\n" + "Developmental Screening Test:" + "\n" + "\n" + "The Developmental Screening Test is designed for the purpose of measuring mental development of children from birth to 15 years of age." +
                                        "The test starts from the ‘Basal Age’ where all characteristics at a particular age are passed and gradually moving through upper age levels." +
                                        "It assesses behavioural characteristics of respective age levels." +
                                        "At each age level, items are drawn from behavioural areas like motor development, speech, language and personal social development." + "\n" + "\n"));
                    Screening.Colspan = 15;
                    Screening.NoWrap = false;
                    Screening.Border = 0;
                    Screening.HorizontalAlignment = 3;
                    BaseTable.AddCell(Screening);

                    PdfPCell Development = new PdfPCell(new Phrase("\n" + "Developmental Age :" + " " + vdr33["PTDEVS_AGE"] + "\n"));
                    Development.Colspan = 15;
                    Development.NoWrap = false;
                    Development.Border = 0;
                    Development.HorizontalAlignment = 3;
                    BaseTable.AddCell(Development);

                    PdfPCell Development1 = new PdfPCell(new Phrase("\n" + "Choronological Age :" + " " + vdr33["PTDEVS_CHRONOLOGICAL_AGE"] + "\n"));
                    Development1.Colspan = 15;
                    Development1.NoWrap = false;
                    Development1.Border = 0;
                    Development1.HorizontalAlignment = 3;
                    BaseTable.AddCell(Development1);

                    PdfPCell Development11 = new PdfPCell(new Phrase("\n" + "Developmental Quotient =" + " Developmental Age/Choronological Age = " + " " + vdr33["PTDEVS_QUOTIENT"] + "\n"));
                    Development11.Colspan = 15;
                    Development11.NoWrap = false;
                    Development11.Border = 0;
                    Development11.HorizontalAlignment = 3;
                    BaseTable.AddCell(Development11);

                    PdfPCell DevelopmentalN = new PdfPCell(new Phrase("\n" + "Please Note:" + " " + "Children with deficit in language & Communication may show overall lower scores than actual." + "\n"));
                    DevelopmentalN.Colspan = 15;
                    DevelopmentalN.NoWrap = false;
                    DevelopmentalN.Border = 0;
                    DevelopmentalN.HorizontalAlignment = 3;
                    BaseTable.AddCell(DevelopmentalN);
                }

                Hashtable vHashTable13 = new Hashtable();
                vHashTable13.Add("PTDS_PTPID", vID);
                DataTable DT13 = DBManager.Get(vHashTable13, "GET_DOWN_SYNDROME");
                if (DT13.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase("\n" + "Down Syndrome Rating :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    PdfPCell cell = new PdfPCell(new Phrase("Down Syndrome Rating", Headingbold));

                    cell.Colspan = DT13.Columns.Count;

                    foreach (DataRow r in DT13.Rows)
                    {
                        if (DT13.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable31 = new Hashtable();
                    vHashTable31.Add("PTDS_PTPID", vID);
                    DataRow vdr13 = RetDR(DBManager.Get(vHashTable31, "GET_DOWN_SYNDROME_REMARK"));
                    if (vdr13 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Down Syndrome Rating Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr13["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }

                Hashtable vHashTable03 = new Hashtable();
                vHashTable03.Add("PTADHD_PTPID", vID);
                DataTable DT03 = DBManager.Get(vHashTable03, "GETPTP_PT_ADHD");
                if (DT03.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase("\n" + "Attention Defecit Hyperactive Disorder :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Attention Defecit Hyperactive Disorder", Headingbold));

                    cell.Colspan = DT03.Columns.Count;

                    foreach (DataRow r in DT03.Rows)
                    {
                        if (DT03.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable32 = new Hashtable();
                    vHashTable32.Add("PTADHD_PTPID", vID);
                    DataRow vdr32 = RetDR(DBManager.Get(vHashTable32, "GET_PT_ADHD_REMARK"));
                    if (vdr32 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Attention Defecit Hyperactive Disorder Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr32["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }


                Hashtable vHashTable04 = new Hashtable();
                vHashTable04.Add("PTCP_PTPID", vID);
                DataTable DT04 = DBManager.Get(vHashTable04, "GETPTP_PT_CEREBAL_PALSY");
                if (DT04.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase( "\n" + "Cerebral Palsy Rating :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Cerebral Palsy Rating", Headingbold));

                    cell.Colspan = DT04.Columns.Count;

                    foreach (DataRow r in DT04.Rows)
                    {
                        if (DT04.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable34 = new Hashtable();
                    vHashTable34.Add("PTCP_PTPID", vID);
                    DataRow vdr34 = RetDR(DBManager.Get(vHashTable34, "GET_PT_CEREBAL_PALSY_REMARK"));
                    if (vdr34 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Cerebral Palsy Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr34["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }

                Hashtable vHashTable24 = new Hashtable();
                vHashTable24.Add("PTDEV_PTPID", vID);
                DataTable DT24 = DBManager.Get(vHashTable24, "GETPTP_PT_DEVELOPMENTAL");
                if (DT24.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase( "\n" + "Developmental Coordination Rating Scale :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Developmental Coordination Rating Scale", Headingbold));

                    cell.Colspan = DT24.Columns.Count;

                    foreach (DataRow r in DT24.Rows)
                    {
                        if (DT24.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable35 = new Hashtable();
                    vHashTable35.Add("PTDEV_PTPID", vID);
                    DataRow vdr35 = RetDR(DBManager.Get(vHashTable35, "GET_PT_DEVELOPMENTAL_REMARK"));
                    if (vdr35 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Developmental Coordination Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr35["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }

                Hashtable vHashTable8 = new Hashtable();
                vHashTable8.Add("PTFRA_PTPID", vID);
                DataTable DT8 = DBManager.Get(vHashTable8, "GETPTP_PT_FRAGILE");
                if (DT8.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase( "\n" + "Fragile-X Syndrome Rating Scale :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Fragile-X Syndrome Rating Scale", Headingbold));

                    cell.Colspan = DT8.Columns.Count;

                    foreach (DataRow r in DT8.Rows)
                    {
                        if (DT8.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable36 = new Hashtable();
                    vHashTable36.Add("PTFRA_PTPID", vID);
                    DataRow vdr36 = RetDR(DBManager.Get(vHashTable36, "GET_PT_FRAGILE_REMARK"));
                    if (vdr36 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Fragile-X Syndrome Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr36["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }

                }

                Hashtable vHashTable29 = new Hashtable();
                vHashTable29.Add("PTGL_PTPID", vID);
                DataTable DT29 = DBManager.Get(vHashTable29, "GETPTP_PT_GLOBAL");
                if (DT29.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase( "\n" + "Global Developmenatal Delay Rating Scale :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Global Developmenatal Delay Rating Scale", Headingbold));

                    cell.Colspan = DT29.Columns.Count;

                    foreach (DataRow r in DT29.Rows)
                    {
                        if (DT29.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable38 = new Hashtable();
                    vHashTable38.Add("PTGL_PTPID", vID);
                    DataRow vdr38 = RetDR(DBManager.Get(vHashTable38, "GET_PT_GLOBAL_REMARK"));
                    if (vdr38 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Global Developmenatal Delay Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr38["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }

                Hashtable vHashTable9 = new Hashtable();
                vHashTable9.Add("PTINT_PTPID", vID);
                DataTable DT9 = DBManager.Get(vHashTable9, "GETPTP_PT_INTELLECTUAL");
                if (DT9.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase("\n" + "Intellectual Disability Rating Scale :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Intellectual Disability Rating Scale", Headingbold));

                    cell.Colspan = DT9.Columns.Count;

                    foreach (DataRow r in DT9.Rows)
                    {
                        if (DT9.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable39 = new Hashtable();
                    vHashTable39.Add("PTINT_PTPID", vID);
                    DataRow vdr39 = RetDR(DBManager.Get(vHashTable39, "GET_PT_INTELLECTUAL_REMARK"));
                    if (vdr39 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Intellectual Disability Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr39["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }

                Hashtable vHashTable12 = new Hashtable();
                vHashTable12.Add("PTLEAR_PTPID", vID);
                DataTable DT12 = DBManager.Get(vHashTable12, "GETPTP_PT_LEARNING");
                if (DT12.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase("\n" + "Learning Disability Rating Scale :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Learning Disability Rating Scale", Headingbold));

                    cell.Colspan = DT12.Columns.Count;

                    foreach (DataRow r in DT12.Rows)
                    {
                        if (DT12.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable40 = new Hashtable();
                    vHashTable40.Add("PTLEAR_PTPID", vID);
                    DataRow vdr40 = RetDR(DBManager.Get(vHashTable40, "GET_PT_LEARNING_REMARK"));
                    if (vdr40 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Learning Disability Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr40["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }

                Hashtable vHashTable16 = new Hashtable();
                vHashTable16.Add("PTSEN_PTPID", vID);
                DataTable DT16 = DBManager.Get(vHashTable16, "GETPTP_PT_SENSORY");
                if (DT16.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase("\n" + "Sensory Processing Rating Scale :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Sensory Processing Rating Scale", Headingbold));

                    cell.Colspan = DT16.Columns.Count;

                    foreach (DataRow r in DT16.Rows)
                    {
                        if (DT16.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable41 = new Hashtable();
                    vHashTable41.Add("PTSEN_PTPID", vID);
                    DataRow vdr41 = RetDR(DBManager.Get(vHashTable41, "GET_PT_SENSORY_REMARK"));
                    if (vdr41 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Sensory Processing Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr41["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }

                Hashtable vHashTable18 = new Hashtable();
                vHashTable18.Add("PTSPEC_PTPID", vID);
                DataTable DT18 = DBManager.Get(vHashTable18, "GETPTP_PT_SPEECH");
                if (DT18.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase("\n" + "Speech Delay Rating Scale :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Speech Delay Rating Scale", Headingbold));

                    cell.Colspan = DT18.Columns.Count;

                    foreach (DataRow r in DT18.Rows)
                    {
                        if (DT18.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[1].ToString() + "\n"));
                            cell.Colspan = 5;
                            BaseTable.AddCell(cell);
                        }
                    }
                    Hashtable vHashTable42 = new Hashtable();
                    vHashTable42.Add("PTSPEC_PTPID", vID);
                    DataRow vdr42 = RetDR(DBManager.Get(vHashTable42, "GET_PT_SPEECH_REMARK"));
                    if (vdr42 != null)
                    {
                        PdfPCell REMARK = new PdfPCell(new Phrase("\n" + "Speech Delay Remarks :", Headingbold));
                        REMARK.Colspan = 15;
                        REMARK.NoWrap = false;
                        REMARK.Border = 0;
                        REMARK.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK);

                        PdfPCell REMARK1 = new PdfPCell(new Phrase("\n" + vdr42["REMARK"] + "\n"));
                        REMARK1.Colspan = 15;
                        REMARK1.NoWrap = false;
                        REMARK1.Border = 0;
                        REMARK1.HorizontalAlignment = 3;
                        BaseTable.AddCell(REMARK1);
                    }
                }

                Hashtable vHashTable4 = new Hashtable();
                vHashTable4.Add("PTV_PTPID", vID);
                DataTable DT4 = DBManager.Get(vHashTable4, "GET_VSMS_NEW");
                if (DT4.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase("\n" + "VSMS Rating :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    PdfPCell Category2 = new PdfPCell(new Phrase("Vineland Maturity Scale is a useful instrument in measuring social maturity of children and young adults. This test not only measures the Social Age and Social Quotient. It also indicate the social deficits and social assets in a growing child." + "\n" + "\n"));
                    Category2.Colspan = 15;
                    Category2.NoWrap = false;
                    Category2.Border = 0;
                    Category2.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category2);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("VSMS Rating", Headingbold));

                    cell.Colspan = DT4.Columns.Count;

                    foreach (DataColumn c in DT4.Columns)
                    {
                        cell = new PdfPCell(new Phrase(c.ColumnName, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                        cell.Colspan = 2;
                        BaseTable.AddCell(cell);
                    }
                    foreach (DataRow r in DT4.Rows)
                    {
                        if (DT4.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[0].ToString()));
                            cell.Colspan = 2;
                            BaseTable.AddCell(cell);
                            cell = new PdfPCell(new Phrase(r[1].ToString()));
                            cell.Colspan = 2;
                            BaseTable.AddCell(cell);
                            BaseTable.AddCell(new Phrase(r[2].ToString()));
                        }
                    }
                }
                PdfPCell IMPRESSION = new PdfPCell(new Phrase("\n" + "Clinical Findings And Diagnostic Impression :" + vdr4["PTR_DST"] + "\n"));
                IMPRESSION.Colspan = 15;
                IMPRESSION.NoWrap = false;
                IMPRESSION.Border = 0; 
                IMPRESSION.HorizontalAlignment = 3;
                BaseTable.AddCell(IMPRESSION);

                Hashtable vHashTable26 = new Hashtable();
                vHashTable26.Add("RECOMM_PTPID", vID);
                DataTable DT26 = DBManager.Get(vHashTable26, "GET_RECOM_MAPPING");
                if (DT26.Rows.Count > 0)
                {
                    PdfPCell Category = new PdfPCell(new Phrase("\n" + "Recommendations :" + "\n" + "\n", Headingbold));
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                    BaseTable.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Recommendations"));

                    cell.Colspan = DT26.Columns.Count;

                        cell = new PdfPCell(new Phrase(DT26.Columns[0].ToString(), FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                        cell.Colspan = 1;
                        BaseTable.AddCell(cell);
                        cell = new PdfPCell(new Phrase(DT26.Columns[1].ToString(), FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                        cell.Colspan = 4;
                        BaseTable.AddCell(cell);
                    
                    foreach (DataRow r in DT26.Rows)
                    {
                        if (DT26.Rows.Count > 0)
                        {
                            cell = new PdfPCell(new Phrase(r[0].ToString()));
                            cell.Colspan = 1;
                            BaseTable.AddCell(cell);
                            cell = new PdfPCell(new Phrase(r[1].ToString()));
                            cell.Colspan = 4;
                            BaseTable.AddCell(cell);
                        }
                    }
                }

                PdfPCell Vasal = new PdfPCell(new Phrase("\n" + "Doctor's Name " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                    + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +
                    " " + " " + " " + " " + " " +" " + " " + " " + " " + ":-" + " " + vdr4["PTR_DOCTOR_NAME"] + "\n" + "\n" +
                     "Doctor's Registration Id / MCI No. / RCI No. " + " " + ":-" + vdr4["PTR_REGISTRATION"] + "\n" + "\n"
                        + "Doctor's Designation. " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + ":-" + vdr55["PTR_DESIGNATION"] + "\n" + "\n"
                        + "Email " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + ":-" + vdr55["PTR_EMAIL"] + "\n" + "\n"
                        + "Phone " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + ":-" + vdr55["PTR_PHONE_NUMBER"] + "\n" + "\n"
                        + "Doctor's Stamp " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + ":-" + "...................." + "\n" + "\n"));
                Vasal.Colspan = 15;
                Vasal.NoWrap = false;
                Vasal.Border = 0;
                Vasal.HorizontalAlignment = 3;
                BaseTable.AddCell(Vasal);
            }
            document.Add(BaseTable);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        document.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=" + Filename);
        Response.End();
    }

    //public void createtable()

    //{
    //    PdfPTable table4 = new PdfPTable(4);
    //    table4.TotalWidth = 720f;
    //    table4.LockedWidth = true;

    //    PdfPCell Scalecell = new PdfPCell(new Phrase("S.NO."));
    //    PdfPCell Valuecell = new PdfPCell(new Phrase("Severity Group"));
    //    PdfPCell Remarkcell = new PdfPCell(new Phrase("Total Raw Score"));


    //    table4.AddCell(Scalecell);
    //    table4.AddCell(Valuecell);
    //    table4.AddCell(Remarkcell);



    //    //DataTable tb = new DataTable();
    //    //DataRow dr;
    //    //tb.Columns.Add("S.NO.", typeof(string));
    //    //tb.Columns.Add("Severity Group", typeof(string));
    //    //tb.Columns.Add("Total Raw Score", typeof(string));

    //    //dr = tb.NewRow();
    //    //dr["S.NO."] = "1";
    //    //dr["Severity Group"] = "Minimal-to-No Symptoms of autism spectrum disorder";
    //    //dr["Total Raw Score"] = "15-29.5";
    //    //tb.Rows.Add(dr);

    //    //dr = tb.NewRow();
    //    //dr["S.NO."] = "2";
    //    //dr["Severity Group"] = "Mild-to-moderate Symptoms of autism spectrum disorder";
    //    //dr["Total Raw Score"] = "30-36.5";
    //    //tb.Rows.Add(dr);

    //    //dr = tb.NewRow();
    //    //dr["S.NO."] = "3";
    //    //dr["Severity Group"] = "Severe Symptoms of autism spectrum disorder";
    //    //dr["Total Raw Score"] = "37 or higher";
    //    //tb.Rows.Add(dr);

    //    //Gv1.DataSource = tb;
    //    //Gv1.DataBind();
    //    //ViewState["table1"] = tb;

    //}

}