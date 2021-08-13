using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;

public partial class DEVELOPMENTAL_SCREENING_TEST : BasePage
{
    ATSession vATSession;
    BLLReport vReport = new BLLReport();
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
        String vID = Request.QueryString["ID"];
        String vID2 = Request.QueryString["id1"];

        if (!IsPostBack)
        {
            try
            {

                if (vATSession.UserType == "ADMIN")
                {
                    if (vID2 != null)
                    {
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DEVELOPMENTAL_SCREENING"));
                        if (vDR1 != null)
                        {
                            TXTID.Value = vDR1["PTDEVS_ID"].ToString();
                            DEVE_AGE_TXT.Text = vDR1["PTDEVS_AGE"].ToString();
                            CHRO_TXT.Text = vDR1["PTDEVS_CHRONOLOGICAL_AGE"].ToString();
                            DEVE_TXT.Text = vDR1["PTDEVS_QUOTIENT"].ToString();
                            btnSave.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID2 != null)
                    {
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DEVELOPMENTAL_SCREENING"));
                        if (vDR1 != null)
                        {
                            TXTID.Value = vDR1["PTDEVS_ID"].ToString();
                            DEVE_AGE_TXT.Text = vDR1["PTDEVS_AGE"].ToString();
                            CHRO_TXT.Text = vDR1["PTDEVS_CHRONOLOGICAL_AGE"].ToString();
                            DEVE_TXT.Text = vDR1["PTDEVS_QUOTIENT"].ToString();
                            btnSave.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    if (vID2 != null)
                    {
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DEVELOPMENTAL_SCREENING"));
                        if (vDR1 != null)
                        {
                            TXTID.Value = vDR1["PTDEVS_ID"].ToString();
                            DEVE_AGE_TXT.Text = vDR1["PTDEVS_AGE"].ToString();
                            CHRO_TXT.Text = vDR1["PTDEVS_CHRONOLOGICAL_AGE"].ToString();
                            DEVE_TXT.Text = vDR1["PTDEVS_QUOTIENT"].ToString();
                            btnSave.Visible = false;
                        }
                        //hide save from Organization
                        btnSave.Visible = false;
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    if (vID2 != null)
                    {
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DEVELOPMENTAL_SCREENING"));
                        if (vDR1 != null)
                        {
                            TXTID.Value = vDR1["PTDEVS_ID"].ToString();
                            DEVE_AGE_TXT.Text = vDR1["PTDEVS_AGE"].ToString();
                            CHRO_TXT.Text = vDR1["PTDEVS_CHRONOLOGICAL_AGE"].ToString();
                            DEVE_TXT.Text = vDR1["PTDEVS_QUOTIENT"].ToString();
                            btnSave.Visible = false;
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        String vID2 = Request.QueryString["id1"];
        if (TXTID.Value == "0")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTDEVS_ID", TXTID.Value);
            vHashtable.Add("PTDEVS_PTPID", vID2);
            vHashtable.Add("PTDEVS_AGE", DEVE_AGE_TXT.Text);
            vHashtable.Add("PTDEVS_CHRONOLOGICAL_AGE", CHRO_TXT.Text);
            vHashtable.Add("PTDEVS_QUOTIENT", DEVE_TXT.Text);
            vHashtable.Add("TYPE", "INS");
            DBManager.ExecInsUps(vHashtable, "INS_PT_DEVELOPMENTAL_SCREENING", vATSession);
        }
        else
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTDEVS_ID", TXTID.Value);
            vHashtable.Add("PTDEVS_PTPID", vID2);
            vHashtable.Add("PTDEVS_AGE", DEVE_AGE_TXT.Text);
            vHashtable.Add("PTDEVS_CHRONOLOGICAL_AGE", CHRO_TXT.Text);
            vHashtable.Add("PTDEVS_QUOTIENT", DEVE_TXT.Text);
            vHashtable.Add("TYPE", "UPD");
            DBManager.ExecInsUps(vHashtable, "INS_PT_DEVELOPMENTAL_SCREENING", vATSession);
        }
        Response.Redirect("DEVELOPMENTAL_SCREENING_TEST.aspx?id1=" + vID2);
    }
}
