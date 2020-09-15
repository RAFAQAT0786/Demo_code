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

public partial class Patient_Doctor_Assessment : BasePage
{
    ATSession vATSession;
    DataTable dt;
    DataTable dt1;
    Font HeadingFontbold;
    BLLAGE vAGE = new BLLAGE();
    Font Headingbold;
    Font NormalFont;
    Document document;
    PdfWriter pdfw;
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

        vAGE = new BLLAGE();

        if (!IsPostBack)
        {
            doctor_id.Visible = false;

            try
            {
                ValidateUserAccess();

                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                //  ATCommon.FillDrpDown(DDLPATIENT, DBManager.Get(new Hashtable(), "CMB_PT_PERSONAL"), "Select Patient Name", "PTP_NAME", "PTP_ID", "0");
                // ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_GRP_MASTER"), "Select Group Name", "AGRP_GROUP", "AGRP_ID", "0");
                if (vATSession.UserType == "ADMIN")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</b>Kindly Choose the disorder then watch the assessment video to gain more clarity on how to evaluate the questions.</ br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  /// OLD WAS THIS 18/10/2017
                        // DataRow vDR = RetDR(DBManager.Get(vHashtable, "GETPTP_ID"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PATIENTNAME.InnerText = PATIENTNAME.InnerText = PATIENTNAME1.InnerText = vDR["PTP_NAME"].ToString();
                            PTP_GENDER_TXT.Text = PATIENTGENDER.InnerText = PATIENTGENDER1.InnerText = vDR["PTP_GENDER"].ToString();
                            PATIENTDATE.InnerText = vDR["PTP_DOB"].ToString();
                            PTP_NAME.Enabled = false;
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            PTP_AGE.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_AGE.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            ASE_ID1.Visible = false;
                            doctor_id.Visible = false;
                            popupiep1.Visible = false;
                            btnSave.Visible = false;
                            HiddenField4.Value = vDR["PTP_CUSTID"].ToString();
                            btnShow.Visible = false;
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTAD_PTAID", TXTID.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt = DBManager.Get(vHashtable1, "GET_PTAD_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTAD_ID"));
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        if (dt.Rows.Count > 0)
                        {
                            TXTID.Value = vDR1["PTAD_PTAID"].ToString();
                            PTP_AGE.Text = vDR1["AGRP_GROUP"].ToString();
                            TXTVALUE1.Value = vDR1["PTA_ASEID"].ToString();
                            PTP_AGE.Enabled = false;
                            DDLDIS.SelectedIndex = DDLDIS.Items.IndexOf(DDLDIS.Items.FindByValue(vDR1["PTA_DISID"].ToString()));
                            DDLDIS.Enabled = false;


                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                                RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                                TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                                if (vDR1 != null)
                                {
                                    PTAD_REMARK.Text = vDR1["PTAD_REMARK"].ToString();
                                    GridView1.Enabled = false;
                                }
                                if (dt.Rows[1]["PTAD_VALUE"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                                if (vDR1["PTAD_SOMETHING"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                            }
                        }
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        ASE_ID1.Visible = false;
                        GridView3.Enabled = false;

                        Hashtable vHashtable4 = new Hashtable();
                        vHashtable4.Add("AGE", PTP_AGE.Text);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID"));
                        if (dt1.Rows.Count > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            AGDD.Visible = false;
                            btnSave.Visible = false;
                        }
                    }

                    Hashtable vHashtable55 = new Hashtable();
                    vHashtable55.Add("PTAD_PTAID", TXTVALUE11.Value);
                    vHashtable55.Add("PTP_ID", vID);
                    vHashtable55.Add("AGRP_GROUP", PTP_AGE.Text);
                    vHashtable55.Add("PTA_ASEID", TXTVALUE1.Value);
                    vHashtable55.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable55.Add("PTA_DISID", DDLDIS.SelectedValue);
                    DataTable dt33 = DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW");
                    DataRow vDR4 = RetDR(DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW"));
                    // if (dt.Columns.Count == 13)----24-12-2018
                    if (vDR4 == null)
                    {
                        GridView1.DataSource = dt33;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        btnSave.Visible = true;
                        ASE_ID1.Visible = false;
                        AGDD.Visible = true;
                        doctor_id.Visible = false;
                        // Div1.Visible = false;
                        btnSave.Visible = false;
                    }
                    else
                    {
                        GridView3.DataSource = dt33;
                        GridView3.DataBind();
                        //ASE_ID1.Visible = true;
                        btnSave.Visible = false;
                        AGDD.Visible = false;
                        doctor_id.Visible = true;
                        ASE_ID1.Visible = false;
                        btnAssessment.Visible = false;
                    }
                    if (dt33.Columns.Count > 24)
                    {
                        for (int j = 0; j < GridView1.Rows.Count; j++)
                        {
                            Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                            RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                            TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                            if (vDR4 != null)
                            {
                                TXTID.Value = vDR4["PTA_ID"].ToString();
                                PTAD_REMARK.Text = vDR4["PTAD_REMARK"].ToString();
                                GridView1.Enabled = false;
                            }
                            if (dt33.Rows[1]["PTAD_VALUE"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                            if (vDR4["PTAD_SOMETHING"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                        }
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</b>Kindly Choose the disorder then watch the assessment video to gain more clarity on how to evaluate the questions.</ br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  /// OLD WAS THIS 18/10/2017
                        // DataRow vDR = RetDR(DBManager.Get(vHashtable, "GETPTP_ID"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PATIENTNAME.InnerText = PATIENTNAME.InnerText = PATIENTNAME1.InnerText = vDR["PTP_NAME"].ToString();
                            PTP_GENDER_TXT.Text = PATIENTGENDER.InnerText = PATIENTGENDER1.InnerText = vDR["PTP_GENDER"].ToString();
                            PATIENTDATE.InnerText = vDR["PTP_DOB"].ToString();
                            PTP_NAME.Enabled = false;
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            PTP_AGE.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_AGE.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            ASE_ID1.Visible = false;
                            doctor_id.Visible = false;
                            popupiep1.Visible = false;
                            btnSave.Visible = false;
                            HiddenField4.Value = vDR["PTP_CUSTID"].ToString();
                            btnShow.Visible = false;
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTAD_PTAID", TXTID.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt = DBManager.Get(vHashtable1, "GET_PTAD_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTAD_ID"));
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        if (dt.Rows.Count > 0)
                        {
                            TXTID.Value = vDR1["PTAD_PTAID"].ToString();
                            PTP_AGE.Text = vDR1["AGRP_GROUP"].ToString();
                            TXTVALUE1.Value = vDR1["PTA_ASEID"].ToString();
                            PTP_AGE.Enabled = false;
                            DDLDIS.SelectedIndex = DDLDIS.Items.IndexOf(DDLDIS.Items.FindByValue(vDR1["PTA_DISID"].ToString()));
                            DDLDIS.Enabled = false;


                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                                RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                                TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                                if (vDR1 != null)
                                {
                                    PTAD_REMARK.Text = vDR1["PTAD_REMARK"].ToString();
                                    GridView1.Enabled = false;
                                }
                                if (dt.Rows[1]["PTAD_VALUE"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                                if (vDR1["PTAD_SOMETHING"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                            }
                        }
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        ASE_ID1.Visible = false;
                        GridView3.Enabled = false;

                        Hashtable vHashtable4 = new Hashtable();
                        vHashtable4.Add("AGE", PTP_AGE.Text);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID"));
                        if (dt1.Rows.Count > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            AGDD.Visible = false;
                            btnSave.Visible = false;
                        }
                    }

                    Hashtable vHashtable55 = new Hashtable();
                    vHashtable55.Add("PTAD_PTAID", TXTVALUE11.Value);
                    vHashtable55.Add("PTP_ID", vID);
                    vHashtable55.Add("AGRP_GROUP", PTP_AGE.Text);
                    vHashtable55.Add("PTA_ASEID", TXTVALUE1.Value);
                    vHashtable55.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable55.Add("PTA_DISID", DDLDIS.SelectedValue);
                    DataTable dt33 = DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW");
                    DataRow vDR4 = RetDR(DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW"));
                    // if (dt.Columns.Count == 13)----24-12-2018
                    if (vDR4 == null)
                    {
                        GridView1.DataSource = dt33;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        btnSave.Visible = true;
                        ASE_ID1.Visible = false;
                        AGDD.Visible = true;
                        doctor_id.Visible = false;
                        // Div1.Visible = false;
                        btnSave.Visible = false;
                    }
                    else
                    {
                        GridView3.DataSource = dt33;
                        GridView3.DataBind();
                        //ASE_ID1.Visible = true;
                        btnSave.Visible = false;
                        AGDD.Visible = false;
                        doctor_id.Visible = true;
                        ASE_ID1.Visible = false;
                        btnAssessment.Visible = false;
                    }
                    if (dt33.Columns.Count > 24)
                    {
                        for (int j = 0; j < GridView1.Rows.Count; j++)
                        {
                            Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                            RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                            TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                            if (vDR4 != null)
                            {
                                TXTID.Value = vDR4["PTA_ID"].ToString();
                                PTAD_REMARK.Text = vDR4["PTAD_REMARK"].ToString();
                                GridView1.Enabled = false;
                            }
                            if (dt33.Rows[1]["PTAD_VALUE"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                            if (vDR4["PTAD_SOMETHING"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                        }
                    }
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</b>Kindly Choose the disorder then watch the assessment video to gain more clarity on how to evaluate the questions.</ br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  /// OLD WAS THIS 18/10/2017
                        // DataRow vDR = RetDR(DBManager.Get(vHashtable, "GETPTP_ID"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PATIENTNAME.InnerText = PATIENTNAME.InnerText = PATIENTNAME1.InnerText = vDR["PTP_NAME"].ToString();
                            PTP_GENDER_TXT.Text = PATIENTGENDER.InnerText = PATIENTGENDER1.InnerText = vDR["PTP_GENDER"].ToString();
                            PATIENTDATE.InnerText = vDR["PTP_DOB"].ToString();
                            PTP_NAME.Enabled = false;
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            PTP_AGE.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_AGE.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            ASE_ID1.Visible = false;
                            doctor_id.Visible = false;
                            popupiep1.Visible = false;
                            btnSave.Visible = false;
                            HiddenField4.Value = vDR["PTP_CUSTID"].ToString();
                            btnShow.Visible = false;
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTAD_PTAID", TXTID.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt = DBManager.Get(vHashtable1, "GET_PTAD_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTAD_ID"));
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        if (dt.Rows.Count > 0)
                        {
                            TXTID.Value = vDR1["PTAD_PTAID"].ToString();
                            PTP_AGE.Text = vDR1["AGRP_GROUP"].ToString();
                            TXTVALUE1.Value = vDR1["PTA_ASEID"].ToString();
                            PTP_AGE.Enabled = false;
                            DDLDIS.SelectedIndex = DDLDIS.Items.IndexOf(DDLDIS.Items.FindByValue(vDR1["PTA_DISID"].ToString()));
                            DDLDIS.Enabled = false;


                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                                RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                                TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                                if (vDR1 != null)
                                {
                                    PTAD_REMARK.Text = vDR1["PTAD_REMARK"].ToString();
                                    GridView1.Enabled = false;
                                }
                                if (dt.Rows[1]["PTAD_VALUE"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                                if (vDR1["PTAD_SOMETHING"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                            }
                        }
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        ASE_ID1.Visible = false;
                        GridView3.Enabled = false;

                        Hashtable vHashtable4 = new Hashtable();
                        vHashtable4.Add("AGE", PTP_AGE.Text);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID"));
                        if (dt1.Rows.Count > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            AGDD.Visible = false;
                            btnSave.Visible = false;
                        }
                    }

                    Hashtable vHashtable55 = new Hashtable();
                    vHashtable55.Add("PTAD_PTAID", TXTVALUE11.Value);
                    vHashtable55.Add("PTP_ID", vID);
                    vHashtable55.Add("AGRP_GROUP", PTP_AGE.Text);
                    vHashtable55.Add("PTA_ASEID", TXTVALUE1.Value);
                    vHashtable55.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable55.Add("PTA_DISID", DDLDIS.SelectedValue);
                    DataTable dt33 = DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW");
                    DataRow vDR4 = RetDR(DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW"));
                    // if (dt.Columns.Count == 13)----24-12-2018
                    if (vDR4 == null)
                    {
                        GridView1.DataSource = dt33;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        btnSave.Visible = true;
                        ASE_ID1.Visible = false;
                        AGDD.Visible = true;
                        doctor_id.Visible = false;
                        // Div1.Visible = false;
                        btnSave.Visible = false;
                    }
                    else
                    {
                        GridView3.DataSource = dt33;
                        GridView3.DataBind();
                        //ASE_ID1.Visible = true;
                        btnSave.Visible = false;
                        AGDD.Visible = false;
                        doctor_id.Visible = true;
                        ASE_ID1.Visible = false;
                        btnAssessment.Visible = false;
                    }
                    if (dt33.Columns.Count > 24)
                    {
                        for (int j = 0; j < GridView1.Rows.Count; j++)
                        {
                            Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                            RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                            TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                            if (vDR4 != null)
                            {
                                TXTID.Value = vDR4["PTA_ID"].ToString();
                                PTAD_REMARK.Text = vDR4["PTAD_REMARK"].ToString();
                                GridView1.Enabled = false;
                            }
                            if (dt33.Rows[1]["PTAD_VALUE"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                            if (vDR4["PTAD_SOMETHING"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                        }
                    }
                }
                else if (vATSession.UserType == "PATIENT" || vATSession.UserType == "Patient")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</b>Kindly Choose the disorder then watch the assessment video to gain more clarity on how to evaluate the questions.</ br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  /// OLD WAS THIS 18/10/2017
                        // DataRow vDR = RetDR(DBManager.Get(vHashtable, "GETPTP_ID"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PATIENTNAME.InnerText = PATIENTNAME.InnerText = PATIENTNAME1.InnerText = vDR["PTP_NAME"].ToString();
                            PTP_GENDER_TXT.Text = PATIENTGENDER.InnerText = PATIENTGENDER1.InnerText = vDR["PTP_GENDER"].ToString();
                            PATIENTDATE.InnerText = vDR["PTP_DOB"].ToString();
                            PTP_NAME.Enabled = false;
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            PTP_AGE.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_AGE.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            ASE_ID1.Visible = false;
                            doctor_id.Visible = false;
                            popupiep1.Visible = false;
                            btnSave.Visible = false;
                            HiddenField4.Value = vDR["PTP_CUSTID"].ToString();
                            btnShow.Visible = false;
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTAD_PTAID", TXTID.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt = DBManager.Get(vHashtable1, "GET_PTAD_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTAD_ID"));
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        if (dt.Rows.Count > 0)
                        {
                            TXTID.Value = vDR1["PTAD_PTAID"].ToString();
                            PTP_AGE.Text = vDR1["AGRP_GROUP"].ToString();
                            TXTVALUE1.Value = vDR1["PTA_ASEID"].ToString();
                            PTP_AGE.Enabled = false;
                            DDLDIS.SelectedIndex = DDLDIS.Items.IndexOf(DDLDIS.Items.FindByValue(vDR1["PTA_DISID"].ToString()));
                            DDLDIS.Enabled = false;


                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                                RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                                TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                                if (vDR1 != null)
                                {
                                    PTAD_REMARK.Text = vDR1["PTAD_REMARK"].ToString();
                                    GridView1.Enabled = false;
                                }
                                if (dt.Rows[1]["PTAD_VALUE"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                                if (vDR1["PTAD_SOMETHING"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                            }
                        }
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        ASE_ID1.Visible = false;
                        GridView3.Enabled = false;

                        Hashtable vHashtable4 = new Hashtable();
                        vHashtable4.Add("AGE", PTP_AGE.Text);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID"));
                        if (dt1.Rows.Count > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            AGDD.Visible = false;
                            btnSave.Visible = false;
                        }
                    }

                    Hashtable vHashtable55 = new Hashtable();
                    vHashtable55.Add("PTAD_PTAID", TXTVALUE11.Value);
                    vHashtable55.Add("PTP_ID", vID);
                    vHashtable55.Add("AGRP_GROUP", PTP_AGE.Text);
                    vHashtable55.Add("PTA_ASEID", TXTVALUE1.Value);
                    vHashtable55.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable55.Add("PTA_DISID", DDLDIS.SelectedValue);
                    DataTable dt33 = DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW");
                    DataRow vDR4 = RetDR(DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW"));
                    // if (dt.Columns.Count == 13)----24-12-2018
                    if (vDR4 == null)
                    {
                        GridView1.DataSource = dt33;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        btnSave.Visible = true;
                        ASE_ID1.Visible = false;
                        AGDD.Visible = true;
                        doctor_id.Visible = false;
                        // Div1.Visible = false;
                        btnSave.Visible = false;
                    }
                    else
                    {
                        GridView3.DataSource = dt33;
                        GridView3.DataBind();
                        //ASE_ID1.Visible = true;
                        btnSave.Visible = false;
                        AGDD.Visible = false;
                        doctor_id.Visible = true;
                        ASE_ID1.Visible = false;
                        btnAssessment.Visible = false;
                    }
                    if (dt33.Columns.Count > 24)
                    {
                        for (int j = 0; j < GridView1.Rows.Count; j++)
                        {
                            Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                            RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                            TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                            if (vDR4 != null)
                            {
                                TXTID.Value = vDR4["PTA_ID"].ToString();
                                PTAD_REMARK.Text = vDR4["PTAD_REMARK"].ToString();
                                GridView1.Enabled = false;
                            }
                            if (dt33.Rows[1]["PTAD_VALUE"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                            if (vDR4["PTAD_SOMETHING"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                        }
                    }
                }
                else if (vATSession.UserType == "PARENT" || vATSession.UserType == "Parent")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</b>Kindly Choose the disorder then watch the assessment video to gain more clarity on how to evaluate the questions.</ br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  /// OLD WAS THIS 18/10/2017
                        // DataRow vDR = RetDR(DBManager.Get(vHashtable, "GETPTP_ID"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PATIENTNAME.InnerText = PATIENTNAME.InnerText = PATIENTNAME1.InnerText = vDR["PTP_NAME"].ToString();
                            PTP_GENDER_TXT.Text = PATIENTGENDER.InnerText = PATIENTGENDER1.InnerText = vDR["PTP_GENDER"].ToString();
                            PATIENTDATE.InnerText = vDR["PTP_DOB"].ToString();
                            PTP_NAME.Enabled = false;
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            PTP_AGE.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_AGE.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            ASE_ID1.Visible = false;
                            doctor_id.Visible = false;
                            popupiep1.Visible = false;
                            btnSave.Visible = false;
                            HiddenField4.Value = vDR["PTP_CUSTID"].ToString();
                            btnShow.Visible = false;
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTAD_PTAID", TXTID.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt = DBManager.Get(vHashtable1, "GET_PTAD_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTAD_ID"));
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        if (dt.Rows.Count > 0)
                        {
                            TXTID.Value = vDR1["PTAD_PTAID"].ToString();
                            PTP_AGE.Text = vDR1["AGRP_GROUP"].ToString();
                            TXTVALUE1.Value = vDR1["PTA_ASEID"].ToString();
                            PTP_AGE.Enabled = false;
                            DDLDIS.SelectedIndex = DDLDIS.Items.IndexOf(DDLDIS.Items.FindByValue(vDR1["PTA_DISID"].ToString()));
                            DDLDIS.Enabled = false;


                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                                RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                                TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                                if (vDR1 != null)
                                {
                                    PTAD_REMARK.Text = vDR1["PTAD_REMARK"].ToString();
                                    GridView1.Enabled = false;
                                }
                                if (dt.Rows[1]["PTAD_VALUE"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                                if (vDR1["PTAD_SOMETHING"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                            }
                        }
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        ASE_ID1.Visible = false;
                        GridView3.Enabled = false;

                        Hashtable vHashtable4 = new Hashtable();
                        vHashtable4.Add("AGE", PTP_AGE.Text);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID"));
                        if (dt1.Rows.Count > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            AGDD.Visible = false;
                            btnSave.Visible = false;
                        }
                    }

                    Hashtable vHashtable55 = new Hashtable();
                    vHashtable55.Add("PTAD_PTAID", TXTVALUE11.Value);
                    vHashtable55.Add("PTP_ID", vID);
                    vHashtable55.Add("AGRP_GROUP", PTP_AGE.Text);
                    vHashtable55.Add("PTA_ASEID", TXTVALUE1.Value);
                    vHashtable55.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable55.Add("PTA_DISID", DDLDIS.SelectedValue);
                    DataTable dt33 = DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW");
                    DataRow vDR4 = RetDR(DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW"));
                    // if (dt.Columns.Count == 13)----24-12-2018
                    if (vDR4 == null)
                    {
                        GridView1.DataSource = dt33;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        btnSave.Visible = true;
                        ASE_ID1.Visible = false;
                        AGDD.Visible = true;
                        doctor_id.Visible = false;
                        // Div1.Visible = false;
                        btnSave.Visible = false;
                    }
                    else
                    {
                        GridView3.DataSource = dt33;
                        GridView3.DataBind();
                        //ASE_ID1.Visible = true;
                        btnSave.Visible = false;
                        AGDD.Visible = false;
                        doctor_id.Visible = true;
                        ASE_ID1.Visible = false;
                        btnAssessment.Visible = false;
                    }
                    if (dt33.Columns.Count > 24)
                    {
                        for (int j = 0; j < GridView1.Rows.Count; j++)
                        {
                            Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                            RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                            TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                            if (vDR4 != null)
                            {
                                TXTID.Value = vDR4["PTA_ID"].ToString();
                                PTAD_REMARK.Text = vDR4["PTAD_REMARK"].ToString();
                                GridView1.Enabled = false;
                            }
                            if (dt33.Rows[1]["PTAD_VALUE"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                            if (vDR4["PTAD_SOMETHING"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                        }
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</b>Kindly Choose the disorder then watch the assessment video to gain more clarity on how to evaluate the questions.</ br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  /// OLD WAS THIS 18/10/2017
                        DataTable dt4 = DBManager.Get(vHashtable, "GET_PATIENT_SCREEN");
                        // DataRow vDR = RetDR(DBManager.Get(vHashtable, "GETPTP_ID"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PATIENTNAME.InnerText = PATIENTNAME.InnerText = PATIENTNAME1.InnerText = vDR["PTP_NAME"].ToString();
                            PTP_GENDER_TXT.Text = PATIENTGENDER.InnerText = PATIENTGENDER1.InnerText = vDR["PTP_GENDER"].ToString();
                            PATIENTDATE.InnerText = vDR["PTP_DOB"].ToString();
                            PTP_NAME.Enabled = false;
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            PTP_AGE.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_AGE.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            ASE_ID1.Visible = false;
                            doctor_id.Visible = false;
                            popupiep1.Visible = false;
                            btnSave.Visible = false;
                            HiddenField4.Value = vDR["PTP_CUSTID"].ToString();
                            //HiddenField1.Value = vDR["AGRP_VIDEO_LINK"].ToString(); --for age-wise video
                            //HiddenField1.Value = vDR["DIS_VIDEO_LINK"].ToString();
                            btnShow.Visible = false;
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTAD_PTAID", TXTID.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt = DBManager.Get(vHashtable1, "GET_PTAD_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTAD_ID"));
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        if (dt.Rows.Count > 0)
                        {
                            TXTID.Value = vDR1["PTAD_PTAID"].ToString();
                            PTP_AGE.Text = vDR1["AGRP_GROUP"].ToString();
                            TXTVALUE1.Value = vDR1["PTA_ASEID"].ToString();
                            PTP_AGE.Enabled = false;
                            DDLDIS.SelectedIndex = DDLDIS.Items.IndexOf(DDLDIS.Items.FindByValue(vDR1["PTA_DISID"].ToString()));
                            DDLDIS.Enabled = false;


                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                                RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                                TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                                if (vDR1 != null)
                                {
                                    PTAD_REMARK.Text = vDR1["PTAD_REMARK"].ToString();
                                    GridView1.Enabled = false;
                                }
                                if (dt.Rows[1]["PTAD_VALUE"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                                if (vDR1["PTAD_SOMETHING"].ToString() == "1")
                                {
                                    chkRow.Checked = true;
                                }
                                else
                                {
                                    chkRow.Checked = false;
                                }
                            }
                        }
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        ASE_ID1.Visible = false;
                        GridView3.Enabled = false;

                        Hashtable vHashtable4 = new Hashtable();
                        vHashtable4.Add("AGE", PTP_AGE.Text);
                        vHashtable4.Add("PTP_ID", vID);
                        DataTable dt1 = DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID");
                        DataRow vDR3 = RetDR(DBManager.Get(vHashtable4, "GET_DISORDER_PERCENTAGE_ASSESSMENT_ID"));
                        if (dt1.Rows.Count > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            AGDD.Visible = false;
                            btnSave.Visible = false;
                        }
                    }

                    Hashtable vHashtable55 = new Hashtable();
                    vHashtable55.Add("PTAD_PTAID", TXTVALUE11.Value);
                    vHashtable55.Add("PTP_ID", vID);
                    vHashtable55.Add("AGRP_GROUP", PTP_AGE.Text);
                    vHashtable55.Add("PTA_ASEID", TXTVALUE1.Value);
                    vHashtable55.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable55.Add("PTA_DISID", DDLDIS.SelectedValue);
                    DataTable dt33 = DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW");
                    DataRow vDR4 = RetDR(DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW"));
                    // if (dt.Columns.Count == 13)----24-12-2018
                    if (vDR4 == null)
                    {
                        GridView1.DataSource = dt33;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        btnSave.Visible = true;
                        ASE_ID1.Visible = false;
                        AGDD.Visible = true;
                        doctor_id.Visible = false;
                        // Div1.Visible = false;
                        btnSave.Visible = false;
                    }
                    else
                    {
                        GridView3.DataSource = dt33;
                        GridView3.DataBind();
                        //ASE_ID1.Visible = true;
                        btnSave.Visible = false;
                        AGDD.Visible = false;
                        doctor_id.Visible = true;
                        ASE_ID1.Visible = false;
                        btnAssessment.Visible = false;
                    }
                    if (dt33.Columns.Count > 24)
                    {
                        for (int j = 0; j < GridView1.Rows.Count; j++)
                        {
                            Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                            RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                            TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");

                            if (vDR4 != null)
                            {
                                TXTID.Value = vDR4["PTA_ID"].ToString();
                                PTAD_REMARK.Text = vDR4["PTAD_REMARK"].ToString();
                                GridView1.Enabled = false;
                            }
                            if (dt33.Rows[1]["PTAD_VALUE"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                            if (vDR4["PTAD_SOMETHING"].ToString() == "1")
                            {
                                chkRow.Checked = true;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                        }
                    }

                }
                else
                {
                    ShowMsg("Invalid Patient ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    private void CreateDynamicTable()
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("PTP_ID", vID);
        // DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  /// OLD WAS THIS 18/10/2017
        DataTable dt = DBManager.Get(vHashtable1, "GETPTP_ID");

        TableRow tr = new TableRow();
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            TableCell tc = new TableCell();
            TextBox Q11OBSERVATION = new TextBox();
            TextBox Q11REMARKS = new TextBox();
            TextBox Q11PERCENTAGE = new TextBox();
            TextBox Q11SCALE = new TextBox();
            
            Q11REMARKS.Text = dt.Rows[j][03].ToString();
            Q11OBSERVATION.Text = dt.Rows[j][10].ToString();
            Q11PERCENTAGE.Text = dt.Rows[j][08].ToString();
            Q11SCALE.Text = dt.Rows[j][09].ToString();
            tc.Controls.Add(Q11REMARKS);
            tc.Controls.Add(Q11OBSERVATION);
            tc.Controls.Add(Q11PERCENTAGE);
            tc.Controls.Add(Q11SCALE);
            tr.Cells.Add(tc);
        }
        // Add the TableRow to the Table
        tbl.Rows.Add(tr);
        tbl.EnableViewState = true;
        ViewState["tbl"] = true;
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "PATIENT")
        {

            Label PTA_ID = (Label)GridView2.Rows[index].FindControl("PTA_ID");
            String vID = Request.QueryString["ID"];
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", vID);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ID");
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Assessment_Word.aspx?id=" + vID + "&id1=" + PTA_ID.Text);

            }
        }
    }

    private void CreateDynamicTableNEW()
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("PTP_ID", vID);
        // DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  /// OLD WAS THIS 18/10/2017
        DataTable dt = DBManager.Get(vHashtable1, "GETPTP_ID");

        TableRow tr = new TableRow();
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            TableCell tc = new TableCell();
            TextBox Q11OBSERVATION = new TextBox();
            TextBox Q11REMARKS = new TextBox();
            TextBox Q11PERCENTAGE = new TextBox();
            TextBox Q11SCALE = new TextBox();
            // txtBox.ID = "txt-" + i.ToString() + "-" + j.ToString();
            Q11REMARKS.Text = dt.Rows[j][03].ToString();
            Q11OBSERVATION.Text = dt.Rows[j][10].ToString();
            Q11PERCENTAGE.Text = dt.Rows[j][08].ToString();
            Q11SCALE.Text = dt.Rows[j][09].ToString();
            tc.Controls.Add(Q11REMARKS);
            tc.Controls.Add(Q11OBSERVATION);
            tc.Controls.Add(Q11PERCENTAGE);
            tc.Controls.Add(Q11SCALE);
            tr.Cells.Add(tc);

        }
        // Add the TableRow to the Table
        tbl.Rows.Add(tr);
        tbl.EnableViewState = true;
        ViewState["tbl"] = true;
        //}
    }

    protected void btnAssessment_Click(object sender, EventArgs e)
    {
            String vID = Request.QueryString["ID"];

            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTAD_PTAID", TXTVALUE11.Value);
            vHashtable.Add("PTP_ID", vID);
            vHashtable.Add("AGRP_GROUP", PTP_AGE.Text);
            vHashtable.Add("PTA_ASEID", TXTVALUE1.Value);
            vHashtable.Add("ASER_DISID", DDLDIS.SelectedValue);
            vHashtable.Add("PTA_DISID", DDLDIS.SelectedValue);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ASSES_DETAIL_NEW");
            DataRow vDR4 = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_ASSES_DETAIL_NEW"));
            if (dt.Columns.Count == 14)/*24-12-2018*/
         //  if(vDR4 == null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Visible = true;
                btnSave.Visible = true;
                ASE_ID1.Visible = false;
                AGDD.Visible = true;
                doctor_id.Visible = false;
                // Div1.Visible = false;
                //btnSave.Visible = false;
                btnSave.Visible = true;
                if (vDR4 != null)
                {
                    HiddenField1.Value = vDR4["DIS_VIDEO_LINK"].ToString();
                    btnShow.Visible = true;
                }
                else
                {
                    btnShow.Visible = false;
                    btnSave.Visible = false;
                }
            }
            else
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
                ASE_ID1.Visible = true;
                btnSave.Visible = false;
                AGDD.Visible = false;
                doctor_id.Visible = true;
               ASE_ID1.Visible = false;
        }
        if (dt.Columns.Count > 24)
        {
            for (int j = 0; j < GridView1.Rows.Count; j++)
            {
                Label PTAD_ASEDID = (Label)GridView1.Rows[j].Cells[6].FindControl("PTAD_ASEDID");
                RadioButton chkRow = (RadioButton)GridView1.Rows[j].Cells[1].FindControl("rdbtn2");
                TextBox PTAD_REMARK = (TextBox)GridView1.Rows[j].Cells[2].FindControl("PTAD_REMARK");
                
                if (vDR4 != null)
                {
                    TXTID.Value = vDR4["PTA_ID"].ToString();
                    PTAD_REMARK.Text = vDR4["PTAD_REMARK"].ToString();
                    GridView1.Enabled = false;
                }
                if (dt.Rows[1]["PTAD_VALUE"].ToString() == "1")
                {
                    chkRow.Checked = true;
                }
                else
                {
                    chkRow.Checked = false;
                }
                if (vDR4["PTAD_SOMETHING"].ToString() == "1")
                {
                    chkRow.Checked = true;
                }
                else
                {
                    chkRow.Checked = false;
                }
            }
        }
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];
        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("PTA_ID", TXTVALUE11.Value);
        vHashtable1.Add("PTA_PTPID", vID);
        vHashtable1.Add("PTA_CUSTID", HiddenField4.Value);
        vHashtable1.Add("PTA_ASEID", ID.Value);
        vHashtable1.Add("PTA_DISID", DDLDIS.SelectedValue);
        vHashtable1.Add("TYPE", "INS");
        //  DBManager.ExecInsUps(vHashtable1, "INS_PTS_MASTER", (ATSession)Session["User"]);
        if (DBManager.ExecInsUpsReturn(vHashtable1, "INS_PTA_ASSES_MASTER", (ATSession)Session["User"]))

        {
            if (Page.IsValid)
            {
                if (GridView1.Rows.Count > 0)
                    try
                    {
                        string data = "";
                        foreach (GridViewRow grd in GridView1.Rows)
                        {
                            HiddenField HiddenID = (HiddenField)grd.FindControl("AGDD_DOBSID");
                            Label ASED_ID = (Label)grd.FindControl("ASED_ID");
                            Label ASED_AGDDID = (Label)grd.FindControl("ASED_AGDDID");
                            TextBox PTAD_REMARK = (TextBox)grd.FindControl("PTAD_REMARK");
                            TextBox PTAD_SCALE = (TextBox)grd.FindControl("PTAD_SCALE");
                            // TextBox PTAD_VALUE = (TextBox)grd.FindControl("PTAD_VALUE");

                            if (grd.RowType == DataControlRowType.DataRow)
                            {
                                RadioButton chkRow = (grd.Cells[0].FindControl("rdbtn2") as RadioButton);
                                string HiddenField1 = chkRow.Checked ? "1" : "0";
                                RadioButton chkRow1 = (grd.Cells[1].FindControl("rdbtn1") as RadioButton);
                                string HiddenField2 = chkRow1.Checked ? "1" : "0";

                                if (chkRow.Checked)
                                {
                                    Hashtable vHashtable2 = new Hashtable();
                                    vHashtable2.Add("PTAD_ID", ID.Value);
                                    vHashtable2.Add("PTAD_PTAID", TXTID.Value);
                                    vHashtable2.Add("PTAD_ASEDID", ASED_ID.Text);
                                    vHashtable2.Add("PTAD_REMARK", PTAD_REMARK.Text);
                                    vHashtable2.Add("PTAD_SOMETHING", HiddenField2);
                                    vHashtable2.Add("PTAD_SCALE", "");
                                    // vHashtable2.Add("PTAD_VALUE", float.Parse(PTAD_VALUE.Text).ToString()); 
                                    vHashtable2.Add("PTAD_VALUE", HiddenField1);
                                    vHashtable2.Add("TYPE", "INS");
                                    DBManager.ExecInsUps(vHashtable2, "INS_PTA_ASSES_DETAIL", (ATSession)Session["User"]);
                                    data = data + ID + " ,  " + TXTID + " , " + ASED_ID + "<br>";

                                    // }
                                }
                                else if (chkRow1.Checked)
                                {
                                    Hashtable vHashtable2 = new Hashtable();
                                    vHashtable2.Add("PTAD_ID", ID.Value);
                                    vHashtable2.Add("PTAD_PTAID", TXTID.Value);
                                    vHashtable2.Add("PTAD_ASEDID", ASED_ID.Text);
                                    vHashtable2.Add("PTAD_REMARK", PTAD_REMARK.Text);
                                    vHashtable2.Add("PTAD_SOMETHING", HiddenField2);
                                    vHashtable2.Add("PTAD_SCALE", "");
                                    // vHashtable2.Add("PTAD_VALUE", float.Parse(PTAD_VALUE.Text).ToString()); 
                                    vHashtable2.Add("PTAD_VALUE", HiddenField1);
                                    vHashtable2.Add("TYPE", "INS");
                                    DBManager.ExecInsUps(vHashtable2, "INS_PTA_ASSES_DETAIL", (ATSession)Session["User"]);
                                    data = data + ID + " ,  " + TXTID + " , " + ASED_ID + "<br>";
                                }
                            }
                        }
                    }
                    catch (Exception xe)
                    {
                        ShowMsg(xe);
                    }
            }
            if (ID.Value != null)
            {
                string values = AGDD_DOBSID.Value.ToString();//.Remove(AGDD_DOBSID.Value.Length - 1);
                string SAP_IDs = string.Empty;
                SAP_IDs = values.TrimEnd(',').ToString();
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("AGE", PTP_AGE.Text);
                vHashtable.Add("ASER_DISID", DDLDIS.SelectedValue);
                DataTable dt = DBManager.Get(vHashtable, "GET_DISORDER_PERCENTAGE_ASSESSMENT");
                GridView2.DataSource = dt;
                GridView2.DataBind();
                doctor_id.Visible = true;
                Response.Redirect("Patient_Doctor_Assessment.aspx?id=" + vID);
                //Response.Redirect("Patient.aspx");
            }
        }
    }

    protected void btnPdfReport_Click(object sender, EventArgs e)
    {

    }

    protected void btnPdf_Click(object sender, EventArgs e)
    {
        Headingbold = new Font(Font.HELVETICA, 12f, Font.BOLD);
        HeadingFontbold = new Font(Font.HELVETICA, 8f, Font.BOLD);
        NormalFont = new Font(Font.HELVETICA, 7f, Font.NORMAL);
        document = new Document(PageSize.A4.Rotate(), 5, 5, 10, 10);
        string Filename = "Patient_Report" + DateTime.Now.Date.ToString("dd_MM_yyyy") + ".pdf";
        try
        {
            pdfw = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            PdfPTable BaseTable = new PdfPTable(4);
            BaseTable.TotalWidth = 820f;
            BaseTable.LockedWidth = true;
            BaseTable.HorizontalAlignment = 100;
            // BaseTable.SetWidths(new float[13] { 300, 100, 200, 105, 60, 50, 65, 80, 60, 65, 55, 70, 70 });
            PdfPCell HeaderRow = new PdfPCell(new Phrase("PARVARISH", Headingbold));
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
            PdfPCell StationCol1 = new PdfPCell(new Phrase("PARVARISH,Gurgaon", HeadingFontbold));
            PdfPCell StationCol2 = new PdfPCell(new Phrase("Transforming lives with hopes and happiness", HeadingFontbold));
            StationCol2.FixedHeight = 18f;
            StationCol1.NoWrap = false;
            StationCol2.NoWrap = false;
            StationCol1.Border = 0;
            StationCol2.Border = 0;
            StationCol1.HorizontalAlignment = 1;
            StationCol2.HorizontalAlignment = 1;
            customertable12.AddCell(StationCol1);
            customertable12.AddCell(StationCol2);
            PdfPCell cust_table1 = new PdfPCell(customertable12);
            cust_table1.Colspan = 13;
            cust_table1.Border = 0;
            BaseTable.AddCell(cust_table1);
            
            PdfPCell HeaderRownew = new PdfPCell(new Phrase("PATIENT REPORT FROM:", HeadingFontbold));
            
            String vID = Request.QueryString["ID"];

            Hashtable vHashTable = new Hashtable();
            vHashTable.Add("PTP_ID", vID);
            DataRow vdr = RetDR(DBManager.Get(vHashTable, "GETPTP_ID_NEW"));
            
            if (vdr != null)
            {
                    PdfPCell patient = new PdfPCell(new Phrase("PATIENT NAME:" + vdr["PTP_NAME"].ToString()));
                    patient.Colspan = 2;
                    // patient.FixedHeight = 18f;
                    patient.NoWrap = false;
                    patient.Border = 0;
                    patient.HorizontalAlignment = 3;
                    patient.PaddingBottom = 4f;
                    patient.PaddingTop = 2f;
                    BaseTable.AddCell(patient);

                    PdfPCell PTP_GENDER_TXT = new PdfPCell(new Phrase("GENDER:" + vdr["PTP_GENDER"].ToString()));
                    PTP_GENDER_TXT.Colspan = 4;
                    PTP_GENDER_TXT.NoWrap = false;
                    PTP_GENDER_TXT.Border = 0;
                    PTP_GENDER_TXT.HorizontalAlignment = 3;
                    PTP_GENDER_TXT.PaddingBottom = 4f;
                    PTP_GENDER_TXT.PaddingTop = 2f;
                    BaseTable.AddCell(PTP_GENDER_TXT);

                    PdfPCell DDLAGE2 = new PdfPCell(new Phrase("AGE:" + vdr["AGRP_GROUP"].ToString() + "\n" + "\n"));
                    DDLAGE2.Colspan = 5;
                    DDLAGE2.NoWrap = false;
                    DDLAGE2.Border = 0;
                    DDLAGE2.HorizontalAlignment = 3;
                    DDLAGE2.PaddingBottom = 4f;
                    DDLAGE2.PaddingTop = 2f;
                    BaseTable.AddCell(DDLAGE2);

                    PdfPCell DDLAGE1 = new PdfPCell(new Phrase("REASON FOR REFERRAL:" + " " + vdr["PTP_NAME"] + " is a" + " " + vdr["AGRP_GROUP"] + " " + "old young boy who was brought for evaluation by his parents, who provided all relevant information.Parents were concerned about his Speech Delay and" + " " + vdr["PTP_NAME"] + " " + "not responding to his name or instructions." + "\n" + "\n"));
                    DDLAGE1.Colspan = 15;
                    DDLAGE1.NoWrap = false;
                    DDLAGE1.Border = 0;
                    DDLAGE1.HorizontalAlignment = 3;
                    BaseTable.AddCell(DDLAGE1);
                   
                    PdfPCell EVALUATION = new PdfPCell(new Phrase("EVALUATION METHOD:" + "1.Clinical Observation" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "2.Parent's Interview" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " 
                        + "3.Development Screening Test" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " "+ " " + " " + " " + " " + " " 
                        + "4.Vineland Social Maturity Scale" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "  
                        + "5.Childhood Autism Rating Scale-2" + "\n" + "\n"));
                    EVALUATION.Colspan = 15;
                    EVALUATION.NoWrap = false;
                    EVALUATION.Border = 0;
                    EVALUATION.HorizontalAlignment = 3;
                    BaseTable.AddCell(EVALUATION);

                PdfPCell Medical = new PdfPCell(new Phrase("Medical History:" + vdr["PTM_DESC"] + "\n" + "\n"));
                        //+ "No medical complications were reported by the Parents." + "\n" + "\n"));
                    Medical.Colspan = 15;
                    Medical.NoWrap = false;
                    Medical.Border = 0;
                    Medical.HorizontalAlignment = 3;
                    BaseTable.AddCell(Medical);

                PdfPCell Developmental = new PdfPCell(new Phrase("Developmental History:" + vdr["PTDEV_DESC"] + "\n" + "\n"));
                        //+ "Mother reported that" + " " + vdr["PTP_NAME"] + " " + "Physical and motor milestones were age appropriate. He started speaking 4-5 words (mama, papa etc) around one and a half years of age but around 2 years he stopped saying the words that he used to say. Now rarely he may say one or two words but not always." +
                        //"According to parents" + " " + vdr["PTP_NAME"] + " " + "has extraordinary Balancing skills and eye hand coordination. He does not fall even if he walks on the edge of the furniture. He can walk with eyes closed and would not bang self into the object." +
                        //" " + vdr["PTP_NAME"] + " " + "likes to spin objects and self. He would not get dizzy even after spinning self for long but would start looking from the corner of his eyes after spinning.  According to parents Vihaan likes to have his own diet, which generally consist of semi solid food only. He does not try new food. If he tries solid food, he would cough it out as if his throat is choking. " +
                        //vdr["PTP_NAME"] + " " + "hearing test and Neurological assessment have been done. He has no issues with hearing or any other neurological impairment." + "\n" + "\n"));
                    Developmental.Colspan = 15;
                    Developmental.NoWrap = false;
                    Developmental.Border = 0;
                    Developmental.HorizontalAlignment = 3;
                    BaseTable.AddCell(Developmental);

                    PdfPCell Family = new PdfPCell(new Phrase("Family History:" + vdr["PTFH_DESC"] + "\n" + "\n"));
                    Family.Colspan = 15;
                    Family.NoWrap = false;
                    Family.Border = 0;
                    Family.HorizontalAlignment = 3;
                    BaseTable.AddCell(Family);


                  PdfPCell Observation = new PdfPCell(new Phrase("On Observation:" + vdr["DOBS_DESC"] + "\n" + "\n" ));
                       // + "Does not have age appropriate Eye Contact"
                       //+ " " + vdr["PTP_NAME"] + " " + "kept constantly moving in the room and was in his own world. He didn’t respond to his name or simple commands. Pretend play or imaginative play is not developed. He was happy and got excited when he saw bubble tubes with lights."
                       // + vdr["PTP_NAME"] + " " + "does not have speech at this stage but has lot of vocalization. He indicates his needs by holding hands. Has repetitive behaviour, he peels off the stickers from the objects. If interrupted then gets aggressive. " +
                       // "Fine motor skills are age appropriate. Inappropriate body use like flapping of hands or wiggling of fingers were not noticed. He enjoys fast movements on swings and enjoyed jumping on trampoline and ball. He looked from the corner of his eyes after he got off the swing."
                       // + vdr["PTP_NAME"] + " " + "showed tactile issues as he was not able to touch fibres, sensory balls, and sensory sand. He showed interest in playing with different toys. He showed discomfort when touched by other therapist. No discomfort was noticed in" + " " + vdr["PTP_NAME"] + " " + "while moving from one room to the other. " +
                       // "His abstract skills like cause and effect are not age appropriate." + "\n" + "\n"));
                    Observation.Colspan = 15;
                    Observation.NoWrap = false;
                    Observation.Border = 0;
                    Observation.HorizontalAlignment = 3;
                    BaseTable.AddCell(Observation);


                    PdfPCell Physical = new PdfPCell(new Phrase("Physical Behaviour:" + vdr["PTP_NAME"] + " "+ "enjoys movement. He can’t seem to sit still, craves fast spinning movement. Gross motor and fine motor skills are age appropriate." + "\n" + "\n"));
                    Physical.Colspan = 15;
                    Physical.NoWrap = false;
                    Physical.Border = 0;
                    Physical.HorizontalAlignment = 3;
                    BaseTable.AddCell(Physical);

                    PdfPCell Motor = new PdfPCell(new Phrase("Oral Motor Development/ Eating Behaviour:" + "He is hypersensitive to oral input and only eats semi solid food." +
                        "When" + " " + vdr["PTP_NAME"] + " "+ "is introduced solid food item, he would cough it out as his throat is choked. He never shows any curiosity to try new food item." +
                        "According to his parents he has preference for limited food items. He can suck but can’t blow." + "\n" + "\n"));
                    Motor.Colspan = 15;
                    Motor.NoWrap = false;
                    Motor.Border = 0;
                    Motor.HorizontalAlignment = 3;
                    BaseTable.AddCell(Motor);

                    PdfPCell Gross = new PdfPCell(new Phrase("Gross Motor and Fine Motor development:" + vdr["PTP_NAME"] + " " +"can walk, run and jumps well, he can walk upstairs and downstairs, pincer grasp is age appropriate." + "\n" + "\n"));
                    Gross.Colspan = 15;
                    Gross.NoWrap = false;
                    Gross.Border = 0;
                    Gross.HorizontalAlignment = 3;
                    BaseTable.AddCell(Gross);

                    PdfPCell Social = new PdfPCell(new Phrase("Social/ Emotional development:" + "He does not socially interact with people, he does not demonstrate trouble when separated from his mother, he used to scream loudly when aggressive or excited. Imaginative/ pretend play not developed." + "\n" + "\n"));
                    Social.Colspan = 15;
                    Social.NoWrap = false;
                    Social.Border = 0;
                    Social.HorizontalAlignment = 3;
                    BaseTable.AddCell(Social);

                    PdfPCell Activities = new PdfPCell(new Phrase("Activities of Daily Living(ADL):"));
                    PdfPCell Self = new PdfPCell(new Phrase("Self-care:" + "1.Eating:" + vdr["PTP_NAME"] + " " + "can feed himself with spoon, he is able to drink water from glass on his own." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "   
                        + "2.Dressing:" + "He can dress and undress himself with assistance." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "  
                        + "3.Bladder/Bowel:" + "He indicates bladder/ bowel movements by maintaining a peculiar posture." + "\n" + "\n"));
                    Self.Colspan = 15;
                    Self.NoWrap = false;
                    Self.Border = 0;
                    Self.HorizontalAlignment = 3;
                    BaseTable.AddCell(Self);
                    
                    PdfPCell REASON = new PdfPCell(new Phrase("The Childhood Autism Rating Scale:" + "The childhood Autism Rating Scale, Second Edition(CARS 2) includes three forms."+
                                    "The three forms are the two rating booklets – Childhood Autism Rating Scale, Second Edition –Standard Version(CARS2 - ST; formerly titled CARS) and the Childhood Autism Rating Scale, Second Edition - High Functioning Version(CARS2-HF)-and the questionnaire for parents or caregivers(CARS2 - QPC)."+
                                  "The CARS2 - ST and CARS2 - HF are not intended as screeners for use in general population.Their primarily values lies in their providing brief, quantitatively specific and reliable yet comprehensively based summary information that can be used to help develop diagnostic hypotheses among referred individuals of all ages and functional levels."+
                                     "CARS2 - ST and CARS2 - HF ratings are based not only on the frequency of behaviours, but also on their intensity, peculiarity and duration.This allows for great flexibility in integrating comprehensive information about a case, and at the same time yields consistent quantitative results.Professionals can also use CARS2 results to help in giving diagnostic feedback to parents, characterizing functional profiles and guiding intervention planning."+
                                        "The CARS - ST and CARS - HF each include 15 items that ask respondents to rate an individual on a scale from 1to 4 in key areas related to autism diagnosis.The ratings were done by the examiner based on" + vdr["PTP_NAME"] + " " + "parent’s interview and her observations."
                                        + vdr["PTP_NAME"] + " " + "obtained a rating of 33 on CARS2-ST, which places him in Mild to Moderate Symptoms of Autism Spectrum Disorder at this time." + "\n" + "\n"));
                    REASON.Colspan = 15;
                    REASON.NoWrap = false;
                    REASON.Border = 0;
                    REASON.HorizontalAlignment = 3;
                    BaseTable.AddCell(REASON);

                    PdfPCell Category = new PdfPCell(new Phrase("Category Rating:" + "\n" + "\n"));
                   // CreateDynamicTable();
                    Category.Colspan = 15;
                    Category.NoWrap = false;
                    Category.Border = 0;
                    Category.HorizontalAlignment = 3;
                    BaseTable.AddCell(Category);

                Hashtable vHashTable3 = new Hashtable();
                vHashTable3.Add("PTP_ID", vID);
                DataTable DT = DBManager.Get(vHashTable3, "GETPTP_ID");
                {
                    if (DT.Rows.Count > 0)
                    {
                        string data = "";
                        foreach (DataRow row in DT.Rows)
                        {
                            // PdfPTable table = new PdfPTable(4);
                            BaseTable.TotalWidth = 720f;
                            BaseTable.LockedWidth = true;

                            PdfPCell Observationcell = new PdfPCell(new Phrase("OBSERVATION :  " + row[11].ToString()));
                            PdfPCell Remarkcell = new PdfPCell(new Phrase("REMARK : " + row[3].ToString()));
                            PdfPCell Percell = new PdfPCell(new Phrase("PERCENTAGE : " + row[8].ToString()));
                            PdfPCell Scalecell = new PdfPCell(new Phrase("SCALE : " + row[9].ToString()));

                            BaseTable.AddCell(Observationcell);
                            BaseTable.AddCell(Remarkcell);
                            BaseTable.AddCell(Percell);
                            BaseTable.AddCell(Scalecell);
                           // document.Add(BaseTable);
                        }
                    }
                }

                //  CreateDynamicTableNEW();

                PdfPCell Screening = new PdfPCell(new Phrase("\n" + "\n" + "Developmental Screening Test:" + "The Developmental Screening Test is designed for the purpose of measuring mental development of children from birth to 15 years of age." +
                                        "The test starts from the ‘Basal Age’ where all characteristics at a particular age are passed and gradually moving through upper age levels."+
                                        "It assesses behavioural characteristics of respective age levels."+
                                        "At each age level, items are drawn from behavioural areas like motor development, speech, language and personal social development." + "\n" + "\n"));
                    Screening.Colspan = 15;
                    Screening.NoWrap = false;
                    Screening.Border = 0;
                    Screening.HorizontalAlignment = 3;
                    BaseTable.AddCell(Screening);

                    PdfPCell Development = new PdfPCell(new Phrase("Developmental Age:" + vdr["AGRP_GROUP"] + "\n" + "\n"));
                    Development.Colspan = 15;
                    Development.NoWrap = false;
                    Development.Border = 0;
                    Development.HorizontalAlignment = 3;
                    BaseTable.AddCell(Development);

                    PdfPCell Quotient = new PdfPCell(new Phrase("Developmental Quotient:" + "50" +"\n" 
                        + "As per developmental screening test" + " " + vdr["PTP_NAME"] + " " + "General Development score is 50 and falls in Delayed range." + "\n" + "\n"));
                    Quotient.Colspan = 15;
                    Quotient.NoWrap = false;
                    Quotient.Border = 0;
                    Quotient.HorizontalAlignment = 3;
                    BaseTable.AddCell(Quotient);

                    PdfPCell Note = new PdfPCell(new Phrase("Please Note:" + "Children with deficit in language & Communication may show overall lower scores than actual." + "\n" + "\n"));
                    Note.Colspan = 15;
                    Note.NoWrap = false;
                    Note.Border = 0;
                    Note.HorizontalAlignment = 3;
                    BaseTable.AddCell(Note);

                    PdfPCell Vineland = new PdfPCell(new Phrase(" Vineland Social Maturity Scale:" + "Vineland Maturity Scale is a useful instrument in measuring social maturity of children and young adults. This test not only measures the Social Age and Social Quotient. It also indicate the social deficits and social assets in a growing child." + "\n" + "\n"));
                    Vineland.Colspan = 15;
                    Vineland.NoWrap = false;
                    Vineland.Border = 0;
                    Vineland.HorizontalAlignment = 3;
                    BaseTable.AddCell(Vineland);

                 PdfPCell Sensory = new PdfPCell(new Phrase(" " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +
                    " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " +
                    " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + "Sensory Evaluation" + "\n" + "\n"));
                    Sensory.Colspan = 15;
                    Sensory.NoWrap = false;
                    Sensory.Border = 0;
                    Sensory.HorizontalAlignment = 3;
                    BaseTable.AddCell(Sensory);

                PdfPCell Tactile = new PdfPCell(new Phrase("Tactile:" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + "• Can tolerate hair cut well." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Avoids touching certain textures of materials." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Avoids messy play with sand, mud, glue etc." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Becomes aggressive with light or unexpected touch." + "\n" + "\n"));
                Tactile.Colspan = 15;
                Tactile.NoWrap = false;
                Tactile.Border = 0;
                Tactile.HorizontalAlignment = 3;
                BaseTable.AddCell(Tactile);

                PdfPCell Auditory = new PdfPCell(new Phrase("Auditory:" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + "• He is not bothered by sounds made by toilet flushing, backward noises, vacuum or blow dryer etc. Earlier he used to cover his ears with noise of running machines. But now he is fine with it." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Does not enjoy very loud noise or continuous talking by siblings." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Enjoys listening to music." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Distracted by sounds not normally noticed by others." + "\n" + "\n"));
                Auditory.Colspan = 15;
                Auditory.NoWrap = false;
                Auditory.Border = 0;
                Auditory.HorizontalAlignment = 3;
                BaseTable.AddCell(Auditory);

                PdfPCell input = new PdfPCell(new Phrase("Oral input:" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + "•	He chews semi solid food. He does not eat solid food items." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Has difficulty in blowing." + "\n" + "\n"));
                input.Colspan = 15;
                input.NoWrap = false;
                input.Border = 0;
                input.HorizontalAlignment = 3;
                BaseTable.AddCell(input);

                PdfPCell Vestibular = new PdfPCell(new Phrase("Vestibular:" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + "• Enjoys swings, slides, merry-go-round." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Does not get dizzy easily." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Enjoys being tipped upside down Enjoys moving/running around in the house."
                        + "\n" + "Overall it seems" + vdr["PTP_NAME"] + "has Sensory Integration issues. He is Hypersensitive to Touch and Oral Input and is Hyposensitive to Movement." + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " + "\n" + "\n"));
                Vestibular.Colspan = 15;
                Vestibular.NoWrap = false;
                Vestibular.Border = 0;
                Vestibular.HorizontalAlignment = 3;
                BaseTable.AddCell(Vestibular);

                PdfPCell IMPRESSION = new PdfPCell(new Phrase("CLINICAL FINDINGS AND DIAGNOSTIC IMPRESSION:" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " 
                        + "• Features of Autism Spectrum Disorder with developmental delays especially are prominent at this time." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "• Sensory Integration issues." + "\n" + "\n"));
                IMPRESSION.Colspan = 15;
                IMPRESSION.NoWrap = false;
                IMPRESSION.Border = 0;
                IMPRESSION.HorizontalAlignment = 3;
                BaseTable.AddCell(IMPRESSION);

                PdfPCell RECOMMENDATIONS = new PdfPCell(new Phrase("RECOMMENDATIONS:" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " " 
                        + "1. TEACCH/ABA therapy is highly recommended" + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "2. Speech therapy with Oral Motor is recommended." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "3. Regular Occupational therapy with emphasis on Sensory Processing is highly recommended." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "4. Play school with intervention therapies is recommended." + "\n" + " " + " " + " " + " " + " " + " " + " " + " " + " " + " "
                        + "5. Use of digital resources like various communication apps, cognitive apps, rhymes etc can be used under adult guidance." + "\n" + "\n"));
                RECOMMENDATIONS.Colspan = 15;
                RECOMMENDATIONS.NoWrap = false;
                RECOMMENDATIONS.Border = 0;
                RECOMMENDATIONS.HorizontalAlignment = 3;
                BaseTable.AddCell(RECOMMENDATIONS);

                PdfPCell Vasal = new PdfPCell(new Phrase("Dr.Mukta Vasal, Ph.D" + "\n" + "Senior Consultant Child& Adolescent Psychologist" + "\n"
                        + "Educator for Gifted Learner (USA)" + "\n" 
                        + "TEACCH Autism Certified (USA)" + "\n" 
                        + "SIPT Certified (USA)" + "\n" + "\n"));
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

    protected void rdbtn1_CheckedChanged(object sender, EventArgs e)
    {
        Response.Write("View Selection changed");
    }

    protected void rdbtn2_CheckedChanged(object sender, EventArgs e)
    {
        Response.Write("No Selection changed");
    }
    protected void rdbtn3_CheckedChanged(object sender, EventArgs e)
    {
        Response.Write("Something Selection changed");
    }

    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        return cell;
    }

    protected void AddHeads(PdfPTable BaseTable)
    {
        PdfPCell cell = null;
        Phrase phrase = null;

        PdfPCell DDLPATIENT1 = new PdfPCell(new Phrase("PATIENT NAME", NormalFont));
        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        // cell.VerticalAlignment = PdfPCell.ALIGN_RIGHT;
        BaseTable.AddCell(DDLPATIENT1);
        PdfPCell PTP_GENDER_TXT = new PdfPCell(new Phrase("GENDER", NormalFont));
        // cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        cell.VerticalAlignment = PdfPCell.ALIGN_RIGHT;
        BaseTable.AddCell(PTP_GENDER_TXT);
        PdfPCell DDLAGE = new PdfPCell(new Phrase("AGE", NormalFont));
        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        // cell.VerticalAlignment = PdfPCell.ALIGN_RIGHT;
        BaseTable.AddCell(DDLAGE);
        PdfPCell DDLDIS = new PdfPCell(new Phrase("DISORDER NAME", NormalFont));
        // cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        cell.VerticalAlignment = PdfPCell.ALIGN_RIGHT;
        BaseTable.AddCell(DDLDIS);
        PdfPCell DOBS_DESC = new PdfPCell(new Phrase("DESCRIBE", NormalFont));
        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        // cell.VerticalAlignment = PdfPCell.ALIGN_RIGHT;
        BaseTable.AddCell(DOBS_DESC);
        PdfPCell PTAD_REMARK = new PdfPCell(new Phrase("REMARK", NormalFont));
        // cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        cell.VerticalAlignment = PdfPCell.ALIGN_RIGHT;
        BaseTable.AddCell(PTAD_REMARK);
    }

    protected void btnVideo_Click(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", vID);
        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  
        if (vDR != null)
        {
            Videolink.Value = vDR["AGRP_VIDEO_LINK"].ToString();
            string path = Videolink.Value;
            Page.Controls.Add(new LiteralControl("<video width='320' height='240' controls='controls'><source src=" + path + " type='video/mp4'></video>"));
        }

    }


        //protected void DDLPATIENT_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    String vID = Request.QueryString["ID"];

        //    Hashtable vHashtable = new Hashtable();
        //    vHashtable.Add("PTP_ID", vID);
        //    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
        //    if (vDR != null)
        //    {

        //        //TXTID.Value = vDR["PTS_ID"].ToString();
        //        // PTP_CUST_TXT.Text = vDR["PTP_NAME"].ToString();
        //        // PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
        //        PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
        //        PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
        //        //  PTP_CUST_TXT.Enabled = false;
        //        //  PTP_AGE_TXT.Enabled = false;
        //        PTP_GENDER_TXT.Enabled = false;
        //        PTP_MOB_TXT.Enabled = false;

        //    }

        // }
        //protected void checkboxNO_CheckedChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        //    int index = row.RowIndex;
        //    CheckBox cb1 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect");
        //    CheckBox cb2 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect1");
        //    CheckBox cb3 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect2");
        //    cb1.Checked = true;
        //    cb2.Checked = false;
        //    cb3.Checked = false;
        //    //string yourvalue = cb1.Text;
        //    //here you can find your control and get value(Id).

        //}
        //protected void checkboxYES_CheckedChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        //    int index = row.RowIndex;
        //    CheckBox cb1 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect");
        //    CheckBox cb2 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect1");
        //    CheckBox cb3 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect2");
        //    cb1.Checked = false;
        //    cb2.Checked = true;
        //    cb3.Checked = false;
        //    //string yourvalue = cb1.Text;
        //    //here you can find your control and get value(Id).

        //}
        //protected void checkboxSomething_CheckedChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        //    int index = row.RowIndex;
        //    CheckBox cb1 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect");
        //    CheckBox cb2 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect1");
        //    CheckBox cb3 = (CheckBox)GridView1.Rows[index].FindControl("chkSelect2");
        //    cb1.Checked = false;
        //    cb2.Checked = false;
        //    cb3.Checked = true;
        //    //string yourvalue = cb1.Text;
        //    //here you can find your control and get value(Id).

        //}
        public void Clear()
    {
    }

    protected void DDLAGE_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}
