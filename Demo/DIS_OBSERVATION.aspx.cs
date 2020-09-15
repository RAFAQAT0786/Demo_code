using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class DIS_OBSERVATION : BasePage
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("DOBS_ID", "0");
                vHashtable.Add("TYPE", "GETALL");
                DataTable vDT = DBManager.Get(vHashtable, "GET_DIS_OBSV_MASTER");
                DataTable dt = DBManager.Get(vHashtable, "GET_DIS_OBSV_MASTER");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DOBS_DESC", OBSV_TXT.Text);
        DataTable dt = DBManager.Get(vHashtable, "GET_DIS_OBSV_SEARCH");
        GridView1.DataSource = dt;
        GridView1.DataBind();
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
            vHashtable.Add("DOBS_ID", values);
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_DIS_OBSV_MASTER");
        }
        ShowDeleteMsg(true);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (OBSV_TXT.Text != null)
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("DOBS_DESC", OBSV_TXT.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_DIS_OBSV_SEARCH");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            ShowMsg("NOT FOUND ANY OBSERVATION");
        }
    }
}