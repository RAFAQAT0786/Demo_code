using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EVALUATION_DISORDER : BasePage
{
    private ATSession vATSession;
    private DataTable dt;
    private DataTable dt1;
    private DataTable dt2;

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
            dt = new DataTable();
            DataColumn NAME = new DataColumn();
            NAME.DataType = Type.GetType("System.String");
            NAME.ColumnName = "DIS_NAME";
            dt.Columns.Add(NAME);

            DataColumn EVA_NAME = new DataColumn();
            EVA_NAME.DataType = Type.GetType("System.String");
            EVA_NAME.ColumnName = "EVA_NAME";
            dt.Columns.Add(EVA_NAME);

            DataColumn EVA_ID = new DataColumn();
            EVA_ID.DataType = Type.GetType("System.String");
            EVA_ID.ColumnName = "EVA_ID";
            dt.Columns.Add(EVA_ID);

            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();

            DDLDIS.Enabled = true;

            try
            {
                ValidateUserAccess();

                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                ATCommon.FillDrpDown(DDLEVA, DBManager.Get(new Hashtable(), "CMB_EVALUATION"), "Select Evaluation Name", "EVA_NAME", "EVA_ID", "0");

                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("EVADIS_DISID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_EVALUATION_DISORDER"));
                    dt1 = DBManager.Get(vHashtable, "GET_EVALUATION_DISORDER");
                    if (vDR != null)
                    {
                        DDLDIS.SelectedItem.Text = vDR["DIS_NAME"].ToString();
                        DDLEVA.SelectedItem.Text = vDR["EVA_NAME"].ToString();
                        this.EVA_ID1.Columns[3].Visible = false;
                        this.EVA_ID1.Columns[2].Visible = false;
                        btnSave.Visible = false;
                        btnAdd.Visible = false;
                    }
                    EVA_ID1.DataSource = dt1;
                    EVA_ID1.DataBind();
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void existence_ServerValidate(object sender, ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISEVALUATION_DISORDER");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["EVA_NAME"].ToString().Equals(DDLEVA.SelectedItem))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }

    protected void EVA_ID1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "delete")
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            Label EVA_ID = (Label)EVA_ID1.Rows[index].FindControl("EVA_ID");
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["EVA_ID"].Equals(EVA_ID.Text))
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    break;
                }
            }
        }
    }

    protected void EVA_ID1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        EVA_ID1.PageIndex = e.NewPageIndex;
    }

    protected void EVA_ID1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String vID = Request.QueryString["ID"];
            if (TXTID.Value == "0")
                try
                {
                    for (int j = 0; j < EVA_ID1.Rows.Count; j++)
                    {
                        Label EVA_ID = (Label)EVA_ID1.Rows[j].Cells[2].FindControl("EVA_ID");

                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("EVADIS_ID", TXTID.Value);
                        vHashtable.Add("EVADIS_EVAID ", EVA_ID.Text);
                        vHashtable.Add("EVADIS_DISID", DDLDIS.SelectedValue);
                        vHashtable.Add("TYPE", "INS");
                        DBManager.ExecInsUps(vHashtable, "INS_EVALUATION_DISORDER", (ATSession)Session["User"]);
                    }
                    Response.Redirect("EVALUATION_DISORDER_LIST.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            else
            {
                for (int j = 0; j < EVA_ID1.Rows.Count; j++)
                {
                    Label EVA_ID = (Label)EVA_ID1.Rows[j].Cells[2].FindControl("EVA_ID");

                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("EVADIS_ID", TXTID.Value);
                    vHashtable1.Add("EVADIS_EVAID ", EVA_ID.Text);
                    vHashtable1.Add("EVADIS_DISID", DDLDIS.SelectedValue);
                    vHashtable1.Add("TYPE", "UPD");
                    DBManager.ExecInsUps(vHashtable1, "INS_EVALUATION_DISORDER", (ATSession)Session["User"]);
                }
                Response.Redirect("EVALUATION_DISORDER_LIST.aspx");
                Clear();
            }
        }
    }

    protected void BindGrid()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        EVA_ID1.DataSource = dt;
        EVA_ID1.DataBind();
        for (int j = 0; j < EVA_ID1.Rows.Count; j++)
        {
            Label EVA_ID = (Label)EVA_ID1.Rows[j].Cells[2].FindControl("EVA_ID");
            EVA_ID.Visible = false;
            this.EVA_ID1.Columns[3].Visible = false;
        }
    }

    protected void addrow()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();
        dr["DIS_NAME"] = DDLDIS.SelectedItem;
        dr["EVA_NAME"] = DDLEVA.SelectedItem;
        dr["EVA_ID"] = DDLEVA.SelectedValue;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
    }

    protected void addrownew()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();
        dr["DIS_NAME"] = DDLDIS.SelectedItem;
        dr["EVA_NAME"] = DDLEVA.SelectedItem;
        dr["EVA_ID"] = DDLEVA.SelectedValue;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        if (dt.Rows.Count <= 25)
        {
            if (dt.Rows.Count > 0)
            {
                bool flag = false;
                foreach (DataRow drow in dt.Rows)
                {
                    if (drow["EVA_NAME"].Equals(DDLEVA.SelectedValue))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                    addrow();
                else
                {
                    ShowMsg("This Evaluation Disorder Is Already Exist");
                }
            }
            else
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["DIS_NAME"] = DDLDIS.SelectedItem;
                dr["EVA_NAME"] = DDLEVA.SelectedItem;
                dr["EVA_ID"] = DDLEVA.SelectedValue;
                dt.Rows.Add(dr);
                ViewState["datagrid"] = dt;
                BindGrid();
            }
        }
        else
            ShowMsg("Maximum 25 Profile Can Be Added.");
    }

    public void Clear()
    {
    }
}