using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class Assessment_Word : BasePage
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
        String vID1 = Request.QueryString["ID1"];
       
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();

                Hashtable vHashtable4 = new Hashtable();
                vHashtable4.Add("PTP_ID", vID);
                vHashtable4.Add("PTA_ID", vID1);
                DataTable dt4 = DBManager.Get(vHashtable4, "GET_KEYWORD");
                DataRow vDR4 = RetDR(DBManager.Get(vHashtable4, "GET_KEYWORD"));
                
                if (vDR4 != null)
                {
                    GridView1.DataSource = dt4;
                    GridView1.DataBind();
                    Div1.Visible = true;
                    Div2.Visible = false;
                }
                else 
                {
                    Hashtable vHashtable5 = new Hashtable();
                    vHashtable5.Add("PTP_ID", vID);
                    vHashtable5.Add("PTAC_ID", vID1);
                    DataTable dt5 = DBManager.Get(vHashtable5, "GET_CURRICULUM_KEYWORD");
                    DataRow vDR5 = RetDR(DBManager.Get(vHashtable5, "GET_CURRICULUM_KEYWORD"));
                    if (vDR5 != null)
                    {
                        GridView2.DataSource = dt5;
                        GridView2.DataBind();
                        Div2.Visible = true;
                        Div1.Visible = false;
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
}