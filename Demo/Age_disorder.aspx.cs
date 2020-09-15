using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Age_disorder : BasePage
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
            coldisname.ColumnName = "AGDD_AGDMID";
            dt.Columns.Add(coldisname);

            DataColumn coltypgroup = new DataColumn();
            coltypgroup.DataType = Type.GetType("System.String");
            coltypgroup.ColumnName = "AGDD_DOBSID";
            dt.Columns.Add(coltypgroup);

            DataColumn coltypgroup1 = new DataColumn();
            coltypgroup1.DataType = Type.GetType("System.String");
            coltypgroup1.ColumnName = "AGDD_DSCATID";
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
            coldobdes.ColumnName = "DOBS_DESC";
            dt.Columns.Add(coldobdes);

            DataColumn coldID = new DataColumn();
            coldID.DataType = Type.GetType("System.String");
            coldID.ColumnName = "AGDD_ID";
            dt.Columns.Add(coldID);

            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();

            DDLDIS.Enabled = true;
            DDLAGE.Enabled = true;

            try
            {
                ValidateUserAccess();

                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_GRP_MASTER"), "Select Group Name", "AGRP_GROUP", "AGRP_ID", "0");
                ATCommon.FillDrpDown(DDLCAT, DBManager.Get(new Hashtable(), "CMB_DIS_CAT_MASTER"), "Select Category Name", "DCAT_NAME", "DCAT_ID", "0");
                //ATCommon.FillDrpDown(DDLSUBCAT, DBManager.Get(new Hashtable(), "CMB_DIS_SUBCAT_MASTER"), "Select Sub Category Name", "DSCAT_DESC", "DSCAT_ID", "0");
                ATCommon.FillDrpDown(DDLOBSER, DBManager.Get(new Hashtable(), "CMB_DIS_OBSV_MASTER"), "Select Observation Name", "DOBS_DESC", "DOBS_ID", "0");
                ATCommon.FillDrpDown(ANALYSIS_DDL, DBManager.Get(new Hashtable(), "CMB_ANALYSIS_MASTER"), "Select Analysis Name", "ANM_NAME", "ANM_ID", "0");

                if (vID != null)
                {
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("ID", vID);
                    dt = DBManager.Get(vHashtable1, "GET_AGDIS_DETAIL");
                    ViewState["datagrid"] = dt;
                    BindGrid();
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("AGDM_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_AGDIS_MASTER_NEW"));

                    if (vDR != null)
                    {
                        TXTID.Value = vDR["AGDM_ID"].ToString();
                        DDLDIS.SelectedValue = vDR["AGDM_DISID"].ToString();
                        DDLAGE.SelectedValue = vDR["AGDM_AGRPID"].ToString();
                        DDLAGE.SelectedItem.Text = vDR["AGRP_GROUP"].ToString();
                        ANALYSIS_DDL.SelectedValue = vDR["AGDM_ANMID"].ToString();
                        DDLAGE.Enabled = false;
                        DDLDIS.Enabled = false;
                        ANALYSIS_DDL.Enabled = false;
                        btnAdd.Visible = false;
                        btnSave.Visible = false;
                        AGE_GRP.Enabled = false;
                    }
                    else
                        ShowMsg("Invalid Age ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void ANALYSIS_DDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("ANM_ID", ANALYSIS_DDL.SelectedValue.ToString());
        ATCommon.FillDrpDown(DDLAGE, DBManager.Get(vHashtable, "CMB_AGEGRP"), "Select Group Name", "AGRP_GROUP", "AGRP_ID", "");
    }

    protected void DDLAGE_SelectedIndexChanged(object sender, EventArgs e)
    {
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTAGDIS_MASTER");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["AGDM_DISID"].ToString().Equals(DDLDIS.SelectedValue) && DR["AGDM_AGRPID"].ToString().Equals(DDLAGE.SelectedValue))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (AGE_GRP.Rows.Count > 0)
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("AGDM_ID", TXTID.Value);
                    vHashtable.Add("AGDM_DISID", DDLDIS.SelectedValue);
                    vHashtable.Add("AGDM_AGRPID", DDLAGE.SelectedValue);
                    vHashtable.Add("AGDM_ANMID", ANALYSIS_DDL.SelectedValue);
                    vHashtable.Add("TYPE", "INS");
                    if (DBManager.ExecInsUpsReturn(vHashtable, "INS_AGDIS_MASTER", (ATSession)Session["User"]))
                    {
                        foreach (GridViewRow grw in AGE_GRP.Rows)
                        {
                            Hashtable vHashtable1 = new Hashtable();
                            Label TYPE_ID = (Label)grw.FindControl("AGDD_DSCATID");
                            Label VALUE = (Label)grw.FindControl("AGDD_AGDMID");
                            Label DESC = (Label)grw.FindControl("AGDD_DOBSID");
                            vHashtable1.Add("AGDD_ID", VALUE.Text);
                            vHashtable1.Add("AGDD_AGDMID", TXTID.Value);
                            vHashtable1.Add("AGDD_DSCATID", TYPE_ID.Text);
                            vHashtable1.Add("AGDD_DOBSID", DESC.Text);
                            DBManager.ExecInsUps(vHashtable1, "INS_AGDIS_DETAIL", (ATSession)Session["User"]);
                        }
                    }
                    Response.Redirect("Age_disorder_List.aspx");
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
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("AGDM_ID", TXTID.Value);
                    vHashtable.Add("AGDM_DISID", DDLDIS.SelectedValue);
                    vHashtable.Add("AGDM_AGRPID", DDLAGE.SelectedValue);
                    vHashtable.Add("AGDM_ANMID", ANALYSIS_DDL.SelectedValue);
                    vHashtable.Add("TYPE", "UPD");
                    if (DBManager.ExecInsUpsReturn(vHashtable, "INS_AGDIS_MASTER", (ATSession)Session["User"]))
                    {
                        foreach (GridViewRow grw in AGE_GRP.Rows)
                        {
                            Hashtable vHashtable1 = new Hashtable();
                            Label TYPE_ID = (Label)grw.FindControl("AGDD_AGDMID");
                            Label VALUE = (Label)grw.FindControl("AGDD_DSCATID");
                            Label DESC = (Label)grw.FindControl("AGDD_DOBSID");
                            vHashtable1.Add("AGDD_ID", TXTID.Value);
                            vHashtable1.Add("AGDD_AGDMID", TYPE_ID.Text);
                            vHashtable1.Add("AGDD_DSCATID", VALUE.Text);
                            vHashtable1.Add("AGDD_DOBSID", DESC.Text);
                            DBManager.ExecInsUps(vHashtable1, "INS_AGDIS_DETAIL", (ATSession)Session["User"]);
                        }
                    }
                    Response.Redirect("Age_disorder_List.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            }
        }
    }

    protected void AGE_GRP_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void AGE_GRP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        AGE_GRP.PageIndex = e.NewPageIndex;
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
        AGE_GRP.DataSource = dt;
        AGE_GRP.DataBind();
        DDLDIS.Enabled = false;
        DDLAGE.Enabled = false;
    }

    protected void addrow()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();
        dr["AGDD_AGDMID"] = DDLAGE.SelectedValue.ToString();
        dr["AGDD_DOBSID"] = DDLOBSER.SelectedValue.ToString();
        dr["AGDD_DSCATID"] = DDLSUBCAT.SelectedValue.ToString();
        dr["DCAT_NAME"] = DDLCAT.SelectedItem;
        dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
        dr["DOBS_DESC"] = DDLOBSER.SelectedItem;
        dr["AGDD_ID"] = DDLDIS.SelectedValue;
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
                    if (drow["DOBS_DESC"].Equals(DDLOBSER.SelectedItem.Text))
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
                dr["AGDD_AGDMID"] = DDLAGE.SelectedValue;
                dr["AGDD_DOBSID"] = DDLOBSER.SelectedValue;
                dr["AGDD_DSCATID"] = DDLSUBCAT.SelectedValue;
                dr["DCAT_NAME"] = DDLCAT.SelectedItem;
                dr["DSCAT_DESC"] = DDLSUBCAT.SelectedItem;
                dr["DOBS_DESC"] = DDLOBSER.SelectedItem;
                dr["AGDD_ID"] = DDLDIS.SelectedValue;
                dt.Rows.Add(dr);
                ViewState["datagrid"] = dt;
                BindGrid();
            }
        }
        else
            ShowMsg("Maximum 120 Profile Can Be Added.");
    }

    public void Clear()
    {
    }

    protected void AGE_GRP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "delete")
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            Label AGDD_DOBSID = (Label)AGE_GRP.Rows[index].FindControl("AGDD_DOBSID");
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["AGDD_DOBSID"].Equals(AGDD_DOBSID.Text))
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    break;
                }
            }
        }
    }
}