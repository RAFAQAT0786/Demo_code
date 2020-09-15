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

public partial class IEP_PATIENT_TEMPLATE : BasePage
{
    ATSession vATSession;
    DataTable dt;
    DataTable dt1;
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

        String vID = Request.QueryString["ID"];
        String CCID = Request.QueryString["id1"];
        if (!IsPostBack)
        {
            dt = new DataTable();
            DataColumn IEPDT_PRICE = new DataColumn();
            IEPDT_PRICE.DataType = Type.GetType("System.String");
            IEPDT_PRICE.ColumnName = "IEPDT_PRICE";
            dt.Columns.Add(IEPDT_PRICE);

            DataColumn coldisname = new DataColumn();
            coldisname.DataType = Type.GetType("System.String");
            coldisname.ColumnName = "IEPDTD_DSCATID";
            dt.Columns.Add(coldisname);

            DataColumn coltypgroup = new DataColumn();
            coltypgroup.DataType = Type.GetType("System.String");
            coltypgroup.ColumnName = "IEPDTD_DCATID";
            dt.Columns.Add(coltypgroup);

            DataColumn coltypgroup1 = new DataColumn();
            coltypgroup1.DataType = Type.GetType("System.String");
            coltypgroup1.ColumnName = "IEPDTD_IEPAID";
            dt.Columns.Add(coltypgroup1);

            DataColumn coldcname = new DataColumn();
            coldcname.DataType = Type.GetType("System.String");
            coldcname.ColumnName = "DCAT_NAME";
            dt.Columns.Add(coldcname);

            DataColumn NAME = new DataColumn();
            NAME.DataType = Type.GetType("System.String");
            NAME.ColumnName = "DIS_NAME";
            dt.Columns.Add(NAME);

            DataColumn coldesc = new DataColumn();
            coldesc.DataType = Type.GetType("System.String");
            coldesc.ColumnName = "DSCAT_DESC";
            dt.Columns.Add(coldesc);

            DataColumn coldobdes = new DataColumn();
            coldobdes.DataType = Type.GetType("System.String");
            coldobdes.ColumnName = "IEPA_DESC";
            dt.Columns.Add(coldobdes);

            DataColumn coldID = new DataColumn();
            coldID.DataType = Type.GetType("System.String");
            coldID.ColumnName = "IEPDT_ID";
            dt.Columns.Add(coldID);

            DataColumn CID = new DataColumn();
            CID.DataType = Type.GetType("System.String");
            CID.ColumnName = "IEPA_ID";
            dt.Columns.Add(CID);

            DataColumn coldIEPD = new DataColumn();
            coldIEPD.DataType = Type.GetType("System.String");
            coldIEPD.ColumnName = "IEPDTD_IEPDTID";
            dt.Columns.Add(coldIEPD);

            DataColumn coldDCAT = new DataColumn();
            coldDCAT.DataType = Type.GetType("System.String");
            coldDCAT.ColumnName = "DSCAT_DCATID";
            dt.Columns.Add(coldDCAT);

            DataColumn IEPDTD_PRODMID = new DataColumn();
            IEPDTD_PRODMID.DataType = Type.GetType("System.String");
            IEPDTD_PRODMID.ColumnName = "IEPDTD_PRODMID";
            dt.Columns.Add(IEPDTD_PRODMID);

            DataColumn PRODM_ID = new DataColumn();
            PRODM_ID.DataType = Type.GetType("System.String");
            PRODM_ID.ColumnName = "PRODM_ID";
            dt.Columns.Add(PRODM_ID);

            DataColumn PRODM_NAME = new DataColumn();
            PRODM_NAME.DataType = Type.GetType("System.String");
            PRODM_NAME.ColumnName = "PRODM_NAME";
            dt.Columns.Add(PRODM_NAME);

            DataColumn IEPAT_DATE = new DataColumn();
            IEPAT_DATE.DataType = Type.GetType("System.String");
            IEPAT_DATE.ColumnName = "IEPAT_DATE";
            dt.Columns.Add(IEPAT_DATE);

            DataColumn IEPAT_REMARK = new DataColumn();
            IEPAT_REMARK.DataType = Type.GetType("System.String");
            IEPAT_REMARK.ColumnName = "IEPAT_REMARK";
            dt.Columns.Add(IEPAT_REMARK);

            DataColumn IEPAT_ID = new DataColumn();
            IEPAT_ID.DataType = Type.GetType("System.String");
            IEPAT_ID.ColumnName = "IEPAT_ID";
            dt.Columns.Add(IEPAT_ID);

            DataColumn IEPA_NAME = new DataColumn();
            IEPA_NAME.DataType = Type.GetType("System.String");
            IEPA_NAME.ColumnName = "IEPA_NAME";
            dt.Columns.Add(IEPA_NAME);

            DataColumn IEPAT_PTPID = new DataColumn();
            IEPAT_PTPID.DataType = Type.GetType("System.String");
            IEPAT_PTPID.ColumnName = "IEPAT_PTPID";
            dt.Columns.Add(IEPAT_PTPID);

            DataColumn IEPDTD_ID = new DataColumn();
            IEPDTD_ID.DataType = Type.GetType("System.String");
            IEPDTD_ID.ColumnName = "IEPDTD_ID";
            dt.Columns.Add(IEPDTD_ID);

            ViewState["datagrid"] = dt;
            BindGrid();

            DDLDIS.Enabled = true;

            try
            {
                ValidateUserAccess();

                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER_PATIENT_NEW"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");

                if (vATSession.UserType == "ADMIN")
                {
                    Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategory for the skills that you want to include in your IEP of your patient." +
                        "<br><b>Suggested Activity:</b> Comprehensive list of suggested activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them as per your need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        "<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need customized intervention resources for our patients.Its our constant endeavor of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        "<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources from website.</ br>" +
                        "<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.The progress can be viewed category,sub-category wise & time-line basis.</ br>" +
                        "<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accomplished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) & No Improvement (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the, <b>update button</b> in order to save the progress of your patient.</br>";

                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("IEPDT_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEPDT_ID_NEW"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["IEPDT_ID"].ToString();
                            DDLDIS.SelectedValue = vDR["IEPDT_DISID"].ToString();
                            btnSave.Visible = false;
                            DDLDIS.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid IEP ID");
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("IEPDT_ID", vID);
                        vHashtable1.Add("IEPAT_PTPID", CCID);
                        dt = DBManager.Get(vHashtable1, "GET_IEP_PATIENT");
                        if (dt.Rows.Count > 0)
                        {
                            ViewState["datagrid"] = dt;
                            BindGrid();
                        }

                        CCID = Request.QueryString["id1"];
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", CCID);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PATIENT_ID"));
                        if (vDR1 != null)
                        {
                            PTP_ID.Value = vDR1["PTP_ID"].ToString();
                            PATIENT_TXT.Text = vDR1["PTP_NAME"].ToString();
                            PATIENT_TXT.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid IEP ID");
                        }
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID != null)
                    {
                        Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategory for the skills that you want to include in your IEP of your patient." +
                        "<br><b>Suggested Activity:</b> Comprehensive list of suggested activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them as per your need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        "<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need customized intervention resources for our patients.Its our constant endeavor of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        "<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources from website.</ br>" +
                        "<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.The progress can be viewed category,sub-category wise & time-line basis.</ br>" +
                        "<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accomplished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) & No Improvement (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the, <b>update button</b> in order to save the progress of your patient.</br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("IEPDT_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEPDT_ID_NEW"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["IEPDT_ID"].ToString();
                            DDLDIS.SelectedValue = vDR["IEPDT_DISID"].ToString();
                            DDLDIS.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid IEP ID");
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("IEPDT_ID", vID);
                        vHashtable1.Add("IEPAT_PTPID", CCID);
                        dt = DBManager.Get(vHashtable1, "GET_IEP_PATIENT");

                        if (dt.Rows.Count > 0)
                        {
                            ViewState["datagrid"] = dt;
                            BindGrid();
                        }

                        CCID = Request.QueryString["id1"];
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", CCID);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PATIENT_ID"));
                        if (vDR1 != null)
                        {
                            PTP_ID.Value = vDR1["PTP_ID"].ToString();
                            PATIENT_TXT.Text = vDR1["PTP_NAME"].ToString();
                            PATIENT_TXT.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid IEP ID");
                        }
                    }
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    if (vID != null)
                    {
                        Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategory for the skills that you want to include in your IEP of your patient." +
                        "<br><b>Suggested Activity:</b> Comprehensive list of suggested activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them as per your need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        "<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need customized intervention resources for our patients.Its our constant endeavor of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        "<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources from website.</ br>" +
                        "<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.The progress can be viewed category,sub-category wise & time-line basis.</ br>" +
                        "<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accomplished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) & No Improvement (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the, <b>update button</b> in order to save the progress of your patient.</br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("IEPDT_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEPDT_ID_NEW"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["IEPDT_ID"].ToString();
                            DDLDIS.SelectedValue = vDR["IEPDT_DISID"].ToString();
                            DDLDIS.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid IEP ID");
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("IEPDT_ID", vID);
                        vHashtable1.Add("IEPAT_PTPID", CCID);
                        dt = DBManager.Get(vHashtable1, "GET_IEP_PATIENT");

                        if (dt.Rows.Count > 0)
                        {
                            ViewState["datagrid"] = dt;
                            BindGrid();
                        }

                        CCID = Request.QueryString["id1"];
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", CCID);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PATIENT_ID"));
                        if (vDR1 != null)
                        {
                            PTP_ID.Value = vDR1["PTP_ID"].ToString();
                            PATIENT_TXT.Text = vDR1["PTP_NAME"].ToString();
                            PATIENT_TXT.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid IEP ID");
                        }
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    if (vID != null)
                    {
                        Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategory for the skills that you want to include in your IEP of your patient." +
                        "<br><b>Suggested Activity:</b> Comprehensive list of suggested activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them as per your need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                        "<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need customized intervention resources for our patients.Its our constant endeavor of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                        "<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources from website.</ br>" +
                        "<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.The progress can be viewed category,sub-category wise & time-line basis.</ br>" +
                        "<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accomplished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) & No Improvement (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the, <b>update button</b> in order to save the progress of your patient.</br>";

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("IEPDT_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEPDT_ID_NEW"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["IEPDT_ID"].ToString();
                            DDLDIS.SelectedValue = vDR["IEPDT_DISID"].ToString();
                            DDLDIS.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid IEP ID");
                        }

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("IEPDT_ID", vID);
                        vHashtable1.Add("IEPAT_PTPID", CCID);
                        dt = DBManager.Get(vHashtable1, "GET_IEP_PATIENT");

                        if (dt.Rows.Count > 0)
                        {
                            ViewState["datagrid"] = dt;
                            BindGrid();
                        }

                        CCID = Request.QueryString["id1"];
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", CCID);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PATIENT_ID"));
                        if (vDR1 != null)
                        {
                            PTP_ID.Value = vDR1["PTP_ID"].ToString();
                            PATIENT_TXT.Text = vDR1["PTP_NAME"].ToString();
                            PATIENT_TXT.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid IEP ID");
                        }
                    }
                }
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
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

    protected void DDLSUBCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DSCAT_ID", DDLSUBCAT.SelectedValue.ToString());
        vHashtable.Add("IEPDT_ID", vID);
        ATCommon.FillDrpDown(DDLIEA, DBManager.Get(vHashtable, "CMB_SUBCATEGORY"), "Select IEP Skill Activity", "IEPA_NAME", "IEPA_ID", "");

        Hashtable vHashtable2 = new Hashtable();
        vHashtable2.Add("DCAT_ID", DDLCAT.SelectedValue.ToString());
        vHashtable2.Add("DSCAT_ID", DDLSUBCAT.SelectedValue.ToString());
        ATCommon.FillDrpDown(DDLPRODUCT, DBManager.Get(vHashtable2, "CMB_PRODCATEGORY"), "Select Resoures", "PRODM_NAME", "PRODM_ID", "");
    }

    protected void existence_ServerValidate(object sender, ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTIEPDT_MASTER");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["IEPDT_DISID"].ToString().Equals(DDLDIS.SelectedValue))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String CCID = Request.QueryString["id1"];
            String vID = Request.QueryString["ID"];

            try
            {
                if (TXTVALUE.Value == "0")
                {
                    addrow();
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("DCAT_ID", DDLCAT.SelectedValue);
                    vHashtable.Add("DSCAT_ID", DDLSUBCAT.SelectedValue);
                    vHashtable.Add("IEPDT_ID", vID);
                    vHashtable.Add("IEPAT_ID", TXTVALUE.Value);
                    vHashtable.Add("IEPAT_IEPDTDID", HiddenField3.Value);
                    vHashtable.Add("IEPAT_PTPID", CCID);
                    vHashtable.Add("IEPAT_DISID ", DDLDIS.SelectedValue);
                    vHashtable.Add("IEPAT_DATE", PTP_DATE_TXT.Text);
                    vHashtable.Add("IEPAT_TOOL", DDLPRODUCT.SelectedValue);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_IEP_PATIENT");
                    BindGrid();
                }
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        }
    }

    protected void IEPDT_ID_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void IEPDT_ID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        IEPDT_ID.PageIndex = e.NewPageIndex;
    }

    public void ObjectDatasource1_Deleted(object source, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            ShowMsg(e.Exception.InnerException.Message);
            e.ExceptionHandled = true;
        }
        else
        {
            ShowMsg(-1);
        }
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    String CCID = Request.QueryString["id1"];

    //    Hashtable vHashtable = new Hashtable();
    //    vHashtable.Add("IEPAT_DATE", PTP_TNAME_TXT.Text);
    //    vHashtable.Add("IEPAT_PTPID", CCID);
    //    DataTable dt = DBManager.Get(vHashtable, "GET_IEP_DATE");
    //    IEPDT_ID.DataSource = dt;
    //    IEPDT_ID.DataBind();
    //}

    protected void BindGrid()
    {
        String CCID = Request.QueryString["id1"];

        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("DIS_ID", DDLDIS.SelectedValue.ToString());
        vHashtable1.Add("PTP_ID", CCID);
        dt = DBManager.Get(vHashtable1, "GET_IEP");
        IEPDT_ID.DataSource = dt;
        IEPDT_ID.DataBind();
        DDLDIS.Enabled = false;
    }

    protected void addrow()
    {
        String vID = Request.QueryString["ID"];
        String CCID = Request.QueryString["id1"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DSCAT_ID", DDLSUBCAT.SelectedValue.ToString());
        vHashtable.Add("IEPDT_ID", vID);
        vHashtable.Add("IEPA_NAME", DDLIEA.SelectedItem.Text);
        DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "CMB_SUBCATEGORY_NEW"));
        if (vDR1 != null)
        {
            HiddenField2.Value = vDR1["IEPA_DESC"].ToString();
            HiddenField3.Value = vDR1["IEPDTD_ID"].ToString();
        }
        if (DDLPRODUCT.SelectedValue != "")
        {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();
        dr["IEPDTD_IEPAID"] = DDLIEA.SelectedValue.ToString();
        dr["IEPDTD_DSCATID"] = DDLSUBCAT.SelectedValue.ToString();
        dr["DCAT_NAME"] = DDLCAT.SelectedItem;
        dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
        dr["DIS_NAME"] = DDLDIS.SelectedItem;
        dr["IEPDTD_IEPDTID"] = TXTID.Value;
        dr["DSCAT_DCATID"] = DDLCAT.SelectedValue.ToString();
        dr["IEPA_DESC"] = HiddenField2.Value;
        dr["IEPDTD_PRODMID"] = DDLPRODUCT.SelectedValue;
        dr["PRODM_NAME"] = DDLPRODUCT.SelectedItem.Text;
        dr["IEPAT_DATE"] = PTP_DATE_TXT.Text;
        dr["IEPAT_PTPID"] = CCID;
            dr["IEPDTD_ID"] = HiddenField3.Value;
            dt.Rows.Add(dr);
            ViewState["datagrid"] = dt;
        }
        else
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            DataRow dr;
            dr = dt.NewRow();
            dr["IEPDTD_IEPAID"] = DDLIEA.SelectedValue.ToString();
            dr["IEPDTD_DSCATID"] = DDLSUBCAT.SelectedValue.ToString();
            dr["DCAT_NAME"] = DDLCAT.SelectedItem;
            dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
            dr["DIS_NAME"] = DDLDIS.SelectedItem;
            dr["IEPDTD_IEPDTID"] = TXTID.Value;
            dr["DSCAT_DCATID"] = DDLCAT.SelectedValue.ToString();
            dr["IEPA_DESC"] = HiddenField2.Value;
            dr["IEPDTD_PRODMID"] = "0";
            dr["PRODM_NAME"] = "";
            dr["IEPAT_DATE"] = PTP_DATE_TXT.Text;
            dr["IEPAT_PTPID"] = CCID;
            dr["IEPDTD_ID"] = HiddenField3.Value;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
    }
    }
    protected void IEPDT_ID_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label IEPDTD_ID = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_ID");
        Label TYPE_ID = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_IEPDTID");
        Label DESC = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_DSCATID");
        Label IEPDTD_PRODMID = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_PRODMID");
        Label IEPDTD_IEPAID = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_IEPAID");

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPDTD_ID", TXTID.Value);
        vHashtable.Add("IEPDTD_DSCATID", DDLSUBCAT.SelectedValue);
        vHashtable.Add("IEPDTD_PRODMID", DDLPRODUCT.SelectedValue);
        DBManager.ExecInsUps(vHashtable, "UPDATE_IEPDTD_ID", vATSession);
        IEPDT_ID.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        BindGrid();
    }

    protected void IEPDT_ID_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    protected void IEPDT_ID_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);

        if (e.CommandName == "delete")
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            Label IEPAT_ID = IEPDT_ID.Rows[index].FindControl("IEPAT_ID") as Label;
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("IEPAT_ID", IEPAT_ID.Text);
            DBManager.ExecDel(vHashtable, "DEL_IEP_PATIENT");
            BindGrid();
            Response.Redirect("IEP_PATIENT_TEMPLATE.aspx?id=" + TXTID.Value + "&id1=" + PTP_ID.Value);
        }
        ShowDeleteMsg(true);
    }

    protected void btnProgress_Click(object sender, EventArgs e)
    {
        Response.Redirect("IEP_PATIENT_PROGRESS_LIST.aspx?id1=" + PTP_ID.Value);
    }
}