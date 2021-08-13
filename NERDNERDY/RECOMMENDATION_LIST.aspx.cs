using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class RECOMMENDATION_LIST : BasePage
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
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("RECOM_ID", "0");
                vHashtable.Add("TYPE", "GETALL");
                DataTable vDT = DBManager.Get(vHashtable, "GET_RECOMMENDATION");
                GridView1.DataSource = vDT;
                GridView1.DataBind();
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
        string values = TXTVALUE.Value.Remove(TXTVALUE.Value.Length - 1);

        foreach (string value in values.Split(','))
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("RECOM_ID", values);
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_RECOMMENDATION");
        }
        ShowDeleteMsg(true);
        Response.Redirect("RECOMMENDATION_LIST.aspx");
    }
}