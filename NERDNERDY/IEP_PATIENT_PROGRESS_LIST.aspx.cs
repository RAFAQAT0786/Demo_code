using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;
using System.Configuration;
using InfoSoftGlobal;
using Utilities;
using System.Text;

public partial class IEP_PATIENT_PROGRESS_LIST : BasePage
{
    ATSession vATSession;
    DataTable dt;
    DataTable dt1;
    Util util = new Util();
    DataRow vDR;
    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        string strPreviousPage = string.Empty;
        if (Request.UrlReferrer != null)
        {
            strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
        }
        if (strPreviousPage == "")
        {
            Response.Redirect("~/Default.aspx");
        }

        String vID = Request.QueryString["id1"];

        if (!IsPostBack)
        {
            try
            {
                Hashtable vHashtable5 = new Hashtable();
                vHashtable5.Add("PTP_ID", vID);
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(vHashtable5, "CMB_DIS_CAT"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");
                Hashtable vHashtable6 = new Hashtable();
                vHashtable6.Add("PTP_ID", vID);
                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(vHashtable6, "CMB_DIS_MASTER_ID"), "Select DisOrder Name", "DIS_NAME", "DIS_ID", "0");

                //FOR CURRICULUM IEP 
                Hashtable vHashtable7 = new Hashtable();
                vHashtable7.Add("PTP_ID", vID);
                ATCommon.FillDrpDown(DDLCUMCAT, DBManager.Get(vHashtable7, "CMB_DIS_CAT_MASTER_CURRICULUM_NEW"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");

                if (vATSession.UserType == "ADMIN")
                {
                    if (vID != null)
                    {
                        //Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategy for the skills that you want to include in your IEP of your patient." +
                        //"<br><b>Suggested Activity:</b> Comprehensive list of suggetsed activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them per you need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        //"<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need cutomized intervention resources for our patients, which can be hands on and research backed. Its our constant endeviour of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        //"<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources form website, if find them useful for your patients.</ br>" +
                        //"<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.  The progress table and graph chart of progress can help you get the details of the current level of your patient's skill development. The progress can be viewed date wise, weekly or monthly.</ br>" +
                        //"<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accompolished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) Not accomolishe (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the update button in order to save the progress of your patient.</br>";

                        getting_IEP_Curriculum_data();
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID != null)
                    {
                        //Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategy for the skills that you want to include in your IEP of your patient." +
                        //"<br><b>Suggested Activity:</b> Comprehensive list of suggetsed activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them per you need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        //"<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need cutomized intervention resources for our patients, which can be hands on and research backed. Its our constant endeviour of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        //"<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources form website, if find them useful for your patients.</ br>" +
                        //"<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.  The progress table and graph chart of progress can help you get the details of the current level of your patient's skill development. The progress can be viewed date wise, weekly or monthly.</ br>" +
                        //"<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accompolished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) Not accomolishe (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the update button in order to save the progress of your patient.</br>";

                        getting_IEP_Curriculum_data();
                    }
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    if (vID != null)
                    {
                        //Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategy for the skills that you want to include in your IEP of your patient." +
                        //"<br><b>Suggested Activity:</b> Comprehensive list of suggetsed activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them per you need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        //"<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need cutomized intervention resources for our patients, which can be hands on and research backed. Its our constant endeviour of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        //"<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources form website, if find them useful for your patients.</ br>" +
                        //"<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.  The progress table and graph chart of progress can help you get the details of the current level of your patient's skill development. The progress can be viewed date wise, weekly or monthly.</ br>" +
                        //"<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accompolished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) Not accomolishe (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the update button in order to save the progress of your patient.</br>";

                        getting_IEP_Curriculum_data();
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    if (vID != null)
                    {
                        //Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategy for the skills that you want to include in your IEP of your patient." +
                        //"<br><b>Suggested Activity:</b> Comprehensive list of suggetsed activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them per you need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        //"<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need cutomized intervention resources for our patients, which can be hands on and research backed. Its our constant endeviour of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        //"<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources form website, if find them useful for your patients.</ br>" +
                        //"<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.  The progress table and graph chart of progress can help you get the details of the current level of your patient's skill development. The progress can be viewed date wise, weekly or monthly.</ br>" +
                        //"<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accompolished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) Not accomolishe (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the update button in order to save the progress of your patient.</br>";

                        getting_IEP_Curriculum_data();
                    }
                }

                else if (vATSession.UserType == "PATIENT" || vATSession.UserType == "Patient")
                {
                    if (vID != null)
                    {
                        //Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategy for the skills that you want to include in your IEP of your patient." +
                        //"<br><b>Suggested Activity:</b> Comprehensive list of suggetsed activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them per you need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        //"<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need cutomized intervention resources for our patients, which can be hands on and research backed. Its our constant endeviour of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        //"<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources form website, if find them useful for your patients.</ br>" +
                        //"<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.  The progress table and graph chart of progress can help you get the details of the current level of your patient's skill development. The progress can be viewed date wise, weekly or monthly.</ br>" +
                        //"<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accompolished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) Not accomolishe (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the update button in order to save the progress of your patient.</br>";
                        progress.Visible = false;
                        getting_IEP_Curriculum_data();
                    }
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    //For showing the Iep activity and Curriculum Data in all master using same function Start
    protected void getting_IEP_Curriculum_data()
    {
        String vID = Request.QueryString["id1"]; // Patient id

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", vID);
        dt = DBManager.Get(vHashtable, "GET_IEP_PATIENT_PTPID_NEW");
        DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_PTPID_NEW"));
        //dt = DBManager.Get(vHashtable, "GET_IEP_PATIENT_PTPID");
        //DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_PTPID"));
        if (vDR1 != null)
        {
            TXTID.Value = vDR1["IEPAT_ID"].ToString();
            PTP_TXT.Text = vDR1["PTP_NAME"].ToString();
            DDLDIS.SelectedItem.Text = vDR1["DIS_NAME"].ToString();
            HiddenField4.Value = vDR1["DIS_ID"].ToString();
            DDLDIS.Enabled = false;
            PTP_TXT.Enabled = false;
            IEPAT_ID.DataSource = dt;
            IEPAT_ID.DataBind();

            //FOR CURRICULUM PATIENT NAME START
            TXT_CUR_PATIENT.Text = vDR1["PTP_NAME"].ToString();
            TXT_CUR_PATIENT.Enabled = false;
            //FOR CURRICULUM PATIENT NAME END

            //FOR TESTING THE CURRICULUM TEMPLATE START 
            Hashtable vHashtable1 = new Hashtable();
            vHashtable1.Add("IEPDT_ID", "16");
            DataRow vDR6 = RetDR(DBManager.Get(vHashtable1, "GET_IEPDT_CURRICULUM"));
            if (vDR6 != null)
            {
                CURRICULUM.Value = vDR6["IEPDT_ID"].ToString();
                //DDLCUMDIS.SelectedValue = vDR6["IEPDT_DISID"].ToString();
                TXT_CUR_DISORDER.Text = vDR6["DIS_NAME"].ToString();
                TXT_CUR_DISORDER.Enabled = false;
                //Creator.Visible = false;

            }
            else
            {
                ShowMsg("Invalid Curriculum IEP ID");
            }
            //FOR TESTING THE CURRICULUM TEMPLATE START 

            //binding for CURRICULUM IEP Start
            BindGrid2();
            //binding for CURRICULUM IEP ENd

            //binding for created iep by therapist
            BindGrid1();


            foreach (GridViewRow row in IEPAT_ID.Rows)
            {
                CheckBox chkRow = (row.Cells[3].FindControl("chkSelect") as CheckBox);
                CheckBox chkRow1 = (row.Cells[4].FindControl("chkSelect") as CheckBox);
                CheckBox chkRow2 = (row.Cells[5].FindControl("chkSelect") as CheckBox);

                if (chkRow != null && chkRow1.Checked)
                {
                    chkRow.Checked = true;
                }
                else
                {
                    chkRow.Checked = false;
                }
                if (chkRow1 != null && chkRow1.Checked)
                {
                    chkRow1.Checked = true;
                }
                else
                {
                    chkRow1.Checked = false;
                }
                if (chkRow2 != null && chkRow1.Checked)
                {
                    chkRow2.Checked = true;
                }
                else
                {
                    chkRow2.Checked = false;
                }

                //IEPAT_ID.Enabled = false;
            }
        }
        else
        {
            ShowMsg("Invalid IEP ID");
        }
    }
    //For showing the Iep activity and Curriculum Data in all master using same function End

    protected void DDLCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["id1"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DCAT_ID", DDLCAT.SelectedValue.ToString());
        vHashtable.Add("PTP_ID", vID);
        ATCommon.FillDrpDown(DDLSUBCAT, DBManager.Get(vHashtable, "CMB_CATEGORY_IEPATID"), "Select Sub Category Name", "DSCAT_DESC", "DSCAT_ID", "");
    }

    protected void DDLSUBCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["id1"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", vID);
        vHashtable.Add("DSCAT_ID", DDLSUBCAT.SelectedValue.ToString());
        dt1 = DBManager.Get(vHashtable, "GET_IEP_PATIENT_DSCATID");
        IEPAT_ID.DataSource = dt1;
        IEPAT_ID.DataBind();
    }

    protected void IEPAT_ID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        String vID = Request.QueryString["id1"];

        IEPAT_ID.PageIndex = e.NewPageIndex;
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", vID);
        //dt = DBManager.Get(vHashtable, "GET_IEP_PATIENT_PTPID");
        dt = DBManager.Get(vHashtable, "GET_IEP_PATIENT_PTPID_NEW");
        IEPAT_ID.DataSource = dt;
        IEPAT_ID.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        String CCID = Request.QueryString["id1"];
        if (DDLDIS.SelectedItem.Text != "-- Select DisOrder Name --")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("IEPAT_DISID", DDLDIS.SelectedValue.ToString());
            vHashtable.Add("PTP_ID", CCID);
            DataTable dt = DBManager.Get(vHashtable, "CMB_DIS_ID");
            IEPAT_ID.DataSource = dt;
            IEPAT_ID.DataBind();
        }
        else
        {
            string message = "Please Select The Disorder First.!!";
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

    protected void btnDate_Click(object sender, EventArgs e)
    {
       
        String CCID = Request.QueryString["id1"];
        if (PTP_FROM_TXT.Text != "" && PTP_TO_TXT.Text != "")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", CCID);
            vHashtable.Add("IEPAT_FROMDATE", PTP_FROM_TXT.Text);
            vHashtable.Add("IEPAT_TODATE", PTP_TO_TXT.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_IEP_DATEWISE");
            IEPAT_ID.DataSource = dt;
            IEPAT_ID.DataBind();
        }
        else
        {
            string message = "Please Select From And To Date First.!!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        PTP_FROM_TXT.Text = "";
        PTP_TO_TXT.Text = "";
    }

    //For getting the value of IEP Created Therapist's Start

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid1();
    }

    protected void BindGrid1()
    {
        String CCID = Request.QueryString["id1"];

        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("DIS_ID", HiddenField4.Value);
        vHashtable1.Add("PTP_ID", CCID);
        dt = DBManager.Get(vHashtable1, "GET_IEP_ACTIVITIES");
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //GridView1.Enabled = false;
        DDLDIS.Enabled = false;
    }

    protected void btnTherapistDate_Click(object sender, EventArgs e)
    {

        String CCID = Request.QueryString["id1"];
        if (THERAPIST_FROM_DATE.Text != "" && THERAPIST_TO_DATE.Text != "")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", CCID);
            vHashtable.Add("IEPAT_FROMDATE", THERAPIST_FROM_DATE.Text);
            vHashtable.Add("IEPAT_TODATE", THERAPIST_TO_DATE.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_IEP_DATEWISE_THERAPIST");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            string message = "Please Select From And To Date First.!!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        THERAPIST_FROM_DATE.Text = "";
        THERAPIST_TO_DATE.Text = "";
    }

    //For getting the value of IEP Created Therapist's End


    //For getting the value of Curriculum IEP Start

    //FOR CURRICULUM IEP START
    protected void DDLCUMCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["id1"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DCAT_ID", DDLCUMCAT.SelectedValue.ToString());
        vHashtable.Add("IEPDT_ID", CURRICULUM.Value);
        vHashtable.Add("IEPAT_PTPID", vID);
        ATCommon.FillDrpDown(DDLCUMSUBCAT, DBManager.Get(vHashtable, "CMB_CATEGORY_ID_PROGRESS"), "Select Sub Category Name", "DSCAT_DESC", "DSCAT_ID", "");
    }

    protected void DDLCUMSUBCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["id1"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", vID);
        vHashtable.Add("DSCAT_ID", DDLCUMSUBCAT.SelectedValue.ToString());
        dt1 = DBManager.Get(vHashtable, "GET_IEP_PATIENT_DSCATID_CURRICULUM");
        GridView2.DataSource = dt1;
        GridView2.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        BindGrid2();
    }

    protected void BindGrid2()
    {
        String CCID = Request.QueryString["id1"];

        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("IEPAT_DISID", "1016");
        vHashtable1.Add("PTP_ID", CCID);
        dt = DBManager.Get(vHashtable1, "CMB_DIS_ID_CURRICULUM");
        GridView2.DataSource = dt;
        GridView2.DataBind();
        //GridView2.Enabled = false;
        TXT_CUR_DISORDER.Enabled = false;
    }

    protected void btnCurSearchDate_Click(object sender, EventArgs e)
    {
        String CCID = Request.QueryString["id1"];
        if (CURRICULUM_FROM_TXT.Text != "" && CURRICULUM_TO_TXT.Text != "")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", CCID);
            vHashtable.Add("IEPAT_FROMDATE", CURRICULUM_FROM_TXT.Text);
            vHashtable.Add("IEPAT_TODATE", CURRICULUM_TO_TXT.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_IEP_DATEWISE_CURRICULUM");
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        else
        {
            string message = "Please Select From And To Date First.!!";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        CURRICULUM_FROM_TXT.Text = "";
        CURRICULUM_TO_TXT.Text = "";
    }

    //For getting the value of Curriculum IEP End

    //for disabled the checkbox in gridview start
    protected void IEPAT_ID_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (true)
            {
                e.Row.Cells[3].Enabled = false;
                e.Row.Cells[4].Enabled = false;
                e.Row.Cells[5].Enabled = false;
            }
        }
    }
    //for disabled the checkbox in gridview End

    //for disabled the checkbox in gridview start
    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (true)
            {
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[7].Enabled = false;
                e.Row.Cells[8].Enabled = false;
            }
        }
    }
    //for disabled the checkbox in gridview End

    //for disabled the checkbox in gridview start
    protected void GridView2_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (true)
            {
                e.Row.Cells[1].Enabled = false;
                e.Row.Cells[2].Enabled = false;
                e.Row.Cells[3].Enabled = false;
                e.Row.Cells[4].Enabled = false;

                //texting for checkbox
                e.Row.Cells[5].Enabled = false;
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[7].Enabled = false;
                e.Row.Cells[8].Enabled = false;
            }
        }
    }
    //for disabled the checkbox in gridview End

}