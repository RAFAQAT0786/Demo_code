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

public partial class UserList : BasePage
{
    ATSession vATSession;
    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        String vID = vATSession.Login;
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        ValidateUserAccess();
        if (vATSession.UserType == "ADMIN")
        {
            Hashtable vHashtable4 = new Hashtable();
            DataTable dt = DBManager.Get(vHashtable4, "GET_USER_DETAIL");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else if (vATSession.UserType == "Organization" || vATSession.UserType == "ORGANIZATION")
        {
            a.Visible = false;
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("USR_LOGIN", vID);
            DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_ORGANIZATION_NEW"));
            if (vDR != null)
            {
                HiddenField1.Value = vDR["USR_ORGANIZATION_NAME"].ToString();
                HiddenField2.Value = vDR["USR_SUBSCRIPTION_NUMBER"].ToString();
            }
            Hashtable vHashtable4 = new Hashtable();
            vHashtable4.Add("CUST_ORGANIZATION_NAME", HiddenField1.Value);
            vHashtable4.Add("CUST_MOBILE", vATSession.Login);
            DataTable dt = DBManager.Get(vHashtable4, "GET_ORGANIZATION");
            Hashtable vHashtable1 = new Hashtable();
            vHashtable1.Add("USR_ORGANIZATION_NAME", HiddenField1.Value);
            vHashtable1.Add("CUST_MOBILE", vATSession.Login);
            DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_ORGANIZATION_COUNT"));
            if (vDR1 != null)
            {
                HiddenField3.Value = vDR1["CUST"].ToString();
            }
            if (HiddenField2.Value != "" && HiddenField3.Value != "")
            {
                TXT_SUB.Text = Convert.ToString(Convert.ToInt32(HiddenField2.Value) - Convert.ToInt32(HiddenField3.Value));
                TXT_SUB.Enabled = false;
                if (TXT_SUB.Text == "0")
                {
                    ID.Visible = false;
                    cust1.Visible = false;
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            
        }
    }
    protected void CreateNewCustbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("User.aspx");
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
        foreach (GridViewRow gr in GridView1.Rows)
        {
            string values = gr.Cells[3].Text;
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("MOBILE", values);
            DBManager.ExecDel(vHashtable, "DEL_CUSTUSER");
        }
        ShowDeleteMsg(true);
        Response.Redirect("UserList.aspx");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected string Name(object name)
    {
        string str = "";
        
         string[] names = name.ToString().Split('_');
         if (names.Length > 1)
             str = names[0] + " " + names[1];
         else
            str = names[0];
             return str; 
    }
    protected void btn_home_Click(object sender, EventArgs e)
    {
        if (vATSession.UserType == "ADMIN")
        {
            Response.Redirect("Admin_Welcome.aspx");
        }
        if (vATSession.UserType == "ORGANIZATION")
        {
            Response.Redirect("Organization_Welcome.aspx");
        }
    }
}
