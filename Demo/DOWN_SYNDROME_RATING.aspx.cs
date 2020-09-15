using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;

public partial class DOWN_SYNDROME_RATING : BasePage
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
                ValidateUserAccess();

                if (vATSession.UserType == "ADMIN")
                {
                    if (vID2 != null)
                    {
                        Label2.Text = "<b>Please note:</b> This is the non standardized rating scale. You may select the best option suited for your patient." + "<br></br>";

                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_DOWN_SYNDROME_NEW");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DOWN_SYNDROME_NEW"));
                        if (dt1.Columns.Count > 6)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            Submitcar1.Visible = false;
                            btnSave.Visible = false;
                            if (vDR1 != null)
                            {
                                Textarea2.InnerText = vDR1["PTDS_REMARKS"].ToString();
                            }
                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                CheckBox checkbox = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox2");

                                if (vDR1["PTDS_STATUS"].ToString() == "1")
                                {
                                    checkbox.Checked = true;
                                }
                                else
                                {
                                    checkbox.Checked = false;
                                }
                            }
                        }
                        if (dt1.Columns.Count == 3)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            Submitcar.Visible = false;
                            btnSave.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID2 != null)
                    {
                        Label2.Text = "<b>Please note:</b> This is the non standardized rating scale. You may select the best option suited for your patient." + "<br></br>";

                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_DOWN_SYNDROME_NEW");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DOWN_SYNDROME_NEW"));
                        if (dt1.Columns.Count > 6)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            Submitcar1.Visible = false;
                            btnSave.Visible = false;
                            if (vDR1 != null)
                            {
                                Textarea2.InnerText = vDR1["PTDS_REMARKS"].ToString();
                            }
                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                CheckBox checkbox = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox2");

                                if (vDR1["PTDS_STATUS"].ToString() == "1")
                                {
                                    checkbox.Checked = true;
                                }
                                else
                                {
                                    checkbox.Checked = false;
                                }
                            }
                        }
                        if (dt1.Columns.Count == 3)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            Submitcar.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    if (vID2 != null)
                    {
                        Label2.Text = "<b>Please note:</b> This is the non standardized rating scale. You may select the best option suited for your patient."+"<br></br>";

                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_DOWN_SYNDROME_NEW");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DOWN_SYNDROME_NEW"));
                        if (dt1.Columns.Count > 6)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            Submitcar1.Visible = false;
                            btnSave.Visible = false;
                            if (vDR1 != null)
                            {
                                Textarea2.InnerText = vDR1["PTDS_REMARKS"].ToString();
                            }
                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                CheckBox checkbox = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox2");

                                if (vDR1["PTDS_STATUS"].ToString() == "1")
                                {
                                    checkbox.Checked = true;
                                }
                                else
                                {
                                    checkbox.Checked = false;
                                }
                            }
                        }
                        if (dt1.Columns.Count == 3)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            Submitcar.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    if (vID2 != null)
                    {
                        Label2.Text = "<b>Please note:</b> This is the non standardized rating scale. You may select the best option suited for your patient." + "<br></br>";

                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_DOWN_SYNDROME_NEW");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DOWN_SYNDROME_NEW"));
                        if (dt1.Columns.Count > 6)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            Submitcar1.Visible = false;
                            btnSave.Visible = false;
                            if (vDR1 != null)
                            {
                                Textarea2.InnerText = vDR1["PTDS_REMARKS"].ToString();
                            }
                            for (int j = 0; j < GridView1.Rows.Count; j++)
                            {
                                CheckBox checkbox = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox2");

                                if (vDR1["PTDS_STATUS"].ToString() == "1")
                                {
                                    checkbox.Checked = true;
                                }
                                else
                                {
                                    checkbox.Checked = false;
                                }
                            }
                        }
                        if (dt1.Columns.Count == 3)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            Submitcar.Visible = false;
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

        if (GridView1.Rows.Count > 0)
        {
            String vID = Request.QueryString["ID"];
            String vID2 = Request.QueryString["id1"];

            foreach (GridViewRow grd in GridView1.Rows)
            {
                Label DOWN_ID = (Label)grd.FindControl("DOWN_ID");
                Label DOWN_NAME = (Label)grd.FindControl("DOWN_NAME");
                Label DOWN_TRAIT = (Label)grd.FindControl("DOWN_TRAIT");
                CheckBox checkbox = (grd.Cells[0].FindControl("CheckBox2") as CheckBox);

                if (checkbox.Checked)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTDS_ID", TXTID.Value);
                    vHashtable.Add("PTDS_PTPID", vID2);
                    vHashtable.Add("PTDS_DOWNID", DOWN_ID.Text);
                    vHashtable.Add("PTDS_DOWN_TRAIT", DOWN_TRAIT.Text);
                    vHashtable.Add("PTDS_REMARKS", Textarea2.InnerText);
                    vHashtable.Add("PTDS_STATUS", "1");
                    vHashtable.Add("TYPE", "INS");
                    DBManager.ExecInsUps(vHashtable, "INS_DOWN_SYNDROME", vATSession);
                }
            }
            Response.Redirect("DOWN_SYNDROME_RATING.aspx?id1=" + vID2);
        }

    }

    protected void chckchanged(object sender, EventArgs e)
    {

        CheckBox chckheader = (CheckBox)GridView1.HeaderRow.FindControl("CheckBox1");

        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chckrw = (CheckBox)row.FindControl("CheckBox2");

            if (chckheader.Checked == true)
            {
                chckrw.Checked = true;
            }
            else
            {
                chckrw.Checked = false;
            }

        }
    }

}
    