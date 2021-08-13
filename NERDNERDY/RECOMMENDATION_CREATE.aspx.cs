using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RECOMMENDATION_CREATE : BasePage
{
    private ATSession vATSession;
    private DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
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

                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("RECOM_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_RECOMMENDATION_MASTER"));
                    DataTable dt2 = DBManager.Get(vHashtable, "GET_RECOMMENDATION_MASTER");
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["RECOM_ID"].ToString();
                        RECO_TXT.Text = vDR["RECOM_TEXT"].ToString();
                        Textarea1.InnerText = vDR["RECOMD_DESC"].ToString();
                        Gridview2.DataSource = dt2;
                        Gridview2.DataBind();
                        RECO_TXT.Enabled = false;
                        Templatenew.Visible = false;
                        Gridview2.HeaderRow.Cells[04].Visible = false;
                        foreach (GridViewRow gdr in Gridview2.Rows)
                        {
                            gdr.Cells[04].Visible = false;
                        }
                    }
                    else
                        ShowMsg("Invalid Recommendation ID");
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
        if (Page.IsValid)
        {
            if (Gridview1.Rows.Count > 0)
                if (TXTID.Value == "0")
                    try
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("RECOM_ID", TXTID.Value);
                        vHashtable.Add("RECOM_TEXT", RECO_TXT.Text);
                        vHashtable.Add("TYPE", "INS");
                        if (DBManager.ExecInsUpsReturn(vHashtable, "INS_RECOMMENDATION_MASTER", (ATSession)Session["User"]))
                        {
                            foreach (GridViewRow grw in Gridview1.Rows)
                            {
                                Label RECOMD_DESC = (Label)grw.FindControl("RECOMD_DESC");

                                Hashtable vHashtable1 = new Hashtable();
                                vHashtable1.Add("RECOMD_ID", TXTVALUE.Value);
                                vHashtable1.Add("RECOMD_RECOMID", TXTID.Value);
                                vHashtable1.Add("RECOMD_DESC", RECOMD_DESC.Text);
                                vHashtable1.Add("TYPE", "INS");
                                DBManager.ExecInsUps(vHashtable1, "INS_RECOMMENDATION_DETAIL", (ATSession)Session["User"]);
                            }
                        }
                        Response.Redirect("RECOMMENDATION_LIST.aspx");
                        Clear();
                    }
                    catch (Exception xe)
                    {
                        ShowMsg(xe);
                    }
                else
                {
                    try
                    {
                        foreach (GridViewRow grw in Gridview1.Rows)
                        {
                            Label RECOMD_DESC = (Label)grw.FindControl("RECOMD_DESC");

                            Hashtable vHashtable1 = new Hashtable();
                            vHashtable1.Add("RECOMD_ID", TXTVALUE.Value);
                            vHashtable1.Add("RECOMD_RECOMID", TXTID.Value);
                            vHashtable1.Add("RECOMD_DESC", RECOMD_DESC.Text);
                            vHashtable1.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable1, "INS_RECOMMENDATION_DETAIL_ID", (ATSession)Session["User"]);
                        }
                        Response.Redirect("RECOMMENDATION_LIST.aspx");
                        Clear();
                    }
                    catch (Exception xe)
                    {
                        ShowMsg(xe);
                    }
                }
        }
    }

    protected void Gridview2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label RECOM_ID = (Label)Gridview2.Rows[e.RowIndex].FindControl("RECOM_ID");
        Label RECOMD_ID = (Label)Gridview2.Rows[e.RowIndex].FindControl("RECOMD_ID");
        Label RECOMD_DESC = (Label)Gridview2.Rows[e.RowIndex].FindControl("RECOMD_DESC");

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("RECOMD_ID", RECOMD_ID.Text);
        vHashtable.Add("RECOMD_DESC", Textarea1.InnerText);
        DBManager.ExecInsUps(vHashtable, "UPDATE_RECOM_ID", vATSession);
        Gridview2.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        Hashtable vHashtable3 = new Hashtable();
        vHashtable3.Add("RECOM_ID", RECOM_ID.Text);
        DataTable dt3 = DBManager.Get(vHashtable3, "GET_RECOMMENDATION_ID");
        Gridview2.DataSource = dt3;
        Gridview2.DataBind();
        Gridview2.HeaderRow.Cells[04].Visible = false;
        foreach (GridViewRow gdr in Gridview2.Rows)
        {
            gdr.Cells[04].Visible = false;
        }
        btnAdd.Visible = true;
        btnSave.Visible = true;
    }

    protected void Gridview2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview2.EditIndex = e.NewEditIndex;
        Label RECOMD_ID = (Label)Gridview2.Rows[e.NewEditIndex].FindControl("RECOMD_ID");
        Label RECOM_ID = (Label)Gridview2.Rows[e.NewEditIndex].FindControl("RECOM_ID");
        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("RECOMD_ID", RECOMD_ID.Text);
        vHashtable1.Add("TYPE", "GET");
        DataRow vDR = RetDR(DBManager.Get(vHashtable1, "GET_RECOMMENDATION_DETAIL_NEW"));
        if (vDR != null)
        {
            RECO_TXT.Text = vDR["RECOM_TEXT"].ToString();
            Textarea1.InnerText = vDR["RECOMD_DESC"].ToString();
        }
        Hashtable vHashtable3 = new Hashtable();
        vHashtable3.Add("RECOM_ID", RECOM_ID.Text);
        DataTable dt3 = DBManager.Get(vHashtable3, "GET_RECOMMENDATION_ID");
        Gridview2.DataSource = dt3;
        Gridview2.DataBind();
        Gridview2.HeaderRow.Cells[04].Visible = false;
        foreach (GridViewRow gdr in Gridview2.Rows)
        {
            gdr.Cells[04].Visible = false;
        }
        btnAdd.Visible = false;
        btnSave.Visible = false;
    }

    protected void Gridview2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridview2.EditIndex = -1;
        Label RECOM_ID = (Label)Gridview2.Rows[e.RowIndex].FindControl("RECOM_ID");
        Hashtable vHashtable3 = new Hashtable();
        vHashtable3.Add("RECOM_ID", RECOM_ID.Text);
        DataTable dt3 = DBManager.Get(vHashtable3, "GET_RECOMMENDATION_ID");
        Gridview2.DataSource = dt3;
        Gridview2.DataBind();
        Gridview2.HeaderRow.Cells[04].Visible = false;
        foreach (GridViewRow gdr in Gridview2.Rows)
        {
            gdr.Cells[04].Visible = false;
        }
        btnAdd.Visible = true;
        btnSave.Visible = true;
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
                    if (drow["RECOMD_DESC"].Equals(Textarea1.InnerText))
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
                dr["RECOM_TEXT"] = RECO_TXT.Text;
                dr["RECOMD_DESC"] = Textarea1.InnerText;
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
        dr["RECOM_TEXT"] = RECO_TXT.Text;
        dr["RECOMD_DESC"] = Textarea1.InnerText;
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

    protected void Gridview2_RowDeleting(object sender, GridViewDeleteEventArgs e)
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

    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "delete")
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            Label RECOMD_DESC = (Label)Gridview2.Rows[index].FindControl("RECOMD_DESC");
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

    public void Clear()
    {
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