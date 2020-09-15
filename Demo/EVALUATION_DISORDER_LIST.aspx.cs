using System;
using System.Collections;
using System.Web.UI.WebControls;

public partial class EVALUATION_DISORDER_LIST : BasePage
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
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();

                if (vATSession.UserType == "ADMIN")
                {
                    Eval.Visible = true;
                    this.GridView1.Columns[3].Visible = false;
                    Div1.Visible = false;
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    Eval.Visible = false;
                    this.GridView1.Columns[3].Visible = false;
                    Div1.Visible = true;
                }
                else
                {
                    ShowMsg("Invalid Evaluation ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
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
        for (int j = 0; j < GridView1.Rows.Count; j++)
        {
            Label EVADIS_DISID = (Label)GridView1.Rows[j].Cells[3].FindControl("EVADIS_DISID");
            CheckBox chkRow = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("chkSelect");
            if (chkRow.Checked)
            {
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("EVADIS_DISID", EVADIS_DISID.Text);
                vHashtable.Add("TYPE", "DEL");
                DBManager.ExecDel(vHashtable, "GET_EVALUATION_DISORDER");
            }
        }
        ShowDeleteMsg(true);
    }
}