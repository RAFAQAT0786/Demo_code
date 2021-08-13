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

public partial class Patient_Doctor_Evaluation : BasePage
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
        String vID = Request.QueryString["ID"];
        String vID2 = Request.QueryString["id1"];
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
                ValidateUserAccess();

                if (vATSession.UserType == "ADMIN")
                {
                    Label1.Text = "You may choose the Test Template given against each Disorder. You can fill the data based on your patients current condition. The choosen test and the data entered will be complied and shown in the PDF report of your Patient." +
                        "<br><b>Disclaimer</b>- Battery of tests corresponding to each disorder is given for your reference. Its totally optional whether to choose our suggested tests or not.NerdNerdy is not providing the assessor the actual test material for the given standardized tests  VSMS, CARS-2, & DST.  The test template is provided to so that the assessor can put and record the data of his/her patient, thus reducing the time and effort. In these templates NerdNerdy has not substituted the actual test material.</ br>";

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("EVA_ID", 0);
                    vHashtable.Add("TYPE", "GETALL");
                    DataTable vDT = DBManager.Get(vHashtable, "GET_EVALUATION_MASTER");
                    GridView1.DataSource = vDT;
                    GridView1.DataBind();
                }
                else if (vATSession.UserType == "DOCTOR" || vATSession.UserType == "Doctor")
                {
                    Label1.Text = "You may choose the Test Template given against each Disorder. You can fill the data based on your patients current condition. The choosen test and the data entered will be complied and shown in the PDF report of your Patient." +
                        "<br><b>Disclaimer</b>- Battery of tests corresponding to each disorder is given for your reference. Its totally optional whether to choose our suggested tests or not.NerdNerdy is not providing the assessor the actual test material for the given standardized tests  VSMS, CARS-2, & DST.  The test template is provided to so that the assessor can put and record the data of his/her patient, thus reducing the time and effort. In these templates NerdNerdy has not substituted the actual test material.</ br>";

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("EVA_ID", 0);
                    vHashtable.Add("TYPE", "GETALL");
                    DataTable vDT = DBManager.Get(vHashtable, "GET_EVALUATION_MASTER");
                    GridView1.DataSource = vDT;
                    GridView1.DataBind();

                }
                else if (vATSession.UserType == "ORGANIZATION" || vATSession.UserType == "Organization")
                {
                    Label1.Text = "You may choose the Test Template given against each Disorder. You can fill the data based on your patients current condition. The choosen test and the data entered will be complied and shown in the PDF report of your Patient." +
                        "<br><b>Disclaimer</b>- Battery of tests corresponding to each disorder is given for your reference. Its totally optional whether to choose our suggested tests or not.NerdNerdy is not providing the assessor the actual test material for the given standardized tests  VSMS, CARS-2, & DST.  The test template is provided to so that the assessor can put and record the data of his/her patient, thus reducing the time and effort. In these templates NerdNerdy has not substituted the actual test material.</ br>";

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("EVA_ID", 0);
                    vHashtable.Add("TYPE", "GETALL");
                    DataTable vDT = DBManager.Get(vHashtable, "GET_EVALUATION_MASTER");
                    GridView1.DataSource = vDT;
                    GridView1.DataBind();
                }
                else if (vATSession.UserType == "THERAPIST" || vATSession.UserType == "Therapist")
                {
                    Label1.Text = "You may choose the Test Template given against each Disorder. You can fill the data based on your patients current condition. The choosen test and the data entered will be complied and shown in the PDF report of your Patient." +
                        "<br><b>Disclaimer</b>- Battery of tests corresponding to each disorder is given for your reference. Its totally optional whether to choose our suggested tests or not.NerdNerdy is not providing the assessor the actual test material for the given standardized tests  VSMS, CARS-2, & DST.  The test template is provided to so that the assessor can put and record the data of his/her patient, thus reducing the time and effort. In these templates NerdNerdy has not substituted the actual test material.</ br>";

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("EVA_ID", 0);
                    vHashtable.Add("TYPE", "GETALL");
                    DataTable vDT = DBManager.Get(vHashtable, "GET_EVALUATION_MASTER");
                    GridView1.DataSource = vDT;
                    GridView1.DataBind();
                }
                else
                {
                    ShowMsg("Invalid Evaluation ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "View")
        {
            String vID2 = Request.QueryString["ID"];
            for (int j = 0; j < GridView1.Rows.Count; j++)
            {
                int id = Convert.ToInt32(e.CommandArgument);

                if (id.ToString() == "1")
                {
                    Response.Redirect("VSMS_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "2")
                {
                    Response.Redirect("CARS_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "3")
                {
                    Response.Redirect("DOWN_SYNDROME_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "4")
                {
                    Response.Redirect("CEREBAL_PALSY_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "5")
                {
                    Response.Redirect("ADHD_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "6")
                {
                    Response.Redirect("DEVELOPMENTAL_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "7")
                {
                    Response.Redirect("FRAGILE_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "8")
                {
                    Response.Redirect("GLOBAL_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "9")
                {
                    Response.Redirect("INTELLECTUAL_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "10")
                {
                    Response.Redirect("LEARNING_DIS_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "11")
                {
                    Response.Redirect("SENSORY_RATING.aspx?id1="+ vID2);
                }
                else if (id.ToString() == "12")
                {
                    Response.Redirect("SPEECH_LANG_RATING.aspx?id1=" + vID2);
                }
                else if (id.ToString() == "13")
                {
                    Response.Redirect("DEVELOPMENTAL_SCREENING_TEST.aspx?id1=" + vID2);
                }
            }
        }
    }
}