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

public partial class Patient_Doctor_Recommendation : BasePage
{
    ATSession vATSession;
    DataTable dt;
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
            dt = new DataTable();

            DataColumn RECOM_TEXT = new DataColumn();
            RECOM_TEXT.DataType = Type.GetType("System.String");
            RECOM_TEXT.ColumnName = "RECOM_TEXT";
            dt.Columns.Add(RECOM_TEXT);

            DataColumn RECOMD_DESC = new DataColumn();
            RECOMD_DESC.DataType = Type.GetType("System.String");
            RECOMD_DESC.ColumnName = "RECOMD_DESC";
            dt.Columns.Add(RECOMD_DESC);

            DataColumn RECOM_ID = new DataColumn();
            RECOM_ID.DataType = Type.GetType("System.String");
            RECOM_ID.ColumnName = "RECOM_ID";
            dt.Columns.Add(RECOM_ID);

            DataColumn RECOMD_ID = new DataColumn();
            RECOMD_ID.DataType = Type.GetType("System.String");
            RECOMD_ID.ColumnName = "RECOMD_ID";
            dt.Columns.Add(RECOMD_ID);

            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();

            try
            {
                ValidateUserAccess();

                Label1.Text = "<b>Step 1</b>-You can select a given category and corresponding to that category is the set of recommendations given for your reference. You may choose those which are useful for your patient. You can add as many recommendations as you wish to, if at any stage you want to delete any recommendation, you can do so by clicking the <b>'cross'</b>." +
                        "<br><b>Step 2</b>- Once you have added you recommendations, you can save them.  At any given point in time, you want to add more recommendations, you can do so. The recommendations which you have <b>'Saved'</b> will be included in your patients PDF report. </ br>";

                ATCommon.FillDrpDown(DDLRECOMMENDATION, DBManager.Get(new Hashtable(), "CMB_RECOMMENDATION"), "Select Recommendation Name", "RECOM_TEXT", "RECOM_ID", "0");
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTP_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataTable dt2 = DBManager.Get(vHashtable, "GET_RECOMMENDATION_MAPPING");
                    Gridview2.DataSource = dt2;
                    Gridview2.DataBind();
                    Templatenew.Visible = false;

                    // Hiding the save and add button from Organization
                    if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                    {
                        btnSave.Visible = false;
                        btnAdd.Visible = false;
                    }
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void DDLRECOMMENDATION_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("RECOM_ID", DDLRECOMMENDATION.SelectedValue.ToString());
        ATCommon.FillDrpDown(DDLDESC, DBManager.Get(vHashtable, "CMB_RECOMD_DESC"), "Select Description Name", "RECOMD_DESC", "RECOMD_ID", "");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Gridview1.Rows.Count > 0)
                if (TXTID.Value == "0")
                    try
                    {
                        foreach (GridViewRow grw in Gridview1.Rows)
                        {
                            String vID2 = Request.QueryString["ID"];
                            Label RECOMD_ID = (Label)grw.FindControl("RECOMD_ID");

                            Hashtable vHashtable1 = new Hashtable();
                            vHashtable1.Add("RECOMM_ID", TXTID.Value);
                            vHashtable1.Add("RECOMM_PTPID", vID2);
                            vHashtable1.Add("RECOMM_RECOMDID", RECOMD_ID.Text);
                            vHashtable1.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable1, "INS_RECOMMENDATION_MAPPING", (ATSession)Session["User"]);
                        }
                        Response.Redirect("Patient.aspx");
                        Clear();
                    }
                    catch (Exception xe)
                    {
                        ShowMsg(xe);
                    }
        }
    }

    public void Clear()
    {
    }
    protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "delete")
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            Label RECOMD_DESC = (Label)Gridview1.Rows[index].FindControl("RECOMD_DESC");
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["RECOMD_DESC"].Equals(RECOMD_DESC.Text))
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    string message = "Observation Deleted successful!!";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    break;
                }
            }
        }
    }

    protected void Gridview2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "delete")
        {
            String vID3 = Request.QueryString["ID"];
            Label RECOMM_ID = Gridview2.Rows[index].FindControl("RECOMM_ID") as Label;
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("RECOMM_ID", RECOMM_ID.Text);
            DBManager.ExecDel(vHashtable, "DEL_RECOMMENDATION_MAPPING");
            BindGrid();
            Response.Redirect("Patient_Doctor_Recommendation.aspx?id=" + vID3);
        }
        ShowDeleteMsg(true);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        if (dt.Rows.Count <= 2225)
        {
            if (dt.Rows.Count > 0)
            {
                bool flag = false;
                foreach (DataRow drow in dt.Rows)
                {
                    if (drow["RECOMD_DESC"].Equals(DDLDESC.SelectedItem.Text))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                    addrow();
                else
                {
                    string message = "This Observation Is Already Exist!!";
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
            else
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["RECOM_ID"] = DDLRECOMMENDATION.SelectedValue;
                dr["RECOMD_ID"] = DDLDESC.SelectedValue;
                dr["RECOM_TEXT"] = DDLRECOMMENDATION.SelectedItem.Text;
                dr["RECOMD_DESC"] = DDLDESC.SelectedItem;
                dt.Rows.Add(dr);
                ViewState["datagrid"] = dt;
                BindGrid();
                Templatenew.Visible = true;
            }
        }
        else
            ShowMsg("Maximum 2225 Profile Can Be Added.");
    }

    protected void addrow()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();
        dr["RECOM_ID"] = DDLRECOMMENDATION.SelectedValue;
        dr["RECOMD_ID"] = DDLDESC.SelectedValue;
        dr["RECOM_TEXT"] = DDLRECOMMENDATION.SelectedItem.Text;
        dr["RECOMD_DESC"] = DDLDESC.SelectedItem;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
        Templatenew.Visible = true;
    }

    protected void BindGrid()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTRECOMMENDATION");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["RECOMD_DESC"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}