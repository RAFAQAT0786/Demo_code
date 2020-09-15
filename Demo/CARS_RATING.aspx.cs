using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;

public partial class CARS_RATING : BasePage
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
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_CARS");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_CARS"));
                        if (dt1.Columns.Count > 6)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            car.Visible = false;
                        }
                        if (dt1.Columns.Count == 2)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            Submitcar.Visible = false;
                            btnSave.Visible = false;
                            //  car.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    if (vID2 != null)
                    {
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_CARS");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_CARS"));
                        if (dt1.Columns.Count > 6)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            car.Visible = false;
                        }
                        if (dt1.Columns.Count == 2)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            Submitcar.Visible = false;
                           // btnSave.Visible = false;
                            //  car.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    if (vID2 != null)
                    {
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID2);
                        DataTable dt1 = DBManager.Get(vHashtable2, "GET_PT_CARS");
                        DataRow vDR1 = RetDR(DBManager.Get(vHashtable2, "GET_PT_CARS"));
                        if (dt1.Columns.Count > 6)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            car.Visible = false;
                        }
                        if (dt1.Columns.Count == 2)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            Submitcar.Visible = false;
                            // btnSave.Visible = false;
                            //  car.Visible = false;
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
                Label CAR_ID = (Label)grd.FindControl("CAR_ID");
                Label CAR_NAME = (Label)grd.FindControl("CAR_NAME");
                //TextBox PTC_VALUE = (TextBox)grd.FindControl("PTC_VALUE");
                TextBox PTC_RAWSCORE = (TextBox)grd.FindControl("PTC_RAWSCORE");
                TextBox PTC_REMARK = (TextBox)grd.FindControl("PTC_REMARK");
                if (PTC_REMARK.Text != "")
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTC_ID", TXTID.Value);
                    vHashtable.Add("PTC_PTPID", vID2);
                    vHashtable.Add("PTC_CARID", CAR_ID.Text);
                    vHashtable.Add("PTC_VALUE", "");
                    vHashtable.Add("PTC_RAWSCORE", PTC_RAWSCORE.Text);
                    vHashtable.Add("PTC_REMARKS", PTC_REMARK.Text);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.ExecInsUps(vHashtable, "INS_PT_CARS", vATSession);
                }
                else if (PTC_REMARK.Text == "" && PTC_RAWSCORE.Text != "")
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTC_ID", TXTID.Value);
                    vHashtable.Add("PTC_PTPID", vID2);
                    vHashtable.Add("PTC_CARID", CAR_ID.Text);
                    vHashtable.Add("PTC_VALUE", "");
                    vHashtable.Add("PTC_RAWSCORE", PTC_RAWSCORE.Text);
                    vHashtable.Add("PTC_REMARKS", "");
                    vHashtable.Add("TYPE", "INS");
                    DBManager.ExecInsUps(vHashtable, "INS_PT_CARS", vATSession);
                }
            }
            Response.Redirect("CARS_RATING.aspx?id1=" + vID2);
        }
    }

}
    