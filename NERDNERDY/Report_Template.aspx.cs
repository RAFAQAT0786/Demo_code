using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_Template : BasePage
{
    private ATSession vATSession;
    private DataRow vDR;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];

        if (!IsPostBack)
        {
            try
            {
                ATCommon.FillDrpDown(DDLAGE, DBManager.Get(new Hashtable(), "CMB_AGE_SCREEN_MASTER"), "Select Group Name", "AGRP_GROUP", "AGRP_ID", "0");
                ATCommon.FillCDWR(EVALUATION_DDL, DBManager.Get(new Hashtable(), "CMB_EVALUATION"), "Select Evaluation Name", "EVA_NAME", "EVA_ID", "");
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("RPT_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_MASTER_REPORT_ID"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["RPT_ID"].ToString();
                        REPORT_TXT.Text = vDR["RPT_NAME"].ToString();
                        DDLAGE.Text = vDR["AGRP_ID"].ToString();
                        REPORT_TXT.Enabled = false;
                        DDLAGE.Enabled = false;
                        SAVEBTN.Visible = false;
                        Textarea1.InnerText = vDR["RPTD_REPREASON"].ToString();
                        Textarea2.InnerText = vDR["RPTD_MED"].ToString();
                        Textarea3.InnerText = vDR["RPTD_PTMID"].ToString();
                        Textarea4.InnerText = vDR["RPTD_PTFHID"].ToString();
                        Textarea5.InnerText = vDR["RPTD_DOBSID"].ToString();
                        Textarea11.InnerText = vDR["RPTD_DST"].ToString();
                        Textarea17.InnerText = vDR["RPTD_RECOM"].ToString();
                        Get_Evaluation_Name(EVALUATION_DDL, vDR["RPTD_EVAID"].ToString(), true);
                    }
                    else
                        ShowMsg("Invalid Patient ID");
                }
                EVALUATION_DDL.Enabled = true;
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void Get_Evaluation_Name(CheckBoxList chklist, String values, bool flag)
    {
        DataRow vDR1;
        for (int i = 0; i < chklist.Items.Count - 1; i++)
            chklist.Items[i].Selected = false;
        foreach (string val in values.Split(','))
        {
            if (val != "")
            {
                Hashtable ht = new Hashtable();
                ht.Add("ID", val);
                vDR1 = RetDR(DBManager.Get(ht, "GET_EVA_NAME"));
                if (vDR1 != null)
                {
                    ListItem li = new ListItem(vDR1[1].ToString(), vDR1[0].ToString());
                    if (!chklist.Items.Contains(li))
                    {
                        chklist.Items.Add(li);
                        chklist.Items[chklist.Items.IndexOf(li)].Selected = true;
                    }
                    else
                        chklist.Items[chklist.Items.IndexOf(li)].Selected = true;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Hashtable vHashtable1 = new Hashtable();
        vHashtable1.Add("RPT_ID", TXTVALUE.Value);
        vHashtable1.Add("RPT_NAME", REPORT_TXT.Text);
        vHashtable1.Add("RPT_AGRP_ID", DDLAGE.SelectedValue);
        vHashtable1.Add("TYPE", "INS");
        if (DBManager.ExecInsUpsReturn(vHashtable1, "INS_REPORT_MASTER", (ATSession)Session["User"]))

        {
            if (Page.IsValid)
            {
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("RPTD_ID", TXTID.Value);
                    vHashtable.Add("RPTD_RPTID", TXTVALUE.Value);
                    vHashtable.Add("RPTD_REPREASON", Textarea1.InnerText);
                    vHashtable.Add("RPTD_EVAID", ATCommon.GetListControlValues(EVALUATION_DDL));
                    vHashtable.Add("RPTD_MED", Textarea2.InnerText);
                    vHashtable.Add("RPTD_PTMID", Textarea3.InnerText);
                    vHashtable.Add("RPTD_PTFHID", Textarea4.InnerText);
                    vHashtable.Add("RPTD_DOBSID", Textarea5.InnerText);
                    vHashtable.Add("RPTD_DST", Textarea11.InnerText);
                    vHashtable.Add("RPTD_AGRPID", DDLAGE.SelectedItem.Text);
                    vHashtable.Add("RPTD_RECOM", Textarea17.InnerText);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.ExecInsUps(vHashtable, "INS_REPORT_DETAIL", (ATSession)Session["User"]);
                    Response.Redirect("Report_Template_List.aspx");
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            }
        }
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTRPTNAME");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["RPT_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}