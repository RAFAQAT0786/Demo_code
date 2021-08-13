using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IEP_MAPPING : BasePage
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
            DataColumn DCAT_NAME = new DataColumn();
            DCAT_NAME.DataType = Type.GetType("System.String");
            DCAT_NAME.ColumnName = "DCAT_NAME";
            dt.Columns.Add(DCAT_NAME);

            DataColumn DSCAT_DESC = new DataColumn();
            DSCAT_DESC.DataType = Type.GetType("System.String");
            DSCAT_DESC.ColumnName = "DSCAT_DESC";
            dt.Columns.Add(DSCAT_DESC);

            DataColumn IEPMD_NAME = new DataColumn();
            IEPMD_NAME.DataType = Type.GetType("System.String");
            IEPMD_NAME.ColumnName = "IEPMD_NAME";
            dt.Columns.Add(IEPMD_NAME);

            DataColumn IEPMD_DESC = new DataColumn();
            IEPMD_DESC.DataType = Type.GetType("System.String");
            IEPMD_DESC.ColumnName = "IEPMD_DESC";
            dt.Columns.Add(IEPMD_DESC);

            DataColumn DCAT_ID = new DataColumn();
            DCAT_ID.DataType = Type.GetType("System.String");
            DCAT_ID.ColumnName = "DCAT_ID";
            dt.Columns.Add(DCAT_ID);

            DataColumn DSCAT_ID = new DataColumn();
            DSCAT_ID.DataType = Type.GetType("System.String");
            DSCAT_ID.ColumnName = "DSCAT_ID";
            dt.Columns.Add(DSCAT_ID);

            DataColumn IEPMD_ID = new DataColumn();
            IEPMD_ID.DataType = Type.GetType("System.String");
            IEPMD_ID.ColumnName = "IEPMD_ID";
            dt.Columns.Add(IEPMD_ID);

            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();

            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("IEPMD_IEPMID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEP_MAPPING_ID"));
                    DataTable dt2 = DBManager.Get(vHashtable, "GET_IEP_MAPPING_ID");
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["IEPM_ID"].ToString();
                        Gridview2.DataSource = dt2;
                        Gridview2.DataBind();
                        Templatenew.Visible = false;
                        btnSave.Visible = true;
                    }
                    else
                        ShowMsg("Invalid IEP Mapping ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void DDLCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DCAT_ID", DDLCAT.SelectedValue.ToString());
        ATCommon.FillDrpDown(DDLSUBCAT, DBManager.Get(vHashtable, "CMB_CATEGORY_ID"), "Select Sub Category Name", "DSCAT_DESC", "DSCAT_ID", "");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Gridview1.Rows.Count > 0)
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("IEPM_ID", TXTID.Value);
                    vHashtable.Add("TYPE", "INS");
                    if (DBManager.ExecInsUpsReturn(vHashtable, "INS_IEP_MAPPING_MASTER", (ATSession)Session["User"]))
                    {
                        foreach (GridViewRow gr in Gridview1.Rows)
                        {
                            Label DCAT_ID = (gr.Cells[5].FindControl("DCAT_ID") as Label);
                            Label DSCAT_ID = (gr.Cells[6].FindControl("DSCAT_ID") as Label);
                            string SKILL = Gridview1.Rows[gr.RowIndex].Cells[2].Text;
                            string Observation = Gridview1.Rows[gr.RowIndex].Cells[3].Text;

                            Hashtable vHashtable1 = new Hashtable();
                            vHashtable1.Add("IEPMD_ID", TXTVALUE.Value);
                            vHashtable1.Add("IEPMD_IEPMID", TXTID.Value);
                            vHashtable1.Add("IEPMD_DCATID", DCAT_ID.Text);
                            vHashtable1.Add("IEPMD_DSCATID", DSCAT_ID.Text);
                            vHashtable1.Add("IEPMD_NAME", SKILL);
                            vHashtable1.Add("IEPMD_DESC", Observation);
                            vHashtable1.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable1, "INS_IEP_MAPPING_DETAIL", (ATSession)Session["User"]);
                        }
                    }
                    Response.Redirect("IEP_MAPPING_List.aspx");
                    Clear();
                    // }
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            else
            {
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("IEPM_ID", TXTID.Value);
                    vHashtable.Add("TYPE", "UPD");
                    if (DBManager.ExecInsUpsReturn(vHashtable, "INS_IEP_MAPPING_MASTER", (ATSession)Session["User"]))
                    {
                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("IEPMD_ID", "");
                        vHashtable1.Add("IEPMD_IEPMID", TXTID.Value);
                        vHashtable1.Add("IEPMD_DCATID", DDLCAT.SelectedValue);
                        vHashtable1.Add("IEPMD_DSCATID", DDLSUBCAT.SelectedValue);
                        vHashtable1.Add("IEPMD_NAME", SKILL_TXT.Text);
                        vHashtable1.Add("IEPMD_DESC", Textarea1.InnerText);
                        vHashtable1.Add("TYPE", "UPD");
                        DBManager.ExecInsUps(vHashtable1, "INS_IEP_MAPPING_DETAIL", (ATSession)Session["User"]);
                    }
                    Response.Redirect("IEP_MAPPING_List.aspx");
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
        Label IEPMD_ID = (Label)Gridview2.Rows[e.RowIndex].FindControl("IEPMD_ID");
        TextBox IEPMD_NAME = (TextBox)Gridview2.Rows[e.RowIndex].FindControl("IEPMD_NAME");
        TextBox IEPMD_DESC = (TextBox)Gridview2.Rows[e.RowIndex].FindControl("IEPMD_DESC");

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPMD_ID", IEPMD_ID.Text);
        vHashtable.Add("IEPMD_NAME", IEPMD_NAME.Text);
        vHashtable.Add("IEPMD_DESC", IEPMD_DESC.Text);
        vHashtable.Add("LAST_USER", vATSession.Login);
        DataRow vDR = RetDR(DBManager.Get(vHashtable, "UPDATE_IEP_MAPPING_DETAIL"));
        Gridview2.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        DataTable dt3 = DBManager.Get(vHashtable, "UPDATE_IEP_MAPPING_DETAIL");
        Gridview2.DataSource = dt3;
        Gridview2.DataBind();
    }

    protected void Gridview2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview2.EditIndex = e.NewEditIndex;
        Label IEPMD_ID = (Label)Gridview2.Rows[e.NewEditIndex].FindControl("IEPMD_ID");

        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("IEPMD_ID", IEPMD_ID.Text);
        vHashtable1.Add("TYPE", "GET");
        DataRow vDR = RetDR(DBManager.Get(vHashtable1, "GET_IEP_MAPPING"));
        DataTable dt3 = DBManager.Get(vHashtable1, "GET_IEP_MAPPING");
        if (vDR != null)
        {
            DDLCAT.SelectedItem.Text = vDR["DCAT_NAME"].ToString();
            DDLSUBCAT.SelectedItem.Text = vDR["DSCAT_DESC"].ToString();
            SKILL_TXT.Text = vDR["IEPMD_NAME"].ToString();
            Textarea1.InnerText = vDR["IEPMD_DESC"].ToString();
        }

        btnAdd.Visible = true;
        btnSave.Visible = true;
    }

    protected void Gridview2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
    }

    protected void Gridview2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String vID2 = Request.QueryString["ID"];
        Label IEPMD_ID = (Label)Gridview2.Rows[e.RowIndex].FindControl("IEPMD_ID");

        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("IEPMD_ID", IEPMD_ID.Text);
        DBManager.ExecDel(vHashtable1, "DEL_IEP_MAPPING_DETAIL");
        ShowDeleteMsg(true);
        Gridview2.EditIndex = -1;
        Response.Redirect("IEP_MAPPING.aspx?id=" + vID2);
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
                    if (drow["DCAT_NAME"].Equals(DDLCAT.SelectedValue))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                    addrow();
                else
                {
                    ShowMsg("This Skill Activity Is Already Exist");
                }
            }
            else
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["DCAT_NAME"] = DDLCAT.SelectedItem.Text;
                dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem.Text;
                dr["IEPMD_NAME"] = SKILL_TXT.Text;
                dr["IEPMD_DESC"] = Textarea1.InnerText;
                dr["DCAT_ID"] = DDLCAT.SelectedValue;
                dr["DSCAT_ID"] = DDLSUBCAT.SelectedValue;
                dt.Rows.Add(dr);
                ViewState["datagrid"] = dt;
                BindGrid();
                Gridview1.HeaderRow.Cells[04].Visible = false;
                foreach (GridViewRow gdr in Gridview1.Rows)
                {
                    gdr.Cells[04].Visible = false;
                }
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
        dr["DCAT_NAME"] = DDLCAT.SelectedItem.Text;
        dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem.Text;
        dr["IEPMD_NAME"] = SKILL_TXT.Text;
        dr["IEPMD_DESC"] = Textarea1.InnerText;
        dr["DCAT_ID"] = DDLCAT.SelectedValue;
        dr["DSCAT_ID"] = DDLSUBCAT.SelectedValue;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
        Gridview1.HeaderRow.Cells[04].Visible = false;
        foreach (GridViewRow gdr in Gridview1.Rows)
        {
            gdr.Cells[04].Visible = false;
        }
        Templatenew.Visible = true;
    }

    protected void BindGrid()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
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
            Label DSCAT_DESC = (Label)Gridview1.Rows[index].FindControl("DSCAT_DESC");
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["DSCAT_DESC"].Equals(DDLSUBCAT.SelectedItem.Text))
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    break;
                }
                else
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    break;
                }
            }
            Gridview1.HeaderRow.Cells[04].Visible = false;
            foreach (GridViewRow gdr in Gridview1.Rows)
            {
                gdr.Cells[04].Visible = false;
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTIEP_MAPPING");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["IEPMD_DESC"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}