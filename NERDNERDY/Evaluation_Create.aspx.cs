﻿using System;
using System.Collections;
using System.Data;
using System.Web.UI;

public partial class Evaluation_Create : BasePage
{
    private ATSession vATSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
        if (!IsPostBack)
        {
            try
            {
                ValidateUserAccess();
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("EVA_ID", vID);
                    vHashtable.Add("TYPE", "GET");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "GET_EVALUATION_MASTER"));
                    if (vDR != null)
                    {
                        TXTID.Value = vDR["EVA_ID"].ToString();
                        EVALUATION_TXT.Text = vDR["EVA_NAME"].ToString();
                    }
                    else
                        ShowMsg("Invalid Condition ID");
                }
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (TXTID.Value != "0")
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("EVA_ID", TXTID.Value);
                    vHashtable.Add("EVA_NAME", EVALUATION_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "UPD");
                    DBManager.Get(vHashtable, "INS_EVALUATION_MASTER");
                    Response.Redirect("Evaluation.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            else
            {
                try
                {
                    Hashtable vHashtable = new Hashtable();
                    vHashtable.Add("EVA_ID", TXTID.Value);
                    vHashtable.Add("EVA_NAME", EVALUATION_TXT.Text);
                    vHashtable.Add("LAST_USER", vATSession.Login);
                    vHashtable.Add("TYPE", "INS");
                    DBManager.Get(vHashtable, "INS_EVALUATION_MASTER");
                    Response.Redirect("Evaluation.aspx");
                    Clear();
                }
                catch (Exception xe)
                {
                    ShowMsg(xe);
                }
            }
        }
    }

    public void Clear()
    {
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTEVALUATION");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["EVA_NAME"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}