using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class Customer_Organization_List : BasePage
{
    private ATSession vATSession;

    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        String vID = Request.QueryString["id"];
        String vID1 = Request.QueryString["id1"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        ValidateUserAccess();
        if (vATSession.UserType == "ADMIN")
        {
            Hashtable vHashtable4 = new Hashtable();
            vHashtable4.Add("CUSTID", vID);
            vHashtable4.Add("CUST_ORGANIZATION_NAME", vID1);
            DataTable dt = DBManager.Get(vHashtable4, "GET_PT_PERSONAL_NEW");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cust1.Visible = true;
            Div1.Visible = false;
            login_pop.Visible = false;
            LinkButton1.Visible = false;
        }
        else if (vATSession.UserType == "Organization" || vATSession.UserType == "ORGANIZATION")
        {
            Hashtable vHashtable4 = new Hashtable();
            vHashtable4.Add("CUSTID", vID);
            vHashtable4.Add("CUST_ORGANIZATION_NAME", vID1);
            DataTable dt = DBManager.Get(vHashtable4, "GET_PT_PERSONAL_NEW");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cust1.Visible = true;
            Div1.Visible = false;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
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

    protected void btn_home_Click(object sender, EventArgs e)
    {
        if (vATSession.UserType == "ADMIN")
        {
            Response.Redirect("Admin_Welcome.aspx");
        }
        if (vATSession.UserType == "ORGANIZATION")
        {
            Response.Redirect("Organization_Welcome.aspx");
        }
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "PATIENT")
        {
            Label CUSTA_SCTPID = (Label)GridView1.Rows[index].FindControl("CUSTA_SCTPID");
            Label PTP_ID = (Label)GridView1.Rows[index].FindControl("PTP_ID");

            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", PTP_ID.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ID");
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Patient_Doctor_Screening.aspx?id=" + PTP_ID.Text);
            }
        }
        else if (e.CommandName == "EVALUATION")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            Hashtable vHashtable2 = new Hashtable();
            vHashtable2.Add("PTP_ID", id);
            DataTable vDT2 = DBManager.Get(vHashtable2, "GET_DIS_MASTER_NEW");
            DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "GET_DIS_MASTER_NEW"));
            Response.Redirect("Patient_Doctor_Evaluation.aspx?id1=" + id);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string values = TXTVALUE.Value.Remove(TXTVALUE.Value.Length - 1);

        Hashtable vHT = new Hashtable();
        vHT.Add("PTP_ID", values);
        DataRow vDR2 = RetDR(DBManager.Get(vHT, "GET_PTPID"));
        if (vDR2 != null)
        {
            HiddenField22.Value = vDR2["PTP_MOBILE"].ToString();
        }

        foreach (string value in values.Split(','))
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", values);
            vHashtable.Add("PTP_MOBILE", HiddenField22.Value);
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_PATIENT_NUMBER");
        }
        ShowDeleteMsg(true);
        Response.Redirect("Customer_Organization.aspx");
    }

    protected void btnSearchPatient_Click(object sender, EventArgs e)
    {
        if (vATSession.UserType == "ADMIN")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("NAME", PTP_NAME_TXT.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ADMIN");
            GridView2.DataSource = dt;
            GridView2.DataBind();
            PTP1.Visible = false;
            Div1.Visible = true;
        }
        else
        {
            if (PTP_NAME_TXT.Text != null)
            {
                String vID3 = Request.QueryString["id"];

                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("NAME", PTP_NAME_TXT.Text);
                vHashtable.Add("PTP_CUSTID", vID3);
                DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_NAME");
                GridView2.DataSource = dt;
                GridView2.DataBind();
                PTP1.Visible = false;
                Div1.Visible = true;
            }
            else
            {
                ShowMsg("NOT FOUND ANY PATIENT NAME");
            }
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "PATIENT")
        {
            Label CUSTA_SCTPID = (Label)GridView2.Rows[index].FindControl("CUSTA_SCTPID");
            Label PTP_ID = (Label)GridView2.Rows[index].FindControl("PTP_ID");

            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", PTP_ID.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ID");
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Patient_Doctor_Screening.aspx?id=" + PTP_ID.Text);
            }
        }
        else if (e.CommandName == "EVALUATION")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            Hashtable vHashtable2 = new Hashtable();
            vHashtable2.Add("PTP_ID", id);
            DataTable vDT2 = DBManager.Get(vHashtable2, "GET_DIS_MASTER_NEW");
            DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "GET_DIS_MASTER_NEW"));
            Response.Redirect("Patient_Doctor_Evaluation.aspx?id1=" + id);
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
    }
}