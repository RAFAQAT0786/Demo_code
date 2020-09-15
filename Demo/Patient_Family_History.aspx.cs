using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_Family_History : BasePage
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
                        TXTVALUE.Value = vDR["PTP_ID"].ToString();
                        PTP_TXT.Text = vDR["PTP_NAME"].ToString();
                        Textarea1.Value = vDR["PTP_NAME"].ToString() + "&nbsp;" + "lives with his/her " + "&nbsp;" +
                            "parents/Institution." + "<br />" +
                            "He/she" + "&nbsp;" +
                            "has younger/older " + "&nbsp;" +
                            "sibling." + "&nbsp;" +
                            "As reported by the mother/father/caregiver" + "&nbsp;" +
                            "there is a /No " + "<br />" + "history of developmental problem within the immediate family....." + "<br />";

                        Hashtable vHashtable2 = new Hashtable();
                        vHashtable2.Add("PTP_ID", vID);
                        DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "GET_PT_FAMILY_HIST_ID"));
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
                    vHashtable.Add("PTFH_ID", TXTID.Value);
                    vHashtable.Add("PTFH_PTPID", PTP_ID.Value);
                    vHashtable.Add("PTFH_RELATION", RELATION_DDL.SelectedValue);
                    vHashtable.Add("PTFH_DESC", Textarea1.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_PT_FAMILY_HIST");
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
                    vHashtable.Add("PTFH_ID", TXTID.Value);
                    vHashtable.Add("PTFH_PTPID", PTP_ID.Value);
                    vHashtable.Add("PTFH_RELATION", RELATION_DDL.SelectedValue);
                    vHashtable.Add("PTFH_DESC", Textarea1.InnerText);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_PT_FAMILY_HIST");
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "modify")
        {
            vATSession = (ATSession)Session["User"];
            if (!vATSession.UserType.Equals("ADMIN"))
            {
                int index = Convert.ToInt16(e.CommandArgument);
                Label PTM_ID = (Label)GridView1.Rows[index].FindControl("PTP_ID");
                Label PTFH_ID = (Label)GridView1.Rows[index].FindControl("PTFH_ID");
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("PTFH_ID", PTFH_ID.Text);
                vHashtable.Add("PTP_ID", PTP_ID.Value);
                DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_PT_FAMILY_HIST_NEW"));
                if (vDR != null)
                {
                    TXTID.Value = vDR["PTFH_ID"].ToString();
                    PTP_ID.Value = vDR["PTP_ID"].ToString();
                    PTP_TXT.Text = vDR["PTP_NAME"].ToString();
                    Textarea1.InnerText = vDR["PTFH_DESC"].ToString();
                    RELATION_DDL.SelectedItem.Text = vDR["PTFH_RELATION"].ToString();
                    btnSave.Visible = true;
                }
            }
            else
            {
                ShowMsg("", "You have no premission to modify");
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
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTPATIENTHIS");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["PTP_NAME"].ToString().Equals(args.Value) || DR["PTFH_RELATION"].ToString().Equals(args.Value) || DR["PTFH_DESC"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
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
            vHashtable.Add("PTFH_ID", "PTFH_ID");
            vHashtable.Add("PTP_ID", "0");
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_PT_FAMILY_HIST");
        }
        ShowDeleteMsg(true);
    }
}