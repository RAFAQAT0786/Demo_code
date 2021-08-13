using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class customer : BasePage
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
        ValidateUserAccess();
        if (vATSession.UserType == "ADMIN" || vATSession.UserType == "GM")
        {
            cust1.Visible = true;
            ID.Visible = false;
        }
        else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
        {
            cust1.Visible = true;
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("USR_LOGIN", vATSession.Login);
            DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_USR_LOGIN"));
            if (vDR != null)
            {
                HiddenField1.Value = vDR["USR_SUBSCRIPTION_NUMBER"].ToString();
            }
            Hashtable vHashtable1 = new Hashtable();
            vHashtable1.Add("USR_LOGIN", vATSession.Login);
            DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_COUNT"));
            if (vDR1 != null)
            {
                HiddenField2.Value = vDR1["CUST"].ToString();
            }

            TXT_SUB.Text = Convert.ToString(Convert.ToInt32(HiddenField1.Value) - Convert.ToInt32(HiddenField2.Value));
            TXT_SUB.Enabled = false;
            if (TXT_SUB.Text == "0")
            {
                ID.Visible = false;
                cust1.Visible = false;
            }
        }
        else if (vATSession.UserType == "DOCTOR")
        {
            cust1.Visible = true;
            a.Visible = false;
            CreateNewCustbtn.Visible = true;
        }
        else
        {
            cust1.Visible = false;
        }
    }

    protected void CreateNewCustbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Customer_Create.aspx");
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
            vHashtable.Add("CUST_ID", value);
            DBManager.ExecDel(vHashtable, "DEL_Customer");
        }
        ShowDeleteMsg(true);
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

    protected void Search_Customer_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search_customer.aspx");
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