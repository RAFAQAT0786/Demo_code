using System;
using System.Collections;
using System.Configuration;
using System.Data;

public partial class Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //imglogo.ImageUrl = "~/Logos/logo.png";
    }

    protected void BTN_LOGIN_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("USR_LOGIN", TXTUSER.Text);
            vHashtable.Add("USR_PASSWORD", TXTPWD.Text);
            DataRow vDR = RetDR(DBManager.GetMasterData(vHashtable, "GETUSER"));
            if (vDR == null)
                lblMsg.Text = "Invalid Login/Password";
            else
            {
                if (vDR["DEL_STATUS"].ToString() == "Y")
                    lblMsg.Text = "Inactive User";
                else
                {
                    string Emp_Id = "";
                    string Cust_Id = "";
                    string PTP_Id = "";
                    Hashtable ht = new Hashtable();
                    ht.Add("USERNAME", TXTUSER.Text);
                    DataRow Emp = RetDR(DBManager.GetMasterData(ht, "GETEMP"));
                    if (Emp != null)
                    {
                        Emp_Id = Emp["EMP_ID"].ToString();
                    }
                    else if (vDR["USR_TYPE"].ToString() != "ADMIN" && vDR["USR_TYPE"].ToString() != "Doctor" && vDR["USR_TYPE"].ToString() != "Patient" && vDR["USR_TYPE"].ToString() != "ORGANIZATION")
                    {
                        DataRow Cust = RetDR(DBManager.GetMasterData(ht, "GETCUSTOMER"));
                        Cust_Id = Cust["CUST_ID"].ToString();
                    }

                    int date1 = DateTime.Now.Year;
                    int date2 = date1 - 1;
                    string finyear = date2 + "-" + date1;

                    ATSession vATSession = new ATSession(vDR["USR_LOGIN"].ToString(), vDR["USR_PASSWORD"].ToString(), vDR["USR_COMPANY"].ToString(), vDR["USR_CONT_NAME"].ToString(), vDR["USR_TYPE"].ToString(), ConfigurationManager.AppSettings["FinYear"], Emp_Id, Cust_Id, PTP_Id);
                    Session["User"] = vATSession;

                    if (vATSession != null)
                    {
                        Hashtable vloght = new Hashtable();
                        vloght.Add("LOG_ID", "0");
                        if (Emp != null)
                        {
                            vloght.Add("LOG_EMP_ID", vATSession.EMP_ID);
                        }
                        else
                        {
                            vloght.Add("LOG_EMP_ID", vATSession.CUST_ID);
                        }
                        vloght.Add("LOG_EMP_NAME", vATSession.UserName);
                        vloght.Add("LOG_LOGIN", vATSession.Login);
                        vloght.Add("LOG_USRTYPE", vATSession.UserType);
                        DataTable vDTLOG = DBManager.ExecInsUpsGet(vloght, "INS_USR_LOGSESSION", "GET_LOGID", (ATSession)Session["User"]);
                        vATSession.LOG_ID = vDTLOG.Rows[0]["LOG_ID"].ToString();
                    }

                    if (vATSession.UserType == "ADMIN")
                        Response.Redirect("Admin_Welcome.aspx");
                    else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                        Response.Redirect("doctor_welcome.aspx");
                    else if (vATSession.UserType == "PATIENT" || vATSession.UserType == "Patient")
                        Response.Redirect("Patient_Welcome.aspx");
                    else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                        Response.Redirect("Organization_Welcome.aspx");
                    else if (vATSession.UserType == "Paediatrician")
                        Response.Redirect("Paediatrician_Welcome.aspx");
                    else if (vATSession.UserType == "Parent")
                        Response.Redirect("Parent_Welcome.aspx");
                    else if (vATSession.UserType == "Therapist")
                        Response.Redirect("Therapist_Welcome.aspx");
                    vATSession.EMP_ID = Emp_Id;
                }
            }
        }
        catch (Exception xe) { lblMsg.Text = xe.Message; }
    }
}