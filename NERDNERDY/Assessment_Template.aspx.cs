using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class Assessment_Template : BasePage
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

            DataColumn coldID = new DataColumn();
            coldID.DataType = Type.GetType("System.String");
            coldID.ColumnName = "AGDD_ID";
            dt.Columns.Add(coldID);

            DataColumn ASE = new DataColumn();
            ASE.DataType = Type.GetType("System.String");
            ASE.ColumnName = "ASE_ID";
            dt.Columns.Add(ASE);

            DataColumn ASER_DISID = new DataColumn();
            ASER_DISID.DataType = Type.GetType("System.String");
            ASER_DISID.ColumnName = "ASER_DISID";
            dt.Columns.Add(ASER_DISID);

            DataColumn coldcname = new DataColumn();
            coldcname.DataType = Type.GetType("System.String");
            coldcname.ColumnName = "ASER_PERCENTAGE";
            dt.Columns.Add(coldcname);

            DataColumn coldesc = new DataColumn();
            coldesc.DataType = Type.GetType("System.String");
            coldesc.ColumnName = "ASER_SCALE";
            dt.Columns.Add(coldesc);
            ViewState["datagrid"] = dt;
            Templatenew.Visible = false;

            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_GRP_MASTER"), "Select Group Name", "AGRP_GROUP", "AGRP_ID", "0");// hard valus anm_id=2
                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
                if (vID != null)
                {
                    TextBox ASER_PERCENTAGE = (TextBox)FindControl("ASER_PERCENTAGE");
                    TextBox ASER_SCALE = (TextBox)FindControl("ASER_SCALE");

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("ASE_ID", vID);
                    vHashtable.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_ASSESS_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["ASE_ID"].ToString();
                        ASSESSMENT_TXT.Text = vDR["ASE_NAME"].ToString();
                        DDLAGE.Text = vDR["AGRP_ID"].ToString();
                        ASSESSMENT_TXT.Enabled = false;
                        DDLAGE.Enabled = false;
                    }
                    else
                        ShowMsg("Invalid Assessment ID");
                }

                if (vID != null)
                {
                    Hashtable vHashtable4 = new Hashtable();
                    vHashtable4.Add("ASE_ID", vID);
                    DataRow vDR4 = RetDR(DBManager.Get(vHashtable4, "GET_ASSESS_ID"));
                    if (vDR4 != null)
                    {
                        DDLDIS.SelectedItem.Text = vDR4["DIS_NAME"].ToString();
                        DDLDIS.SelectedValue = vDR4["ASER_DISID"].ToString();
                    }
                }

                if (DDLAGE.SelectedValue != "0")
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("ASE_ID", TXTID.Value);
                    vHashtable.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue);
                    vHashtable.Add("TYPE", "GET");
                    DataTable dt4 = DBManager.Get(vHashtable, "GET_MASTER_ASSESSMENT");
                    if (dt4.Columns.Count > 0)
                    {
                        GV_NEWTEMPLATE1.Visible = false;
                        GV_NEWTEMPLATE1.Visible = true;
                        GV_NEWTEMPLATE1.DataSource = dt4;
                        GV_NEWTEMPLATE1.DataBind();
                    }
                    if (dt4.Columns.Count > 24)
                    {
                        if (Panel1.Visible == true)
                        {
                            for (int j = 0; j < GV_NEWTEMPLATE1.Rows.Count; j++)
                            {
                                TextBox ASER_PERCENTAGE = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[4].FindControl("ASER_PERCENTAGE");
                                TextBox ASER_SCALE = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[5].FindControl("ASER_SCALE");
                                ASER_PERCENTAGE.Text = dt4.Rows[j][21].ToString();
                                ASER_SCALE.Text = dt4.Rows[j][22].ToString();
                                ASER_PERCENTAGE.Enabled = false;
                                ASER_SCALE.Enabled = false;
                                ASER_ID.Value = dt4.Rows[j][19].ToString();
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
        vHashtable.Add("ASE_ID", TXTID.Value);
        vHashtable.Add("ASER_DISID", DDLDIS.SelectedValue);
        vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue);
        vHashtable.Add("TYPE", "GET");
        DataTable dt = DBManager.Get(vHashtable, "GET_MASTER_ASSESSMENT");
        if (dt.Columns.Count == 12)
        {
            GV_NEWTEMPLATE1.DataSource = dt;
            GV_NEWTEMPLATE1.DataBind();
        }
        else
        {
            GV_NEWTEMPLATE1.DataSource = dt;
            GV_NEWTEMPLATE1.DataBind();
        }
        if (dt.Columns.Count > 24)
        {
            if (Panel1.Visible == true)
            {
                for (int j = 0; j < GV_NEWTEMPLATE1.Rows.Count; j++)
                {
                    string prod_nam1 = dt.Rows[j][0].ToString();
                    if (prod_nam1 != null)
                    {
                        TextBox ASER_PERCENTAGE = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[4].FindControl("ASER_PERCENTAGE");
                        TextBox ASER_SCALE = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[5].FindControl("ASER_SCALE");
                        TextBox ASER_KEYWORD = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[6].FindControl("ASER_KEYWORD");
                        ASER_PERCENTAGE.Text = dt.Rows[j][20].ToString();
                        ASER_SCALE.Text = dt.Rows[j][21].ToString();
                        ASER_KEYWORD.Text = dt.Rows[j][26].ToString();
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
        ATCommon.FillDrpDown(DDLDIS, DBManager.Get(vHashtable, "CMB_DIS_AGE_NEW"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (DDLAGE.SelectedItem.Text != null)
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("AGDM_ID", AGDM_ID.Value);
            vHashtable.Add("DIS_ID", DDLDIS.SelectedValue);
            vHashtable.Add("AGRP_ID", DDLAGE.SelectedValue);
            vHashtable.Add("ASE_ID", TXTID.Value);
            vHashtable.Add("ASER_DISID", DDLDIS.SelectedValue);
            DataTable dt = DBManager.Get(vHashtable, "GET_ASER_ID");
            DataRow vDR2 = RetDR(DBManager.Get(vHashtable, "GET_ASER_ID"));
            if (dt.Columns.Count == 14)
            {
                if (vDR2 != null)
                {
                    GV_NEWTEMPLATE1.DataSource = dt;
                    GV_NEWTEMPLATE1.DataBind();
                    Templatenew.Visible = true;
                    btnSave.Visible = true;
                }
                else
                {
                    GV_NEWTEMPLATE1.DataSource = dt;
                    GV_NEWTEMPLATE1.DataBind();
                    Templatenew.Visible = true;
                    btnSave.Visible = false;
                }

                foreach (GridViewRow gdr in GV_NEWTEMPLATE1.Rows)
                {
                    gdr.Cells[9].Visible = false;
                }
            }
            else
            {
                GV_NEWTEMPLATE1.DataSource = dt;
                GV_NEWTEMPLATE1.DataBind();
                Templatenew.Visible = true;
                btnSave.Visible = false;
            }
            if (dt.Columns.Count > 24)
            {
                if (Panel1.Visible == true)
                {
                    for (int j = 0; j < GV_NEWTEMPLATE1.Rows.Count; j++)
                    {
                        string prod_nam1 = dt.Rows[j][0].ToString();
                        if (prod_nam1 != null)
                        {
                            TextBox ASER_PERCENTAGE = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[4].FindControl("ASER_PERCENTAGE");
                            TextBox ASER_SCALE = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[5].FindControl("ASER_SCALE");
                            TextBox ASER_KEYWORD = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[6].FindControl("ASER_KEYWORD");
                            ASER_PERCENTAGE.Text = dt.Rows[j][20].ToString();
                            ASER_SCALE.Text = dt.Rows[j][21].ToString();
                            ASER_KEYWORD.Text = dt.Rows[j][26].ToString();
                            ASER_KEYWORD.Enabled = false;
                            ASER_PERCENTAGE.Enabled = false;
                            ASER_SCALE.Enabled = false;
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
                vHashtable1.Add("ASE_ID", TXTID.Value);
                vHashtable1.Add("ASE_NAME", ASSESSMENT_TXT.Text);
                vHashtable1.Add("ASE_AGRP_ID", DDLAGE.SelectedValue);
                if (DBManager.ExecInsUpsReturn(vHashtable1, "INS_ASSESSMENT_MASTER", (ATSession)Session["User"]))
                {
                    if (TXTID.Value == "0")
                    {
                        for (int j = 0; j < GV_NEWTEMPLATE1.Rows.Count; j++)
                        {
                            Label DCAT_NAME = (Label)GV_NEWTEMPLATE1.FindControl("DCAT_NAME");
                            Label DSCAT_DESC = (Label)GV_NEWTEMPLATE1.FindControl("DSCAT_DESC");
                            Label DOBS_DESC = (Label)GV_NEWTEMPLATE1.FindControl("DOBS_DESC");
                            Label AGDD_ID = (Label)GV_NEWTEMPLATE1.Rows[j].Cells[2].FindControl("AGDD_ID");
                            TextBox ASER_PERCENTAGE = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[4].FindControl("ASER_PERCENTAGE");
                            TextBox ASER_SCALE = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[5].FindControl("ASER_SCALE");
                            TextBox ASER_KEYWORD = (TextBox)GV_NEWTEMPLATE1.Rows[j].Cells[6].FindControl("ASER_KEYWORD");

                            Hashtable vHashtable = new Hashtable();
                            vHashtable.Add("ASED_ID", TextID.Value);
                            vHashtable.Add("ASED_ASEID", TXTID.Value);
                            vHashtable.Add("ASED_AGDDID", AGDD_ID.Text);
                            vHashtable.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable, "INS_ASSESSMENT_DETAIL", (ATSession)Session["User"]);

                            if (ASER_PERCENTAGE.Text != "")
                            {
                                Hashtable vHashtable2 = new Hashtable();
                                vHashtable2.Add("ASER_ID", ID.Value);
                                vHashtable2.Add("ASER_ASEDID", ASED_ID.Value);
                                vHashtable2.Add("ASER_PERCENTAGE", ASER_PERCENTAGE.Text);
                                vHashtable2.Add("ASER_SCALE", ASER_SCALE.Text);
                                vHashtable2.Add("ASER_DISID", DDLDIS.SelectedValue);
                                vHashtable2.Add("TYPE", "INS");
                                vHashtable2.Add("ASER_KEYWORD", ASER_KEYWORD.Text);
                                DBManager.ExecInsUpsReturn(vHashtable2, "INS_ASSESSMENT_DISORDER_RATE", (ATSession)Session["User"]);
                            }
                        }
                    }
                }
                Response.Redirect("Assessment_Template_List.aspx");
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        else if (TXTID.Value != "0")
            try
            {
                Hashtable vHashtable1 = new Hashtable();
                vHashtable1.Add("ASE_ID", TXTID.Value);
                vHashtable1.Add("ASE_NAME", ASSESSMENT_TXT.Text);
                vHashtable1.Add("ASE_AGRP_ID", DDLAGE.SelectedValue);
                if (DBManager.ExecInsUpsReturn(vHashtable1, "INS_ASSESSMENT_MASTER", (ATSession)Session["User"]))
                {
                    if (DDLDIS.SelectedValue != "0")
                    {
                        foreach (GridViewRow grd in GV_NEWTEMPLATE1.Rows)
                        {
                            Label AGDD_ID = (Label)grd.FindControl("AGDD_ID");

                            Hashtable vHashtable = new Hashtable();
                            vHashtable.Add("ASED_ID", TextID.Value);
                            vHashtable.Add("ASED_ASEID", TXTID.Value);
                            vHashtable.Add("ASED_AGDDID", AGDD_ID.Text);
                            vHashtable.Add("TYPE", "INS");
                            DBManager.ExecInsUps(vHashtable, "INS_ASSESSMENT_DETAIL_NEW", (ATSession)Session["User"]);
                            Label DCAT_NAME = (Label)grd.FindControl("DCAT_NAME");
                            Label DSCAT_DESC = (Label)grd.FindControl("DSCAT_DESC");
                            Label DOBS_DESC = (Label)grd.FindControl("DOBS_DESC");
                            Label ASED_ID = (Label)grd.FindControl("ASED_ID");
                            TextBox ASER_PERCENTAGE = (TextBox)grd.FindControl("ASER_PERCENTAGE");
                            TextBox ASER_SCALE = (TextBox)grd.FindControl("ASER_SCALE");
                            TextBox ASER_KEYWORD = (TextBox)grd.FindControl("ASER_KEYWORD");

                            Hashtable vHashtable2 = new Hashtable();
                            vHashtable2.Add("ASER_ID", ID.Value);
                            vHashtable2.Add("ASER_ASEDID", ASED_ID.Text);
                            vHashtable2.Add("ASER_PERCENTAGE", ASER_PERCENTAGE.Text);
                            vHashtable2.Add("ASER_SCALE", ASER_SCALE.Text);
                            vHashtable2.Add("ASER_DISID", DDLDIS.SelectedValue);
                            vHashtable2.Add("TYPE", "INS");
                            vHashtable2.Add("ASER_KEYWORD", ASER_KEYWORD.Text);
                            DBManager.ExecInsUpsReturn(vHashtable2, "INS_ASSESSMENT_DISORDER_RATE_ASEDID", (ATSession)Session["User"]);
                        }
                    }
                }
                Response.Redirect("Assessment_Template_List.aspx");
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        else
        {
            try
            {
                foreach (GridViewRow grd in GV_NEWTEMPLATE1.Rows)
                {
                    TextBox ASER_PERCENTAGE = (TextBox)grd.FindControl("ASER_PERCENTAGE");
                    TextBox ASER_SCALE = (TextBox)grd.FindControl("ASER_SCALE");
                    TextBox ASER_KEYWORD = (TextBox)grd.FindControl("ASER_KEYWORD");

                    Hashtable vHashtable2 = new Hashtable();
                    vHashtable2.Add("ASER_ID", ID.Value);
                    vHashtable2.Add("ASER_ASEDID", TextID.Value);
                    vHashtable2.Add("ASER_PERCENTAGE", ASER_PERCENTAGE.Text);
                    vHashtable2.Add("ASER_SCALE", ASER_SCALE.Text);
                    vHashtable2.Add("ASER_DISID", DDLDIS.SelectedValue);
                    vHashtable2.Add("TYPE", "UPD");
                    vHashtable2.Add("LAST_USER", vATSession.Login);
                    vHashtable2.Add("ASER_KEYWORD", ASER_KEYWORD.Text);
                    DBManager.Get(vHashtable2, "INS_ASSESSMENT_DISORDER_RATE");
                }
                Response.Redirect("Assessment_Template_List.aspx");
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        }
    }

    protected void GV_NEWTEMPLATE1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label ASER_ID = (Label)GV_NEWTEMPLATE1.Rows[e.RowIndex].FindControl("ASER_ID");
        TextBox ASER_PERCENTAGE = (TextBox)GV_NEWTEMPLATE1.Rows[e.RowIndex].FindControl("ASER_PERCENTAGE");
        TextBox ASER_SCALE = (TextBox)GV_NEWTEMPLATE1.Rows[e.RowIndex].FindControl("ASER_SCALE");
        TextBox ASER_KEYWORD = (TextBox)GV_NEWTEMPLATE1.Rows[e.RowIndex].FindControl("ASER_KEYWORD");
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("ASER_ID", ASER_ID.Text);
        vHashtable.Add("ASER_PERCENTAGE", ASER_PERCENTAGE.Text);
        vHashtable.Add("ASER_SCALE", ASER_SCALE.Text);
        vHashtable.Add("ASER_KEYWORD", ASER_KEYWORD.Text);
        DBManager.ExecInsUps(vHashtable, "UPDATE_ASER_ID", vATSession);
        GV_NEWTEMPLATE1.EditIndex = -1;
        ShowMsg("Updated Successfully..........");
        BindGrid();
        ASER_PERCENTAGE.Enabled = false;
        ASER_SCALE.Enabled = false;
    }

    protected void GV_NEWTEMPLATE1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_NEWTEMPLATE1.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void GV_NEWTEMPLATE1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_NEWTEMPLATE1.EditIndex = -1;
        BindGrid();
    }

    public void Clear()
    {
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTASSESSMENT");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["ASE_NAME"].ToString().Equals(args.Value))
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
