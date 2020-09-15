using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IEP_DISORDER_TEMPLATE : BasePage
{
    private ATSession vATSession;
    private DataTable dt;
    private DataTable dt1;
    private DataTable dt2;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
        if (!IsPostBack)
        {
            dt = new DataTable();
            DataColumn IEPDT_PRICE = new DataColumn();
            IEPDT_PRICE.DataType = Type.GetType("System.String");
            IEPDT_PRICE.ColumnName = "IEPDT_PRICE";
            dt.Columns.Add(IEPDT_PRICE);

            dt = new DataTable();
            DataColumn coldisname = new DataColumn();
            coldisname.DataType = Type.GetType("System.String");
            coldisname.ColumnName = "IEPDTD_DSCATID";
            dt.Columns.Add(coldisname);

            DataColumn coltypgroup = new DataColumn();
            coltypgroup.DataType = Type.GetType("System.String");
            coltypgroup.ColumnName = "IEPDTD_DCATID";
            dt.Columns.Add(coltypgroup);

            DataColumn coltypgroup1 = new DataColumn();
            coltypgroup1.DataType = Type.GetType("System.String");
            coltypgroup1.ColumnName = "IEPDTD_IEPAID";
            dt.Columns.Add(coltypgroup1);

            DataColumn coldcname = new DataColumn();
            coldcname.DataType = Type.GetType("System.String");
            coldcname.ColumnName = "DCAT_NAME";
            dt.Columns.Add(coldcname);

            DataColumn NAME = new DataColumn();
            NAME.DataType = Type.GetType("System.String");
            NAME.ColumnName = "DIS_NAME";
            dt.Columns.Add(NAME);

            DataColumn coldesc = new DataColumn();
            coldesc.DataType = Type.GetType("System.String");
            coldesc.ColumnName = "DSCAT_DESC";
            dt.Columns.Add(coldesc);

            DataColumn coldobdes = new DataColumn();
            coldobdes.DataType = Type.GetType("System.String");
            coldobdes.ColumnName = "IEPA_DESC";
            dt.Columns.Add(coldobdes);

            DataColumn coldID = new DataColumn();
            coldID.DataType = Type.GetType("System.String");
            coldID.ColumnName = "IEPDT_ID";
            dt.Columns.Add(coldID);

            DataColumn CID = new DataColumn();
            CID.DataType = Type.GetType("System.String");
            CID.ColumnName = "IEPA_ID";
            dt.Columns.Add(CID);

            DataColumn coldIEPD = new DataColumn();
            coldIEPD.DataType = Type.GetType("System.String");
            coldIEPD.ColumnName = "IEPDTD_IEPDTID";
            dt.Columns.Add(coldIEPD);

            DataColumn coldDCAT = new DataColumn();
            coldDCAT.DataType = Type.GetType("System.String");
            coldDCAT.ColumnName = "DSCAT_DCATID";
            dt.Columns.Add(coldDCAT);

            DataColumn IEPS_ID = new DataColumn();
            IEPS_ID.DataType = Type.GetType("System.String");
            IEPS_ID.ColumnName = "IEPS_ID";
            dt.Columns.Add(IEPS_ID);

            DataColumn IEPS_DESC = new DataColumn();
            IEPS_DESC.DataType = Type.GetType("System.String");
            IEPS_DESC.ColumnName = "IEPS_DESC";
            dt.Columns.Add(IEPS_DESC);

            DataColumn IEPDTD_PRODMID = new DataColumn();
            IEPDTD_PRODMID.DataType = Type.GetType("System.String");
            IEPDTD_PRODMID.ColumnName = "IEPDTD_PRODMID";
            dt.Columns.Add(IEPDTD_PRODMID);

            DataColumn PRODM_ID = new DataColumn();
            PRODM_ID.DataType = Type.GetType("System.String");
            PRODM_ID.ColumnName = "PRODM_ID";
            dt.Columns.Add(PRODM_ID);

            DataColumn PRODM_NAME = new DataColumn();
            PRODM_NAME.DataType = Type.GetType("System.String");
            PRODM_NAME.ColumnName = "PRODM_NAME";
            dt.Columns.Add(PRODM_NAME);

            DataColumn IEPDTD_ID = new DataColumn();
            IEPDTD_ID.DataType = Type.GetType("System.String");
            IEPDTD_ID.ColumnName = "IEPDTD_ID";
            dt.Columns.Add(IEPDTD_ID);

            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();

            DDLDIS.Enabled = true;
            IEP_NAME_TXT.Enabled = true;

            try
            {
                ValidateUserAccess();

                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                ATCommon.FillDrpDown(DDLIEA, DBManager.Get(new Hashtable(), "CMB_IEP_SKILL_ACTIVITY"), "Select IEA Name", "IEPA_DESC", "IEPA_ID", "0");
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");
                ATCommon.FillDrpDown(DDLPRODUCT, DBManager.Get(new Hashtable(), "CMB_PRODUCT_MASTER"), "Select Product Name", "PRODM_NAME", "PRODM_ID", "0");

                if (vID != null)
                {
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("ID", vID);
                    dt = DBManager.Get(vHashtable1, "GET_IEPDTD_DETAIL");
                    ViewState["datagrid"] = dt;
                    BindGrid();

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("IEPDTD_IEPDTID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_IEPDT_MASTER_ID"));
                    dt1 = DBManager.Get(vHashtable, "GET_IEPDT_MASTER_ID");

                    if (vDR != null)
                    {
                        TXTID.Value = vDR["IEPDT_ID"].ToString();
                        DDLDIS.SelectedValue = vDR["IEPDT_DISID"].ToString();
                        IEP_NAME_TXT.Text = vDR["IEPDT_NAME"].ToString();
                        DDLCAT_SelectedIndexChanged(sender, e);
                        for (int j = 0; j < IEPDT_ID.Rows.Count; j++)
                        {
                            Label IEPDTD_ID2 = (Label)IEPDT_ID.Rows[j].Cells[10].FindControl("IEPDTD_ID");
                            IEPDT_ID.HeaderRow.Cells[13].Visible = false;
                            foreach (GridViewRow gdr in IEPDT_ID.Rows)
                            {
                                gdr.Cells[13].Visible = false;
                            }
                        }
                        Hashtable vHashtable3 = new Hashtable();
                        vHashtable3.Add("IEPDT_ID", vID);
                        DataRow vDR2 = RetDR(DBManager.Get(vHashtable3, "GET_IEPDT_DETAIL_ID"));
                        dt2 = DBManager.Get(vHashtable3, "GET_IEPDT_DETAIL_ID");
                        for (int j = 0; j < IEPDT_ID.Rows.Count; j++)
                        {
                            TXTVALUE12.Value = dt2.Rows[j][2].ToString();
                        }
                        IEP_NAME_TXT.Enabled = false;
                        DDLDIS.Enabled = false;
                        btnAdd.Visible = false;
                        btnSave.Visible = false;
                    }
                    else
                        ShowMsg("Invalid IEP ID");
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

    protected void existence_ServerValidate(object sender, ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTIEPDT_MASTER");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["IEPDT_DISID"].ToString().Equals(DDLDIS.SelectedValue) && DR["IEPDT_NAME"].ToString().Equals(IEP_NAME_TXT.Text))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
    protected void btnAddNewIep_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (TXTID.Value == "0")
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("IEPDT_ID", TXTID.Value);
                    vHashtable.Add("IEPDT_DISID ", DDLDIS.SelectedValue);
                    vHashtable.Add("IEPDT_NAME", IEP_NAME_TXT.Text);
                    vHashtable.Add("TYPE", "INS");
                    if (DBManager.ExecInsUpsReturn(vHashtable, "INS_IEPDT_MASTER", (ATSession)Session["User"]))
                    {
                        foreach (GridViewRow grw in IEPDT_ID.Rows)
                        {
                            Label DCATID = (Label)grw.FindControl("DSCAT_DCATID");
                            Label TYPE_ID = (Label)grw.FindControl("IEPDTD_DSCATID");
                            Label DESC = (Label)grw.FindControl("IEPDTD_IEPAID");
                            Label IEPDTD_PRODMID = (Label)grw.FindControl("IEPDTD_PRODMID");

                            Hashtable vHashtable1 = new Hashtable();
                            vHashtable1.Add("IEPDTD_ID", TXTVALUE.Value);
                            vHashtable1.Add("IEPDTD_IEPDTID", TXTID.Value);
                            vHashtable1.Add("IEPDTD_DCATID", DCATID.Text);
                            vHashtable1.Add("IEPDTD_DSCATID", TYPE_ID.Text);
                            vHashtable1.Add("IEPDTD_PRODMID", IEPDTD_PRODMID.Text);
                            vHashtable1.Add("IEPDTD_IEPAID", DESC.Text);
                            vHashtable1.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable1, "INS_IEPDTD_DETAIL", (ATSession)Session["User"]);
                        }
                    }
                    Response.Redirect("IEP_DISORDER_TEMPLATE_LIST.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            else
            {
                bool Found = false;
                if (IEPDT_ID.Rows.Count > 0)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("IEPDT_NAME", IEP_NAME_TXT.Text);
                    vHashtable.Add("IEPDT_DISID", DDLDIS.SelectedValue.ToString());
                    DataTable Dt = DBManager.Get(vHashtable, "EXISTIEPDT_DIS_MASTER");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "EXISTIEPDT_DIS_MASTER"));
                    foreach (DataRow DR in Dt.Rows)
                    {

                        if (DR["IEPA_DESC"].ToString().Equals(DDLIEA.SelectedItem.Text))
                {
                            //Update the Quantity of the found row
                            //row.Cells[2].Value = Convert.ToString(1 + Convert.ToInt16(row.Cells[2].Value));
                            Found = true;
                        }

                    }
                    if (!Found)
                    {
                        //Add the row to grid view
                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("IEPDTD_ID", TXTVALUE.Value);
                        vHashtable1.Add("IEPDTD_IEPDTID", TXTID.Value);
                        vHashtable1.Add("IEPDTD_DCATID", DDLCAT.SelectedValue.ToString());
                        vHashtable1.Add("IEPDTD_DSCATID", DDLSUBCAT.SelectedValue.ToString());
                        vHashtable1.Add("IEPDTD_PRODMID", DDLPRODUCT.SelectedValue.ToString());
                        vHashtable1.Add("IEPDTD_IEPAID", DDLIEA.SelectedValue.ToString());
                        vHashtable1.Add("TYPE", "INS");
                        DBManager.ExecInsUps(vHashtable1, "INS_IEPDTD_DETAIL_NEW", (ATSession)Session["User"]);
                    }
                    else
                    {
                        string message = "IEP Skill Activity Already Exist!!";
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
                    string message = "IEP Skill Activity Already Exist!!";
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
        }
    }

    protected void IEPDT_ID_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void IEPDT_ID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        IEPDT_ID.PageIndex = e.NewPageIndex;
        BindGrid();
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
        DataTable dt = (DataTable)ViewState["datagrid"];
        IEPDT_ID.DataSource = dt;
        IEPDT_ID.DataBind();
        DDLDIS.Enabled = false;
        IEP_NAME_TXT.Enabled = false;
        for (int j = 0; j < IEPDT_ID.Rows.Count; j++)
        {
            Label IEPDTD_ID2 = (Label)IEPDT_ID.Rows[j].Cells[10].FindControl("IEPDTD_ID");
            //TXTVALUE12.Value = vDR["IEPDTD_ID"].ToString();
            //IEPDTD_ID2.Text = dt1.Rows[j][21].ToString();
            //HiddenField1.Value = IEPDTD_ID2.Text;

            IEPDT_ID.HeaderRow.Cells[13].Visible = false;
            foreach (GridViewRow gdr in IEPDT_ID.Rows)
            {
                gdr.Cells[13].Visible = false;
            }
        }
    }
    protected void addrow()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();
        dr["IEPDTD_IEPAID"] = DDLIEA.SelectedValue.ToString();
        dr["IEPDTD_DSCATID"] = DDLSUBCAT.SelectedValue.ToString();
        dr["DCAT_NAME"] = DDLCAT.SelectedItem;
        dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
        dr["IEPA_DESC"] = DDLIEA.SelectedItem.Text;
        dr["DIS_NAME"] = DDLDIS.SelectedItem;
        dr["IEPDTD_IEPDTID"] = TXTID.Value;
        dr["DSCAT_DCATID"] = DDLCAT.SelectedValue.ToString();

        dr["IEPDTD_PRODMID"] = DDLPRODUCT.SelectedValue;
        dr["PRODM_NAME"] = DDLPRODUCT.SelectedItem.Text;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
    }

    protected void addrownew()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();

        dr["IEPDTD_IEPAID"] = DDLIEA.SelectedValue.ToString();
        dr["IEPDTD_DSCATID"] = DDLSUBCAT.SelectedValue.ToString();
        dr["DCAT_NAME"] = DDLCAT.SelectedItem;
        dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
        dr["IEPA_DESC"] = DDLIEA.SelectedItem.Text;
        dr["DIS_NAME"] = DDLDIS.SelectedItem;
        dr["IEPDT_DISID"] = DDLDIS.SelectedValue;
        dr["IEPDTD_IEPDTID"] = TXTID.Value;
        dr["DSCAT_DCATID"] = DDLCAT.SelectedValue.ToString();
        dr["IEPDTD_PRODMID"] = DDLPRODUCT.SelectedValue;
        dr["PRODM_NAME"] = DDLPRODUCT.SelectedItem.Text;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
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
                        if (drow["IEPA_DESC"].Equals(DDLIEA.SelectedItem.Text))
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
                dr["IEPDTD_IEPAID"] = DDLIEA.SelectedValue.ToString();
                dr["IEPDTD_DSCATID"] = DDLSUBCAT.SelectedValue.ToString();
                dr["DCAT_NAME"] = DDLCAT.SelectedItem;
                dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
                dr["IEPA_DESC"] = DDLIEA.SelectedItem.Text;
                dr["DIS_NAME"] = DDLDIS.SelectedItem;
                dr["IEPDTD_IEPDTID"] = TXTID.Value;
                dr["DSCAT_DCATID"] = DDLCAT.SelectedValue.ToString();
                dr["IEPDTD_PRODMID"] = DDLPRODUCT.SelectedValue;
                dr["PRODM_NAME"] = DDLPRODUCT.SelectedItem.Text;
                dt.Rows.Add(dr);
                ViewState["datagrid"] = dt;
                BindGrid();
            }
        }
        else
            ShowMsg("Maximum 2225 Profile Can Be Added.");
    }

    public void Clear()
    {
    }

    protected void IEPDT_ID_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label IEPDTD_ID = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_ID");
        Label TYPE_ID = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_IEPDTID");
        Label DESC = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_DSCATID");
        Label IEPDTD_PRODMID = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_PRODMID");
        Label IEPDTD_IEPAID = (Label)IEPDT_ID.Rows[e.RowIndex].FindControl("IEPDTD_IEPAID");
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPDTD_ID", IEPDTD_ID.Text);
        vHashtable.Add("IEPDTD_DCATID", DDLCAT.SelectedValue);
        vHashtable.Add("IEPDTD_DSCATID", DDLSUBCAT.SelectedValue);
        vHashtable.Add("IEPDTD_PRODMID", DDLPRODUCT.SelectedValue);
        vHashtable.Add("IEPDTD_IEPAID", DDLIEA.SelectedValue);
        DBManager.ExecInsUps(vHashtable, "UPDATE_IEPDTD_ID", vATSession);
        IEPDT_ID.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        BindGrid();
        IEPDT_ID.HeaderRow.Cells[13].Visible = false;
        foreach (GridViewRow gdr in IEPDT_ID.Rows)
        {
            gdr.Cells[13].Visible = false;
        }
        Response.Redirect("IEP_DISORDER_TEMPLATE.aspx?id=" + TXTID.Value);
        //}
    }

    protected void IEPDT_ID_RowEditing(object sender, GridViewEditEventArgs e)
    {
        IEPDT_ID.EditIndex = e.NewEditIndex;
        Label IEPDTD_ID = (Label)IEPDT_ID.Rows[e.NewEditIndex].FindControl("IEPDTD_ID");
        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("IEPDTD_ID", IEPDTD_ID.Text);
        vHashtable1.Add("TYPE", "GET");
        DataRow vDR = RetDR(DBManager.Get(vHashtable1, "GET_IEPDT_MASTER_NEW"));
        if (vDR != null)
        {
            DDLCAT.SelectedIndex = DDLCAT.Items.IndexOf(DDLCAT.Items.FindByValue(vDR["DCAT_ID"].ToString()));
            DDLCAT_SelectedIndexChanged(sender, e);
            DDLSUBCAT.SelectedIndex = DDLSUBCAT.Items.IndexOf(DDLSUBCAT.Items.FindByValue(vDR["IEPDTD_DSCATID"].ToString()));
            DDLIEA.SelectedIndex = DDLIEA.Items.IndexOf(DDLIEA.Items.FindByValue(vDR["IEPDTD_IEPAID"].ToString()));
            DDLPRODUCT.SelectedIndex = DDLPRODUCT.Items.IndexOf(DDLPRODUCT.Items.FindByValue(vDR["IEPDTD_PRODMID"].ToString()));
        }
        IEPDT_ID.DataSource = dt;
        IEPDT_ID.DataBind();
        BindGrid();
        IEPDT_ID.HeaderRow.Cells[13].Visible = false;
        foreach (GridViewRow gdr in IEPDT_ID.Rows)
        {
            gdr.Cells[13].Visible = false;
        }
        btnAdd.Visible = false;
        btnSave.Visible = false;
    }

    protected void IEPDT_ID_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        IEPDT_ID.EditIndex = -1;
        BindGrid();
        IEPDT_ID.HeaderRow.Cells[13].Visible = false;
        foreach (GridViewRow gdr in IEPDT_ID.Rows)
        {
            gdr.Cells[13].Visible = false;
        }
    }

    protected void IEPDT_ID_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "delete")
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            Label IEPDTD_IEPAID = (Label)IEPDT_ID.Rows[index].FindControl("IEPDTD_IEPAID");
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["IEPDTD_IEPAID"].Equals(IEPDTD_IEPAID.Text))
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    break;
                }
                else
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("IEPDTD_ID", TXTID.Value);
                    DBManager.ExecDel(vHashtable, "DEL_IEPDTD_DETAIL");
                }
            }
        }
    }
}