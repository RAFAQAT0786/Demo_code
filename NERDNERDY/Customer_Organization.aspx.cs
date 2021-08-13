using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Web.UI;

public partial class Customer_Organization : BasePage
{
    ATSession vATSession;
    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }
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
                if (vATSession.UserType == "ORGANIZATION")
                {
                    
                    GridView1.HeaderRow.Cells[07].Visible = false;
                    foreach (GridViewRow gdr in GridView1.Rows)
                    {
                        gdr.Cells[07].Visible = false;
                    }
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
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("USR_LOGIN", TXTVALUE.Value.Remove(TXTVALUE.Value.Length-1));
        DBManager.ExecDel(vHashtable, "DEL_USER");
    }
}
