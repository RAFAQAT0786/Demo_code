using System;
using System.Collections;
using System.Data;

public partial class Patient_Doctor_Assessment_Report : BasePage
{
    private ATSession vATSession;
    private DataRow vDR;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
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

                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("@DIS_ID", vID);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_ID"));
                    if (vDR != null)
                    {
                    }
                    else
                        ShowMsg("Invalid Patient ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void Updatebtn_Click(object sender, EventArgs e)
    {
        
    }
}