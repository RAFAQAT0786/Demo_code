using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_Condition : BasePage
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
                ATCommon.FillDrpDown(COND_ID, DBManager.Get(new Hashtable(), "CMB_CONDITION_MASTER"), "Select Condition Name", "COND_NAME", "COND_ID", "0");
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
                        Textarea1.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "mother was " +
                            "------------ " + "years old and father- was " + "------------- " + "years old at the time of the birth of" + "&nbsp;" +
                            vDR["PTP_NAME"].ToString() + "&nbsp;" + "There were" + "&nbsp;" + "complications / no complications" + "&nbsp;" +
                            "during pregnancy reported by the mother and" + "&nbsp;" + "he / she" + "&nbsp;" + "was born with no apparent  medical complications/ issues like" + "&nbsp;" +
                            "------------------------------------" + "&nbsp;" + vDR["PTP_NAME"].ToString() + "&nbsp;" +
                            "was full term / pre-term" + "and was born through C-section / normal delivery." +
                            "The mother" + "&nbsp;" + "----------" + "&nbsp;" + "did not face complications/ faced complications during delivery." + "&nbsp;" +
                            "------------------------------------" + "&nbsp;" + vDR["PTP_NAME"].ToString() + "&nbsp;"
                              + "birth weight was " + "----------.";

                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID);
                        DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "GET_PT_MENTAL_ID"));
                        if (vDR2 != null)
                        {
                            btnSave.Visible = false;
                        }
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
                    vHashtable.Add("PTM_ID", TXTID.Value);
                    vHashtable.Add("PTM_PTPID", PTP_ID.Value);
                    vHashtable.Add("PTM_CONDID", COND_ID.SelectedValue);
                    vHashtable.Add("PTM_DESC", Textarea1.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_PT_MENTAL");
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
                    vHashtable.Add("PTM_ID", TXTID.Value);
                    vHashtable.Add("PTM_PTPID", PTP_ID.Value);
                    vHashtable.Add("PTM_CONDID", COND_ID.SelectedValue);
                    vHashtable.Add("PTM_DESC", Textarea1.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_PT_MENTAL");
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
            vHashtable.Add("PTM_ID", "PTM_ID");
            vHashtable.Add("PTP_ID", "0");
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_PT_MENTAL");
        }
        ShowDeleteMsg(true);
    }

    protected void AddModify(string EDU_ID)
    {
        try
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTM_ID", TXTID.Value);
            vHashtable.Add("PTM_PTPID", PTP_ID.Value);
            vHashtable.Add("PTM_CONDID", COND_ID.SelectedValue);
            vHashtable.Add("PTM_DESC", Textarea1.InnerText);
            vHashtable.Add("LAST_USER", vATSession.Login);
            vHashtable.Add("TYPE", "INS");
            DBManager.ExecInsUps(vHashtable, "INS_PT_MENTAL", (ATSession)Session["User"]);
            ShowMsg(int.Parse(TXTID.Value));
            Response.Redirect("Patient_Condition.aspx?id=" + TXTID.Value);
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
                Label PTM_ID = (Label)GridView1.Rows[index].FindControl("PTM_ID");
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("PTM_ID", PTM_ID.Text);
                vHashtable.Add("PTP_ID", PTP_ID.Value);
                DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PT_MENTAL_NEW"));
                if (vDR != null)
                {
                    TXTID.Value = vDR["PTM_ID"].ToString();
                    PTP_TXT.Text = vDR["PTP_NAME"].ToString();
                    COND_ID.SelectedValue = vDR["PTM_CONDID"].ToString();
                    Textarea1.InnerText = vDR["PTM_DESC"].ToString();
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