using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

public class BasePage : System.Web.UI.Page
{
    protected String GetHomeUrl()
    {
        string homePageUrl = string.Empty;
        ATSession vATSession = (ATSession)Session["User"];
        if (vATSession == null)
        {
            Response.Redirect("default.aspx");
        }
        if (vATSession != null)
        {
            if (vATSession.UserType == "ADMIN")
            {
                homePageUrl = "~/Admin_Welcome.aspx";
            }
            else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
            {
                homePageUrl = "~/doctor_welcome.aspx";
            }
            else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
            {
                homePageUrl = "~/Organization_Welcome.aspx";
            }
            else if (vATSession.UserType == "Paediatrician")
            {
                homePageUrl = "~/Paediatrician_Welcome.aspx";
            }
            else if (vATSession.UserType == "PATIENT" || vATSession.UserType == "Patient")
            {
                homePageUrl = "~/Patient_Welcome.aspx";
            }
            else if (vATSession.UserType == "PARENT" || vATSession.UserType == "Parent")
            {
                homePageUrl = "~/Parent_Welcome.aspx";
            }
            else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
            {
                homePageUrl = "~/Therapist_Welcome.aspx";
            }
        }
        return homePageUrl;
    }

    protected ATSession GetSession()
    {
        ATSession vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("default.aspx");
        return vATSession;
    }

    protected void DownloadFile(string filePath)
    {
        WebClient client = new System.Net.WebClient();
        Byte[] buffer = client.DownloadData(filePath);
        if (buffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
        }
    }

    protected String GetReqVal(String pValue)
    {
        if (Request.QueryString["ID"] != null)
            return Request.QueryString["ID"];
        else if (pValue == "0")
            return "0";
        else
            return pValue;
    }

    protected DataRow RetDR(DataTable vDataTable)
    {
        if (vDataTable.Rows.Count > 0)
            return vDataTable.Rows[0];
        else
            return null;
    }

    protected String GetReqDate(String pValue)
    {
        if (Request.QueryString["ID"] != null)
            return Request.QueryString["ID"];
        else
            return pValue;
    }

    protected void ShowMsg(String pType, String pMsg)
    {
        Label lblMsg = (Label)this.Form.FindControl("lblMsg");
        if (pType == "M")
            lblMsg.ForeColor = System.Drawing.Color.Green;
        else
            lblMsg.ForeColor = System.Drawing.Color.Red;
        lblMsg.Text = pMsg;
    }

    protected void ShowMsg(String pMsg)
    {
        Label lblMsg = (Label)this.Form.FindControl("lblMsg");
        lblMsg.ForeColor = System.Drawing.Color.Green;
        lblMsg.Text = pMsg;
    }

    protected void ShowDeleteMsg(bool flag)
    {
        Label lblMsg = (Label)this.Form.FindControl("lblMsg");
        lblMsg.ForeColor = System.Drawing.Color.Green;
        String vMsg = "Record Deleted Successfully ";
        lblMsg.Text = vMsg;
    }

    protected void ShowMsg(int pType)
    {
        Label lblMsg = (Label)this.Form.FindControl("lblMsg");
        lblMsg.ForeColor = System.Drawing.Color.Green;
        String vMsg = "Record has been ";
        vMsg += (pType == -1 ? "deleted" : (pType == 0 ? "inserted" : "updated")) + " successfully.";
        lblMsg.Text = vMsg;
    }

    protected void ShowMsg(Exception pException)
    {
        Label lblMsg = (Label)this.Form.FindControl("lblMsg");
        lblMsg.ForeColor = System.Drawing.Color.Red;
        lblMsg.Text = pException.Message;
    }

    protected void SetMasterPage(Page page)
    {
        ATSession atSession = GetSession();
        if (atSession.UserType == "ADMIN")
            Page.MasterPageFile = "~/Admin.master";
        else if (atSession.UserType == "DOCTOR" || atSession.UserType == "Doctor")
            Page.MasterPageFile = "~/DOCTOR.master";
        else if (atSession.UserType == "ORGANIZATION" || atSession.UserType == "Organization")
            Page.MasterPageFile = "~/Organization.master";
        else if (atSession.UserType == "Paediatrician")
            Page.MasterPageFile = "~/Paediatrician.master";
        else if (atSession.UserType == "PATIENT" || atSession.UserType == "Patient")
            Page.MasterPageFile = "Patient.master";
        else if (atSession.UserType == "PARENT" || atSession.UserType == "Parent")
            Page.MasterPageFile = "Parent.master";
        else if (atSession.UserType == "THERAPIST" || atSession.UserType == "Therapist")
            Page.MasterPageFile = "Therapist.master";
    }

    protected void ValidateUserAccess()
    {
        ATSession vATSession = (ATSession)Session["User"];
        if (vATSession == null)
        {
            Response.Redirect("default.aspx");
        }
        if (vATSession != null)
        {
            string fileName = Request.AppRelativeCurrentExecutionFilePath.ToLower().Replace("~/", "");
            fileName = fileName.Replace(".aspx", "");
            string[] adminPages = ConfigurationManager.AppSettings["AdminPages"].ToString().Replace(" ", "").Split(',');
            string[] doctorPages = ConfigurationManager.AppSettings["doctorPages"].ToString().Replace(" ", "").Split(',');
            string[] organizationPages = ConfigurationManager.AppSettings["OrganizationPages"].ToString().Replace(" ", "").Split(',');
            string[] paediatricianPages = ConfigurationManager.AppSettings["PaediatricianPages"].ToString().Replace(" ", "").Split(',');
            string[] patientPages = ConfigurationManager.AppSettings["PatientPages"].ToString().Replace(" ", "").Split(',');
            string[] parentPages = ConfigurationManager.AppSettings["ParentPages"].ToString().Replace(" ", "").Split(',');
            string[] therapistPages = ConfigurationManager.AppSettings["TherapistPages"].ToString().Replace(" ", "").Split(',');
            bool hasAccess = false;
            if (vATSession.UserType == "ADMIN")
            {
                hasAccess = adminPages.Contains(fileName);
            }
            else if (vATSession.UserType == "Doctor")
            {
                hasAccess = doctorPages.Contains(fileName);
            }
            
            else if (vATSession.UserType == "ORGANIZATION")
            {
                hasAccess = organizationPages.Contains(fileName);
            }
            else if (vATSession.UserType == "Paediatrician")
            {
                hasAccess = paediatricianPages.Contains(fileName);
            }
            else if (vATSession.UserType == "Patient")
            {
                hasAccess = patientPages.Contains(fileName);
            }
            else if (vATSession.UserType == "Parent")
            {
                hasAccess = parentPages.Contains(fileName);
            }
            else if (vATSession.UserType == "Therapist")
            {
                hasAccess = therapistPages.Contains(fileName);
            }
            if (!hasAccess)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}