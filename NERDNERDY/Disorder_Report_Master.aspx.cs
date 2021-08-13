using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Disorder_Report_Master : BasePage
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
            DataColumn DIS_NAME = new DataColumn();
            DIS_NAME.DataType = Type.GetType("System.String");
            DIS_NAME.ColumnName = "DIS_NAME";
            dt.Columns.Add(DIS_NAME);

            DataColumn DISO_RETT_PHY = new DataColumn();
            DISO_RETT_PHY.DataType = Type.GetType("System.String");
            DISO_RETT_PHY.ColumnName = "DISO_RETT_PHY";
            dt.Columns.Add(DISO_RETT_PHY);

            DataColumn DISO_RETT_OBSER = new DataColumn();
            DISO_RETT_OBSER.DataType = Type.GetType("System.String");
            DISO_RETT_OBSER.ColumnName = "DISO_RETT_OBSER";
            dt.Columns.Add(DISO_RETT_OBSER);

            DataColumn DISO_RET_DISID = new DataColumn();
            DISO_RET_DISID.DataType = Type.GetType("System.String");
            DISO_RET_DISID.ColumnName = "DISO_RET_DISID";
            dt.Columns.Add(DISO_RET_DISID);

            DataColumn DISO_RET_ID = new DataColumn();
            DISO_RET_ID.DataType = Type.GetType("System.String");
            DISO_RET_ID.ColumnName = "DISO_RET_ID";
            dt.Columns.Add(DISO_RET_ID);

            DataColumn DISO_RETT_ID = new DataColumn();
            DISO_RETT_ID.DataType = Type.GetType("System.String");
            DISO_RETT_ID.ColumnName = "DISO_RETT_ID";
            dt.Columns.Add(DISO_RETT_ID);

            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();

            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("DISO_RET_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_DISORDER_RET_MASTER"));
                    DataTable dt2 = DBManager.Get(vHashtable, "GET_DISORDER_RET_MASTER");
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["DISO_RET_ID"].ToString();
                        TXTVALUE.Value = vDR["DISO_RETT_ID"].ToString();
                        DDLDIS.SelectedValue = vDR["DISO_RET_DISID"].ToString();
                        PHY_TRADE_TXT.Text = vDR["DISO_RETT_PHY"].ToString();
                        OBSERVATION_TXT.Text = vDR["DISO_RETT_OBSER"].ToString();
                        Gridview1.DataSource = dt2;
                        Gridview1.DataBind();
                        Gridview1.HeaderRow.Cells[05].Visible = false;
                        foreach (GridViewRow gdr in Gridview1.Rows)
                        {
                            gdr.Cells[05].Visible = false;
                        }
                    }
                    else
                        ShowMsg("Invalid Disorder Report ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Gridview1.Rows.Count > 0)
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("DISO_RET_ID", TXTID.Value);
                    vHashtable.Add("DISO_RET_DISID", DDLDIS.SelectedValue);
                    vHashtable.Add("TYPE", "INS");
                    if (DBManager.ExecInsUpsReturn(vHashtable, "INS_DISORDER_RET_MASTER", (ATSession)Session["User"]))
                    {
                        foreach (GridViewRow grw in Gridview1.Rows)
                        {
                            Label DISO_RET_PHY = (Label)grw.FindControl("DISO_RETT_PHY");
                            Label DISO_RET_OBSER = (Label)grw.FindControl("DISO_RETT_OBSER");

                            Hashtable vHashtable1 = new Hashtable();
                            vHashtable1.Add("DISO_RETT_ID", TXTVALUE.Value);
                            vHashtable1.Add("DISO_RETT_DISORETID", TXTID.Value);
                            vHashtable1.Add("DISO_RETT_PHY", DISO_RET_PHY.Text);
                            vHashtable1.Add("DISO_RETT_OBSER", DISO_RET_OBSER.Text);
                            vHashtable1.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable1, "INS_DISORDER_RET_DETAIL", (ATSession)Session["User"]);
                        }
                    }
                    Response.Redirect("Disorder_Report_Master_List.aspx");
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
                        Label DISO_RET_PHY = (Label)grw.FindControl("DISO_RETT_PHY");
                        Label DISO_RET_OBSER = (Label)grw.FindControl("DISO_RETT_OBSER");

                        Hashtable vHashtable1 = new Hashtable();
                        vHashtable1.Add("DISO_RETT_ID", TXTVALUE.Value);
                        vHashtable1.Add("DISO_RETT_DISORETID", TXTID.Value);
                        vHashtable1.Add("DISO_RETT_PHY", DISO_RET_PHY.Text);
                        vHashtable1.Add("DISO_RETT_OBSER", DISO_RET_OBSER.Text);
                        vHashtable1.Add("TYPE", "UPD");
                        DBManager.Get(vHashtable1, "INS_DISORDER_RET_DETAIL");
                    }
                    Response.Redirect("Disorder_Report_Master_List.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            }
        }
    }

    protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label DISO_RET_ID = (Label)Gridview1.Rows[e.RowIndex].FindControl("DISO_RET_ID");
        Label DISO_RETT_ID = (Label)Gridview1.Rows[e.RowIndex].FindControl("DISO_RETT_ID");
        Label DISO_RETT_PHY = (Label)Gridview1.Rows[e.RowIndex].FindControl("DISO_RETT_PHY");
        Label DISO_RETT_OBSER = (Label)Gridview1.Rows[e.RowIndex].FindControl("DISO_RETT_OBSER");

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DISO_RETT_ID", DISO_RETT_ID.Text);
        vHashtable.Add("DISO_RETT_PHY", PHY_TRADE_TXT.Text);
        vHashtable.Add("DISO_RETT_OBSER", OBSERVATION_TXT.Text);
        DBManager.ExecInsUps(vHashtable, "UPDATE_DISO_ID", vATSession);
        Gridview1.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        Hashtable vHashtable3 = new Hashtable();
        vHashtable3.Add("DISO_RET_ID", DISO_RET_ID.Text);
        DataTable dt3 = DBManager.Get(vHashtable3, "GET_DISORDER_RET_MASTER_ID");
        Gridview1.DataSource = dt3;
        Gridview1.DataBind();
        // BindGrid();
    }

    protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview1.EditIndex = e.NewEditIndex;
        Label DISO_RETT_ID = (Label)Gridview1.Rows[e.NewEditIndex].FindControl("DISO_RETT_ID");
        Label DISO_RET_ID = (Label)Gridview1.Rows[e.NewEditIndex].FindControl("DISO_RET_ID");
        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("DISO_RETT_ID", DISO_RETT_ID.Text);
        vHashtable1.Add("TYPE", "GET");
        DataRow vDR = RetDR(DBManager.Get(vHashtable1, "GET_DISORDER_RET_MASTER_NEW"));
        if (vDR != null)
        {
            DDLDIS.SelectedItem.Text = vDR["DIS_NAME"].ToString();
            PHY_TRADE_TXT.Text = vDR["DISO_RETT_PHY"].ToString();
            OBSERVATION_TXT.Text = vDR["DISO_RETT_OBSER"].ToString();
        }
        Hashtable vHashtable3 = new Hashtable();
        vHashtable3.Add("DISO_RET_ID", DISO_RET_ID.Text);
        DataTable dt3 = DBManager.Get(vHashtable3, "GET_DISORDER_RET_MASTER_ID");
        Gridview1.DataSource = dt3;
        Gridview1.DataBind();
        Gridview1.HeaderRow.Cells[05].Visible = false;
        foreach (GridViewRow gdr in Gridview1.Rows)
        {
            gdr.Cells[05].Visible = false;
        }
        btnAdd.Visible = false;
        btnSave.Visible = false;
    }

    protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridview1.EditIndex = -1;
        Label DISO_RET_ID = (Label)Gridview1.Rows[e.RowIndex].FindControl("DISO_RET_ID");
        Hashtable vHashtable3 = new Hashtable();
        vHashtable3.Add("DISO_RET_ID", DISO_RET_ID.Text);
        DataTable dt3 = DBManager.Get(vHashtable3, "GET_DISORDER_RET_MASTER_ID");
        Gridview1.DataSource = dt3;
        Gridview1.DataBind();
        Gridview1.HeaderRow.Cells[05].Visible = false;
        foreach (GridViewRow gdr in Gridview1.Rows)
        {
            gdr.Cells[05].Visible = false;
        }
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
                    if (drow["DIS_NAME"].Equals(DDLDIS.SelectedValue))
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
                dr["DIS_NAME"] = DDLDIS.SelectedItem.Text;
                dr["DISO_RETT_PHY"] = PHY_TRADE_TXT.Text;
                dr["DISO_RETT_OBSER"] = OBSERVATION_TXT.Text;
                dt.Rows.Add(dr);
                ViewState["datagrid"] = dt;
                BindGrid();
                Gridview1.HeaderRow.Cells[04].Visible = false;
                foreach (GridViewRow gdr in Gridview1.Rows)
                {
                    gdr.Cells[04].Visible = false;
                }
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
        dr["DIS_NAME"] = DDLDIS.SelectedItem.Text;
        dr["DISO_RETT_PHY"] = PHY_TRADE_TXT.Text;
        dr["DISO_RETT_OBSER"] = OBSERVATION_TXT.Text;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
        Gridview1.HeaderRow.Cells[04].Visible = false;
        foreach (GridViewRow gdr in Gridview1.Rows)
        {
            gdr.Cells[04].Visible = false;
        }
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
            Label OBSERVATION_TXT = (Label)Gridview1.Rows[index].FindControl("DISO_RET_OBSER");
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["DISO_RETT_OBSER"].Equals(OBSERVATION_TXT.Text))
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
            Gridview1.HeaderRow.Cells[05].Visible = false;
            foreach (GridViewRow gdr in Gridview1.Rows)
            {
                gdr.Cells[05].Visible = false;
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTDISRET");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["DISO_RETT_PHY"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}