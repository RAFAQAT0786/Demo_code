using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Web.UI;

public partial class User_AdminList : BasePage
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
                BindData();
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }
    
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("USR_LOGIN", TXTVALUE.Value.Remove(TXTVALUE.Value.Length-1));
        DBManager.ExecDel(vHashtable, "DEL_USER");
    }
    protected void BindData()
    {
        if (vATSession.UserType == "ORGANIZATION")
        {
            String vID = vATSession.Login;

            Hashtable vHashtable2 = new Hashtable();
            vHashtable2.Add("USR_LOGIN", vID);
            DataRow vDR = RetDR(DBManager.Get(vHashtable2, "GET_USER"));
            DataTable vDT3 = DBManager.Get(vHashtable2, "GET_USER");
                    LinkButton.Visible = false;
            ID.Visible = false;
            GridView1.HeaderRow.Cells[07].Visible = false;
            foreach (GridViewRow gdr in GridView1.Rows)
            {
                gdr.Cells[07].Visible = false;
            }
            if (vDR != null)
            {
                GridView1.DataSource = vDT3;
                GridView1.DataBind();
                }
            }
          else
            {
         if (ORGANIZATION_NAME_TXT.Text != "")
            {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("NAME", ORGANIZATION_NAME_TXT.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_ORGANIZATION_ADMIN");
            DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_ORGANIZATION_ADMIN"));
            if (vDR != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            }
        else
        {
                Hashtable vHashtable = new Hashtable();
                DataTable vDT3 = DBManager.Get(vHashtable, "GET_USER_INFO");
                GridView1.DataSource = vDT3;
                GridView1.DataBind();
            }
        }
    }
    protected void btnSearchOrganization_Click(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("NAME", ORGANIZATION_NAME_TXT.Text);
        DataTable dt = DBManager.Get(vHashtable, "GET_ORGANIZATION_ADMIN");
        DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_ORGANIZATION_ADMIN"));
        if (vDR != null)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
