using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;

public partial class VSMS_RATING : BasePage
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
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_VSMS");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_VSMS"));
                        if (dt1.Columns.Count > 5)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            car.Visible = false;
                            btnSave.Visible = false;
                        }
                        if (dt1.Columns.Count == 2)
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
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_VSMS");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_VSMS"));
                        if (dt1.Columns.Count > 5)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            car.Visible = false;
                            btnSave.Visible = false;
                        }
                        if (dt1.Columns.Count == 2)
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
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_VSMS");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_VSMS"));
                        if (dt1.Columns.Count > 5)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            car.Visible = false;
                            btnSave.Visible = false;
                        }
                        if (dt1.Columns.Count == 2)
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
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_VSMS");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_VSMS"));
                        if (dt1.Columns.Count > 5)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            car.Visible = false;
                            btnSave.Visible = false;
                        }
                        if (dt1.Columns.Count == 2)
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
        String vID = Request.QueryString["ID"];
        String vID2 = Request.QueryString["id1"];

        if (GridView1.Rows.Count > 0)
        {
            foreach (GridViewRow grd in GridView1.Rows)
            {
                Label VSMS_ID = (Label)grd.FindControl("VSMS_ID");
                Label VSMS_NAME = (Label)grd.FindControl("VSMS_NAME");
                TextBox PTV_VALUE = (TextBox)grd.FindControl("PTV_VALUE");
                TextBox AGE_MONTH = (TextBox)grd.FindControl("AGE_MONTH");
                if (PTV_VALUE.Text != "")
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTV_ID", TXTID.Value);
                    vHashtable.Add("PTV_PTPID", vID2);
                    vHashtable.Add("PTV_VSMSID", VSMS_ID.Text);
                    vHashtable.Add("PTV_VALUE", PTV_VALUE.Text);
                    vHashtable.Add("TYPE", "INS");
                    vHashtable.Add("PTV_AGE_MONTH", AGE_MONTH.Text);
                    DBManager.ExecInsUps(vHashtable, "INS_PT_VSMS", vATSession);
                }
            }
            Response.Redirect("VSMS_RATING.aspx?id1=" + vID2);
        }
    }
}
    