using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Curriculum_Observation : BasePage
{
    ATSession vATSession;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
        if (!IsPostBack)
        {
            dt = new DataTable();
            DataColumn coldisname = new DataColumn();
            coldisname.DataType = Type.GetType("System.String");
            coldisname.ColumnName = "CURRICULUM_ID";
            dt.Columns.Add(coldisname);

            DataColumn coltypgroup = new DataColumn();
            coltypgroup.DataType = Type.GetType("System.String");
            coltypgroup.ColumnName = "CURRICULUM_DSCATID";
            dt.Columns.Add(coltypgroup);

            DataColumn coltypgroup1 = new DataColumn();
            coltypgroup1.DataType = Type.GetType("System.String");
            coltypgroup1.ColumnName = "CURRICULUM_DCATID";
            dt.Columns.Add(coltypgroup1);

            DataColumn coldcname = new DataColumn();
            coldcname.DataType = Type.GetType("System.String");
            coldcname.ColumnName = "DCAT_NAME";
            dt.Columns.Add(coldcname);

            DataColumn coldesc = new DataColumn();
            coldesc.DataType = Type.GetType("System.String");
            coldesc.ColumnName = "DSCAT_DESC";
            dt.Columns.Add(coldesc);

            DataColumn coldobdes = new DataColumn();
            coldobdes.DataType = Type.GetType("System.String");
            coldobdes.ColumnName = "CURRICULUM_KEYWORD";
            dt.Columns.Add(coldobdes);

            DataColumn coldID = new DataColumn();
            coldID.DataType = Type.GetType("System.String");
            coldID.ColumnName = "CURRICULUM_DESC";
            dt.Columns.Add(coldID);

            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();

            DDLAGE.Enabled = true;
            btnUpdate.Visible = false;

            try
            {
                ValidateUserAccess();

                ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_GRP_MASTER"), "Select Group Name", "AGRP_GROUP", "AGRP_ID", "0");
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");

                if (vID != null)
                {
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("AGRPID", vID);
                    dt = DBManager.Get(vHashtable1, "GET_CURRICULUM_OBSERVATION");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable1, "GET_CURRICULUM_OBSERVATION"));
                    ViewState["datagrid"] = dt;
                    BindGrid();
                    btnAdd.Visible = false;
                    btnSave.Visible = false;
                    
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
            if (CURRICULUM.Rows.Count > 0)
                try
                {
                    foreach (GridViewRow grw in CURRICULUM.Rows)
                    {
                        Label CURRICULUM_DSCATID = (Label)grw.FindControl("CURRICULUM_DSCATID");
                        Label CURRICULUM_DCATID = (Label)grw.FindControl("CURRICULUM_DCATID");
                        Label CURRICULUM_KEYWORD = (Label)grw.FindControl("CURRICULUM_KEYWORD");
                        Label CURRICULUM_DESC = (Label)grw.FindControl("CURRICULUM_DESC");

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("CURRICULUM_ID", TXTID.Value);
                        vHashtable.Add("CURRICULUM_DCATID", CURRICULUM_DCATID.Text);
                        vHashtable.Add("CURRICULUM_DSCATID", CURRICULUM_DSCATID.Text);
                        vHashtable.Add("CURRICULUM_AGRPID", DDLAGE.SelectedValue);
                        vHashtable.Add("CURRICULUM_KEYWORD", CURRICULUM_KEYWORD.Text);
                        vHashtable.Add("CURRICULUM_DESC", CURRICULUM_DESC.Text);
                        vHashtable.Add("TYPE", "INS");
                        DBManager.ExecInsUps(vHashtable, "INS_CURRICULUM_OBSERVATION_MASTER", (ATSession)Session["User"]);
                    }
                        
                    Response.Redirect("Curriculum_Observation_List.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            else if (TXTID.Value == "0")
            {
                ShowMsg("Please add the Observation");
            }
            else
            {
                try
                {
                    foreach (GridViewRow grw in CURRICULUM.Rows)
                    {
                        Label CURRICULUM_ID = (Label)grw.FindControl("CURRICULUM_ID");
                        Label CURRICULUM_DSCATID = (Label)grw.FindControl("CURRICULUM_DSCATID");
                        Label CURRICULUM_DCATID = (Label)grw.FindControl("CURRICULUM_DCATID");
                        Label CURRICULUM_KEYWORD = (Label)grw.FindControl("CURRICULUM_KEYWORD");
                        Label CURRICULUM_DESC = (Label)grw.FindControl("CURRICULUM_DESC");

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("CURRICULUM_ID", CURRICULUM_ID.Text);
                        vHashtable.Add("CURRICULUM_DCATID", CURRICULUM_DCATID.Text);
                        vHashtable.Add("CURRICULUM_DSCATID", CURRICULUM_DSCATID.Text);
                        vHashtable.Add("CURRICULUM_AGRPID", DDLAGE.SelectedValue);
                        vHashtable.Add("CURRICULUM_KEYWORD", CURRICULUM_KEYWORD.Text);
                        vHashtable.Add("CURRICULUM_DESC", CURRICULUM_DESC.Text);
                        vHashtable.Add("TYPE", "INS");
                        DBManager.ExecInsUps(vHashtable, "INS_CURRICULUM_OBSERVATION_MASTER", (ATSession)Session["User"]);
                    }
                    Response.Redirect("Curriculum_Observation_List.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CURRICULUM_ID", TXTVALUE.Value);
        vHashtable.Add("CURRICULUM_KEYWORD", KEYWORD_TXT.Text);
        vHashtable.Add("CURRICULUM_DESC", Textarea1.InnerText);
        DBManager.ExecInsUps(vHashtable, "UPDATE_CURRICULUM_OBSERVATION", vATSession);
        CURRICULUM.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        BindGrid();
    }
    protected void CURRICULUM_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void CURRICULUM_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CURRICULUM.PageIndex = e.NewPageIndex;
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

    protected void BindGrid()
    {
        String vID = Request.QueryString["ID"];

        if (vID != null)
        {
            Hashtable vHashtable1 = new Hashtable();
            vHashtable1.Add("AGRPID", vID);
            dt = DBManager.Get(vHashtable1, "GET_CURRICULUM_OBSERVATION");
            CURRICULUM.DataSource = dt;
            CURRICULUM.DataBind();
        }
        else
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            CURRICULUM.DataSource = dt;
            CURRICULUM.DataBind();
            DDLAGE.Enabled = false;
        }
        
    }

    protected void addrow()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();
        dr["CURRICULUM_ID"] = TXTID.Value;
        dr["DCAT_NAME"] = DDLCAT.SelectedItem;
        dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
        dr["CURRICULUM_DESC"] = Textarea1.InnerText;
        dr["CURRICULUM_KEYWORD"] = KEYWORD_TXT.Text;
        dr["CURRICULUM_DCATID"] = DDLCAT.SelectedValue;
        dr["CURRICULUM_DSCATID"] = DDLSUBCAT.SelectedValue;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        if (dt.Rows.Count <= 120)
        {
            if (dt.Rows.Count > 0)
            {
                bool flag = false;
                foreach (DataRow drow in dt.Rows)
                {
                    if (drow["CURRICULUM_DESC"].Equals(Textarea1.InnerText))
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
                dr["CURRICULUM_ID"] = TXTID.Value;
                dr["DCAT_NAME"] = DDLCAT.SelectedItem;
                dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
                dr["CURRICULUM_DESC"] = Textarea1.InnerText;
                dr["CURRICULUM_KEYWORD"] = KEYWORD_TXT.Text;
                dr["CURRICULUM_DCATID"] = DDLCAT.SelectedValue;
                dr["CURRICULUM_DSCATID"] = DDLSUBCAT.SelectedValue;
                dt.Rows.Add(dr);
                ViewState["datagrid"] = dt;
                BindGrid();
                foreach (GridViewRow gdr in CURRICULUM.Rows)
                {
                    gdr.Cells[7].Visible = false;
                    foreach (DataControlField col in CURRICULUM.Columns)
                    {
                        if (col.HeaderText == "Modify")
                            col.Visible = false;

                    }
                }
            }
        }
        else
        {
            ShowMsg("Maximum 120 Profile Can Be Added.");
        }
    }

    public void Clear()
    {
    }


    protected void CURRICULUM_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "delete")
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            Label CURRICULUM_DESC = (Label)CURRICULUM.Rows[index].FindControl("CURRICULUM_DESC");
            Label CURRICULUM_ID = (Label)CURRICULUM.Rows[index].FindControl("CURRICULUM_ID"); // testing for deleting the CURRICULUM_ID
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["CURRICULUM_DESC"].Equals(CURRICULUM_DESC.Text))
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    break;
                }
               
            }
            if (CURRICULUM_ID.Text != "0")
            {
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("CURRICULUM_ID", CURRICULUM_ID.Text);
                DBManager.ExecInsUps(vHashtable, "DELETE_CURRICULUM_OBSERVATION_MASTER", vATSession);

                String vID = Request.QueryString["ID"];
                Hashtable vHashtable1 = new Hashtable();
                vHashtable1.Add("AGRPID", vID);
                dt = DBManager.Get(vHashtable1, "GET_CURRICULUM_OBSERVATION");
                ViewState["datagrid"] = dt;
                BindGrid();
                
            }
        }
        if (e.CommandName == "modify")
        {
                 vATSession = (ATSession)Session["User"];
                Label CURRICULUM_ID = (Label)CURRICULUM.Rows[index].FindControl("CURRICULUM_ID");

                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("CURRICULUM_ID", CURRICULUM_ID.Text);
                DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_CURRICULUM_OBSERVATION_ID"));

                if (vDR != null)
                {
                    DDLAGE.SelectedItem.Text = vDR["AGRP_GROUP"].ToString();
                    DDLCAT.SelectedItem.Text = vDR["DCAT_NAME"].ToString();
                    DDLSUBCAT.SelectedItem.Text = vDR["DSCAT_DESC"].ToString();
                    KEYWORD_TXT.Text = vDR["CURRICULUM_KEYWORD"].ToString();
                    Textarea1.InnerText = vDR["CURRICULUM_DESC"].ToString();
                    TXTVALUE.Value = vDR["CURRICULUM_ID"].ToString();
                    btnUpdate.Visible = true;
                    DDLAGE.Enabled = false;
                    DDLCAT.Enabled = false;
                    DDLSUBCAT.Enabled = false;
                }
        }
    }

    //for editing updating and cancel the row start
    protected void CURRICULUM_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
        Label CURRICULUM_ID = (Label)CURRICULUM.Rows[e.RowIndex].FindControl("CURRICULUM_ID");
        Label CURRICULUM_DESC = (Label)CURRICULUM.Rows[e.RowIndex].FindControl("CURRICULUM_DESC");
        Label CURRICULUM_KEYWORD = (Label)CURRICULUM.Rows[e.RowIndex].FindControl("CURRICULUM_KEYWORD");

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CURRICULUM_ID", CURRICULUM_ID.Text);
        vHashtable.Add("CURRICULUM_KEYWORD", CURRICULUM_KEYWORD.Text);
        vHashtable.Add("CURRICULUM_DESC", CURRICULUM_DESC.Text);
        DBManager.ExecInsUps(vHashtable, "UPDATE_CURRICULUM_OBSERVATION", vATSession);
        CURRICULUM.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        BindGrid();
    }

    protected void CURRICULUM_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CURRICULUM.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void CURRICULUM_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        CURRICULUM.EditIndex = -1;
        BindGrid();
    }


}