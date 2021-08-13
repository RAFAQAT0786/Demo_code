using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_Profile : BasePage
{
    private ATSession vATSession;

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
        PTP_TXT.Text = vATSession.UserName;
        if (vATSession.UserType == "ADMIN")
        {
            GridView1.Visible = true;
            hidden1.Visible = true;
        }
        else
        {
            GridView1.Visible = true;
        }
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(COND_ID, DBManager.Get(new Hashtable(), "CMB_CONDITION_MASTER"), "Select Condition Name", "COND_NAME", "COND_ID", "0");
                ATCommon.FillDrpDown(DEVCOND_ID, DBManager.Get(new Hashtable(), "CMB_DEVELOPMENT_MASTER"), "Select Development Condition Name", "DEV_NAME", "DEV_ID", "0");
                if (vID != null)
                {
                    PTP_ID.Value = vID;
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTP_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_DETAIL"));
                    if (vDR != null)
                    {
                        PTP_ID.Value = vID;
                        vID = vDR["PTP_ID"].ToString();
                        PTP_TXT.Text = vDR["PTP_NAME"].ToString();
                    }
                    else
                        ShowMsg("Invalid ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (TXTID.Value != "0")
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTF_ID", TXTID.Value);
                    vHashtable.Add("PTF_PTPID", PTP_ID.Value);
                    vHashtable.Add("PTF_CONDID", COND_ID.SelectedValue);
                    vHashtable.Add("PTF_DEVID", DEVCOND_ID.SelectedValue);
                    vHashtable.Add("PTF_RELATION", RELATION_DDL.Text);
                    vHashtable.Add("PTF_CONDESC", PTP_COND_DESC.Text);
                    vHashtable.Add("PTF_RELDESC", PTP_REL_DESC.Text);
                    vHashtable.Add("PTF_DEVDESC", PTP_DEV_DESC.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_PT_PROFILE");
                    Response.Redirect("Patient_Profile.aspx?id=" + PTP_ID.Value);
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
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTF_ID", TXTID.Value);
                    vHashtable.Add("PTF_PTPID", PTP_ID.Value);
                    vHashtable.Add("PTF_CONDID", COND_ID.SelectedValue);
                    vHashtable.Add("PTF_DEVID", DEVCOND_ID.SelectedValue);
                    vHashtable.Add("PTF_RELATION", RELATION_DDL.Text);
                    vHashtable.Add("PTF_CONDESC", PTP_COND_DESC.Text);
                    vHashtable.Add("PTF_RELDESC", PTP_REL_DESC.Text);
                    vHashtable.Add("PTF_DEVDESC", PTP_DEV_DESC.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_PT_PROFILE");
                    Response.Redirect("Patient_Profile.aspx?id=" + PTP_ID.Value);
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            }
        }
    }

    public void Clear()
    {
    }
    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string values = TXTVALUE.Value.Remove(TXTVALUE.Value.Length - 1);

        foreach (string value in values.Split(','))
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTF_ID", "PTF_ID");
            vHashtable.Add("PTP_ID", "0");
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_PT_PROFILE");
        }
        ShowDeleteMsg(true);
    }

    protected void AddModify(string EDU_ID)
    {
        try
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTF_ID", TXTID.Value);
            vHashtable.Add("PTF_PTPID", PTP_ID.Value);
            vHashtable.Add("PTF_CONDID", COND_ID.SelectedValue);
            vHashtable.Add("PTF_DEVID", DEVCOND_ID.SelectedValue);
            vHashtable.Add("PTF_RELATION", RELATION_DDL.Text);
            vHashtable.Add("PTF_CONDESC", PTP_COND_DESC.Text);
            vHashtable.Add("PTF_RELDESC", PTP_REL_DESC.Text);
            vHashtable.Add("PTF_DEVDESC", PTP_DEV_DESC.Text);
            vHashtable.Add("LAST_USER", vATSession.Login);
            vHashtable.Add("TYPE", "INS");
            DBManager.Get(vHashtable, "INS_PT_PROFILE");
            ShowMsg(int.Parse(TXTID.Value));
            Response.Redirect("Patient_Profile.aspx?id=" + TXTID.Value);
        }
        catch (Exception xe) { ShowMsg(xe); }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "modify")
        {
            vATSession = (ATSession)Session["User"];
            if (!vATSession.UserType.Equals("ADMIN"))
            {
                int index = Convert.ToInt16(e.CommandArgument);
                Label PTF_ID = (Label)GridView1.Rows[index].FindControl("PTF_ID");
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("PTF_ID", PTF_ID.Text);
                vHashtable.Add("PTP_ID", PTP_ID.Value);
                DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PT_PROFILE_NEW"));
                if (vDR != null)
                {
                    TXTID.Value = vDR["PTF_ID"].ToString();
                    PTP_TXT.Text = vDR["PTP_NAME"].ToString();
                    COND_ID.SelectedValue = vDR["PTF_CONDID"].ToString();
                    DEVCOND_ID.SelectedValue = vDR["PTF_DEVID"].ToString();
                    PTP_COND_DESC.Text = vDR["PTF_CONDESC"].ToString();
                    PTP_DEV_DESC.Text = vDR["PTF_DEVDESC"].ToString();
                    PTP_REL_DESC.Text = vDR["PTF_RELDESC"].ToString();
                    RELATION_DDL.SelectedValue = vDR["PTF_RELATION"].ToString();
                }
            }
            else if (vATSession.UserType.Equals("ADMIN"))
            {
                int index = Convert.ToInt16(e.CommandArgument);
                Label PTF_ID = (Label)GridView1.Rows[index].FindControl("PTF_ID");
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("PTF_ID", PTF_ID.Text);
                vHashtable.Add("PTP_ID", PTP_ID.Value);
                DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PT_PROFILE_NEW"));
                if (vDR != null)
                {
                    TXTID.Value = vDR["PTF_ID"].ToString();
                    PTP_TXT.Text = vDR["PTP_NAME"].ToString();
                    COND_ID.SelectedValue = vDR["PTF_CONDID"].ToString();
                    DEVCOND_ID.SelectedValue = vDR["PTF_DEVID"].ToString();
                    PTP_COND_DESC.Text = vDR["PTF_CONDESC"].ToString();
                    PTP_DEV_DESC.Text = vDR["PTF_DEVDESC"].ToString();
                    PTP_REL_DESC.Text = vDR["PTF_RELDESC"].ToString();
                    RELATION_DDL.SelectedValue = vDR["PTF_RELATION"].ToString();
                }
            }
        }
    }
}