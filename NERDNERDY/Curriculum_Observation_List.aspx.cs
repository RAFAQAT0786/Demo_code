using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
public partial class Curriculum_Observation_List : BasePage
{
    ATSession vATSession;

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
                BindGrid();
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void BindGrid()
    {
        Hashtable vHashtable1 = new Hashtable();
        DataTable dt = DBManager.Get(vHashtable1, "GET_CURRICULUM_AGE_GROUP");
        GridView1.DataSource = dt;
        GridView1.DataBind();
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }

}