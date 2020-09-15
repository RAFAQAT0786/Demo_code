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

        if (!IsPostBack)
        {
            try
            {
                ATCommon.FillDrpDown(DDLIEA, DBManager.Get(new Hashtable(), "CMB_IEP_SKILL_ACTIVITY"), "Select IEA Name", "IEPA_DESC", "IEPA_ID", "0");
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER_PATIENT_NEW"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");

                if (vATSession.UserType == "ADMIN")
                {
                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("IEPAT_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_NEW"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["IEPAT_ID"].ToString();
                            IEPAT_REMARK.Text = vDR["IEPAT_REMARK"].ToString();
                            PTP_DATE_TXT.Text = vDR["IEPAT_DATE"].ToString();
                            DDLCAT.SelectedItem.Text = vDR["DCAT_NAME"].ToString();
                            DDLSUBCAT.SelectedItem.Text = vDR["DSCAT_DESC"].ToString();
                            DDLIEA.SelectedItem.Text = vDR["IEPA_DESC"].ToString();
                            TXTVALUE.Value = vDR["IEPAT_DISID"].ToString();
                            PTP_DATE_TXT.Enabled = false;
                            DDLIEA.Enabled = false;
                            DDLCAT.Enabled = false;
                            DDLSUBCAT.Enabled = false;
                            if (vDR["IEPAT_PRESENT"].ToString() == "1")
                            {
                                chkSelect1.Checked = true;
                            }
                            else
                            {
                                chkSelect1.Checked = false;
                            }
                            if (vDR["IEPAT_ABSENT"].ToString() == "1")
                            {
                                chkSelect.Checked = true;
                            }
                            else
                            {
                                chkSelect.Checked = false;
                            }
                            if (vDR["IEPAT_REG"].ToString() == "1")
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
                        }
                        else
                            ShowMsg("Invalid IEP ID");
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("IEPAT_ID", vID);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_NEW"));
                        if (vDR1 != null)
                        {
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
                        }
                        else
                            ShowMsg("Invalid IEP ID");

                    }
                  }
                else
                {
                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("IEPAT_ID", vID);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable, "GET_IEP_PATIENT_NEW"));
                        if (vDR1 != null)
                        {
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
                        }
                        else
                            ShowMsg("Invalid IEP ID");
                    }
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void Updatebtn_Click(object sender, EventArgs e)
    {
        string hdnID = chkSelect.Checked ? "1" : "0";
        string HiddenField1 = chkSelect1.Checked ? "1" : "0";
        string HiddenField2 = chkSelect2.Checked ? "1" : "0";

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

    protected void DDLCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DCAT_ID", DDLCAT.SelectedValue.ToString());
        vHashtable.Add("IEPDT_ID", vID);
        ATCommon.FillDrpDown(DDLSUBCAT, DBManager.Get(vHashtable, "CMB_CATEGORY_ID_NEW"), "Select Sub Category Name", "DSCAT_DESC", "DSCAT_ID", "");
    }
}