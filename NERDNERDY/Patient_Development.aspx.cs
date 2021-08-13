using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_Development : BasePage
{
    private ATSession vATSession;
    private DataTable dt;

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
            btnSave.Visible = false;
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
                ATCommon.FillDrpDown(DEVCOND_ID, DBManager.Get(new Hashtable(), "CMB_DEVELOPMENT_MASTER"), "Select Development Condition Name", "DEV_NAME", "DEV_ID", "0");
                if (vID != null)
                {
                    PTP_ID.Value = vID;
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("PTP_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PATIENT_DEVELOPMENT_NEW"));
                    if (vDR != null)
                    {
                        PTP_ID.Value = vID;
                        vID = vDR["PTP_ID"].ToString();
                        PTP_TXT.Text = vDR["PTP_NAME"].ToString();
                        Textarea1.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "did/did not reach all the major developmental milestones on time. The developmental " +
                            "milestones were reported as within the normal range for ------------" + "<br />" +
                            "a)	Physical development" + "<br />" +
                            "b)	Speech and language development" + "<br />" +
                            "c)	Cognitive development" + "<br />" +
                            "d)	Fine Motor development" + "<br />" +
                            "e)	Gross Motor Development." + "<br />" + "However, he/she has poor----------" + "<br />" + "a)	Physical development" + "<br />" + "b)	Speech and language development" + "<br />" +
                            "c)	Cognitive development" + "<br />" + "d)	Fine Motor development"
                              + "<br />" + "e)	Gross Motor Development.";
                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID);
                        DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "GET_PT_DEVELOPMENT_ID"));
                        if (vDR2 != null)
                        {
                            btnSave.Visible = false;
                        }
                    }
                    else
                        ShowMsg("Invalid Patient Development ID");
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
                    vHashtable.Add("PTDEV_ID", TXTID.Value);
                    vHashtable.Add("PTDEV_PTPID", PTP_ID.Value);
                    vHashtable.Add("PTDEV_DEVID", DEVCOND_ID.SelectedValue);
                    vHashtable.Add("PTDEV_DESC", Textarea1.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_PT_DEVELOPMENT");
                    Response.Redirect("Patient_Create.aspx?id=" + PTP_ID.Value);
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
                    vHashtable.Add("PTDEV_ID", TXTID.Value);
                    vHashtable.Add("PTDEV_PTPID", PTP_ID.Value);
                    vHashtable.Add("PTDEV_DEVID", DEVCOND_ID.SelectedValue);
                    vHashtable.Add("PTDEV_DESC", Textarea1.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_PT_DEVELOPMENT");
                    Response.Redirect("Patient_Create.aspx?id=" + PTP_ID.Value);
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
            vHashtable.Add("PTDEV_ID", "PTDEV_ID");
            vHashtable.Add("PTP_ID", "0");
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_PT_DEVELOPMENT");
        }
        ShowDeleteMsg(true);
    }

    protected void AddModify(string EDU_ID)
    {
        try
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTDEV_ID", TXTID.Value);
            vHashtable.Add("PTDEV_PTPID", PTP_ID.Value);
            vHashtable.Add("PTDEV_DEVID", DEVCOND_ID.SelectedValue);
            vHashtable.Add("PTDEV_DESC", Textarea1.InnerText);
            vHashtable.Add("TYPE", "INS");
            DBManager.ExecInsUps(vHashtable, "INS_PT_DEVELOPMENT", (ATSession)Session["User"]);
            ShowMsg(int.Parse(TXTID.Value));
            Response.Redirect("Patient_Development.aspx?id=" + TXTID.Value);
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
                Label PTDEV_ID = (Label)GridView1.Rows[index].FindControl("PTDEV_ID");

                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("PTDEV_ID", PTDEV_ID.Text);
                vHashtable.Add("PTP_ID", PTP_ID.Value);
                DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PT_DEVELOPMENT_NEW"));
                if (vDR != null)
                {
                    TXTID.Value = vDR["PTDEV_ID"].ToString();
                    PTP_TXT.Text = vDR["PTP_NAME"].ToString();
                    DEVCOND_ID.SelectedValue = vDR["PTDEV_DEVID"].ToString();
                    Textarea1.InnerText = vDR["PTDEV_DESC"].ToString();
                    btnSave.Visible = true;
                }
            }
            else
            {
                ShowMsg("", "You have no premission to modify");
            }
        }
    }
}