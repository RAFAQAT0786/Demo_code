using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

public partial class Customer_Create : BasePage
{
    private ATSession vATSession;
    private byte[] Image;
    private DataRow vDR2;
    private Hashtable vHashtable2 = new Hashtable();
    private DataTable dt;
    private Hashtable vHashtable1 = new Hashtable();

    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        String vID = Request.QueryString["ID"];

        if (vATSession == null)
            Response.Redirect("Default.aspx");

        if (!IsPostBack)
        {
            dt = new DataTable();
            DataColumn coltypid = new DataColumn();
            coltypid.DataType = Type.GetType("System.String");
            coltypid.ColumnName = "CUSTP_TYPE_ID";
            dt.Columns.Add(coltypid);

            DataColumn coltypname = new DataColumn();
            coltypname.DataType = Type.GetType("System.String");
            coltypname.ColumnName = "CUST_TYP_NAME";
            dt.Columns.Add(coltypname);

            DataColumn colvalue = new DataColumn();
            colvalue.DataType = Type.GetType("System.String");
            colvalue.ColumnName = "CUSTP_VALUE";
            dt.Columns.Add(colvalue);

            DataColumn coldesc = new DataColumn();
            coldesc.DataType = Type.GetType("System.String");
            coldesc.ColumnName = "CUSTP_DESC";
            dt.Columns.Add(coldesc);
            ViewState["datagrid"] = dt;
            BindGrid();
            Clear();
            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(CUST_COUNTRY_DDL, DBManager.Get(new Hashtable(), "CMB_COUNTRY_MASTER"), "Select Country Name", "COUNTRY_NAME", "COUNTRY_ID", "0");
                ATCommon.FillCDWR(CUST_TYPE_DDL, DBManager.Get(new Hashtable(), "CMB_CUST_TYPE"), "", "CUST_TYP_NAME", "CUST_TYP_ID", "0");
                ATCommon.FillDrpDown(ORGANIZATION_DDL, DBManager.Get(new Hashtable(), "CMB_ORGANIZATION"), "Select Organization Name", "USR_ORGANIZATION_NAME", "USR_LOGIN", "0");

                //Hashtable vHashta = new Hashtable();
                //vHashta.Add("STATE_ID", ddl_state.SelectedValue);
                //ATCommon.FillDrpDown(ddl_state, DBManager.Get(vHashta, "CMB_State"), "Select State Name", "STATE_NAME", "STATE_ID", "");

                if (vATSession.UserType == "ADMIN")
                {
                    ATCommon.FillCDWR(CUST_TYPE_DDL, DBManager.Get(new Hashtable(), "CMB_CUST_TYPE"), "Select Customer type", "CUST_TYP_NAME", "CUST_TYP_ID", "0");
                    ATCommon.FillDrpDown(CUST_CATRGORY_DDL, DBManager.Get(new Hashtable(), "[GET_CATEGORY]"), "Select Category ", "CAT_NAME", "CAT_ID", "0");
                }
                else
                {
                    ATCommon.FillDrpDown(CUST_TYPE_DDL, DBManager.Get(new Hashtable(), "CMB_CUST_TYPE_VSO"), "", "CUST_TYP_NAME", "CUST_TYP_ID", "0");
                    ATCommon.FillDrpDown(CUST_CATRGORY_DDL, DBManager.Get(new Hashtable(), "[GET_CATEGORY_BY_VSR]"), "Select Category ", "CAT_NAME", "CAT_ID", "0");
                }
                if (vID != null)
                {
                    Hashtable vHashtable4 = new Hashtable();
                    vHashtable4.Add("CUSTPID", vID);
                    dt = DBManager.Get(vHashtable4, "GET_CUSTPROFILE");
                    ViewState["datagrid"] = dt;
                    BindGrid();
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("ID", vID);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_CUSTOMER_ID"));
                    if (vDR != null)
                    {
                        if (vATSession.UserType == "ADMIN")
                        {
                            CUST_NAME_TXT.Text = vDR["CUST_NAME"].ToString();
                            CUST_PREFIX_NAME.Text = vDR["CUST_PREFIX"].ToString();
                            CUST_COUNTRY_DDL.SelectedValue = vDR["CUST_COUNTRY_ID"].ToString();
                            string Prospective = vDR["CUST_PROSPECTIVE"].ToString().Trim();
                            if (vDR["CUST_PROSPECTIVE"].ToString().Trim() == "Yes")
                            {
                                ddlProspective.SelectedIndex = 2;
                            }
                            else if (vDR["CUST_PROSPECTIVE"].ToString().Trim() == "No")
                            {
                                ddlProspective.SelectedIndex = 1;
                            }
                            TXTID.Value = vDR["CUST_ID"].ToString();
                            CUST_ADD_TXT.Text = vDR["CUST_ROAD_STREET_HOUSE"].ToString();
                            CUST_COMP_NAME_TXT.Text = vDR["CUST_COMP_NAME"].ToString();
                            CUST_PIN_TXT.Text = vDR["CUST_PIN"].ToString();
                            CUST_PH_TXT.Text = vDR["CUST_PHONE"].ToString();
                            TXT_DESIGNATION.Text = vDR["CUST_DESIGNATION"].ToString();
                            CUST_EMAIL_TXT.Text = vDR["CUST_EMAIL"].ToString();
                            CUST_MOBILE_TXT.Text = vDR["CUST_MOBILE"].ToString();
                            txt_vil.Text = vDR["CUST_VILLAGE_TWN_CITY"].ToString();
                            CUST_CONSL_TXT.Text = vDR["CUST_CONSULT_NAME"].ToString();
                            CUST_CONSL_MOB_TXT.Text = vDR["CUST_CONSULT_MOB"].ToString();
                            txt_post.Text = vDR["CUST_POST_OFFICE"].ToString();
                            ddl_state.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_STA_ID"].ToString()));
                            ddlProspective.SelectedItem.Text = vDR["CUST_PROSPECTIVE"].ToString();
                            CUST_CATRGORY_DDL.SelectedIndex = CUST_CATRGORY_DDL.Items.IndexOf(CUST_CATRGORY_DDL.Items.FindByValue(vDR["CUST_CATRGORY_ID"].ToString()));
                            CUST_STATION_DDL.SelectedItem.Text = vDR["CITY_NAME"].ToString();//09112010 changed
                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["CUST_COUNTRY_ID"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);
                            ORGANIZATION_DDL.SelectedItem.Text = vDR["CUST_ORGANIZATION_NAME"].ToString();
                            HiddenField1.Value = vDR["CUST_ARHQ_ID"].ToString();
                            TXT_START.Text = vDR["CUST_FROM_DATE"].ToString();
                            TXT_END.Text = vDR["CUST_TO_DATE"].ToString();
                        }
                        else
                        {
                            string Prospective = vDR["CUST_PROSPECTIVE"].ToString().Trim();
                            if (vDR["CUST_PROSPECTIVE"].ToString().Trim() == "Yes")
                            {
                                ddlProspective.SelectedIndex = 2;
                            }
                            else if (vDR["CUST_PROSPECTIVE"].ToString().Trim() == "No")
                            {
                                ddlProspective.SelectedIndex = 1;
                            }
                            TXTID.Value = vDR["CUST_ID"].ToString();

                            CUST_NAME_TXT.Text = vDR["CUST_NAME"].ToString();
                            CUST_PREFIX_NAME.Text = vDR["CUST_PREFIX"].ToString();

                            if (CUST_NAME_TXT.Text == "STORE" || CUST_NAME_TXT.Text == "MEDSTORE")
                            {
                                CUST_NAME_TXT.Enabled = true;
                            }
                            else
                            {
                                CUST_NAME_TXT.Enabled = true;
                            }
                            CUST_COMP_NAME_TXT.Enabled = false;
                            CUST_ADD_TXT.Text = vDR["CUST_ROAD_STREET_HOUSE"].ToString();
                            CUST_COMP_NAME_TXT.Text = vDR["CUST_COMP_NAME"].ToString();
                            CUST_COMP_NAME_TXT.Enabled = false;
                            CUST_PIN_TXT.Text = vDR["CUST_PIN"].ToString();
                            CUST_PH_TXT.Text = vDR["CUST_PHONE"].ToString();
                            CUST_EMAIL_TXT.Text = vDR["CUST_EMAIL"].ToString();
                            TXT_DESIGNATION.Text = vDR["CUST_DESIGNATION"].ToString();
                            CUST_MOBILE_TXT.Text = vDR["CUST_MOBILE"].ToString();
                            txt_vil.Text = vDR["CUST_VILLAGE_TWN_CITY"].ToString();
                            CUST_CONSL_TXT.Text = vDR["CUST_CONSULT_NAME"].ToString();
                            CUST_CONSL_MOB_TXT.Text = vDR["CUST_CONSULT_MOB"].ToString();
                            txt_post.Text = vDR["CUST_POST_OFFICE"].ToString();
                            ddlProspective.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_PROSPECTIVE"].ToString()));
                            ddl_state.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_STA_ID"].ToString()));
                            CUST_CATRGORY_DDL.SelectedIndex = CUST_CATRGORY_DDL.Items.IndexOf(CUST_CATRGORY_DDL.Items.FindByValue(vDR["CUST_CATRGORY_ID"].ToString()));
                            CUST_CATRGORY_DDL.Enabled = false;
                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["CUST_COUNTRY_ID"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);
                            ddl_state.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_STA_ID"].ToString()));
                            ddlProspective.SelectedItem.Text = vDR["CUST_PROSPECTIVE"].ToString();
                            ORGANIZATION_DDL.SelectedItem.Text = vDR["CUST_ORGANIZATION_NAME"].ToString();
                            CUST_STATION_DDL.SelectedItem.Text = vDR["CITY_NAME"].ToString();
                            HiddenField1.Value = vDR["CUST_ARHQ_ID"].ToString();
                            TXT_START.Text = vDR["CUST_FROM_DATE"].ToString();
                            TXT_END.Text = vDR["CUST_TO_DATE"].ToString();
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
        string PTP_MOBILE = "";
        try
        {
            if (TXTID.Value == "0")
            {
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("CUST_ID", TXTID.Value);
                vHashtable.Add("CUST_VSOHQ_ID", "0");
                vHashtable.Add("CUST_STA_ID", ddl_state.SelectedValue);
                vHashtable.Add("CUST_NAME", CUST_NAME_TXT.Text);
                vHashtable.Add("CUST_PROSPECTIVE", ddlProspective.SelectedItem.Text);
                vHashtable.Add("CUST_PREFIX", CUST_PREFIX_NAME.SelectedItem.Text);
                vHashtable.Add("CUST_ADDRESS", CUST_ADD_TXT.Text);
                vHashtable.Add("CUST_COMP_NAME", CUST_COMP_NAME_TXT.Text);
                vHashtable.Add("CUST_DISTRICT", "0");
                vHashtable.Add("CUST_VILLAGE_TWN_CITY", txt_vil.Text);
                vHashtable.Add("CUST_POST_OFFICE", txt_post.Text);
                vHashtable.Add("CUST_STATE", "0");
                vHashtable.Add("CUST_CATRGORY_ID", CUST_CATRGORY_DDL.SelectedValue);
                vHashtable.Add("CUST_CONSULT_NAME", CUST_CONSL_TXT.Text);
                vHashtable.Add("CUST_CONSULT_MOB", CUST_CONSL_MOB_TXT.Text);
                vHashtable.Add("CUST_PIN", CUST_PIN_TXT.Text);
                vHashtable.Add("CUST_PHONE", CUST_PH_TXT.Text);
                vHashtable.Add("CUST_EMAIL", CUST_EMAIL_TXT.Text);
                vHashtable.Add("CUST_MOBILE", CUST_MOBILE_TXT.Text);
                vHashtable.Add("CUST_DEALER", vATSession.CUST_ID);
                vHashtable.Add("CUST_DESIGNATION", TXT_DESIGNATION.Text);
                vHashtable.Add("CUST_COUNTRY_ID", CUST_COUNTRY_DDL.SelectedValue);
                vHashtable.Add("CUST_ARHQ_ID", CUST_STATION_DDL.SelectedValue);
                vHashtable.Add("CUST_ORGANIZATION_NAME", ORGANIZATION_DDL.SelectedItem.Text);
                vHashtable.Add("CUST_FROM_DATE", TXT_START.Text);
                vHashtable.Add("CUST_TO_DATE", TXT_END.Text);
                if (DBManager.ExecInsUpsReturn(vHashtable, "INS_CUSTOMER_NEW", (ATSession)Session["User"]))
                {
                    if (TXTID.Value.Equals("0"))
                    {
                        try
                        {
                            string pwd = Create_Password();
                            Hashtable vHT = new Hashtable();
                            vHT.Add("ID", TXTID.Value);

                            if (TXTID.Value == "0")
                                vHT.Add("USR_LOGIN", CUST_MOBILE_TXT.Text);
                            else
                                vHT.Add("USR_LOGIN", CUST_MOBILE_TXT.Text.Trim());
                            vHT.Add("USR_COMPANY", CUST_COMP_NAME_TXT.Text);
                            vHT.Add("USR_ZONE_ID", CUST_COUNTRY_DDL.SelectedValue);
                            vHT.Add("USR_REGHQ_ID", ddl_state.SelectedValue);
                            vHT.Add("USR_ARHQ_ID", CUST_STATION_DDL.SelectedValue);
                            vHT.Add("USR_VSOHQ_ID", "0");
                            vHT.Add("USR_CONT_NAME", CUST_NAME_TXT.Text);
                            vHT.Add("USR_ADDRESS", "");
                            vHT.Add("USR_TYPE", "Doctor");
                            vHT.Add("USR_PIN", "");
                            vHT.Add("USR_PHONE", CUST_PH_TXT.Text);
                            vHT.Add("USR_MOBILE", CUST_MOBILE_TXT.Text);
                            vHT.Add("USR_FAX", "");
                            vHT.Add("USR_EMAIL", CUST_EMAIL_TXT.Text);
                            vHT.Add("USR_PASSWORD", pwd);
                            vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue);
                            vHT.Add("USR_ORGANIZATION_NAME", ORGANIZATION_DDL.Text);
                            DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);
                            ATApp vATApp = (ATApp)Application["Config"];
                            String vBody = "Dear " + CUST_NAME_TXT.Text + "\n\nLogin Detaials for Nerdnerdy Intranet Application.\n\n";
                            vBody += "URL is: nerdnerdy.in\n";
                            if (TXTID.Value == "0")
                                vBody += "Login: " + PTP_MOBILE + "\nPassword:" + pwd + "\n\n";
                            else
                                vBody += "Login: " + CUST_MOBILE_TXT.Text + "\nPassword:" + pwd + "\n\n";
                            vBody += "For any query, please revert us back.\n\nThanks and Regards\n";

                            ATCommon.SendMail(CUST_MOBILE_TXT.Text, "Login Detaials for Nerdnerdy Intranet Application.", vBody, vATApp);
                            ShowMsg(int.Parse(TXTID.Value));
                            Clear();
                        }
                        catch (Exception xe) { ShowMsg(xe); }
                    }
                    else
                    {
                        Hashtable vHT1 = new Hashtable();
                        vHT1.Add("USR_LOGIN", CUST_MOBILE_TXT.Text.Trim());
                        vHT1.Add("USR_ZONE_ID", CUST_COUNTRY_DDL.SelectedValue);
                        vHT1.Add("USR_REGHQ_ID", ddl_state.SelectedValue);
                        vHT1.Add("USR_ARHQ_ID", CUST_STATION_DDL.SelectedValue);
                        vHT1.Add("USR_VSOHQ_ID", "0");
                        vHT1.Add("USR_CONT_NAME", CUST_NAME_TXT.Text);
                        vHT1.Add("USR_TYPE", "Doctor");
                        vHT1.Add("USR_EMAIL", CUST_EMAIL_TXT.Text);
                        DBManager.ExecInsUps(vHT1, "UPDATE_USER", (ATSession)Session["User"]);
                    }
                }
                {
                    DBManager.DeleteadminRec(TXTID.Value, "DEL_CUST_PROFILE");
                    foreach (GridViewRow grw in CUST_PROFILE.Rows)
                    {
                        Hashtable vHashtable1 = new Hashtable();
                        Label TYPE_ID = (Label)grw.FindControl("CUSTP_TYPE_ID");
                        Label VALUE = (Label)grw.FindControl("CUSTP_VALUE");
                        Label DESC = (Label)grw.FindControl("CUSTP_DESC");
                        vHashtable1.Add("CUST_ID", TXTID.Value);
                        vHashtable1.Add("CUSTP_TYPE_ID", TYPE_ID.Text);
                        vHashtable1.Add("CUSTP_VALUE", VALUE.Text);
                        vHashtable1.Add("CUSTP_DESC", DESC.Text);
                        DBManager.ExecInsUps(vHashtable1, "INS_CUST_PROFILE", (ATSession)Session["User"]);
                    }
                }

                ShowMsg(int.Parse(TXTID.Value));
                Clear();
                Response.Redirect("customer.aspx");
            }
            else
            {
                Hashtable vHashtable = new Hashtable();
                vHashtable.Add("CUST_ID", TXTID.Value);
                vHashtable.Add("CUST_VSOHQ_ID", "0");
                vHashtable.Add("CUST_STA_ID", ddl_state.SelectedValue);
                vHashtable.Add("CUST_NAME", CUST_NAME_TXT.Text);
                vHashtable.Add("CUST_PROSPECTIVE", ddlProspective.SelectedItem.Text);
                vHashtable.Add("CUST_PREFIX", CUST_PREFIX_NAME.SelectedItem.Text);
                vHashtable.Add("CUST_ADDRESS", CUST_ADD_TXT.Text);
                vHashtable.Add("CUST_COMP_NAME", CUST_COMP_NAME_TXT.Text);
                vHashtable.Add("CUST_DISTRICT", "0");
                vHashtable.Add("CUST_VILLAGE_TWN_CITY", txt_vil.Text);
                vHashtable.Add("CUST_POST_OFFICE", txt_post.Text);
                vHashtable.Add("CUST_STATE", "0");
                vHashtable.Add("CUST_CATRGORY_ID", CUST_CATRGORY_DDL.SelectedValue);
                vHashtable.Add("CUST_CONSULT_NAME", CUST_CONSL_TXT.Text);
                vHashtable.Add("CUST_CONSULT_MOB", CUST_CONSL_MOB_TXT.Text);
                vHashtable.Add("CUST_PIN", CUST_PIN_TXT.Text);
                vHashtable.Add("CUST_PHONE", CUST_PH_TXT.Text);
                vHashtable.Add("CUST_EMAIL", CUST_EMAIL_TXT.Text);
                vHashtable.Add("CUST_MOBILE", CUST_MOBILE_TXT.Text);
                vHashtable.Add("CUST_DEALER", vATSession.CUST_ID);
                vHashtable.Add("CUST_DESIGNATION", TXT_DESIGNATION.Text);
                vHashtable.Add("CUST_COUNTRY_ID", CUST_COUNTRY_DDL.SelectedValue);
                vHashtable.Add("CUST_ARHQ_ID", HiddenField1.Value);
                vHashtable.Add("CUST_ORGANIZATION_NAME", ORGANIZATION_DDL.SelectedItem.Text);
                vHashtable.Add("CUST_FROM_DATE", TXT_START.Text);
                vHashtable.Add("CUST_TO_DATE", TXT_END.Text);
                if (DBManager.ExecInsUpsReturn(vHashtable, "INS_CUSTOMER_NEW", (ATSession)Session["User"]))
                {
                    if (TXTID.Value.Equals("0"))
                    {
                        try
                        {
                            string pwd = Create_Password();
                            Hashtable vHT = new Hashtable();
                            vHT.Add("ID", TXTID.Value);

                            if (TXTID.Value == "0")
                                vHT.Add("USR_LOGIN", CUST_MOBILE_TXT.Text);
                            else
                                vHT.Add("USR_LOGIN", CUST_MOBILE_TXT.Text.Trim());
                            vHT.Add("USR_COMPANY", CUST_COMP_NAME_TXT.Text);
                            vHT.Add("USR_ZONE_ID", CUST_COUNTRY_DDL.SelectedValue);
                            vHT.Add("USR_REGHQ_ID", ddl_state.SelectedValue);
                            vHT.Add("USR_ARHQ_ID", CUST_STATION_DDL.SelectedValue);
                            vHT.Add("USR_VSOHQ_ID", "0");
                            vHT.Add("USR_CONT_NAME", CUST_NAME_TXT.Text);
                            vHT.Add("USR_ADDRESS", "");
                            vHT.Add("USR_TYPE", "Doctor");
                            vHT.Add("USR_PIN", "");
                            vHT.Add("USR_PHONE", CUST_PH_TXT.Text);
                            vHT.Add("USR_MOBILE", CUST_MOBILE_TXT.Text);
                            vHT.Add("USR_FAX", "");
                            vHT.Add("USR_EMAIL", CUST_EMAIL_TXT.Text);
                            vHT.Add("USR_PASSWORD", pwd);
                            vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue);
                            vHT.Add("USR_ORGANIZATION_NAME", ORGANIZATION_DDL.Text);
                            DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);
                            ATApp vATApp = (ATApp)Application["Config"];

                            String vBody = "Dear " + CUST_NAME_TXT.Text + "\n\nLogin Detaials for Nerdnerdy Web Application.\n\n";
                            vBody += "URL is: nerdnerdy.in\n";
                            if (TXTID.Value == "0")
                                vBody += "Login: " + PTP_MOBILE + "\nPassword:" + pwd + "\n\n";
                            else
                                vBody += "Login: " + CUST_MOBILE_TXT.Text + "\nPassword:" + pwd + "\n\n";
                            vBody += "For any query, please revert us back.\n\nThanks and Regards\n";

                            ATCommon.SendMail(CUST_MOBILE_TXT.Text, "Login Detaials for Nerdnerdy Web Application.", vBody, vATApp);
                            ShowMsg(int.Parse(TXTID.Value));
                            Clear();
                        }
                        catch (Exception xe) { ShowMsg(xe); }
                    }
                    else
                    {
                        Hashtable vHT1 = new Hashtable();
                        vHT1.Add("USR_LOGIN", CUST_MOBILE_TXT.Text.Trim());
                        vHT1.Add("USR_ZONE_ID", CUST_COUNTRY_DDL.SelectedValue);
                        vHT1.Add("USR_REGHQ_ID", ddl_state.SelectedValue);
                        vHT1.Add("USR_ARHQ_ID", CUST_STATION_DDL.SelectedValue);
                        vHT1.Add("USR_VSOHQ_ID", "0");
                        vHT1.Add("USR_CONT_NAME", CUST_NAME_TXT.Text);
                        vHT1.Add("USR_TYPE", "Doctor");
                        vHT1.Add("USR_EMAIL", CUST_EMAIL_TXT.Text);
                        DBManager.ExecInsUps(vHT1, "UPDATE_USER", (ATSession)Session["User"]);
                    }
                }
                {
                    DBManager.DeleteadminRec(TXTID.Value, "DEL_CUST_PROFILE");
                    foreach (GridViewRow grw in CUST_PROFILE.Rows)
                    {
                        Hashtable vHashtable1 = new Hashtable();
                        Label TYPE_ID = (Label)grw.FindControl("CUSTP_TYPE_ID");
                        Label VALUE = (Label)grw.FindControl("CUSTP_VALUE");
                        Label DESC = (Label)grw.FindControl("CUSTP_DESC");
                        vHashtable1.Add("CUST_ID", TXTID.Value);
                        vHashtable1.Add("CUSTP_TYPE_ID", TYPE_ID.Text);
                        vHashtable1.Add("CUSTP_VALUE", VALUE.Text);
                        vHashtable1.Add("CUSTP_DESC", DESC.Text);
                        DBManager.ExecInsUps(vHashtable1, "INS_CUST_PROFILE", (ATSession)Session["User"]);
                    }
                }

                ShowMsg(int.Parse(TXTID.Value));
                Clear();
                Response.Redirect("customer.aspx");
            }
        }
        catch (Exception xe)
        {
            ShowMsg(xe);
        }
        // }
    }
    }
    protected string Create_Password()
    {
        string pwd = "";
        Random Rand = new Random();
        for (int i = 0; i < 4; i++)
        {
            if (i < 3)
                pwd += Convert.ToChar(Rand.Next(65, 90));
            else
                pwd += Rand.Next(0, 100).ToString();
        }
        return pwd;
    }

    public void Clear()
    {
        CUST_TYPE_DDL.SelectedIndex = 0;
        TXT_DISC.Text = "";
        TXT_VALUE.Text = "";
    }

    protected void BindGrid()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        CUST_PROFILE.DataSource = dt;
        CUST_PROFILE.DataBind();
    }

    protected void addrow()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        DataRow dr;
        dr = dt.NewRow();
        dr["CUSTP_TYPE_ID"] = CUST_TYPE_DDL.SelectedValue.ToString();
        dr["CUST_TYP_NAME"] = CUST_TYPE_DDL.SelectedItem;
        dr["CUSTP_VALUE"] = TXT_VALUE.Text;
        dr["CUSTP_DESC"] = TXT_DISC.Text;
        dt.Rows.Add(dr);
        ViewState["datagrid"] = dt;
        BindGrid();
    }

    protected void Addbtn_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        if (dt.Rows.Count <= 25)
        {
            if (dt.Rows.Count > 0)
            {
                bool flag = false;
                foreach (DataRow drow in dt.Rows)
                {
                    if (drow["CUST_TYP_NAME"].Equals(CUST_TYPE_DDL.SelectedItem.Text))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                    addrow();
                else
                {
                    ShowMsg("This Profile Is Already Exist");
                }
            }
            else
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["CUSTP_TYPE_ID"] = CUST_TYPE_DDL.SelectedValue.ToString();
                dr["CUST_TYP_NAME"] = CUST_TYPE_DDL.SelectedItem;
                dr["CUSTP_VALUE"] = TXT_VALUE.Text;
                dr["CUSTP_DESC"] = TXT_DISC.Text;
                dt.Rows.Add(dr);
                ViewState["datagrid"] = dt;
                BindGrid();
            }
        }
        else
            ShowMsg("Maximum 25 Profile Can Be Added.");
    }

    protected void CUST_PROFILE_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "delete")
        {
            DataTable dt = (DataTable)ViewState["datagrid"];
            Label CUST_TYP_NAME = (Label)CUST_PROFILE.Rows[index].FindControl("CUST_TYP_NAME");
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["CUST_TYP_NAME"].Equals(CUST_TYP_NAME.Text))
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    break;
                }
            }
        }
    }

    protected void CUST_PROFILE_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void existence_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            Hashtable vHT = new Hashtable();
            vHT.Add("Name", CUST_PREFIX_NAME.Text + " " + CUST_NAME_TXT.Text);
            vHT.Add("Mobile", CUST_MOBILE_TXT.Text);
            args.IsValid = DBManager.Exist(vHT, "EXISTCUSTOMER");
        }
    }
    protected void existuser_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTCUSTOMEREMAIL");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["CUST_EMAIL"].ToString().Equals(args.Value) || DR["USR_EMAIL"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }

        }
    }
    protected void CUST_COUNTRY_DDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable vHashta = new Hashtable();
        vHashta.Add("COUNTRY_ID", CUST_COUNTRY_DDL.SelectedValue);
        ATCommon.FillDrpDown(ddl_state, DBManager.Get(vHashta, "CMB_State"), "Select State Name", "STATE_NAME", "STATE_ID", "");
        UP_COUNTRY.Update();
        up_state.Update();
        
    }

    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("STATE_ID", ddl_state.SelectedValue.ToString());
        ATCommon.FillDrpDown(CUST_STATION_DDL, DBManager.Get(vHashtable, "CMB_City"), "Select City Name", "CITY_NAME", "CITY_ID", "");
        CUST_STATION_DDL.Enabled = true;
        UP_STATION.Update();
        up_state.Update();
    }

    protected void CUST_TYPE_DDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        
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