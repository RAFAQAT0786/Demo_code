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
            Div2.Visible = false;

            try
            {
                ValidateUserAccess();

                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                // hiding the Curriculum disorder in dropdown list
                DDLDIS.Items.FindByValue("1016").Enabled = false;

                if (vATSession.UserType == "ADMIN")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</ br>";

                        Binddata();
                        btnAssessment.Visible = false;

                        Hashtable vHashtable55 = new Hashtable();
                        vHashtable55.Add("PTAD_PTAID", TXTVALUE11.Value);
                        vHashtable55.Add("PTP_ID", vID);
                        vHashtable55.Add("AGRP_GROUP", PTP_AGE.Text);
                        vHashtable55.Add("PTA_ASEID", TXTVALUE1.Value);
                        vHashtable55.Add("ASER_DISID", DDLDIS.SelectedValue);
                        vHashtable55.Add("PTA_DISID", DDLDIS.SelectedValue);
                        DataTable dt33 = DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW");
                        DataRow vDR4 = RetDR(DBManager.Get(vHashtable55, "GET_PATIENT_ASSES_DETAIL_NEW"));
                        if (vDR4 == null)
                        {
                            Div1.Visible = false;
                            Div2.Visible = false;
                            btnSaveCurriculum.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID != null)
                    {
                        Binddata();
                    }
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</ br>";

                        Binddata();
                        //hiding the save button from Organization
                        btnAssessment.Visible = false;
                        btnSaveCurriculum.Visible = false;

                    }
                }
                else if (vATSession.UserType == "PATIENT" || vATSession.UserType == "Patient")
                {
                    if (vID != null)
                    {
                        //Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        //"<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</ br>";
                        Instructions.Visible = false;
                        HiddenField5.Value = "Patient";

                        Binddata();

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                        if (vDR != null)
                        {
                            btnAssessment.Visible = false;
                        }

                    }
                }
                else if (vATSession.UserType == "PARENT" || vATSession.UserType == "Parent")
                {
                    if (vID != null)
                    {
                        Label1.Text = "NerdNerdy's Assessment & Customized IEP scale would help you developing comprehensive IEP, thus leading towards systematic  intervention process." +
                        "<br> Try to answer all question in either <b>'Yes'/'No' or 'Sometimes'.</ br>";

                        Binddata();

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN")); 
                        if (vDR != null)
                        {
                            HiddenField4.Value = vDR["PTP_CUSTID"].ToString();
                        }

                        Hashtable vHashtable6 = new Hashtable();
                        vHashtable6.Add("PTPP_CUSTID", HiddenField4.Value);
                        DataRow vDR6 = RetDR(DBManager.Get(vHashtable6, "GET_PARENT_CUSTID"));
                        if (vDR6 != null)
                        {
                            DDLDIS.SelectedValue = vDR6["PTPP_DISID"].ToString();
                            DDLDIS.Enabled = false;
                            btnSave.Visible = true;
                        }

                    }

                    Hashtable vHashtable60 = new Hashtable();
                    vHashtable60.Add("PTACD_PTPID", vID);
                    DataTable dt60 = DBManager.Get(vHashtable60, "GET_PATIENT_CURRICULUM_OBSERVATION");
                    DataRow vDR60 = RetDR(DBManager.Get(vHashtable60, "GET_PATIENT_CURRICULUM_OBSERVATION"));

                    if (vDR60 == null)
                    {

                        if (PTP_AGE.Text == "8-9" || PTP_AGE.Text == "9-10" || PTP_AGE.Text == "10-11")
                        {
                            Hashtable vHashtable1 = new Hashtable();
                            vHashtable1.Add("AGRP_ID", HiddenField1.Value);
                            vHashtable1.Add("ASER_DISID", DDLDIS.SelectedValue);
                            vHashtable1.Add("SECOND_AGRPID", "15");
                            DataTable dt1 = DBManager.Get(vHashtable1, "GET_CURRICULUM_OBSERVATION_MASTER");
                            GridView4.DataSource = dt1;
                            GridView4.DataBind();
                            ASE_ID1.Visible = false;
                            AGDD.Visible = false;
                            Div1.Visible = true;
                            btnSave.Visible = false;
                            AGDD.Visible = false;
                            btnSaveCurriculum.Visible = true;
                        }

                        else if (PTP_AGE.Text == "11-12" || PTP_AGE.Text == "12-13" || PTP_AGE.Text == "13-14" || PTP_AGE.Text == "14-15" || PTP_AGE.Text == "15-16")
                        {
                            Hashtable vHashtable1 = new Hashtable();
                            vHashtable1.Add("AGRP_ID", HiddenField1.Value);
                            vHashtable1.Add("ASER_DISID", DDLDIS.SelectedValue);
                            vHashtable1.Add("SECOND_AGRPID", "16");
                            DataTable dt1 = DBManager.Get(vHashtable1, "GET_CURRICULUM_OBSERVATION_MASTER");
                            GridView4.DataSource = dt1;
                            GridView4.DataBind();
                            ASE_ID1.Visible = false;
                            AGDD.Visible = false;
                            Div1.Visible = true;
                            btnSave.Visible = false;
                            AGDD.Visible = false;
                            btnSaveCurriculum.Visible = true;
                        }

                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    Binddata();
                }
                else
                {
                    ShowMsg("Invalid Patient ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    // Binding the get data from Binddata Start
    protected void Binddata()
    {
        String vID = Request.QueryString["ID"];

        if (vID != null)
        {
           
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", vID);
            DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));  
            if (vDR != null)
            {
                PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                
                PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                PTP_AGE.Text = vDR["AGRP_GROUP"].ToString();
                PTP_NAME.Enabled = false;
                PTP_AGE.Enabled = false;
                PTP_MOB_TXT.Enabled = false;
                PTP_GENDER_TXT.Enabled = false;
                ASE_ID1.Visible = false;
                doctor_id.Visible = false;
                btnSave.Visible = false;
                HiddenField4.Value = vDR["PTP_CUSTID"].ToString();
                HiddenField1.Value = vDR["AGRP_ID"].ToString();
                //hide extra div
                Div1.Visible = false;
                AGDD.Visible = false;
                btnSaveCurriculum.Visible = false;
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
        
        if (vDR4 == null)
        {
            GridView1.DataSource = dt33;
            GridView1.DataBind();
            GridView1.Visible = true;
            btnSave.Visible = true;
            ASE_ID1.Visible = false;
            AGDD.Visible = true;
            doctor_id.Visible = false;
            btnSave.Visible = false;
        }
        else
        {
            GridView3.DataSource = dt33;
            GridView3.DataBind();
            btnSave.Visible = false;
            AGDD.Visible = false;
            doctor_id.Visible = true;
            ASE_ID1.Visible = false;
            btnAssessment.Visible = false;
            Div1.Visible = false;
            Div2.Visible = false;
            btnSaveCurriculum.Visible = false;

            Hashtable vHashtable07 = new Hashtable();
            vHashtable07.Add("VD_ANMID", "2");
            vHashtable07.Add("VD_AGRPID", HiddenField1.Value);
            vHashtable07.Add("VD_DISID", DDLDIS.SelectedValue);
            DataTable dt07 = DBManager.Get(vHashtable07, "GET_TEMPLATE_VIDEO_LINK");
            DataRow vDR07 = RetDR(DBManager.Get(vHashtable07, "GET_TEMPLATE_VIDEO_LINK"));
            if (vDR07 != null)
            {
                HiddenField2.Value = vDR07["VD_VIDEO_LINK"].ToString();
            }
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

        //for getting the data from patient curriculum master Start

        Hashtable vHashtable60 = new Hashtable();
        vHashtable60.Add("PTACD_PTPID", vID);
        DataTable dt60 = DBManager.Get(vHashtable60, "GET_PATIENT_CURRICULUM_OBSERVATION");
        DataRow vDR6 = RetDR(DBManager.Get(vHashtable60, "GET_PATIENT_CURRICULUM_OBSERVATION"));
        if (vDR6 != null)
        {
            GridView4.DataSource = dt60;
            GridView4.DataBind();
            GridView4.Visible = true;
            Div2.Visible = true;
            btnSave.Visible = false;
            ASE_ID1.Visible = false;
            AGDD.Visible = false;
            doctor_id.Visible = false;
            Div1.Visible = false;
            btnSave.Visible = false;
            btnSaveCurriculum.Visible = false;
            btnAssessment.Visible = false;
            DDLDIS.SelectedIndex = DDLDIS.Items.IndexOf(DDLDIS.Items.FindByValue(vDR6["PTAC_DISID"].ToString()));
            DDLDIS.Enabled = false;

            Hashtable vHashtable4 = new Hashtable();
            vHashtable4.Add("PTACD_PTPID", vID);
            DataTable dt1 = DBManager.Get(vHashtable4, "GET_PATIENT_CURRICULUM_OBSERVATION_DISORDER");
            GridView5.DataSource = dt1;
            GridView5.DataBind();

        }

        //for getting the data from patient curriculum master End
    }
    // Binding the get data from Binddata End

    //Gridview2 is used in Customised IEP for showing the Iep in next page start
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
    //Gridview2 is used in Customised IEP for showing the Iep in next page End

    //Button Assessment is used in finding the data which was linking with Disorder start
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
            if (dt.Columns.Count == 13)/*24-12-2018*/
         //  if(vDR4 == null)
            {

            //testing for the age group above 8-9 1-2 for getting the data from CURRICULUM table Start

            if (PTP_AGE.Text == "8-9" || PTP_AGE.Text == "9-10" || PTP_AGE.Text == "10-11")
            {
                Hashtable vHashtable1 = new Hashtable();
                vHashtable1.Add("AGRP_ID", HiddenField1.Value);
                vHashtable1.Add("ASER_DISID", DDLDIS.SelectedValue);
                vHashtable1.Add("SECOND_AGRPID", "15");
                DataTable dt1 = DBManager.Get(vHashtable1, "GET_CURRICULUM_OBSERVATION_MASTER");
                GridView4.DataSource = dt1;
                GridView4.DataBind();
                ASE_ID1.Visible = false;
                AGDD.Visible = false;
                Div1.Visible = true;
                btnSave.Visible = false;
                AGDD.Visible = false;
                btnSaveCurriculum.Visible = true;
            }

           else if (PTP_AGE.Text == "11-12" || PTP_AGE.Text == "12-13" || PTP_AGE.Text == "13-14" || PTP_AGE.Text == "14-15" || PTP_AGE.Text == "15-16")
            {
                Hashtable vHashtable1 = new Hashtable();
                vHashtable1.Add("AGRP_ID", HiddenField1.Value);
                vHashtable1.Add("ASER_DISID", DDLDIS.SelectedValue);
                vHashtable1.Add("SECOND_AGRPID", "16");
                DataTable dt1 = DBManager.Get(vHashtable1, "GET_CURRICULUM_OBSERVATION_MASTER");
                GridView4.DataSource = dt1;
                GridView4.DataBind();
                ASE_ID1.Visible = false;
                AGDD.Visible = false;
                Div1.Visible = true;
                btnSave.Visible = false;
                AGDD.Visible = false;
                btnSaveCurriculum.Visible = true;
            }

            //testing for the age group 1-2 for getting the data from CURRICULUM table ENd
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Visible = true;
                btnSave.Visible = true;
                ASE_ID1.Visible = false;
                AGDD.Visible = true;
                doctor_id.Visible = false;
                btnSave.Visible = true;
            }

            Hashtable vHashtable07 = new Hashtable();
            vHashtable07.Add("VD_ANMID", "2");
            vHashtable07.Add("VD_AGRPID", HiddenField1.Value);
            vHashtable07.Add("VD_DISID", DDLDIS.SelectedValue);
            DataTable dt07 = DBManager.Get(vHashtable07, "GET_TEMPLATE_VIDEO_LINK");
            DataRow vDR07 = RetDR(DBManager.Get(vHashtable07, "GET_TEMPLATE_VIDEO_LINK"));
            if (vDR07 != null)
            {
                HiddenField2.Value = vDR07["VD_VIDEO_LINK"].ToString();
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

            Hashtable vHashtable07 = new Hashtable();
            vHashtable07.Add("VD_ANMID", "2");
            vHashtable07.Add("VD_AGRPID", HiddenField1.Value);
            vHashtable07.Add("VD_DISID", DDLDIS.SelectedValue);
            DataTable dt07 = DBManager.Get(vHashtable07, "GET_TEMPLATE_VIDEO_LINK");
            DataRow vDR07 = RetDR(DBManager.Get(vHashtable07, "GET_TEMPLATE_VIDEO_LINK"));
            if (vDR07 != null)
            {
                HiddenField2.Value = vDR07["VD_VIDEO_LINK"].ToString();
            }
            
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
    //Button Assessment is used in finding the data which was linking with Disorder End

    //Button Save is used to assessment where the age group is less than 7-8 start
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
                                    vHashtable2.Add("PTAD_VALUE", HiddenField1);
                                    vHashtable2.Add("TYPE", "INS");
                                    DBManager.ExecInsUps(vHashtable2, "INS_PTA_ASSES_DETAIL", (ATSession)Session["User"]);
                                    data = data + ID + " ,  " + TXTID + " , " + ASED_ID + "<br>";

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
            }
        }
    }
    //Button Save is used to assessment where the age group is less than 7-8 End

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

    
    public void Clear()
    {
    }

    //for saving the curriculum and other data into curriculum table Start
    protected void btnSaveCurriculum_Click(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];
        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("PTAC_ID", TXTVALUE11.Value);
        vHashtable1.Add("PTAC_CUSTID", HiddenField4.Value);
        vHashtable1.Add("PTAC_DISID", DDLDIS.SelectedValue);
        if (DBManager.ExecInsUpsReturn(vHashtable1, "INS_PTA_CURRICULUM_MASTER", (ATSession)Session["User"]))
        {
            if (Page.IsValid)
            {
                if (GridView4.Rows.Count > 0)
                    try
                    {
                        string data = "";
                        int last_length = GridView4.Rows.Count;
                        int current_row = 0;
                        foreach (GridViewRow grd in GridView4.Rows)
                        {
                            Label CURRICULUM_ID = (Label)grd.FindControl("CURRICULUM_ID");
                            TextBox PTAD_REMARK = (TextBox)grd.FindControl("PTAD_REMARK");
                            TextBox PTAD_SCALE = (TextBox)grd.FindControl("PTAD_SCALE");
                            
                            current_row++;

                            if (grd.RowType == DataControlRowType.DataRow)
                            {
                                RadioButton chkRow = (grd.Cells[0].FindControl("rdbtn2") as RadioButton);
                                string HiddenField1 = chkRow.Checked ? "1" : "0";
                                RadioButton chkRow1 = (grd.Cells[1].FindControl("rdbtn1") as RadioButton);
                                string HiddenField2 = chkRow1.Checked ? "1" : "0";
                                
                                if(current_row == last_length -1)
                                {
                                    chkRow.Checked = true;
                                }
                                if (chkRow.Checked)
                                {
                                    Hashtable vHashtable2 = new Hashtable();
                                    vHashtable2.Add("PTACD_ID", ID.Value);
                                    vHashtable2.Add("PTACD_PTACID", TXTVALUE11.Value);
                                    vHashtable2.Add("PTACD_PTPID", vID);
                                    vHashtable2.Add("PTACD_CURRICULUMID", CURRICULUM_ID.Text);
                                    vHashtable2.Add("PTACD_REMARK", PTAD_REMARK.Text);
                                    vHashtable2.Add("PTACD_SOMETHING", HiddenField2);
                                    vHashtable2.Add("PTACD_SCALE", "");
                                    vHashtable2.Add("PTACD_VALUE", HiddenField1);
                                    DBManager.ExecInsUps(vHashtable2, "INS_PTA_CURRICULUM_DETAIL", (ATSession)Session["User"]);
                                   
                                }
                                else if (chkRow1.Checked)
                                {
                                    Hashtable vHashtable2 = new Hashtable();
                                    vHashtable2.Add("PTACD_ID", ID.Value);
                                    vHashtable2.Add("PTACD_PTACID", TXTVALUE11.Value);
                                    vHashtable2.Add("PTACD_PTPID", vID);
                                    vHashtable2.Add("PTACD_CURRICULUMID", CURRICULUM_ID.Text);
                                    vHashtable2.Add("PTACD_REMARK", PTAD_REMARK.Text);
                                    vHashtable2.Add("PTACD_SOMETHING", HiddenField2);
                                    vHashtable2.Add("PTACD_SCALE", "");
                                    vHashtable2.Add("PTACD_VALUE", HiddenField1);
                                    DBManager.ExecInsUps(vHashtable2, "INS_PTA_CURRICULUM_DETAIL", (ATSession)Session["User"]);
                                }
                            }
                        }
                        doctor_id.Visible = false;
                        Div2.Visible = true;
                        Response.Redirect("Patient_Doctor_Assessment.aspx?id=" + vID);
                    }
                    catch (Exception xe)
                    {
                        ShowMsg(xe);
                    }
            }
        }
    }

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt16(e.CommandArgument);
            if (e.CommandName == "PATIENT")
            {

                Label PTAC_ID = (Label)GridView5.Rows[index].FindControl("PTAC_ID");
                String vID = Request.QueryString["ID"];
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("PTP_ID", vID);
                DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ID");
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("Assessment_Word.aspx?id=" + vID + "&id1=" + PTAC_ID.Text);
                }
            }
        }
    //for saving the curriculum data into curriculum table End

}
