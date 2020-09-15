using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Patient_Template : BasePage
{
    private ATSession vATSession;
    private DataTable dt;
    private DataTable dt1;

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
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(DDLTEMP, DBManager.Get(new Hashtable(), "CMB_ANALYSIS_MASTER"), "Select Template Name", "ANM_NAME", "ANM_ID", "0");

                if (vATSession.UserType == "ADMIN")
                {
                    Link.Visible = false;
                    Div1.Visible = false;
                    Div2.Visible = false;
                    Div3.Visible = false;

                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PTP_ID"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["PTP_ID"].ToString();
                            AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_CUST.Text = vDR["PTP_CUSTID"].ToString();
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PTP_NAME.Enabled = false;
                            AGE_TXT.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid Patient ID");
                        }
                    }
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    Link.Visible = false;
                    Div1.Visible = false;
                    Div2.Visible = false;
                    Div3.Visible = false;

                    if (vID != null)
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("PTP_ID", vID);
                        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PTP_ID"));
                        if (vDR != null)
                        {
                            TXTID.Value = vDR["PTP_ID"].ToString();
                            AGE_TXT.Text = vDR["AGRP_GROUP"].ToString();
                            PTP_CUST.Text = vDR["PTP_CUSTID"].ToString();
                            PTP_NAME.Text = vDR["PTP_NAME"].ToString();
                            PTP_NAME.Enabled = false;
                            AGE_TXT.Enabled = false;
                        }
                        else
                        {
                            ShowMsg("Invalid Patient ID");
                        }
                    }
                    if (PTP_CUST.Text != null)
                    {
                        Hashtable vHashtable3 = new Hashtable();
                        vHashtable3.Add("CUST_ID", PTP_CUST.Text);
                        DataTable vDT = DBManager.Get(vHashtable3, "GET_CUST_SELL");
                        if (vDT.Rows.Count > 0)
                        {
                            GridView5.DataSource = vDT;
                            GridView5.DataBind();
                        }
                        else
                        {
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

    protected void DDLTEMP_SelectedIndexChanged(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("NAME", DDLTEMP.SelectedItem.Text);
        DataTable dt = DBManager.Get(vHashtable, "GET_TEMPLATE_NEWID"); 
        if (DDLTEMP.SelectedItem.Text == "Screening")
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Hashtable vHashtable1 = new Hashtable();
            DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "TOTAL_SCTP_PRICE"));
            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("NAME", DDLTEMP.SelectedItem.Text);
            DataTable dt5 = DBManager.Get(vHashtable5, "GET_TEMPLATE_QUANTITY");
            DataTable dt6 = new DataTable();
            var count = dt5.AsEnumerable().Where(r => r.Field<string>("Price") == "0" && r.Field<string>("Quantity") == "0");
            if (count == null)
            {
                dt6 = count.CopyToDataTable();
            }
            if (dt6.Rows.Count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Buy The Template First....!')", true);
            }
            else
            {
            }
            Link.Visible = true;
            Div1.Visible = false;
            Div2.Visible = false;
            Div3.Visible = false;
        }
        else if (DDLTEMP.SelectedItem.Text == "Assessment")
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
            Hashtable vHashtable2 = new Hashtable();
            DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "TOTAL_ASE_PRICE"));
            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("NAME", DDLTEMP.SelectedItem.Text);
            DataTable dt5 = DBManager.Get(vHashtable5, "GET_TEMPLATE_QUANTITY");
            DataTable dt6 = new DataTable();
            var count = dt5.AsEnumerable().Where(r => r.Field<string>("Price") == "0" && r.Field<string>("Quantity") == "0");
            if (count == null)
            {
                dt6 = count.CopyToDataTable();
            }
            if (dt6.Rows.Count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Buy The Template First....!')", true);
            }
            else
            {
            }
            Link.Visible = false;
            Div1.Visible = true;
        }
        else if (DDLTEMP.SelectedItem.Text == "IEP Report")
        {
            GridView3.DataSource = dt;
            GridView3.DataBind();
            Hashtable vHashtable3 = new Hashtable();
            DataRow vDR3 = RetDR(DBManager.Get(vHashtable3, "TOTAL_IEPDT_PRICE"));
            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("NAME", DDLTEMP.SelectedItem.Text);
            DataTable dt5 = DBManager.Get(vHashtable5, "GET_TEMPLATE_QUANTITY");
            DataTable dt6 = new DataTable();
            var count = dt5.AsEnumerable().Where(r => r.Field<string>("Price") == "0" && r.Field<string>("Quantity") == "0");
            if (count == null)
            {
                dt6 = count.CopyToDataTable();
            }
            if (dt6.Rows.Count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Buy The Template First....!')", true);
            }
            else
            {
            }
            Div1.Visible = false;
            Div3.Visible = false;
            Link.Visible = false;
            Div2.Visible = true;
        }
        else if (DDLTEMP.SelectedItem.Text == "Report Template")
        {
            GridView4.DataSource = dt;
            GridView4.DataBind();
            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("NAME", DDLTEMP.SelectedItem.Text);
            DataTable dt5 = DBManager.Get(vHashtable5, "GET_TEMPLATE_QUANTITY");
            DataTable dt6 = new DataTable();
            var count = dt5.AsEnumerable().Where(r => r.Field<string>("Price") == "0" && r.Field<string>("Quantity") == "0");
            if (count == null) 
            {
                dt6 = count.CopyToDataTable();
            }
            if (dt6.Rows.Count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Buy The Template First....!')", true);
            }
            else
            {
            }
            Div1.Visible = false;
            Link.Visible = false;
            Div2.Visible = false;
            Div3.Visible = true;
        }
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("Buy_Patient_Template.aspx");
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];
        Button btn = (Button)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        var amt = gvr.Cells[0].Text;

        string SCTP_ID = (gvr.Cells[0].FindControl("SCTP_ID") as Label).Text;
        string ASE_ID = (gvr.Cells[1].FindControl("ASE_ID") as Label).Text;
        string RPT_ID = (gvr.Cells[2].FindControl("RPT_ID") as Label).Text;
        string IEPDT_ID = (gvr.Cells[3].FindControl("IEPDT_ID") as Label).Text;
        if (SCTP_ID != "")
        {
            Response.Redirect("Patient_Doctor_Screening.aspx?id=" + vID + "&id1=" + PTP_CUST.Text);
        }
        else if (ASE_ID != "")
        {
            Response.Redirect("Patient_Doctor_Assessment.aspx?id=" + vID);
        }
        else if (RPT_ID != "")
        {
            Response.Redirect("Patient_Doctor_Report.aspx?id=" + vID);
        }
        else if (IEPDT_ID != "")
        {
            Response.Redirect("Patient_IEP.aspx?id=" + vID);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        String vID = Request.QueryString["ID"];
        foreach (GridViewRow gvrow in GridView5.Rows)
        {
            string TEMPLATE1 = GridView5.Rows[gvrow.RowIndex].Cells[0].Text;
            string PRICE1 = GridView5.Rows[gvrow.RowIndex].Cells[1].Text;
            string QUANTITY1 = GridView5.Rows[gvrow.RowIndex].Cells[2].Text;

            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("CUSTS_ID", TXTVALUE.Value);
            vHashtable5.Add("CUSTS_CUSTID", PTP_CUST.Text);
            vHashtable5.Add("CUSTS_NAME", TEMPLATE1);
            vHashtable5.Add("CUSTS_QUANTITY", QUANTITY1);
            vHashtable5.Add("CUSTS_PRICE", PRICE1);
            vHashtable5.Add("CUSTS_PTPID", vID);
            vHashtable5.Add("LAST_USER", vATSession.Login);
            DataTable dt5 = DBManager.Get(vHashtable5, "INS_CUST_SELL_NEW");
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    private void GetSelectedRows()
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("NAME", DDLTEMP.SelectedItem.Text);
        DataTable dt = DBManager.Get(vHashtable, "GET_TEMPLATE");
        DataRow dr = RetDR(DBManager.Get(vHashtable, "GET_TEMPLATE"));
        DataTable dt2 = new DataTable();
        dt2.Columns.Add("TEMPLATE_NAME").ToString();
        dt2.Columns.Add("PRICE_NAME").ToString();
        dt2.Columns.Add("QUANTITY").ToString();
        dt2.Columns.Add("SCTP_ID").ToString();
        dt2.Columns.Add("ASE_ID").ToString();
        dt2.Columns.Add("RPT_ID").ToString();
        dt2.Columns.Add("IEPDT_ID").ToString();
        dt2.Columns.Add("SCTP_NAME").ToString();
        dt2.Columns.Add("ASE_NAME").ToString();
        dt2.Columns.Add("RPT_NAME").ToString();
        dt2.Columns.Add("IEPDT_NAME").ToString();
        dt2.Columns.Add("SCTP_PRICE").ToString();
        dt2.Columns.Add("ASE_PRICE").ToString();
        dt2.Columns.Add("RPT_PRICE").ToString();
        dt2.Columns.Add("IEPDT_PRICE").ToString();
        dt2.Columns.Add("QUANTITY2").ToString();
        dt2.Columns.Add("QUANTITY3").ToString();
        dt2.Columns.Add("QUANTITY4").ToString();
        dt2.Columns.Add("QUANTITY5").ToString();
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            if (gvrow.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSelect") as CheckBox);
                if (chkSelect.Checked)
                {
                    var NAME = (gvrow.Cells[1].FindControl("TEMPLATE_NAME") as Label).Text;
                    var PRICE = (gvrow.Cells[2].FindControl("PRICE_NAME") as Label).Text;
                    var QUANTITY = (gvrow.Cells[3].FindControl("QUANTITY") as Label).Text;
                    string id = (gvrow.Cells[4].FindControl("SCTP_ID") as Label).Text;
                    var TEMPLATE1 = (gvrow.Cells[1].FindControl("TEMPLATE_NAME") as Label).Text;
                    var PRICE1 = (gvrow.Cells[2].FindControl("PRICE_NAME") as Label).Text;
                    var QUANTITY2 = (gvrow.Cells[3].FindControl("QUANTITY") as Label).Text;

                    DataRow gv2dr = dt2.NewRow();
                    gv2dr["TEMPLATE_NAME"] = NAME;
                    gv2dr["PRICE_NAME"] = PRICE;
                    gv2dr["QUANTITY"] = QUANTITY;
                    gv2dr["SCTP_ID"] = id;
                    gv2dr["SCTP_NAME"] = TEMPLATE1;
                    gv2dr["SCTP_PRICE"] = PRICE1;
                    gv2dr["QUANTITY2"] = QUANTITY2;
                    dt2.Rows.Add(gv2dr);
                }
            }
        }
        foreach (GridViewRow gvrow in GridView2.Rows)
        {
            if (gvrow.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSelect") as CheckBox);
                if (chkSelect.Checked)
                {
                    var NAME = (gvrow.Cells[1].FindControl("TEMPLATE_NAME") as Label).Text;
                    var PRICE = (gvrow.Cells[2].FindControl("PRICE_NAME") as Label).Text;
                    var QUANTITY = (gvrow.Cells[3].FindControl("QUANTITY") as Label).Text;
                    string id1 = (gvrow.Cells[4].FindControl("ASE_ID") as Label).Text;
                    var TEMPLATE2 = (gvrow.Cells[1].FindControl("TEMPLATE_NAME") as Label).Text;
                    var PRICE2 = (gvrow.Cells[2].FindControl("PRICE_NAME") as Label).Text;
                    var QUANTITY3 = (gvrow.Cells[3].FindControl("QUANTITY") as Label).Text;

                    DataRow gv2dr = dt2.NewRow();
                    gv2dr["TEMPLATE_NAME"] = NAME;
                    gv2dr["PRICE_NAME"] = PRICE;
                    gv2dr["QUANTITY"] = QUANTITY;
                    gv2dr["ASE_ID"] = id1;
                    gv2dr["ASE_NAME"] = TEMPLATE2;
                    gv2dr["ASE_PRICE"] = PRICE2;
                    gv2dr["QUANTITY3"] = QUANTITY3;
                    dt2.Rows.Add(gv2dr);
                }
            }
        }
        foreach (GridViewRow gvrow in GridView3.Rows)
        {
            if (gvrow.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSelect") as CheckBox);
                if (chkSelect.Checked)
                {
                    var NAME = (gvrow.Cells[1].FindControl("TEMPLATE_NAME") as Label).Text;
                    var PRICE = (gvrow.Cells[2].FindControl("PRICE_NAME") as Label).Text;
                    var QUANTITY = (gvrow.Cells[3].FindControl("QUANTITY") as Label).Text;
                    string id2 = (gvrow.Cells[4].FindControl("IEPDT_ID") as Label).Text;
                    var TEMPLATE3 = (gvrow.Cells[1].FindControl("TEMPLATE_NAME") as Label).Text;
                    var PRICE3 = (gvrow.Cells[2].FindControl("PRICE_NAME") as Label).Text;
                    var QUANTITY4 = (gvrow.Cells[3].FindControl("QUANTITY") as Label).Text;

                    DataRow gv2dr = dt2.NewRow();
                    gv2dr["TEMPLATE_NAME"] = NAME;
                    gv2dr["PRICE_NAME"] = PRICE;
                    gv2dr["QUANTITY"] = QUANTITY;
                    gv2dr["IEPDT_ID"] = id2;
                    gv2dr["IEPDT_NAME"] = TEMPLATE3;
                    gv2dr["IEPDT_PRICE"] = PRICE3;
                    gv2dr["QUANTITY4"] = QUANTITY4;
                    dt2.Rows.Add(gv2dr);
                }
            }
        }
        foreach (GridViewRow gvrow in GridView4.Rows)
        {
            if (gvrow.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (gvrow.Cells[0].FindControl("chkSelect") as CheckBox);
                if (chkSelect.Checked)
                {
                    var NAME = (gvrow.Cells[1].FindControl("TEMPLATE_NAME") as Label).Text;
                    var PRICE = (gvrow.Cells[2].FindControl("PRICE_NAME") as Label).Text;
                    var QUANTITY = (gvrow.Cells[3].FindControl("QUANTITY") as Label).Text;
                    string id3 = (gvrow.Cells[4].FindControl("RPT_ID") as Label).Text;
                    var TEMPLATE4 = (gvrow.Cells[1].FindControl("TEMPLATE_NAME") as Label).Text;
                    var PRICE4 = (gvrow.Cells[2].FindControl("PRICE_NAME") as Label).Text;
                    var QUANTITY4 = (gvrow.Cells[3].FindControl("QUANTITY") as Label).Text;

                    DataRow gv2dr = dt2.NewRow();
                    gv2dr["TEMPLATE_NAME"] = NAME;
                    gv2dr["PRICE_NAME"] = PRICE;
                    gv2dr["QUANTITY"] = QUANTITY;
                    gv2dr["RPT_ID"] = id3;
                    gv2dr["RPT_NAME"] = TEMPLATE4;
                    gv2dr["RPT_PRICE"] = PRICE4;
                    gv2dr["QUANTITY4"] = QUANTITY4;
                    dt2.Rows.Add(gv2dr);
                }
            }
        }
        GridView5.DataSource = dt2;
        GridView5.DataBind();
    }

    protected void chkSelect_CheckChanged(object sender, EventArgs e)
    {
        GetSelectedRows();
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView5.PageIndex = e.NewPageIndex;
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
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
}