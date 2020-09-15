using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;
using System.ComponentModel;

public partial class Patient_Doctor_Screening : BasePage
{
    ATSession vATSession;
    DataTable dt;
    DataTable dt1;
    DataTable dt2;
    DataTable dt3;
    DataTable dt4;
    private int CheckBoxIndex;
    private bool CheckAllWasChecked;

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
            dt1 = new DataTable();
            DataColumn DOBS_DESC = new DataColumn();
            DOBS_DESC.DataType = Type.GetType("System.String");
            DOBS_DESC.ColumnName = "DOBS_DESC";
            dt1.Columns.Add(DOBS_DESC);

            DataColumn PTS_REMARK = new DataColumn();
            PTS_REMARK.DataType = Type.GetType("System.String");
            PTS_REMARK.ColumnName = "PTS_REMARK";
            dt1.Columns.Add(PTS_REMARK);

            DataColumn PTS_ID = new DataColumn();
            PTS_ID.DataType = Type.GetType("System.String");
            PTS_ID.ColumnName = "PTS_ID";
            dt1.Columns.Add(PTS_ID);

            doctor_id.Visible = true;
            ViewState["datagrid"] = dt1;

            try
            {
                ValidateUserAccess();

                if (vATSession.UserType == "ADMIN")
                {
                    if (vID != null)
                    {
                        Label1.Text = "This Screening tool is designed to identify children from the ages of 2 to 8 years, who may be at a risk of neurodevelopmental disorders. Based on the screening results, the child can be further referred for comprehensive assessment by the certified professional." +
                        "<br>Please answer the given questions that best describes the child, based on your observations (by certified mental health professional) and from the inputs of the caregiver. Try your best to answer all the questions either in <b>'Yes'  or 'No' .</b>. After all the questions are answered, click the save button. The results of disorders  are shown as Scored Rank.";

                        Label2.Text = "NerdNerdy’s screening scale is to be used for the reference purposes only, by the registered medical and rehabilitation practitioners . The results of the tests should be  clinically correlated by the medical/rehabilitation specialist. The screening tool should not be understood to constitute any type of diagnosis or healthcare recommendation for patients.";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            AGRP_ID.Value = vDR["AGRP_ID"].ToString();
                            PTP_AGE_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_NAME.Enabled = false;
                            btnSave.Visible = false;
                            TXTVALUE.Value = vDR["PTP_CUSTID"].ToString();

                            btnSave.Visible = false;
                            pt1.Visible = false;
                            remark.Visible = false;
                            dis.Visible = false;
                            doctor_id.Visible = false;
                        }
                        Hashtable vHashtable9 = new Hashtable();
                        vHashtable9.Add("AGRP_ID", AGRP_ID.Value);
                        DataRow vDR9 = RetDR(DBManager.Get(vHashtable9, "GET_SCT_MASTER_NEW"));
                        if (vDR9 != null)
                        {
                            SCTP_ID.Value = vDR9["SCTP_ID"].ToString();
                        }

                        Hashtable vHashtable10 = new Hashtable();
                        vHashtable10.Add("PTP_ID", vID);
                        vHashtable10.Add("SCTP_ID", SCTP_ID.Value);
                        DataRow vDR10 = RetDR(DBManager.Get(vHashtable10, "GET_SCREEN_MASTER"));
                        if (vDR10 != null)
                        {
                            HiddenField3.Value = vDR10["PTS_ID"].ToString();
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTS_ID", HiddenField3.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt1 = DBManager.Get(vHashtable1, "GET_PTS_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTS_ID"));
                        PTP_REMARK_TXT.Text = dt1.Rows[0]["PTS_REMARK"].ToString();
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();

                        btnSave.Visible = false;
                        btnScreen.Visible = false;
                        PTP_REMARK_TXT.Enabled = false;
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        GridView1.Enabled = false;

                        Hashtable vHashtable3 = new Hashtable();
                        vHashtable3.Add("AGE", PTP_AGE_TXT.Text);
                        vHashtable3.Add("PTP_ID", vID);
                        vHashtable3.Add("PTS_ID", HiddenField3.Value);
                        vHashtable3.Add("SCTP_ID", SCTP_ID.Value);
                        dt2 = DBManager.Get(vHashtable3, "GET_DISORDER_PERCENTAGE_NEW_ID");
                        GridView2.DataSource = dt2;
                        GridView2.DataBind();
                        GridView2.Visible = true;

                        pt1.Visible = true;
                        remark.Visible = true;
                        dis.Visible = true;
                        doctor_id.Visible = true;
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID != null)
                    {
                        Label1.Text = "This Screening tool is designed to identify children from the ages of 2 to 8 years, who may be at a risk of neurodevelopmental disorders. Based on the screening results, the child can be further referred for comprehensive assessment by the certified professional." +
                        "<br>Please answer the given questions that best describes the child, based on your observations (by certified mental health professional) and from the inputs of the caregiver. Try your best to answer all the questions either in <b>'Yes'  or 'No' .</b>. After all the questions are answered, click the save button. The results of disorders  are shown as Scored Rank.";

                        Label2.Text = "NerdNerdy’s screening scale is to be used for the reference purposes only, by the registered medical and rehabilitation practitioners . The results of the tests should be  clinically correlated by the medical/rehabilitation specialist. The screening tool should not be understood to constitute any type of diagnosis or healthcare recommendation.";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            AGRP_ID.Value = vDR["AGRP_ID"].ToString();
                            PTP_AGE_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_NAME.Enabled = false;
                            TXTVALUE.Value = vDR["PTP_CUSTID"].ToString();

                            btnSave.Visible = false;
                            pt1.Visible = false;
                            remark.Visible = false;
                            dis.Visible = false;
                            doctor_id.Visible = false;
                        }
                        Hashtable vHashtable9 = new Hashtable();
                        vHashtable9.Add("AGRP_ID", AGRP_ID.Value);
                        DataRow vDR9 = RetDR(DBManager.Get(vHashtable9, "GET_SCT_MASTER_NEW"));
                        if (vDR9 != null)
                        {
                            SCTP_ID.Value = vDR9["SCTP_ID"].ToString();
                        }

                        Hashtable vHashtable10 = new Hashtable();
                        vHashtable10.Add("PTP_ID", vID);
                        vHashtable10.Add("SCTP_ID", SCTP_ID.Value);
                        DataRow vDR10 = RetDR(DBManager.Get(vHashtable10, "GET_SCREEN_MASTER"));
                        if (vDR10 != null)
                        {
                            HiddenField3.Value = vDR10["PTS_ID"].ToString();
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTS_ID", HiddenField3.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt1 = DBManager.Get(vHashtable1, "GET_PTS_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTS_ID"));
                        PTP_REMARK_TXT.Text = dt1.Rows[0]["PTS_REMARK"].ToString();
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();

                        btnSave.Visible = false;
                        btnScreen.Visible = false;
                        PTP_REMARK_TXT.Enabled = false;
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        GridView1.Enabled = false;

                        Hashtable vHashtable3 = new Hashtable();
                        vHashtable3.Add("AGE", PTP_AGE_TXT.Text);
                        vHashtable3.Add("PTP_ID", vID);
                        vHashtable3.Add("PTS_ID", HiddenField3.Value);
                        vHashtable3.Add("SCTP_ID", SCTP_ID.Value);
                        dt2 = DBManager.Get(vHashtable3, "GET_DISORDER_PERCENTAGE_NEW_ID");
                        GridView2.DataSource = dt2;
                        GridView2.DataBind();
                        GridView2.Visible = true;

                        pt1.Visible = true;
                        remark.Visible = true;
                        dis.Visible = true;
                        doctor_id.Visible = true;
                    }
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    if (vID != null)
                    {
                        Label1.Text = "This Screening tool is designed to identify children from the ages of 2 to 8 years, who may be at a risk of neurodevelopmental disorders. Based on the screening results, the child can be further referred for comprehensive assessment by the certified professional." +
                        "<br>Please answer the given questions that best describes the child, based on your observations (by certified mental health professional) and from the inputs of the caregiver. Try your best to answer all the questions either in <b>'Yes'  or 'No' .</b>. After all the questions are answered, click the save button. The results of disorders  are shown as Scored Rank.";

                        Label2.Text = "NerdNerdy’s screening scale is to be used for the reference purposes only, by the registered medical and rehabilitation practitioners . The results of the tests should be  clinically correlated by the medical/rehabilitation specialist. The screening tool should not be understood to constitute any type of diagnosis or healthcare recommendation.";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            AGRP_ID.Value = vDR["AGRP_ID"].ToString();
                            PTP_AGE_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_NAME.Enabled = false;
                            TXTVALUE.Value = vDR["PTP_CUSTID"].ToString();

                            btnSave.Visible = false;
                            pt1.Visible = false;
                            remark.Visible = false;
                            dis.Visible = false;
                            doctor_id.Visible = false;
                        }
                        Hashtable vHashtable9 = new Hashtable();
                        vHashtable9.Add("AGRP_ID", AGRP_ID.Value);
                        DataRow vDR9 = RetDR(DBManager.Get(vHashtable9, "GET_SCT_MASTER_NEW"));
                        if (vDR9 != null)
                        {
                            SCTP_ID.Value = vDR9["SCTP_ID"].ToString();
                        }

                        Hashtable vHashtable10 = new Hashtable();
                        vHashtable10.Add("PTP_ID", vID);
                        vHashtable10.Add("SCTP_ID", SCTP_ID.Value);
                        DataRow vDR10 = RetDR(DBManager.Get(vHashtable10, "GET_SCREEN_MASTER"));
                        if (vDR10 != null)
                        {
                            HiddenField3.Value = vDR10["PTS_ID"].ToString();
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTS_ID", HiddenField3.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt1 = DBManager.Get(vHashtable1, "GET_PTS_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTS_ID"));
                        PTP_REMARK_TXT.Text = dt1.Rows[0]["PTS_REMARK"].ToString();
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();

                        btnSave.Visible = false;
                        btnScreen.Visible = false;
                        PTP_REMARK_TXT.Enabled = false;
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        GridView1.Enabled = false;

                        Hashtable vHashtable3 = new Hashtable();
                        vHashtable3.Add("AGE", PTP_AGE_TXT.Text);
                        vHashtable3.Add("PTP_ID", vID);
                        vHashtable3.Add("PTS_ID", HiddenField3.Value);
                        vHashtable3.Add("SCTP_ID", SCTP_ID.Value);
                        dt2 = DBManager.Get(vHashtable3, "GET_DISORDER_PERCENTAGE_NEW_ID");
                        GridView2.DataSource = dt2;
                        GridView2.DataBind();
                        GridView2.Visible = true;

                        pt1.Visible = true;
                        remark.Visible = true;
                        dis.Visible = true;
                        doctor_id.Visible = true;
                    }
                }
                else if (vATSession.UserType == "Paediatrician")
                {
                    if (vID != null)
                    {
                        Label1.Text = "This Screening tool is designed to identify children from the ages of 2 to 8 years, who may be at a risk of neurodevelopmental disorders. Based on the screening results, the child can be further referred for comprehensive assessment by the certified professional." +
                        "<br>Please answer the given questions that best describes the child, based on your observations (by certified mental health professional) and from the inputs of the caregiver. Try your best to answer all the questions either in <b>'Yes'  or 'No' .</b>. After all the questions are answered, click the save button. The results of disorders  are shown as Scored Rank.";

                        Label2.Text = "NerdNerdy’s screening scale is to be used for the reference purposes only, by the registered medical and rehabilitation practitioners . The results of the tests should be  clinically correlated by the medical/rehabilitation specialist. The screening tool should not be understood to constitute any type of diagnosis or healthcare recommendation.";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            AGRP_ID.Value = vDR["AGRP_ID"].ToString();
                            PTP_AGE_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_NAME.Enabled = false;
                            TXTVALUE.Value = vDR["PTP_CUSTID"].ToString();

                            btnSave.Visible = false;
                            pt1.Visible = false;
                            remark.Visible = false;
                            dis.Visible = false;
                            doctor_id.Visible = false;
                        }
                        Hashtable vHashtable9 = new Hashtable();
                        vHashtable9.Add("AGRP_ID", AGRP_ID.Value);
                        DataRow vDR9 = RetDR(DBManager.Get(vHashtable9, "GET_SCT_MASTER_NEW"));
                        if (vDR9 != null)
                        {
                            SCTP_ID.Value = vDR9["SCTP_ID"].ToString();
                        }

                        Hashtable vHashtable10 = new Hashtable();
                        vHashtable10.Add("PTP_ID", vID);
                        vHashtable10.Add("SCTP_ID", SCTP_ID.Value);
                        DataRow vDR10 = RetDR(DBManager.Get(vHashtable10, "GET_SCREEN_MASTER"));
                        if (vDR10 != null)
                        {
                            HiddenField3.Value = vDR10["PTS_ID"].ToString();
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTS_ID", HiddenField3.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt1 = DBManager.Get(vHashtable1, "GET_PTS_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTS_ID"));
                        PTP_REMARK_TXT.Text = dt1.Rows[0]["PTS_REMARK"].ToString();
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();

                        btnSave.Visible = false;
                        btnScreen.Visible = false;
                        PTP_REMARK_TXT.Enabled = false;
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        GridView1.Enabled = false;

                        Hashtable vHashtable3 = new Hashtable();
                        vHashtable3.Add("AGE", PTP_AGE_TXT.Text);
                        vHashtable3.Add("PTP_ID", vID);
                        vHashtable3.Add("PTS_ID", HiddenField3.Value);
                        vHashtable3.Add("SCTP_ID", SCTP_ID.Value);
                        dt2 = DBManager.Get(vHashtable3, "GET_DISORDER_PERCENTAGE_NEW_ID");
                        GridView2.DataSource = dt2;
                        GridView2.DataBind();
                        GridView2.Visible = true;

                        pt1.Visible = true;
                        remark.Visible = true;
                        dis.Visible = true;
                        doctor_id.Visible = true;
                    }
                }
                else if (vATSession.UserType == "Therapist")
                {
                    if (vID != null)
                    {
                        Label1.Text = "This Screening tool is designed to identify children from the ages of 2 to 8 years, who may be at a risk of neurodevelopmental disorders. Based on the screening results, the child can be further referred for comprehensive assessment by the certified professional." +
                        "<br>Please answer the given questions that best describes the child, based on your observations (by certified mental health professional) and from the inputs of the caregiver. Try your best to answer all the questions either in <b>'Yes'  or 'No' .</b>. After all the questions are answered, click the save button. The results of disorders  are shown as Scored Rank.";

                        Label2.Text = "NerdNerdy’s screening scale is to be used for the reference purposes only, by the registered medical and rehabilitation practitioners . The results of the tests should be  clinically correlated by the medical/rehabilitation specialist. The screening tool should not be understood to constitute any type of diagnosis or healthcare recommendation.";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
                        if (vDR != null)
                        {
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
                            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
                            AGRP_ID.Value = vDR["AGRP_ID"].ToString();
                            PTP_AGE_TXT.Enabled = false;
                            PTP_GENDER_TXT.Enabled = false;
                            PTP_MOB_TXT.Enabled = false;
                            PTP_NAME.Enabled = false;
                            TXTVALUE.Value = vDR["PTP_CUSTID"].ToString();

                            btnSave.Visible = false;
                            pt1.Visible = false;
                            remark.Visible = false;
                            dis.Visible = false;
                            doctor_id.Visible = false;
                        }
                        Hashtable vHashtable9 = new Hashtable();
                        vHashtable9.Add("AGRP_ID", AGRP_ID.Value);
                        DataRow vDR9 = RetDR(DBManager.Get(vHashtable9, "GET_SCT_MASTER_NEW"));
                        if (vDR9 != null)
                        {
                            SCTP_ID.Value = vDR9["SCTP_ID"].ToString();
                        }

                        Hashtable vHashtable10 = new Hashtable();
                        vHashtable10.Add("PTP_ID", vID);
                        vHashtable10.Add("SCTP_ID", SCTP_ID.Value);
                        DataRow vDR10 = RetDR(DBManager.Get(vHashtable10, "GET_SCREEN_MASTER"));
                        if (vDR10 != null)
                        {
                            HiddenField3.Value = vDR10["PTS_ID"].ToString();
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("PTS_ID", HiddenField3.Value);
                        vHashtable1.Add("PTP_ID", vID);
                        dt1 = DBManager.Get(vHashtable1, "GET_PTS_ID");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PTS_ID"));
                        PTP_REMARK_TXT.Text = dt1.Rows[0]["PTS_REMARK"].ToString();
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();

                        btnSave.Visible = false;
                        btnScreen.Visible = false;
                        PTP_REMARK_TXT.Enabled = false;
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        GridView1.Enabled = false;

                        Hashtable vHashtable3 = new Hashtable();
                        vHashtable3.Add("AGE", PTP_AGE_TXT.Text);
                        vHashtable3.Add("PTP_ID", vID);
                        vHashtable3.Add("PTS_ID", HiddenField3.Value);
                        vHashtable3.Add("SCTP_ID", SCTP_ID.Value);
                        dt2 = DBManager.Get(vHashtable3, "GET_DISORDER_PERCENTAGE_NEW_ID");
                        GridView2.DataSource = dt2;
                        GridView2.DataBind();
                        GridView2.Visible = true;

                        pt1.Visible = true;
                        remark.Visible = true;
                        dis.Visible = true;
                        doctor_id.Visible = true;
                    }
                }
                else
                    ShowMsg("Invalid Patient ID");
            }
            catch (Exception xe)
            {
            }
        }
    }

    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("AGRP_GROUP", PTP_AGE_TXT.Text);
        DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_SCR_DETAIL_NEW");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void rdbtn1_CheckedChanged(object sender, EventArgs e)
    {
        Response.Write("View Selection changed");
    }

    protected void rdbtn2_CheckedChanged(object sender, EventArgs e)
    {
        Response.Write("Something Selection changed");
    }

    protected void btnScreen_Click(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];
        Hashtable vHashtable4 = new Hashtable();
        vHashtable4.Add("PTP_ID", vID);
        dt4 = DBManager.Get(vHashtable4, "GET_PTS");

        if (dt4.Rows.Count >= 1)
        {
            Hashtable vHashtable1 = new Hashtable();
            vHashtable1.Add("AGRP_GROUP", PTP_AGE_TXT.Text);
            DataTable dt2 = DBManager.Get(vHashtable1, "GET_PATIENT_SCR_DETAIL");
            DataRow vDR2 = RetDR(DBManager.Get(vHashtable1, "GET_PATIENT_SCR_DETAIL"));
            if (vDR2 != null)
            {
                Hashtable vHashtable2 = new Hashtable();
                vHashtable2.Add("AGRP_GROUP", PTP_AGE_TXT.Text);
                DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PATIENT_SCR_DETAIL"));
                DataTable dt1 = DBManager.Get(vHashtable2, "GET_PATIENT_SCR_DETAIL");

                Hashtable vHashtable14 = new Hashtable();
                vHashtable14.Add("PTP_ID", vID);
                dt4 = DBManager.Get(vHashtable14, "GET_PTS");
                DataRow vDR4 = RetDR(DBManager.Get(vHashtable14, "GET_PTS"));
                GridView1.DataSource = dt4;
                GridView1.DataBind();
                PTP_REMARK_TXT.Text = dt4.Rows[0]["PTS_REMARK"].ToString();

                if (dt4.Rows[1]["PTSD_SOMETHING"].ToString() == "1")
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        RadioButton chkSelect1 = (RadioButton)row.FindControl("SelectUnSelect");
                        RadioButton chkRow1 = (row.Cells[1].FindControl("chkSelect1") as RadioButton);
                        RadioButton chkRow = (row.Cells[0].FindControl("chkSelect") as RadioButton);
                        if (chkRow1 != null && chkRow1.Checked)
                        {
                            chkRow1.Checked = true;
                        }
                        else
                        {
                            chkRow1.Checked = false;
                        }
                        if (vDR4["PTSD_VIEW"].ToString() == "1")
                        {
                            chkRow.Checked = true;
                        }
                        else
                        {
                            chkRow.Checked = false;
                        }
                    }
                    btnSave.Visible = false;
                    btnScreen.Visible = false;
                    PTP_REMARK_TXT.Enabled = false;
                }
                GridView1.DataSource = dt4;
                GridView1.DataBind();
                GridView1.Enabled = false;
            }
            Hashtable vHashtable3 = new Hashtable();
            vHashtable3.Add("AGE", PTP_AGE_TXT.Text);
            vHashtable3.Add("PTP_ID", vID);
            dt2 = DBManager.Get(vHashtable3, "GET_DISORDER_PERCENTAGE_NEW");
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            GridView2.Visible = true;
        }
        else
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("AGRP_GROUP", PTP_AGE_TXT.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_SCR_DETAIL_NEW");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            btnSave.Visible = true;
            pt1.Visible = true;
            remark.Visible = true;
            dis.Visible = true;
            doctor_id.Visible = true;
        }
    }
    protected void BindGrid()
    {
        DataTable dt1 = (DataTable)ViewState["datagrid"];
        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        string values = AGDD_DOBSID.Value.ToString();
        string SAP_IDs = string.Empty;

        SAP_IDs = values.TrimEnd(',').ToString();
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("AGE", PTP_AGE_TXT.Text);
        DataTable dt = DBManager.Get(vHashtable, "GET_DISORDER_PERCENTAGE");
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("PTS_ID", TXTID.Value);
        vHashtable1.Add("PTS_PTPID", vID);
        vHashtable1.Add("PTS_CUSTID", TXTVALUE.Value);
        vHashtable1.Add("PTS_SCTPID", SCTP_ID.Value);
        vHashtable1.Add("PTS_REMARK", PTP_REMARK_TXT.Text);
        vHashtable1.Add("TYPE", "INS");
        if (DBManager.ExecInsUpsReturn(vHashtable1, "INS_PTS_MASTER", (ATSession)Session["User"]))
        {
            if (Page.IsValid)
            {
                if (GridView1.Rows.Count > 0)
                    try
                    {
                        string data = "";
                        foreach (GridViewRow grd in GridView1.Rows)
                        {
                            Label SCTD_ID = (Label)grd.FindControl("SCTD_ID");
                            Label SCTD_AGDDID = (Label)grd.FindControl("SCTD_AGDDID");
                            Label PTSD_SOMETHING = (Label)grd.FindControl("PTSD_SOMETHING");

                            if (grd.RowType == DataControlRowType.DataRow)
                            {
                                RadioButton chkRow = (grd.Cells[1].FindControl("rdbtn1") as RadioButton);
                                string HiddenField1 = chkRow.Checked ? "1" : "0";
                                RadioButton chkRow1 = (grd.Cells[2].FindControl("rdbtn2") as RadioButton);
                                string HiddenField2 = chkRow1.Checked ? "1" : "0";
                                if (chkRow.Checked) 
                                {
                                    Hashtable vHashtable2 = new Hashtable();
                                    vHashtable2.Add("PTSD_ID", ID.Value);
                                    vHashtable2.Add("PTSD_PTSID", TXTID.Value);
                                    vHashtable2.Add("PTSD_SCTDID", SCTD_ID.Text);
                                    vHashtable2.Add("PTSD_SOMETHING", HiddenField2);
                                    vHashtable2.Add("PTSD_VIEW", HiddenField1);
                                    vHashtable2.Add("TYPE", "INS");
                                    DBManager.ExecInsUps(vHashtable2, "INS_PTS_DETAIL", (ATSession)Session["User"]);
                                    data = data + ID + " ,  " + TXTID + " , " + SCTD_ID + "<br>";
                                }
                                else if (chkRow1.Checked)
                                {
                                    Hashtable vHashtable2 = new Hashtable();
                                    vHashtable2.Add("PTSD_ID", ID.Value);
                                    vHashtable2.Add("PTSD_PTSID", TXTID.Value);
                                    vHashtable2.Add("PTSD_SCTDID", SCTD_ID.Text);
                                    vHashtable2.Add("PTSD_SOMETHING", HiddenField2);
                                    vHashtable2.Add("PTSD_VIEW", HiddenField1);
                                    vHashtable2.Add("TYPE", "INS");
                                    DBManager.ExecInsUps(vHashtable2, "INS_PTS_DETAIL", (ATSession)Session["User"]);
                                }
                            }
                        }
                        if (ID.Value != null)
                        {
                            string values = AGDD_DOBSID.Value.ToString();
                            string SAP_IDs = string.Empty;
                            SAP_IDs = values.TrimEnd(',').ToString();
                            Hashtable vHashtable = new Hashtable();
                            vHashtable.Add("AGE", PTP_AGE_TXT.Text);
                            vHashtable.Add("PTP_ID", vID);
                            DataTable dt = DBManager.Get(vHashtable, "GET_DISORDER_PERCENTAGE_NEW");
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                            doctor_id.Visible = true;
                        }
                    }
                    catch (Exception xe)
                    {
                        ShowMsg(xe);
                    }
            }
        }
        Response.Redirect("Patient_Doctor_Screening.aspx?id=" + vID);
    }

    protected void DDLPATIENT_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", TXTID.Value);
        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_SCREEN"));
        if (vDR != null)
        {
            PTP_AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
            PTP_GENDER_TXT.Text = vDR["PTP_GENDER"].ToString();
            PTP_MOB_TXT.Text = vDR["PTP_MOBILE"].ToString();
            PTP_AGE_TXT.Enabled = false;
            PTP_GENDER_TXT.Enabled = false;
            PTP_MOB_TXT.Enabled = false;
        }
    }

    protected void checkbox_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cb1 = (CheckBox)GridView1.Rows[index].FindControl("chkview");
        string yourvalue = cb1.Text;
    }

    public void Clear()
    {
    }
}