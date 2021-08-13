using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class Template_Video_List : BasePage
{
    private ATSession vATSession;

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
                BindGrid();
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }
    protected void BindGrid()
    {
        String vID = Request.QueryString["ID"];

        Hashtable vHashtable = new Hashtable();
        DataTable dt = DBManager.Get(vHashtable, "GET_TEMPLATE_VIDEO_DETAIL");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string values = TXTVALUE.Value.Remove(TXTVALUE.Value.Length - 1);

        foreach (string value in values.Split(','))
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("VD_ID", values);
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_TEMPLATE_VIDEO_DELETE");
        }
        ShowDeleteMsg(true);
        Response.Redirect("Template_Video_List.aspx");
    }
}