using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class EVALUATION_RECOMMENDED_TEST : BasePage
{
    private ATSession vATSession;
    private DataTable dt;
    private DataTable dt1;
    private DataTable dt2;

    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["id"];
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();
                Label1.Text = "You may choose the Test template given against each Disorder. You can fill the data based on your patients current condition. The choosen test and the data entered will be complied and shown in the PDF report of your Patient." +
                        "<br><b>Suggested Tests</b>- Battery of tests corresponding to each disorder is given for your reference. Its totally optional whether to choose our suggested tests or not.</ br>" +
                        "<br><b>Disclaimer:</b> NerdNerdy is not providing the assessor the actual test material for the given standardized tests  VSMS, CARS-2, & DST.  The test template is provided to so that the Assessor can put and record the data of his/her pateint, thus reducing the time and effort. In these templates NerdNerdy has not substituted the actual test material.</ br>";

                ATCommon.FillDrpDown(DDLDIS, DBManager.Get(new Hashtable(), "CMB_DIS_MASTER"), "Select Disorder Name", "DIS_NAME", "DIS_ID", "0");
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void EVA_ID1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        EVA_ID1.PageIndex = e.NewPageIndex;
    }

    protected void EVA_ID1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void DDLDIS_Click(object sender, EventArgs e)
    {
        String vID = Request.QueryString["id1"];

        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("EVADIS_DISID", DDLDIS.SelectedValue);
        dt1 = DBManager.Get(vHashtable, "GET_EVALUATION_DISORDER_ID");
        EVA_ID1.DataSource = dt1;
        EVA_ID1.DataBind();
    }

    public void Clear()
    {
    }
}