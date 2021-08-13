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
using System.IO;

public partial class User : BasePage
{
    ATSession vATSession;
    byte[] Image;
    DataRow vDR2;
    Hashtable vHashtable2 = new Hashtable();
    DataTable dt;
    Hashtable vHashtable1 = new Hashtable();
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
            //BindGrid();
            Clear();
            try
            {
                ValidateUserAccess();
                ATCommon.FillDrpDown(CUST_COUNTRY_DDL, DBManager.Get(new Hashtable(), "CMB_COUNTRY_MASTER"), "Select Country Name", "COUNTRY_NAME", "COUNTRY_ID", "0");

                //Hashtable vHashta = new Hashtable();
                //vHashta.Add("STATE_ID", ddl_state.SelectedValue);
                //ATCommon.FillDrpDown(ddl_state, DBManager.Get(vHashta, "CMB_State"), "Select State Name", "STATE_NAME", "STATE_ID", "");

                if (vID != null)
                {
                    Hashtable vHashtable4 = new Hashtable();
                    vHashtable4.Add("CUSTPID", vID);
                    dt = DBManager.Get(vHashtable4, "GET_CUSTPROFILE");
                    ViewState["datagrid"] = dt;
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("ID", vID);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_CUSTOMER_ID"));
                    if (vDR != null)
                    {
                        if (vATSession.UserType == "ORGANIZATION")
                        {
                            CUST_NAME_TXT.Text = vDR["CUST_NAME"].ToString();
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
                            TXT_DESIGNATION.Text = vDR["CUST_DESIGNATION"].ToString();
                            CUST_EMAIL_TXT.Text = vDR["CUST_EMAIL"].ToString();
                            CUST_MOBILE_TXT.Text = vDR["CUST_MOBILE"].ToString();
                            //ddl_state.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_STA_ID"].ToString()));
                            ddlProspective.SelectedItem.Text = vDR["CUST_PROSPECTIVE"].ToString();
                            CUST_STATION_DDL.SelectedItem.Text = vDR["CITY_NAME"].ToString();
                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["CUST_COUNTRY_ID"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);

                            ddl_state.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_STA_ID"].ToString()));
                            ddl_state_SelectedIndexChanged(sender, e);

                            CUST_STATION_DDL.SelectedIndex = CUST_STATION_DDL.Items.IndexOf(CUST_STATION_DDL.Items.FindByValue(vDR["CUST_ARHQ_ID"].ToString()));
                            //CUST_STATION_DDL.SelectedValue = vDR["CUST_ARHQ_ID"].ToString();

                            ORGANIZATION_DDL.Text = vDR["CUST_ORGANIZATION_NAME"].ToString();
                            HiddenField1.Value = vDR["CUST_ARHQ_ID"].ToString();
                            TXT_START.Text = vDR["CUST_FROM_DATE"].ToString();
                            TXT_END.Text = vDR["CUST_TO_DATE"].ToString();
                            TXT_VALUE.Text = vDR["CUST_VALUE"].ToString();

                            // hide save button 
                            //btnSave.Visible = false;

                            Hashtable vHashtable5 = new Hashtable();
                            vHashtable5.Add("USR_LOGIN", CUST_MOBILE_TXT.Text);
                            DataRow vDR5 = RetDR(DBManager.Get(vHashtable5, "GET_INFO_NEW"));
                            if (vDR5 != null)
                            {
                                TXT_LOGIN.Text = vDR5["USR_LOGIN"].ToString();
                                TXT_PASSWORD.Text = vDR5["USR_PASSWORD"].ToString();
                                ORGANIZATION_DDL.Enabled = false;
                                TXT_LOGIN.Enabled = false;
                                TXT_PASSWORD.Enabled = false;
                                CUST_MOBILE_TXT.Enabled = false;
                                //DDL_USER_TYPE.SelectedValue = vDR5["USR_TYPE"].ToString();
                                DDL_USER_TYPE.SelectedItem.Text = vDR5["USR_TYPE"].ToString();
                                DDL_USER_TYPE.Enabled = false;
                            }

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
                            CUST_EMAIL_TXT.Text = vDR["CUST_EMAIL"].ToString();
                            TXT_DESIGNATION.Text = vDR["CUST_DESIGNATION"].ToString();
                            CUST_MOBILE_TXT.Text = vDR["CUST_MOBILE"].ToString();

                            CUST_COUNTRY_DDL.SelectedIndex = CUST_COUNTRY_DDL.Items.IndexOf(CUST_COUNTRY_DDL.Items.FindByValue(vDR["CUST_COUNTRY_ID"].ToString()));
                            CUST_COUNTRY_DDL_SelectedIndexChanged(sender, e);

                            ddl_state.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_STA_ID"].ToString()));
                            ddl_state_SelectedIndexChanged(sender, e);

                            CUST_STATION_DDL.SelectedIndex = CUST_STATION_DDL.Items.IndexOf(CUST_STATION_DDL.Items.FindByValue(vDR["CUST_ARHQ_ID"].ToString()));

                            ddlProspective.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_PROSPECTIVE"].ToString()));
                            
                            
                            //ddl_state.SelectedIndex = ddl_state.Items.IndexOf(ddl_state.Items.FindByValue(vDR["CUST_STA_ID"].ToString()));
                            ddlProspective.SelectedItem.Text = vDR["CUST_PROSPECTIVE"].ToString();
                            ORGANIZATION_DDL.Text = vDR["CUST_ORGANIZATION_NAME"].ToString();
                            CUST_STATION_DDL.SelectedItem.Text = vDR["CITY_NAME"].ToString();
                            HiddenField1.Value = vDR["CUST_ARHQ_ID"].ToString();
                            TXT_START.Text = vDR["CUST_FROM_DATE"].ToString();
                            TXT_END.Text = vDR["CUST_TO_DATE"].ToString();
                            TXT_VALUE.Text = vDR["CUST_VALUE"].ToString();

                            Hashtable vHashtable5 = new Hashtable();
                            vHashtable5.Add("USR_LOGIN", CUST_MOBILE_TXT.Text);
                            DataRow vDR5 = RetDR(DBManager.Get(vHashtable5, "GET_INFO_NEW"));
                            if (vDR5 != null)
                            {
                                TXT_LOGIN.Text = vDR5["USR_LOGIN"].ToString();
                                TXT_PASSWORD.Text = vDR5["USR_PASSWORD"].ToString();
                                ORGANIZATION_DDL.Enabled = false;
                                TXT_LOGIN.Enabled = false;
                                TXT_PASSWORD.Enabled = false;
                                //DDL_USER_TYPE.SelectedValue = vDR5["USR_TYPE"].ToString();
                                DDL_USER_TYPE.SelectedItem.Text = vDR5["USR_TYPE"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    String vID2 = vATSession.Login;
                    Hashtable vHashtable5 = new Hashtable();
                    vHashtable5.Add("USR_LOGIN", vID2);
                    DataRow vDR5 = RetDR(DBManager.Get(vHashtable5, "GET_INFO"));
                    if (vDR5 != null)
                    {
                        ORGANIZATION_DDL.Text = vDR5["USR_ORGANIZATION_NAME"].ToString();
                        ORGANIZATION_DDL.Enabled = false;
                        TXT_LOGIN.Enabled = false;
                        TXT_PASSWORD.Enabled = false;
                    }

                    Hashtable vHashtable6 = new Hashtable();
                    vHashtable6.Add("CUST_MOBILE", vID2);
                    DataRow vDR6 = RetDR(DBManager.Get(vHashtable6, "GET_CUSTOMER"));
                    if (vDR6 != null)
                    {
                        HiddenField5.Value = vDR6["CUST_ID"].ToString();
                    }

                    Hashtable vHashtable7 = new Hashtable();
                    vHashtable7.Add("CUST_ID", HiddenField5.Value);
                    DataRow vDR7 = RetDR(DBManager.Get(vHashtable7, "GET_PATIENT_TOTAL"));
                    if (vDR7 != null)
                    {
                        HiddenField6.Value = vDR7["PATIENT"].ToString();
                    }

                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("USR_LOGIN", vID2);
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_ORGANIZATION_NEW"));
                    if (vDR != null)
                    {
                        ORGANIZATION_NAME.Value = vDR["USR_ORGANIZATION_NAME"].ToString();
                        HiddenField2.Value = vDR["USR_SUBSCRIPTION_NUMBER"].ToString();
                    }
                    Hashtable vHashtable1 = new Hashtable();
                    vHashtable1.Add("USR_ORGANIZATION_NAME", ORGANIZATION_DDL.Text);
                    vHashtable1.Add("USR_MOBILE", vATSession.Login);
                    DataRow vDR1 = RetDR(DBManager.Get(vHashtable1, "GET_PATIENT_COUNT"));
                    if (vDR1 != null)
                    {
                        HiddenField3.Value = vDR1["PATIENT"].ToString();
                    }
                    Hashtable vHashtable15 = new Hashtable();
                    vHashtable15.Add("USR_LOGIN", vATSession.Login);
                    DataRow vDR15 = RetDR(DBManager.Get(vHashtable15, "GET_TOTALPATIENT"));
                    if (vDR15 != null)
                    {
                        HiddenField7.Value = vDR15["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
                    }
                    if (HiddenField2.Value != "" && HiddenField3.Value != "")
                    {
                        //HiddenField7.Value= Convert.ToString(Convert.ToInt32(HiddenField2.Value) - Convert.ToInt32(HiddenField6.Value));
                        TXT_VALUE.Text = Convert.ToString(Convert.ToInt32(HiddenField7.Value) - Convert.ToInt32(HiddenField3.Value));
                        if (TXT_VALUE.Text == "0")
                        {
                            btnSave.Visible = false;
                            string message = "Please Buy Your Patient Subscription!!";
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                        }
                        else if (TXT_VALUE.Text.StartsWith("-"))
                        {
                            btnSave.Visible = false;
                            string message = "Please Buy Your Patient Subscription!!";
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                            TXT_VALUE.Text = "0";
                        }
                        
                    }
                    else if (HiddenField7.Value != null && HiddenField3.Value != null)
                    {
                        if (HiddenField3.Value != "")
                    {
                        TXT_VALUE.Text = Convert.ToString(Convert.ToInt32(HiddenField7.Value) - Convert.ToInt32(HiddenField3.Value));

                        string message1 = "Only" + " " + TXT_VALUE.Text + " " + "Patient Subscription Is Remaining!!";
                        System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
                        sb1.Append("<script type = 'text/javascript'>");
                        sb1.Append("window.onload=function(){");
                        sb1.Append("alert('");
                        sb1.Append(message1);
                        sb1.Append("')};");
                        sb1.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());

                        if (TXT_VALUE.Text == "0")
                        {
                            btnSave.Visible = false;
                            string message = "Please Buy Your Patient Subscription!!";
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
                        else
                        {
                            Hashtable vHashtable10 = new Hashtable();
                            //vHashtable10.Add("USR_LOGIN", vATSession.Login);
                            vHashtable10.Add("USR_ORGANIZATION_NAME", ORGANIZATION_DDL.Text);
                            DataRow vDR10 = RetDR(DBManager.Get(vHashtable10, "GET_DOCTOR_TOTAL"));
                            if (vDR10 != null)
                            {
                                HiddenField10.Value = vDR10["DOCTOR"].ToString();
                            }
                            HiddenField11.Value= Convert.ToString(Convert.ToInt32(HiddenField2.Value) - Convert.ToInt32(HiddenField10.Value));
                            string message1 = "Only" + " " + HiddenField11.Value + " " + "Subscription Is Remaining!!";
                            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
                            sb1.Append("<script type = 'text/javascript'>");
                            sb1.Append("window.onload=function(){");
                            sb1.Append("alert('");
                            sb1.Append(message1);
                            sb1.Append("')};");
                            sb1.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
                            //TXT_VALUE.Text = Convert.ToString(Convert.ToInt32(HiddenField2.Value) - Convert.ToInt32(HiddenField6.Value));
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String vID2 = vATSession.Login;
            Hashtable vHashtable6 = new Hashtable();
            vHashtable6.Add("USR_LOGIN", vID2);
            DataRow vDR6 = RetDR(DBManager.Get(vHashtable6, "GET_USER"));
            if (vDR6 != null)
            {
                HiddenField5.Value = vDR6["USR_ORGANIZATION_NAME"].ToString();
            }

            Hashtable vHashtable15 = new Hashtable();
            vHashtable15.Add("USR_LOGIN", vATSession.Login);
            DataRow vDR15 = RetDR(DBManager.Get(vHashtable15, "GET_TOTALPATIENT"));
            if (vDR15 != null)
            {
                HiddenField7.Value = vDR15["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
            }
            
                Hashtable vHashtable16 = new Hashtable();
                vHashtable16.Add("USR_ORGANIZATION_NAME", HiddenField5.Value);
                DataRow vDR16 = RetDR(DBManager.Get(vHashtable16, "GET_REMAINING_PATIENT"));
                if (vDR16 != null)
                {
                    
                   HiddenField6.Value = vDR16["PATIENT"].ToString();
                }
           // }
            if (HiddenField7.Value != "" && HiddenField6.Value != "")
            {
                HiddenField8.Value = Convert.ToString(Convert.ToInt32(HiddenField7.Value) - Convert.ToInt32(HiddenField6.Value));
                if (int.Parse(TXT_VALUE.Text) <= int.Parse(HiddenField8.Value))
                {
                    btnSave.Visible = true;
               
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
                        vHashtable.Add("CUST_PREFIX", "");
                        vHashtable.Add("CUST_ADDRESS", "");
                        vHashtable.Add("CUST_COMP_NAME", "");
                        vHashtable.Add("CUST_DISTRICT", "0");
                        vHashtable.Add("CUST_VILLAGE_TWN_CITY", "");
                        vHashtable.Add("CUST_POST_OFFICE", "");
                        vHashtable.Add("CUST_STATE", "0");
                        vHashtable.Add("CUST_CATRGORY_ID", "");
                        vHashtable.Add("CUST_CONSULT_NAME", "");
                        vHashtable.Add("CUST_CONSULT_MOB", "");
                        vHashtable.Add("CUST_PIN", "");
                        vHashtable.Add("CUST_PHONE", "");
                        vHashtable.Add("CUST_EMAIL", CUST_EMAIL_TXT.Text);
                        vHashtable.Add("CUST_MOBILE", CUST_MOBILE_TXT.Text);
                        vHashtable.Add("CUST_DEALER", vATSession.CUST_ID);
                        vHashtable.Add("CUST_DESIGNATION", TXT_DESIGNATION.Text);
                        vHashtable.Add("CUST_COUNTRY_ID", CUST_COUNTRY_DDL.SelectedValue);
                        vHashtable.Add("CUST_ARHQ_ID", CUST_STATION_DDL.SelectedValue);
                        vHashtable.Add("CUST_ORGANIZATION_NAME", ORGANIZATION_DDL.Text);
                        vHashtable.Add("CUST_FROM_DATE", TXT_START.Text);
                        vHashtable.Add("CUST_TO_DATE", TXT_END.Text);
                        vHashtable.Add("CUST_VALUE", TXT_VALUE.Text);
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
                                    vHT.Add("USR_ZONE_ID", CUST_COUNTRY_DDL.SelectedValue);
                                        //vHT.Add("USR_TYPE", "Doctor");
                                        if (DDL_USER_TYPE.SelectedValue == "Health care professional")
                                        {
                                            vHT.Add("USR_TYPE", "Paediatrician");
                                        }
                                        else
                                        {
                                            vHT.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                                        }
                                    vHT.Add("USR_REGHQ_ID", ddl_state.SelectedValue);
                                    vHT.Add("USR_ARHQ_ID", CUST_STATION_DDL.SelectedValue);
                                    vHT.Add("USR_VSOHQ_ID", "0");
                                    vHT.Add("USR_COMPANY", "");
                                    vHT.Add("USR_CONT_NAME", CUST_NAME_TXT.Text);
                                    vHT.Add("USR_ADDRESS", "");
                                    vHT.Add("USR_PIN", "");
                                    vHT.Add("USR_PHONE", "");
                                    vHT.Add("USR_MOBILE", CUST_MOBILE_TXT.Text);
                                    vHT.Add("USR_FAX", "");
                                    vHT.Add("USR_EMAIL", CUST_EMAIL_TXT.Text);
                                    vHT.Add("USR_PASSWORD", pwd);
                                    vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue);
                                    vHT.Add("USR_ORGANIZATION_NAME", ORGANIZATION_DDL.Text);
                                    vHT.Add("USR_FROM_DATE", TXT_START.Text);
                                    vHT.Add("USR_TO_DATE", TXT_END.Text);
                                    vHT.Add("USR_SUBSCRIPTION_NUMBER", "");
                                    vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", TXT_VALUE.Text);
                                    vHT.Add("USR_CLINICAL_HEAD", "");
                                    DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);
                                        ATApp vATApp = (ATApp)Application["Config"];

                                        String vBody = "Dear " + CUST_NAME_TXT.Text + "\n\nLogin Detaials for NerdNerdy Web Application.\n\n";
                                        vBody += "URL is: nerdnerdy.in\n";
                                        vBody += "Login: " + CUST_MOBILE_TXT.Text + "\nPassword:" + pwd + "\n\n";
                                        vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
                                        ATCommon.SendMail(CUST_EMAIL_TXT.Text, "Login Detaials for NerdNerdy Web Application.", vBody, vATApp);
                                        ShowMsg(int.Parse(TXTID.Value));
                                    Response.Redirect("UserList.aspx");
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
                                    //vHT1.Add("USR_TYPE", "Doctor");
                                    //vHT1.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                                    if (DDL_USER_TYPE.SelectedValue == "Health care professional")
                                    {
                                        vHT1.Add("USR_TYPE", "Paediatrician");
                                    }
                                    else
                                    {
                                        vHT1.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                                    }
                                    vHT1.Add("USR_EMAIL", CUST_EMAIL_TXT.Text);
                                vHT1.Add("USR_MOBILE", CUST_MOBILE_TXT.Text);
                                vHT1.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", TXT_VALUE.Text);
                                    DBManager.ExecInsUps(vHT1, "UPDATE_USER", (ATSession)Session["User"]);
                                }
                        }
                        ShowMsg(int.Parse(TXTID.Value));
                        Clear();
                        Response.Redirect("UserList.aspx");
                    }
                    else
                    {
                        Hashtable vHashtable = new Hashtable();
                        vHashtable.Add("CUST_ID", TXTID.Value);
                        vHashtable.Add("CUST_VSOHQ_ID", "0");
                        vHashtable.Add("CUST_STA_ID", ddl_state.SelectedValue);
                        vHashtable.Add("CUST_NAME", CUST_NAME_TXT.Text);
                        vHashtable.Add("CUST_PROSPECTIVE", ddlProspective.SelectedItem.Text);
                        vHashtable.Add("CUST_PREFIX", "");
                        vHashtable.Add("CUST_ADDRESS", "");
                        vHashtable.Add("CUST_COMP_NAME", "");
                        vHashtable.Add("CUST_DISTRICT", "0");
                        vHashtable.Add("CUST_VILLAGE_TWN_CITY", "");
                        vHashtable.Add("CUST_POST_OFFICE", "");
                        vHashtable.Add("CUST_STATE", "0");
                        vHashtable.Add("CUST_CATRGORY_ID", "");
                        vHashtable.Add("CUST_CONSULT_NAME", "");
                        vHashtable.Add("CUST_CONSULT_MOB", "");
                        vHashtable.Add("CUST_PIN", "");
                        vHashtable.Add("CUST_PHONE", "");
                        vHashtable.Add("CUST_EMAIL", CUST_EMAIL_TXT.Text);
                        vHashtable.Add("CUST_MOBILE", CUST_MOBILE_TXT.Text);
                        vHashtable.Add("CUST_DEALER", vATSession.CUST_ID);
                        vHashtable.Add("CUST_DESIGNATION", TXT_DESIGNATION.Text);
                        vHashtable.Add("CUST_COUNTRY_ID", CUST_COUNTRY_DDL.SelectedValue);
                        vHashtable.Add("CUST_ARHQ_ID", HiddenField1.Value);
                        vHashtable.Add("CUST_ORGANIZATION_NAME", ORGANIZATION_DDL.Text);
                        vHashtable.Add("CUST_FROM_DATE", TXT_START.Text);
                        vHashtable.Add("CUST_TO_DATE", TXT_END.Text);
                        vHashtable.Add("CUST_VALUE", TXT_VALUE.Text);
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
                                    vHT.Add("USR_COMPANY", "");
                                    vHT.Add("USR_ZONE_ID", CUST_COUNTRY_DDL.SelectedValue);
                                    vHT.Add("USR_REGHQ_ID", ddl_state.SelectedValue);
                                    vHT.Add("USR_ARHQ_ID", CUST_STATION_DDL.SelectedValue);
                                    vHT.Add("USR_VSOHQ_ID", "0");
                                    vHT.Add("USR_CONT_NAME", CUST_NAME_TXT.Text);
                                    vHT.Add("USR_ADDRESS", "");
                                        //vHT.Add("USR_TYPE", "Doctor");
                                        if (DDL_USER_TYPE.SelectedValue == "Health care professional")
                                        {
                                            vHT.Add("USR_TYPE", "Paediatrician");
                                        }
                                        else
                                        {
                                            vHT.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                                        }
                                        //vHT.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                                        vHT.Add("USR_PIN", "");
                                    vHT.Add("USR_PHONE", "");
                                    vHT.Add("USR_MOBILE", CUST_MOBILE_TXT.Text);
                                    vHT.Add("USR_FAX", "");
                                    vHT.Add("USR_EMAIL", CUST_EMAIL_TXT.Text);
                                    vHT.Add("USR_PASSWORD", pwd);
                                    vHT.Add("USR_COUNTRY", CUST_COUNTRY_DDL.SelectedValue);
                                    vHT.Add("USR_ORGANIZATION_NAME", ORGANIZATION_DDL.Text);
                                    vHT.Add("USR_FROM_DATE", TXT_START.Text);
                                    vHT.Add("USR_TO_DATE", TXT_END.Text);
                                    vHT.Add("USR_SUBSCRIPTION_NUMBER", "");
                                    vHT.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", TXT_VALUE.Text);
                                    vHT.Add("USR_CLINICAL_HEAD", "");
                                    DBManager.ExecInsUps(vHT, "INS_USER", (ATSession)Session["User"]);
                                    ATApp vATApp = (ATApp)Application["Config"];

                                    String vBody = "Dear " + CUST_NAME_TXT.Text + "\n\nLogin Detaials for NerdNerdy Web Application.\n\n";
                                    vBody += "URL is: nerdnerdy.in\n";
                                    vBody += "Login: " + CUST_MOBILE_TXT.Text + "\nPassword:" + pwd + "\n\n";
                                    vBody += "For any query, please revert us back.\n\nThanks and Regards\n";
                                    ATCommon.SendMail(CUST_EMAIL_TXT.Text, "Login Detaials for NerdNerdy Web Application.", vBody, vATApp);
                                    ShowMsg(int.Parse(TXTID.Value));
                                        Response.Redirect("UserList.aspx");
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
                                    //vHT1.Add("USR_TYPE", "Doctor");
                                    //vHT1.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                                    if (DDL_USER_TYPE.SelectedValue == "Health care professional")
                                    {
                                        vHT1.Add("USR_TYPE", "Paediatrician");
                                    }
                                    else
                                    {
                                        vHT1.Add("USR_TYPE", DDL_USER_TYPE.SelectedValue);
                                    }
                                    vHT1.Add("USR_EMAIL", CUST_EMAIL_TXT.Text);
                                vHT1.Add("USR_MOBILE", CUST_MOBILE_TXT.Text);
                                vHT1.Add("USR_PATIENT_SUBSCRIPTION_NUMBER", TXT_VALUE.Text);
                                    DBManager.ExecInsUps(vHT1, "UPDATE_USER", (ATSession)Session["User"]);
                                }
                        }

                        ShowMsg(int.Parse(TXTID.Value));
                        Clear();
                        Response.Redirect("UserList.aspx");
                    }
                }
            catch (Exception xe)
            {
                ShowMsg(xe);
            }
    }
                else
                {
                    //string message = "You Have Less Patient Subscription as subscribed !!";
                    string message = "You Have" + " " + HiddenField7.Value + " " + "Patient Subscription as subscribed!!";
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
    } 
    protected void CUST_PROFILE_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }
    protected void existence_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTMOBILEEMAIL");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["CUST_MOBILE"].ToString().Equals(args.Value) || DR["USR_LOGIN"].ToString().Equals(args.Value)
                    || DR["CUST_EMAIL"].ToString().Equals(args.Value) || DR["USR_EMAIL"].ToString().Equals(args.Value))
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
    
    protected void CUST_STATION_DDL_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void existuser_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            String vID2 = vATSession.Login;
            Hashtable vHashtable6 = new Hashtable();
            vHashtable6.Add("CUST_MOBILE", vID2);
            DataRow vDR6 = RetDR(DBManager.Get(vHashtable6, "GET_CUSTOMER"));
            if (vDR6 != null)
            {
                HiddenField5.Value = vDR6["CUST_ID"].ToString();
            }

            Hashtable vHashtable7 = new Hashtable();
            vHashtable7.Add("CUST_ID", HiddenField5.Value);
            DataRow vDR7 = RetDR(DBManager.Get(vHashtable7, "GET_PATIENT_TOTAL"));
            if (vDR7 != null)
            {
                HiddenField6.Value = vDR7["PATIENT"].ToString();
            }
            Hashtable vHashtable15 = new Hashtable();
            vHashtable15.Add("USR_LOGIN", vATSession.Login);
            DataRow vDR15 = RetDR(DBManager.Get(vHashtable15, "GET_TOTALPATIENT"));
            if (vDR15 != null)
            {
                HiddenField7.Value = vDR15["USR_PATIENT_SUBSCRIPTION_NUMBER"].ToString();
            }
            if (HiddenField7.Value != "" && HiddenField6.Value != "")
            {
                HiddenField8.Value = Convert.ToString(Convert.ToInt32(HiddenField7.Value) - Convert.ToInt32(HiddenField6.Value));
                if (int.Parse(HiddenField8.Value) <= int.Parse(TXT_VALUE.Text))
                {
                    btnSave.Visible = true;
                }
                else
                {
                    //btnSave.Visible = false;
                    string message = "You Have Less Patient Left!!";
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
}
