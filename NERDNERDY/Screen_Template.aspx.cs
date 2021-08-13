using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class Screen_Template : BasePage
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
            dt = new DataTable();
            DataColumn coldisname = new DataColumn();
            coldisname.DataType = Type.GetType("System.String");
            coldisname.ColumnName = "DCAT_NAME";
            dt.Columns.Add(coldisname);

            DataColumn coltypgroup = new DataColumn();
            coltypgroup.DataType = Type.GetType("System.String");
            coltypgroup.ColumnName = "DSCAT_DESC";
            dt.Columns.Add(coltypgroup);

            DataColumn coltypgroup1 = new DataColumn();
            coltypgroup1.DataType = Type.GetType("System.String");
            coltypgroup1.ColumnName = "DOBS_DESC";
            dt.Columns.Add(coltypgroup1);

            DataColumn coldcname = new DataColumn();
            coldcname.DataType = Type.GetType("System.String");
            coldcname.ColumnName = "SCTR_PERCENTAGE";
            dt.Columns.Add(coldcname);

            DataColumn coldesc = new DataColumn();
            coldesc.DataType = Type.GetType("System.String");
            coldesc.ColumnName = "SCTR_SCALE";
            dt.Columns.Add(coldesc);

            DataColumn coldID = new DataColumn();
            coldID.DataType = Type.GetType("System.String");
            coldID.ColumnName = "AGDD_ID";
            dt.Columns.Add(coldID);

            DataColumn SCREEN = new DataColumn();
            SCREEN.DataType = Type.GetType("System.String");
            SCREEN.ColumnName = "SCTD_SCTPID";
            dt.Columns.Add(SCREEN);

            DataColumn SCREENT = new DataColumn();
            SCREENT.DataType = Type.GetType("System.String");
            SCREENT.ColumnName = "SCTR_SCTDID";
            dt.Columns.Add(SCREENT);

            DataColumn SCTR = new DataColumn();
            SCTR.DataType = Type.GetType("System.String");
            SCTR.ColumnName = "SCTR_ID";
            dt.Columns.Add(SCTR);

            DataColumn SCTR_DISID = new DataColumn();
            SCTR_DISID.DataType = Type.GetType("System.String");
            SCTR_DISID.ColumnName = "SCTR_DISID";
            dt.Columns.Add(SCTR_DISID);

            DataColumn SCTP_ID = new DataColumn();
            SCTP_ID.DataType = Type.GetType("System.String");
            SCTP_ID.ColumnName = "SCTP_ID";
            dt.Columns.Add(SCTP_ID);

            ViewState["datagrid"] = dt;
            Templatenew.Visible = false;
            btnSave.Visible = false;

            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_SCREEN_MASTER"), "Select Group Name", "AGRP_GROUP", "AGRP_ID", "0");//AGRP_ANMID=1 HARD
                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                if (vID != null)
                {
                    TextBox SCTR_PERCENTAGE = (TextBox)FindControl("SCTR_PERCENTAGE");
                    TextBox SCTR_SCALE = (TextBox)FindControl("SCTR_SCALE");

                    if (vID != null)
                    {
                        Hashtable vHashtable4 = new Hashtable();
                        vHashtable4.Add("SCTP_ID", vID);
                        DataRow vDR4 = RetDR(DBManager.Get(vHashtable4, "GET_MASTER_DISID"));
                        if (vDR4 != null)
                        {
                            DDLDIS.SelectedItem.Text = vDR4["DIS_NAME"].ToString();
                            HiddenField1.Value = vDR4["SCTR_DISID"].ToString();
                        }
                    }

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("SCTP_ID", vID);
                    vHashtable.Add("SCTR_DISID", HiddenField1.Value);
                    vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_MASTER_SCREEN_ID"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["SCTP_ID"].ToString();
                        SCREEN_TXT.Text = vDR["SCTP_NAME"].ToString();
                        DDLAGE.Text = vDR["AGRP_ID"].ToString();
                        SCREEN_TXT.Enabled = false;
                        DDLAGE.Enabled = false;
                    }
                    else
                        ShowMsg("Invalid Screen ID");
                }

                if (DDLAGE.SelectedValue != "0")
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("SCTP_ID", TXTID.Value);
                    vHashtable.Add("SCTR_DISID", HiddenField1.Value);
                    vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue);
                    vHashtable.Add("TYPE", "GET");
                    DataTable dt4 = DBManager.Get(vHashtable, "GET_MASTER_SCREEN_NEW");
                    if (dt4.Columns.Count > 0)
                    {
                        GV_NEWTEMPLATE.Visible = true;
                        GV_NEWTEMPLATE.DataSource = dt4;
                        GV_NEWTEMPLATE.DataBind();
                    }
                    if (dt4.Columns.Count > 15)
                    {
                        if (Panel1.Visible == true)
                        {
                            for (int j = 0; j < GV_NEWTEMPLATE.Rows.Count; j++)
                            {
                                TextBox SCTR_PERCENTAGE = (TextBox)GV_NEWTEMPLATE.Rows[j].Cells[4].FindControl("SCTR_PERCENTAGE");
                                TextBox SCTR_SCALE = (TextBox)GV_NEWTEMPLATE.Rows[j].Cells[5].FindControl("SCTR_SCALE");
                                SCTR_PERCENTAGE.Text = dt4.Rows[j][23].ToString();
                                SCTR_SCALE.Text = dt4.Rows[j][24].ToString();
                                SCTR_PERCENTAGE.Enabled = false;
                                SCTR_SCALE.Enabled = false;
                                SCTR_ID.Value = dt4.Rows[j][21].ToString();
                            }
                        }
                        btnSave.Visible = false;
                    }
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void BindGrid()
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("SCTP_ID", TXTID.Value);
        vHashtable.Add("SCTR_DISID", DDLDIS.SelectedValue);
        vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue);
        vHashtable.Add("TYPE", "GET");
        DataTable dt = DBManager.Get(vHashtable, "GET_MASTER_SCREEN");

        if (dt.Columns.Count == 12)
        {
            GV_NEWTEMPLATE.DataSource = dt;
            GV_NEWTEMPLATE.DataBind();
            btnSave.Visible = true;
        }
        else
        {
            GV_NEWTEMPLATE.DataSource = dt;
            GV_NEWTEMPLATE.DataBind();
            btnSave.Visible = false;
        }

        if (dt.Columns.Count > 24)
        {
            if (Panel1.Visible == true)
            {
                for (int j = 0; j < GV_NEWTEMPLATE.Rows.Count; j++)
                {
                    string prod_nam1 = dt.Rows[j][0].ToString();
                    if (prod_nam1 != null)
                    {
                        TextBox SCTR_PERCENTAGE = (TextBox)GV_NEWTEMPLATE.Rows[j].Cells[4].FindControl("SCTR_PERCENTAGE");
                        TextBox SCTR_SCALE = (TextBox)GV_NEWTEMPLATE.Rows[j].Cells[5].FindControl("SCTR_SCALE");
                        SCTR_PERCENTAGE.Text = dt.Rows[j][23].ToString();
                        SCTR_SCALE.Text = dt.Rows[j][24].ToString();
                    }
                }
            }
            else
            {
                BindGrid();
            }
        }
    }

    protected void DDLAGE_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue.ToString());
        ATCommon.FillDrpDown(DDLDIS, DBManager.Get(vHashtable, "CMB_DIS_AGE"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "");
    }

    protected void DDLDIS_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (DDLAGE.SelectedItem.Text != null)
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("AGDM_ID", AGDM_ID.Value);
            vHashtable.Add("DIS_ID", DDLDIS.SelectedValue);
            vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue);
            vHashtable.Add("SCTP_ID", TXTID.Value);
            vHashtable.Add("SCTR_DISID", DDLDIS.SelectedValue);
            DataTable dt = DBManager.Get(vHashtable, "GET_AGDM_ID");

            if (dt.Columns.Count == 15)
            {
                GV_NEWTEMPLATE.DataSource = dt;
                GV_NEWTEMPLATE.DataBind();
                Templatenew.Visible = true;
                btnSave.Visible = true;
            }
            else
            {
                GV_NEWTEMPLATE.DataSource = dt;
                GV_NEWTEMPLATE.DataBind();
                Templatenew.Visible = true;
                btnSave.Visible = false;
            }
            if (dt.Columns.Count > 24)
            {
                if (Panel1.Visible == true)
                {
                    for (int j = 0; j < GV_NEWTEMPLATE.Rows.Count; j++)
                    {
                        string prod_nam1 = dt.Rows[j][0].ToString();
                        if (prod_nam1 != null)
                        {
                            TextBox SCTR_PERCENTAGE = (TextBox)GV_NEWTEMPLATE.Rows[j].Cells[4].FindControl("SCTR_PERCENTAGE");
                            TextBox SCTR_SCALE = (TextBox)GV_NEWTEMPLATE.Rows[j].Cells[5].FindControl("SCTR_SCALE");
                            SCTR_PERCENTAGE.Text = dt.Rows[j][23].ToString();
                            SCTR_SCALE.Text = dt.Rows[j][24].ToString();
                            SCTR_PERCENTAGE.Enabled = false;
                            SCTR_SCALE.Enabled = false;
                        }
                    }
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (TXTID.Value == "0")
            try
            {
                Hashtable vHashtable1 = new Hashtable();
                vHashtable1.Add("SCTP_ID", TXTID.Value);
                vHashtable1.Add("SCTP_NAME", SCREEN_TXT.Text);
                vHashtable1.Add("SCTP_AGRP_ID", DDLAGE.SelectedValue);
                if (DBManager.ExecInsUpsReturn(vHashtable1, "INS_SCT_MASTER", (ATSession)Session["User"]))
                {
                    if (TXTID.Value == "0")
                    {
                        foreach (GridViewRow grd in GV_NEWTEMPLATE.Rows)
                        {
                            Label DCAT_NAME = (Label)grd.FindControl("DCAT_NAME");
                            Label DSCAT_DESC = (Label)grd.FindControl("DSCAT_DESC");
                            Label DOBS_DESC = (Label)grd.FindControl("DOBS_DESC");
                            Label AGDD_ID = (Label)grd.FindControl("AGDD_ID");
                            Label DOBS_ID = (Label)grd.FindControl("DOBS_ID");
                            TextBox SCTR_PERCENTAGE = (TextBox)grd.FindControl("SCTR_PERCENTAGE");
                            TextBox SCTR_SCALE = (TextBox)grd.FindControl("SCTR_SCALE");

                            Hashtable vHashtable = new Hashtable();
                            vHashtable.Add("SCTD_ID", TextID.Value);
                            vHashtable.Add("SCTD_SCTPID", TXTID.Value);
                            vHashtable.Add("SCTD_AGDDID", AGDD_ID.Text);
                            vHashtable.Add("SCTD_DOBSID", DOBS_ID.Text);
                            vHashtable.Add("SCTD_DISID", DDLDIS.SelectedValue);
                            vHashtable.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable, "INS_SCT_DETAIL", (ATSession)Session["User"]);

                            Hashtable vHashtable2 = new Hashtable();
                            vHashtable2.Add("SCTR_ID", ID.Value);
                            vHashtable2.Add("SCTR_SCTDID", TextID.Value);
                            vHashtable2.Add("SCTR_PERCENTAGE", SCTR_PERCENTAGE.Text);
                            vHashtable2.Add("SCTR_SCALE", SCTR_SCALE.Text);
                            vHashtable2.Add("SCTR_DISID", DDLDIS.SelectedValue);
                            vHashtable2.Add("TYPE", "INS");
                            DBManager.ExecInsUpsReturn(vHashtable2, "INS_SCT_DISORDER_RATE", (ATSession)Session["User"]);
                        }
                    }
                }
                Response.Redirect("Screen_Template_List.aspx");
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        else if (TXTID.Value != "0")
            try
            {
                Hashtable vHashtable1 = new Hashtable();
                vHashtable1.Add("SCTP_ID", TXTID.Value);
                vHashtable1.Add("SCTP_NAME", SCREEN_TXT.Text);
                vHashtable1.Add("SCTP_AGRP_ID", DDLAGE.SelectedValue);
                if (DBManager.ExecInsUpsReturn(vHashtable1, "INS_SCT_MASTER", (ATSession)Session["User"]))
                {
                    if (DDLDIS.SelectedValue != "0")
                    {
                        foreach (GridViewRow grd in GV_NEWTEMPLATE.Rows)
                        {
                            Label AGDD_ID = (Label)grd.FindControl("AGDD_ID");
                            Label DOBS_ID = (Label)grd.FindControl("DOBS_ID");

                            Hashtable vHashtable = new Hashtable();
                            vHashtable.Add("SCTD_ID", TextID.Value);
                            vHashtable.Add("SCTD_SCTPID", TXTID.Value);
                            vHashtable.Add("SCTD_AGDDID", AGDD_ID.Text);
                            vHashtable.Add("SCTD_DOBSID", DOBS_ID.Text);
                            vHashtable.Add("SCTD_DISID", DDLDIS.SelectedValue);
                            vHashtable.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable, "INS_SCT_DETAIL_NEW", (ATSession)Session["User"]);
                            Label SCTD_ID = (Label)grd.FindControl("SCTD_ID");
                            Label DCAT_NAME = (Label)grd.FindControl("DCAT_NAME");
                            Label DSCAT_DESC = (Label)grd.FindControl("DSCAT_DESC");
                            Label DOBS_DESC = (Label)grd.FindControl("DOBS_DESC");
                            TextBox SCTR_PERCENTAGE = (TextBox)grd.FindControl("SCTR_PERCENTAGE");
                            TextBox SCTR_SCALE = (TextBox)grd.FindControl("SCTR_SCALE");

                            Hashtable vHashtable2 = new Hashtable();
                            vHashtable2.Add("SCTR_ID", ID.Value);
                            vHashtable2.Add("SCTR_SCTDID", TextID.Value);
                            vHashtable2.Add("SCTR_PERCENTAGE", SCTR_PERCENTAGE.Text);
                            vHashtable2.Add("SCTR_SCALE", SCTR_SCALE.Text);
                            vHashtable2.Add("SCTR_DISID", DDLDIS.SelectedValue);
                            vHashtable2.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable2, "INS_SCT_DISORDER_RATE_SCTDID", (ATSession)Session["User"]);
                        }
                    }
                }
                Response.Redirect("Screen_Template_List.aspx");
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        else
        {
            try
            {
                foreach (GridViewRow grd in GV_NEWTEMPLATE.Rows)
                {
                    TextBox SCTR_PERCENTAGE = (TextBox)grd.FindControl("SCTR_PERCENTAGE");
                    TextBox SCTR_SCALE = (TextBox)grd.FindControl("SCTR_SCALE");

                    Hashtable vHashtable2 = new Hashtable();
                    vHashtable2.Add("SCTR_ID", ID.Value);
                    vHashtable2.Add("SCTR_SCTDID", TextID.Value);
                    vHashtable2.Add("SCTR_PERCENTAGE", SCTR_PERCENTAGE.Text);
                    vHashtable2.Add("SCTR_SCALE", SCTR_SCALE.Text);
                    vHashtable2.Add("SCTR_DISID", DDLDIS.SelectedValue);
                    vHashtable2.Add("TYPE", "UPD");
                    vHashtable2.Add("LAST_USER", vATSession.Login);
                    DBManager.Get(vHashtable2, "INS_SCT_DISORDER_RATE");
                }
                Response.Redirect("Screen_Template_List.aspx");
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        }
    }

    protected void GV_NEWTEMPLATE_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label SCTR_ID = (Label)GV_NEWTEMPLATE.Rows[e.RowIndex].FindControl("SCTR_ID");
        TextBox SCTR_PERCENTAGE = (TextBox)GV_NEWTEMPLATE.Rows[e.RowIndex].FindControl("SCTR_PERCENTAGE");
        TextBox SCTR_SCALE = (TextBox)GV_NEWTEMPLATE.Rows[e.RowIndex].FindControl("SCTR_SCALE");
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("SCTR_ID", SCTR_ID.Text);
        vHashtable.Add("SCTR_PERCENTAGE", SCTR_PERCENTAGE.Text);
        vHashtable.Add("SCTR_SCALE", SCTR_SCALE.Text);
        DBManager.ExecInsUps(vHashtable, "UPDATE_SCTR_ID", vATSession);
        GV_NEWTEMPLATE.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        BindGrid();
        SCTR_PERCENTAGE.Enabled = false;
        SCTR_SCALE.Enabled = false;
    }

    protected void GV_NEWTEMPLATE_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_NEWTEMPLATE.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void GV_NEWTEMPLATE_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_NEWTEMPLATE.EditIndex = -1;
        BindGrid();
    }

    public void Clear()
    {
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTSCT");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["SCTP_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
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