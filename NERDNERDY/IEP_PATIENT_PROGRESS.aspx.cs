using System;
using System.Collections;
using System.Data;

public partial class IEP_PATIENT_PROGRESS : BasePage
{
    private ATSession vATSession;
    private DataRow vDR;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
        string[] urls_paramets = vID.Split(' ');
        string Id = urls_paramets[0];
        if (urls_paramets.Length > 5)
        {
            string Category = urls_paramets[5];
        }


        if (!IsPostBack)
        {
            try
            {
                ATCommon.FillDrpDown(DDLIEA, DBManager.Get(new Hashtable(), "CMB_IEP_SKILL_ACTIVITY"), "Select IEA Name", "IEPA_DESC", "IEPA_ID", "0");
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER_PATIENT_NEW"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");

                if (vATSession.UserType == "ADMIN")
                {
                    if (urls_paramets.Length == 6)
                    {
                        //Step- for checking the argument[5] is equal is Curriculum
                        if (urls_paramets[5] == "Curriculum")
                        {
                            getting_curriculum_data(); // for getting the data of curriculum activities
                            btnupdate.Visible = false;
                        }
                    }
                    else
                    {
                        getting_IEP_Activity_data(); // for getting the data of IEP activities
                        btnupdate.Visible = false;
                    }
                   // }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (urls_paramets.Length == 6)
                    {
                        //Step- for checking the argument[5] is equal is Curriculum
                        if (urls_paramets[5] == "Curriculum")
                        {
                            getting_curriculum_data();  // for getting the data of curriculum activities
                        }
                    }
                    else
                    {
                        getting_IEP_Activity_data();   // for getting the data of IEP activities
                    }
                   // }
                }

                else if (vATSession.UserType == "PATIENT" || vATSession.UserType == "Patient")
                {
                    //Step- for checking the argument[5] is equal is Curriculum
                    if (urls_paramets.Length == 6)
                    {
                        //Step- for checking the argument[5] is equal is Curriculum
                        if (urls_paramets[5] == "Curriculum")
                        {
                            getting_curriculum_data();  // for getting the data of curriculum activities
                        }
                    }
                    else
                    {
                        getting_IEP_Activity_data(); // for getting the data of Iep activities
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    //Step- for checking the argument[5] is equal is Curriculum
                    if (urls_paramets.Length == 6)
                    {
                        //Step- for checking the argument[5] is equal is Curriculum
                        if (urls_paramets[5] == "Curriculum")
                        {
                            getting_curriculum_data();  // for getting the data of curriculum activities
                        }
                    }
                    else
                    {
                        getting_IEP_Activity_data(); // for getting the data of IEP activities
                    }
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    // Trail for showing the Iep activity Data Start
    protected void getting_IEP_Activity_data()
    {
        String vID = Request.QueryString["ID"];
        string[] urls_paramets = vID.Split(' ');

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPAT_ID", urls_paramets[0]);
        DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_NEW"));
        if (vDR1 != null)
        {
            // For getting the name of category , sub-category, activity , date and disable=false start
            TXTID.Value = vDR1["IEPAT_ID"].ToString();
            IEPAT_REMARK.Text = vDR1["IEPAT_REMARK"].ToString();
            PTP_DATE_TXT.Text = vDR1["IEPAT_DATE"].ToString();
            DDLCAT.SelectedItem.Text = vDR1["DCAT_NAME"].ToString();
            DDLSUBCAT.SelectedItem.Text = vDR1["DSCAT_DESC"].ToString();
            DDLIEA.SelectedItem.Text = vDR1["IEPA_DESC"].ToString();
            TXTVALUE.Value = vDR1["IEPAT_DISID"].ToString();
            PTP_DATE_TXT.Enabled = false;
            DDLIEA.Enabled = false;
            DDLCAT.Enabled = false;
            DDLSUBCAT.Enabled = false;
            // For getting the name of category , sub-category, activity , date and disable=false End

            // for getting the checkbox selected Start
            if (vDR1["IEPAT_PRESENT"].ToString() == "1")
            {
                chkSelect1.Checked = true;
            }
            else
            {
                chkSelect1.Checked = false;
            }
            if (vDR1["IEPAT_ABSENT"].ToString() == "1")
            {
                chkSelect.Checked = true;
            }
            else
            {
                chkSelect.Checked = false;
            }
            if (vDR1["IEPAT_REG"].ToString() == "1")
            {
                chkSelect2.Checked = true;
            }
            else
            {
                chkSelect2.Checked = false;
            }
            if (IEPAT_REMARK.Text != "")
            {
                btnupdate.Visible = false;
            }
         // for getting the checkbox selected End
        }
        else
        {
            ShowMsg("Invalid IEP ID");
        }
    }
    // Trail for showing the Iep activity Data End

    // Trail for showing the Data Start
    protected void getting_curriculum_data()
    {
        String vID = Request.QueryString["ID"];
        string[] urls_paramets = vID.Split(' ');

        //Step 2- for checking the argument[5] is equal is Curriculum
        if (urls_paramets[5] == "Curriculum")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("IEPAT_ID", urls_paramets[0]);
            DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_CURRICULUM"));
            if (vDR1 != null)
            {
                // For getting the name of category , sub-category, activity , date and disable=false start
                TXTID.Value = vDR1["IEPAT_ID"].ToString();
                IEPAT_REMARK.Text = vDR1["IEPAT_REMARK"].ToString();
                PTP_DATE_TXT.Text = vDR1["IEPAT_DATE"].ToString();
                DDLCAT.SelectedItem.Text = vDR1["DCAT_NAME"].ToString();
                DDLSUBCAT.SelectedItem.Text = vDR1["DSCAT_DESC"].ToString();
                DDLIEA.SelectedItem.Text = vDR1["IEPA_DESC"].ToString();
                TXTVALUE.Value = vDR1["IEPAT_DISID"].ToString();
                PTP_DATE_TXT.Enabled = false;
                DDLIEA.Enabled = false;
                DDLCAT.Enabled = false;
                DDLSUBCAT.Enabled = false;
                // For getting the name of category , sub-category, activity , date and disable=false End

                // for getting the checkbox selected Start
                if (vDR1["IEPAT_PRESENT"].ToString() == "1")
                {
                    chkSelect1.Checked = true;
                }
                else
                {
                    chkSelect1.Checked = false;
                }
                if (vDR1["IEPAT_ABSENT"].ToString() == "1")
                {
                    chkSelect.Checked = true;
                }
                else
                {
                    chkSelect.Checked = false;
                }
                if (vDR1["IEPAT_REG"].ToString() == "1")
                {
                    chkSelect2.Checked = true;
                }
                else
                {
                    chkSelect2.Checked = false;
                }
                if (IEPAT_REMARK.Text != "")
                {
                    btnupdate.Visible = false;
                }
                // for getting the checkbox selected End
            }
        }
        //Step 3- else go the another table in iep_patient
        else
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("IEPAT_ID", urls_paramets[0]);
            DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_NEW"));
            if (vDR1 != null)
            {
                // For getting the name of category , sub-category, activity , date and disable=false Start
                TXTID.Value = vDR1["IEPAT_ID"].ToString();
                IEPAT_REMARK.Text = vDR1["IEPAT_REMARK"].ToString();
                PTP_DATE_TXT.Text = vDR1["IEPAT_DATE"].ToString();
                DDLCAT.SelectedItem.Text = vDR1["DCAT_NAME"].ToString();
                DDLSUBCAT.SelectedItem.Text = vDR1["DSCAT_DESC"].ToString();
                DDLIEA.SelectedItem.Text = vDR1["IEPA_DESC"].ToString();
                TXTVALUE.Value = vDR1["IEPAT_DISID"].ToString();
                PTP_DATE_TXT.Enabled = false;
                DDLIEA.Enabled = false;
                DDLCAT.Enabled = false;
                DDLSUBCAT.Enabled = false;
                // For getting the name of category , sub-category, activity , date and disable=false End

                // for getting the checkbox selected Start
                if (vDR1["IEPAT_PRESENT"].ToString() == "1")
                {
                    chkSelect1.Checked = true;
                }
                else
                {
                    chkSelect1.Checked = false;
                }
                if (vDR1["IEPAT_ABSENT"].ToString() == "1")
                {
                    chkSelect.Checked = true;
                }
                else
                {
                    chkSelect.Checked = false;
                }
                if (vDR1["IEPAT_REG"].ToString() == "1")
                {
                    chkSelect2.Checked = true;
                }
                else
                {
                    chkSelect2.Checked = false;
                }
                if (IEPAT_REMARK.Text != "")
                {
                    btnupdate.Visible = false;
                }
                // for getting the checkbox selected Start
            }
        }
    }
    // Trail for showing the Data End

    protected void Updatebtn_Click(object sender, EventArgs e)
    {
        string hdnID = chkSelect.Checked ? "1" : "0";
        string HiddenField1 = chkSelect1.Checked ? "1" : "0";
        string HiddenField2 = chkSelect2.Checked ? "1" : "0";

        String vID = Request.QueryString["ID"];
        string[] urls_paramets = vID.Split(' ');
        //Step 1- for checking the argument string is equal to 6
        if (urls_paramets.Length == 6)
        {
            //Step 2- for checking the argument[5] is equal is Curriculum
            if (urls_paramets[5] == "Curriculum")
            {
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("IEPAT_ID", TXTID.Value);
                vHashtable.Add("IEPAT_REMARK", IEPAT_REMARK.Text);
                vHashtable.Add("IEPAT_ABSENT", hdnID);
                vHashtable.Add("IEPAT_PRESENT", HiddenField1);
                vHashtable.Add("IEPAT_REG", HiddenField2);
                DBManager.ExecInsUps(vHashtable, "UPDATE_IEP_PATIENT_CURRICULUM", vATSession);
                ShowMsg("Update Successful");
                btnupdate.Visible = false;
            }
            else 
            {
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("IEPAT_ID", TXTID.Value);
                vHashtable.Add("IEPAT_REMARK", IEPAT_REMARK.Text);
                vHashtable.Add("IEPAT_ABSENT", hdnID);
                vHashtable.Add("IEPAT_PRESENT", HiddenField1);
                vHashtable.Add("IEPAT_REG", HiddenField2);
                DBManager.ExecInsUps(vHashtable, "UPDATE_IEPAT_ID", vATSession);
                ShowMsg("Update Successful");
                btnupdate.Visible = false;
            }
        }
        else
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("IEPAT_ID", TXTID.Value);
            vHashtable.Add("IEPAT_REMARK", IEPAT_REMARK.Text);
            vHashtable.Add("IEPAT_ABSENT", hdnID);
            vHashtable.Add("IEPAT_PRESENT", HiddenField1);
            vHashtable.Add("IEPAT_REG", HiddenField2);
            DBManager.ExecInsUps(vHashtable, "UPDATE_IEPAT_ID", vATSession);
            ShowMsg("Update Successful");
            btnupdate.Visible = false;
        }

         
    }

    protected void DDLCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DCAT_ID", DDLCAT.SelectedValue.ToString());
        vHashtable.Add("IEPDT_ID", vID);
        ATCommon.FillDrpDown(DDLSUBCAT, DBManager.Get(vHashtable, "CMB_CATEGORY_ID_NEW"), "Select Sub Category Name", "DSCAT_DESC", "DSCAT_ID", "");
    }
}