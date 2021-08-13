using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class Patient_IEP : BasePage
{
    private ATSession vATSession;
    private DataTable dt;
    private DataTable dt1;

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
            dt = new DataTable();
            DataColumn IEPDT_ID = new DataColumn();
            IEPDT_ID.DataType = Type.GetType("System.String");
            IEPDT_ID.ColumnName = "IEPDT_ID";
            dt.Columns.Add(IEPDT_ID);

            DataColumn coldisname = new DataColumn();
            coldisname.DataType = Type.GetType("System.String");
            coldisname.ColumnName = "IEPDT_NAME";
            dt.Columns.Add(coldisname);

            DataColumn coltypgroup = new DataColumn();
            coltypgroup.DataType = Type.GetType("System.String");
            coltypgroup.ColumnName = "IEPDT_PRICE";
            dt.Columns.Add(coltypgroup);

            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();

            try
            {
                if (vID != null)
                {
                    //Label1.Text = "The IEP template assist the therapists to create daily, weekly, monthly or yearly Individualized Educational plan (IEP) of your patient. You may select category first and then its corresponding subcategy for the skills that you want to include in your IEP of your patient." +
                    //    "<br><b>Suggested Activity:</b> Comprehensive list of suggetsed activities is provided to you (therapist) based on the skills that you have included in your patient's  IEP . You can use these activities as it is or can modify them per you need. Kindly note that these are suggested activities, its therapists decision whether to use them or not.</ br>" +
                    //    "<br><b>Intervention Resources:</b> Intervention Resources/tools are an integral part of any therapy. In our therapy sessions, we need cutomized intervention resources for our patients, which can be hands on and research backed. Its our constant endeviour of NerdNerdy, to create, develop or bring in unique research backed intervention tools for our children.</ br>" +
                    //    "<br>Based on the chosen IEP, the resources can be selected under the resource tab. The link would come in the IEP itself, once you click the link, it will take you to the website. You can buy the resources form website, if find them useful for your patients.</ br>" +
                    //    "<br><b>Progress Review-</b> You can review the progress of your patient through progress review tab.  The progress table and graph chart of progress can help you get the details of the current level of your patient's skill development. The progress can be viewed date wise, weekly or monthly.</ br>" +
                    //    "<br><b>Progress-</b> You can fill the progress of your patient by selecting options- Accompolished (if the patient has acquired the skill that you introduced in your IEP), Emerging (If the skill is still not fully acquired) Not accomolishe (if the skill is not acquired and needs more practice, thus can be reintroduced in your IEP). Once you select any of the three given options, please update the progress by clicking the update button in order to save the progress of your patient.</br>";

                    Hashtable vHashtable3 = new Hashtable();
                    vHashtable3.Add("PTP_ID", vID);
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable3, "GET_PATIENT_SCREEN"));
                    if (vDR1 != null)
                    {
                        TXTID.Value = vDR1["PTP_ID"].ToString();
                        PATIENT_TXT.Text = vDR1["PTP_NAME"].ToString();
                        HiddenField1.Value = vDR1["AGRP_GROUP"].ToString();
                        PATIENT_TXT.Enabled = false;
                    }
                    Hashtable vHashtable13 = new Hashtable();
                    vHashtable13.Add("PTP_ID", vID);
                    DataRow vDR13 = RetDR(DBManager.Get(vHashtable13, "GET_DISORDER"));
                    if (vDR13 != null)
                    {
                        IEP_DIS_TXT.Text = vDR13["DIS_NAME"].ToString();
                        IEP_DIS_TXT.Enabled = false;
                        // }

                        //if (IEP_DIS_TXT.Text != null)
                        if (IEP_DIS_TXT.Text != "")
                        {
                            Hashtable vHashtable5 = new Hashtable();
                            vHashtable5.Add("DIS_NAME", IEP_DIS_TXT.Text);
                            DataTable dt2 = DBManager.Get(vHashtable5, "GET_DISORDER_ID");
                            GridView1.DataSource = dt2;
                            GridView1.DataBind();
                            PTP_IEP.Visible = true;
                        }
                    }

                    Hashtable vHashtable14 = new Hashtable();
                    vHashtable14.Add("PTP_ID", vID);
                    DataRow vDR14 = RetDR(DBManager.Get(vHashtable14, "GET_CURRICULUM_DISORDER"));
                    if (vDR14 != null)
                    {
                        IEP_DIS_TXT.Text = vDR14["DIS_NAME"].ToString();
                        IEP_DIS_TXT.Enabled = false;

                        if (IEP_DIS_TXT.Text != "")
                        {
                            Hashtable vHashtable6 = new Hashtable();
                            vHashtable6.Add("DIS_NAME", IEP_DIS_TXT.Text);
                            DataTable dt6 = DBManager.Get(vHashtable6, "GET_DISORDER_ID");
                            GridView1.DataSource = dt6;
                            GridView1.DataBind();
                            PTP_IEP.Visible = true;
                        }
                    }
                }
            }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (IEP_DIS_TXT.Text != null)
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("DIS_NAME", IEP_DIS_TXT.Text);
            DataTable dt = DBManager.Get(vHashtable, "GET_DISORDER_ID");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            PTP_IEP.Visible = true;
        }
        else
        {
            ShowMsg("NOT FOUND ANY DIS ORDER NAME");
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

    protected void BindGrid()
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPDT_ID", TXTID.Value);
        DataTable dt = DBManager.Get(vHashtable, "GET_IEPDT_ID");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "PATIENT")
        {
            Label lb = (Label)GridView1.Rows[index].FindControl("PATIENT");
            Label IEPDT_ID = (Label)GridView1.Rows[index].FindControl("IEPDT_ID");
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", TXTID.Value);
            DataTable dt = DBManager.Get(vHashtable, "GET_PATIENT_ID");
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("IEP_PATIENT_TEMPLATE.aspx?id=" + IEPDT_ID.Text + "&id1=" + TXTID.Value);
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }

    public void Clear()
    {
    }
}