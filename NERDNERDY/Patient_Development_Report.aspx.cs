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

public partial class Patient_Development_Report : BasePage
{
    ATSession vATSession;
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
                        Binddata();

                        //HIde the save button 
                        SAVEBTN.Visible = false;
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    Binddata();
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    Binddata();
                    //HIde the save button 
                    SAVEBTN.Visible = false;
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    Binddata();
                }
            }
            catch (Exception xe)
            {
                //ShowMsg(xe);
            }
        }
    }

    // Binding the get data from Binddata Start
    protected void Binddata()
    {
        Label2.Text = "<b>NerdNerdy</b> report template assists the organizations and therapists to develop and genertae customized reports for your Patients. Kindly follow the steps given below." +
                        "<br><b>Step 1- Basic Information</b>-In a given text box fill the basic information of your patient like <b>Medical, Developmental and Family history, Symptoms and Clinical observations</b> (Suggested template in text box is given for your reference, you may modify, add or delete text per your patient)</br>" +
                        "<br><b>Step 2- Test administered</b>-To Compile the scores of the tests in the report,Go to patient detail and click Test adminstered tab.</br>" +
                        "<br><b>Step 3- Recommendation</b>- Go to <b>Patient detail</b>…....click <b>Recommendations</b>….. Recommendations you have added and saved for your patient will be shown in your patients PDF report.</br>" +
                        "<br><b>Step 4- Save & Generate Report</b>-Please fill all the enteries given on the Report template page.  You can save report for your Patient. At this stage you can make changes in any section of the report and save it again. After you confirm the disclaimer, you can genertae the PDF report of your patient. The changes cannot be made after you have generated the PDF report.</br>";


        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", vID);
        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
        if (vDR != null)
        {
            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
            PTP_NAME_TXT.Text = vDR["PTP_NAME"].ToString();
            TXTID2.Value = vDR["AGRP_ID"].ToString();
            PTP_AGE_TXT.Enabled = false;
            PTP_GENDER_TXT.Enabled = false;
            PTP_NAME_TXT.Enabled = false;
            TXT_DOC_NAME.Text = vDR["CUST_NAME"].ToString();
            TXT_DOC_DESIG.Text = vDR["CUST_DESIGNATION"].ToString();


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
            Hashtable vHashtable4 = new Hashtable();
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
                Textarea6.InnerText = vDR3["PTR_SYMPTOMS"].ToString();
                GRADE_TXT.Text = vDR3["PTR_GRADE"].ToString();
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
                }
                else
                {
                    CheckBox1.Checked = false;
                }
            }

        }
    }
    // Binding the get data from Binddata End
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
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

}