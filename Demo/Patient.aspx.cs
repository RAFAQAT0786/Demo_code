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

public partial class Patient : BasePage
{
    ATSession vATSession;
    ATSession pATSession;

    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        string strPreviousPage = string.Empty;
        if (Request.UrlReferrer != null)
        {
            strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
        }
        if (strPreviousPage == "")
        {
            Response.Redirect("~/Default.aspx");
        }

        if (!IsPostBack)
        {
            try
            {
                if (vATSession.UserType == "ADMIN")
                {
                    Label2.Text = "<b>Please note:</b> This application is a proprietary of NerdNerdy Technologies Pvt Ltd. The system and content related to this software is under the Patent(awaited) and Copy right protection." + "<br></br>";

                    ValidateUserAccess();
                    LinkButton1.Visible = false;
                    Div1.Visible = false;
                    LinkButton1.Visible = false;
                    login_pop.Visible = false;
                    ID.Visible = false;
                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    Label2.Text = "<b>Please note:</b> This application is a proprietary of NerdNerdy Technologies Pvt Ltd. The system and content related to this software is under the Patent(awaited) and Copy right protection." + "<br></br>";

                    ValidateUserAccess();
                    LinkButton1.Visible = false;
                    Div1.Visible = false;
                    login_pop.Visible = false;
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_USR_LOGIN"));
                    if (vDR != null)
                    {
                        HiddenField1.Value = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                        HiddenField3.Value = vDR["USR_ORGANIZATION_NAME"].ToString();
                    }
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("CUST_ORGANIZATION_NAME", HiddenField3.Value);
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_COUNT_PATIENT"));
                    if (vDR1 != null)
                    {
                        HiddenField2.Value = vDR1["CUST"].ToString();
                    }
                    
                    Hashtable vHashtable15 = new Hashtable();
                    vHashtable15.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR15 = RetDR(DBManager.Get(vHashtable15, "GET_TOTALPATIENT"));
                    if (vDR15 != null)
                    {
                        HiddenField7.Value = vDR15["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }
                    Hashtable vHashtable16 = new Hashtable();
                    vHashtable16.Add("USR_ORGANIZATION_NAME", HiddenField3.Value);
                    DataRow vDR16 = RetDR(DBManager.Get(vHashtable16, "GET_TOTALPATIENT_NUMBER"));
                    if (vDR16 != null)
                    {
                        HiddenField10.Value = vDR16["USED_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }
                    if (HiddenField7.Value != "" && HiddenField10.Value != "")
                    {

                        HiddenField8.Value = Convert.ToString(Convert.ToInt32(HiddenField7.Value) - Convert.ToInt32(HiddenField10.Value));
                    }
                    if (HiddenField1.Value != "" && HiddenField2.Value != "")
                    {
                        //TXT_SUB.Text = Convert.ToString(Convert.ToInt32(HiddenField1.Value) - Convert.ToInt32(HiddenField2.Value));
                        TXT_SUB.Text = HiddenField8.Value;
                        TXT_SUB.Enabled = false;
                        if (TXT_SUB.Text == "0")
                        {
                            ID.Visible = true;
                            login_pop.Visible = false;
                        }
                    }
                }
                else if (vATSession.UserType == "Paediatrician")
                {
                    Label2.Text = "<b>Please note:</b> This application is a proprietary of NerdNerdy Technologies Pvt Ltd. The system and content related to this software is under the Patent(awaited) and Copy right protection." + "<br></br>";

                    ValidateUserAccess();
                    LinkButton1.Visible = false;
                    Div1.Visible = false;
                    login_pop.Visible = false;
                    this.GridView1.Columns[7].Visible = false;
                    this.GridView1.Columns[8].Visible = false;
                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;
                    this.GridView1.Columns[11].Visible = false;
                    this.GridView1.Columns[12].Visible = false;
                    this.GridView1.Columns[13].Visible = false;
                    this.GridView1.Columns[14].Visible = false;
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_USR_LOGIN_PAEDIATRICIAN"));
                    if (vDR != null)
                    {
                        HiddenField1.Value = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                        HiddenField3.Value = vDR["USR_ORGANIZATION_NAME"].ToString();
                    }
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("CUST_ORGANIZATION_NAME", HiddenField3.Value);
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_COUNT_PATIENT"));
                    if (vDR1 != null)
                    {
                        HiddenField2.Value = vDR1["CUST"].ToString();
                    }

                    Hashtable vHashtable15 = new Hashtable();
                    vHashtable15.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR15 = RetDR(DBManager.Get(vHashtable15, "GET_TOTALPATIENT_PAEDIATRICIAN"));
                    if (vDR15 != null)
                    {
                        HiddenField7.Value = vDR15["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }

                    Hashtable vHashtable36 = new Hashtable();
                    vHashtable36.Add("CUST_ORGANIZATION_NAME", HiddenField3.Value);
                    DataRow vDR36 = RetDR(DBManager.Get(vHashtable36, "GET_COUNT_CUST"));
                    if (vDR36 != null)
                    {
                        HiddenField12.Value = vDR36["CUST_ID"].ToString();
                    }

                    Hashtable vHashtable16 = new Hashtable();
                    vHashtable16.Add("PTP_CUSTID", HiddenField12.Value);
                    DataRow vDR16 = RetDR(DBManager.Get(vHashtable16, "GET_TOTALPATIENT_NUMBER_PAEDIATRICIAN"));
                    if (vDR16 != null)
                    {
                        HiddenField10.Value = vDR16["USED_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }
                    if (HiddenField7.Value != "" && HiddenField10.Value != "")
                    {

                        HiddenField8.Value = Convert.ToString(Convert.ToInt32(HiddenField7.Value) - Convert.ToInt32(HiddenField10.Value));
                    }
                    if (HiddenField1.Value != "" && HiddenField2.Value != "")
                    {
                        //TXT_SUB.Text = Convert.ToString(Convert.ToInt32(HiddenField1.Value) - Convert.ToInt32(HiddenField2.Value));
                        TXT_SUB.Text = HiddenField8.Value;
                        TXT_SUB.Enabled = false;
                        if (TXT_SUB.Text == "0")
                        {
                            ID.Visible = true;
                            login_pop.Visible = false;
                            HEADER1.Visible = false;
                        }
                        else
                        {
                            login_pop.Visible = true;
                        }
                    }
                }
                else if (vATSession.UserType == "Patient")
                {
                    Label2.Text = "<b>Please note:</b> This application is a proprietary of NerdNerdy Technologies Pvt Ltd. The system and content related to this software is under the Patent(awaited) and Copy right protection." + "<br></br>";

                    ValidateUserAccess();
                    HEADER1.Visible = false;
                    ID.Visible = false;
                    LinkButton1.Visible = false;
                    Div1.Visible = false;
                    login_pop.Visible = false;
                    this.GridView1.Columns[7].Visible = false;
                    this.GridView1.Columns[8].Visible = false;
                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;
                    this.GridView1.Columns[6].Visible = false;
                    //this.GridView1.Columns[12].Visible = false;
                    this.GridView1.Columns[13].Visible = false;
                    this.GridView1.Columns[14].Visible = false;
                }
                else if (vATSession.UserType == "Parent")
                {
                    Label2.Text = "<b>Please note:</b> This application is a proprietary of NerdNerdy Technologies Pvt Ltd. The system and content related to this software is under the Patent(awaited) and Copy right protection." + "<br></br>";

                    ValidateUserAccess();
                    //HEADER1.Visible = false;
                    //ID.Visible = false;
                    LinkButton1.Visible = false;
                    Div1.Visible = false;
                    //login_pop.Visible = false;
                    this.GridView1.Columns[7].Visible = false;
                    this.GridView1.Columns[8].Visible = false;
                    this.GridView1.Columns[9].Visible = false;
                    this.GridView1.Columns[10].Visible = false;
                    this.GridView1.Columns[6].Visible = false;
                    //this.GridView1.Columns[12].Visible = false;
                    this.GridView1.Columns[13].Visible = false;
                    this.GridView1.Columns[14].Visible = false;
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_USR_LOGIN_PARENT"));
                    if (vDR != null)
                    {
                        HiddenField1.Value = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                        HiddenField3.Value = vDR["USR_ORGANIZATION_NAME"].ToString();
                    }
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("CUST_ORGANIZATION_NAME", HiddenField3.Value);
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_COUNT_PATIENT"));
                    if (vDR1 != null)
                    {
                        HiddenField2.Value = vDR1["CUST"].ToString();
                    }

                    Hashtable vHashtable15 = new Hashtable();
                    vHashtable15.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR15 = RetDR(DBManager.Get(vHashtable15, "GET_TOTALPATIENT_PARENT"));
                    if (vDR15 != null)
                    {
                        HiddenField7.Value = vDR15["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }

                    Hashtable vHashtable36 = new Hashtable();
                    vHashtable36.Add("CUST_ORGANIZATION_NAME", HiddenField3.Value);
                    DataRow vDR36 = RetDR(DBManager.Get(vHashtable36, "GET_COUNT_CUST"));
                    if (vDR36 != null)
                    {
                        HiddenField12.Value = vDR36["CUST_ID"].ToString();
                    }

                    Hashtable vHashtable16 = new Hashtable();
                    vHashtable16.Add("PTP_CUSTID", HiddenField12.Value);
                    DataRow vDR16 = RetDR(DBManager.Get(vHashtable16, "GET_TOTALPATIENT_NUMBER_PAEDIATRICIAN"));
                    if (vDR16 != null)
                    {
                        HiddenField10.Value = vDR16["USED_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }
                    if (HiddenField7.Value != "" && HiddenField10.Value != "")
                    {

                        HiddenField8.Value = Convert.ToString(Convert.ToInt32(HiddenField7.Value) - Convert.ToInt32(HiddenField10.Value));
                    }
                    if (HiddenField1.Value != "" && HiddenField2.Value != "")
                    {
                        //TXT_SUB.Text = Convert.ToString(Convert.ToInt32(HiddenField1.Value) - Convert.ToInt32(HiddenField2.Value));
                        TXT_SUB.Text = HiddenField8.Value;
                        TXT_SUB.Enabled = false;
                        if (TXT_SUB.Text == "0")
                        {
                            ID.Visible = true;
                            login_pop.Visible = false;
                            HEADER1.Visible = false;
                        }
                        else
                        {
                            login_pop.Visible = true;
                        }
                    }
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    Label2.Text = "<b>Please note:</b> This application is a proprietary of NerdNerdy Technologies Pvt Ltd. The system and content related to this software is under the Patent(awaited) and Copy right protection." + "<br></br>";

                    ValidateUserAccess();
                    LinkButton1.Visible = false;
                    Div1.Visible = false;
                    //login_pop.Visible = false;
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_USR_LOGIN_THERAPIST"));
                    if (vDR != null)
                    {
                        HiddenField1.Value = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                        HiddenField3.Value = vDR["USR_ORGANIZATION_NAME"].ToString();
                    }
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("CUST_ORGANIZATION_NAME", HiddenField3.Value);
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_COUNT_PATIENT"));
                    if (vDR1 != null)
                    {
                        HiddenField2.Value = vDR1["CUST"].ToString();
                    }

                    Hashtable vHashtable15 = new Hashtable();
                    vHashtable15.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR15 = RetDR(DBManager.Get(vHashtable15, "GET_TOTAL_THERAPIST"));
                    if (vDR15 != null)
                    {
                        HiddenField7.Value = vDR15["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }
                    Hashtable vHashtable36 = new Hashtable();
                    vHashtable36.Add("CUST_ORGANIZATION_NAME", HiddenField3.Value);
                    DataRow vDR36 = RetDR(DBManager.Get(vHashtable36, "GET_COUNT_CUST"));
                    if (vDR36 != null)
                    {
                        HiddenField12.Value = vDR36["CUST_ID"].ToString();
                    }
                    Hashtable vHashtable16 = new Hashtable();
                    vHashtable16.Add("PTP_CUSTID", HiddenField12.Value);
                    DataRow vDR16 = RetDR(DBManager.Get(vHashtable16, "GET_TOTALPATIENT_NUMBER_THERAPIST"));
                    if (vDR16 != null)
                    {
                        HiddenField10.Value = vDR16["USED_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }
                    if (HiddenField7.Value != "" && HiddenField10.Value != "")
                    {

                        HiddenField8.Value = Convert.ToString(Convert.ToInt32(HiddenField7.Value) - Convert.ToInt32(HiddenField10.Value));
                    }
                    if (HiddenField1.Value != "" && HiddenField2.Value != "")
                    {
                        //TXT_SUB.Text = Convert.ToString(Convert.ToInt32(HiddenField1.Value) - Convert.ToInt32(HiddenField2.Value));
                        TXT_SUB.Text = HiddenField8.Value;
                        TXT_SUB.Enabled = false;
                        if (TXT_SUB.Text == "0")
                        {
                            ID.Visible = true;
                            login_pop.Visible = false;
                        }
                    }
                }
                else
                {
                    Label2.Text = "<b>Please note:</b> This application is a proprietary of NerdNerdy Technologies Pvt Ltd. The system and content related to this software is under the Patent(awaited) and Copy right protection." + "<br></br>";

                    ValidateUserAccess();
                    Div1.Visible = false;
                    ID.Visible = false;
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_USR_LOGIN_ID"));
                    if (vDR != null)
                    {
                        HiddenField1.Value = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                        HiddenField3.Value = vDR["USR_ORGANIZATION_NAME"].ToString();
                    }
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("CUST_MOBILE", vATSession.Login);
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_CUST_MOBILE"));
                    if (vDR1 != null)
                    {
                        HiddenField2.Value = vDR1["CUST_ID"].ToString();
                    }
                    Hashtable vHashtable2 = new Hashtable();
                    vHashtable2.Add("PTP_CUSTID", HiddenField2.Value);
                    DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "GET_COUNT_PATIENT_TOTAL"));
                    if (vDR2 != null)
                    {
                        HiddenField5.Value = vDR2["CUST"].ToString();
                }
                    if (HiddenField1.Value != "" && HiddenField5.Value != "")
                    {
                        TXT_SUB.Text = Convert.ToString(Convert.ToInt32(HiddenField1.Value) - Convert.ToInt32(HiddenField5.Value));
                        TXT_SUB.Enabled = false;
                        if (TXT_SUB.Text == "0")
                        {
                            ID.Visible = true;
                            LinkButton1.Visible = false;
                            login_pop.Visible = false;
                            string message = "Please Buy Patient Subscription !!";
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                        }
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

    protected void btnYes_Click(object sender, EventArgs e)
    {
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "PATIENT")
        {
            Label CUSTA_SCTPID = (Label)GridView1.Rows[index].FindControl("CUSTA_SCTPID");
            Label PTP_ID = (Label)GridView1.Rows[index].FindControl("PTP_ID");

            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", PTP_ID.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ID");
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Patient_Doctor_Screening.aspx?id=" + PTP_ID.Text);
            }
        }
        else if (e.CommandName == "EVALUATION")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            Hashtable vHashtable2 = new Hashtable();
            vHashtable2.Add("PTP_ID", id);
            DataTable vDT2 = DBManager.Get(vHashtable2, "GET_DIS_MASTER_NEW");
            DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "GET_DIS_MASTER_NEW"));
            Response.Redirect("Patient_Doctor_Evaluation.aspx?id1=" + id);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string values = TXTVALUE.Value.Remove(TXTVALUE.Value.Length - 1);

        Hashtable vHT = new Hashtable();
        vHT.Add("PTP_ID", values);
        DataRow vDR2 = RetDR(DBManager.Get(vHT, "GET_PTPID"));
        if (vDR2 != null)
        {
            HiddenField22.Value = vDR2["PTP_MOBILE"].ToString();
        }

        foreach (string value in values.Split(','))
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", values);
            vHashtable.Add("PTP_MOBILE", HiddenField22.Value);
            vHashtable.Add("TYPE", "DEL");
            DBManager.ExecDel(vHashtable, "GET_PATIENT_NUMBER");
        }
        ShowDeleteMsg(true);
        Response.Redirect("Patient.aspx");
    }

    protected void btnSearchPatient_Click(object sender, EventArgs e)
    {
        if (vATSession.UserType == "ADMIN")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("NAME", PTP_NAME_TXT.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ADMIN");
            GridView2.DataSource = dt;
            GridView2.DataBind();
            PTP1.Visible = false;
            Div1.Visible = true;
        }
        else if (vATSession.UserType == "ORGANIZATION")
        {

            if (PTP_NAME_TXT.Text != "")
            {
                Hashtable vHashtable2 = new Hashtable();
                vHashtable2.Add("USR_LOGIN", vATSession.Login);
                DataRow vDR = RetDR(DBManager.Get(vHashtable2, "GET_USR_LOGIN_ID"));
                if (vDR != null)
                {
                    HiddenField1.Value = vDR["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    HiddenField3.Value = vDR["USR_ORGANIZATION_NAME"].ToString();
                }

                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("NAME", PTP_NAME_TXT.Text);
                vHashtable.Add("CUST_ORGANIZATION_NAME", HiddenField3.Value);
                DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ADMIN_NEW");
                GridView2.DataSource = dt;
                GridView2.DataBind();
                PTP1.Visible = false;
                Div1.Visible = true;
            }
            else
            {
                ShowMsg("NOT FOUND ANY PATIENT NAME");
            }
        }

        else
        {

            if (PTP_NAME_TXT.Text != "")
            {
                String vID = vATSession.UserName;

                Hashtable vHashtable2 = new Hashtable();
                vHashtable2.Add("CUST_NAME", vID);
                DataRow vDR = RetDR(DBManager.Get(vHashtable2, "GET_CUST"));
                if (vDR != null)
                {
                    CUST_ID.Value = vDR["CUST_ID"].ToString();
                }

                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("NAME", PTP_NAME_TXT.Text);
                vHashtable.Add("PTP_CUSTID", CUST_ID.Value);
                DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_NAME");
                GridView2.DataSource = dt;
                GridView2.DataBind();
                PTP1.Visible = false;
                Div1.Visible = true;
            }
            else
            {
                ShowMsg("NOT FOUND ANY PATIENT NAME");
            }
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "PATIENT")
        {
            Label CUSTA_SCTPID = (Label)GridView2.Rows[index].FindControl("CUSTA_SCTPID");
            Label PTP_ID = (Label)GridView2.Rows[index].FindControl("PTP_ID");

            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", PTP_ID.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ID");
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Patient_Doctor_Screening.aspx?id=" + PTP_ID.Text);
            }
        }
        else if (e.CommandName == "EVALUATION")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            Hashtable vHashtable2 = new Hashtable();
            vHashtable2.Add("PTP_ID", id);
            DataTable vDT2 = DBManager.Get(vHashtable2, "GET_DIS_MASTER_NEW");
            DataRow vDR2 = RetDR(DBManager.Get(vHashtable2, "GET_DIS_MASTER_NEW"));
            Response.Redirect("Patient_Doctor_Evaluation.aspx?id1=" + id);
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
    }
}