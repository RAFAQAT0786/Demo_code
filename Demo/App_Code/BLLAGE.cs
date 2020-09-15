using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

/// <summary>
/// Summary description for BLLGIFT
/// </summary>
public class BLLAGE
{
    public void DelCARSRATING(String PTP_ID)
    {
        Hashtable vHashtable2 = new Hashtable();
        vHashtable2.Add("PTP_ID", "PTP_ID");
        DBManager.ExecDel(vHashtable2, "GET_PT_CARS");
    }

    public DataTable GetReport(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("RPT_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_REPORT_MASTER");
        return vDT;
    }

    public void DelReport(String RPT_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("RPT_ID", "RPT_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_REPORT_MASTER");
    }

    public DataTable GetVsms(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("VSMS_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_VSMS_MASTER");
        return vDT;
    }

    public void DelVsms(String VSMS_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("VSMS_ID", "VSMS_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_VSMS_MASTER");
    }

    public DataTable GetCar(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CAR_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_CAR_MASTER");
        return vDT;
    }

    public void DelCar(String CAR_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("CAR_ID", "CAR_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_CAR_MASTER");
    }

    public DataTable GetAnalysis(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("ANM_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_ANALYSIS_MASTER");
        return vDT;
    }

    public void DelAnalysis(String ANM_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("ANM_ID", "ANM_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_ANALYSIS_MASTER");
    }

    public DataTable GetIepskillMASTER(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPS_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_IEP_SKILL_MASTER_NEW");
        return vDT;
    }

    public void DelIepskillMASTER(String IEPS_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPS_ID", "IEPS_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_IEP_SKILL_MASTER_NEW");
    }

    public DataTable GetIepskill(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPA_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_IEP_SKILL_ACTIVITY");
        return vDT;
    }

    public void DelIepskill(String IEPA_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPA_ID", "IEPA_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_IEP_SKILL_ACTIVITY");
    }

    public DataTable GetIepactivity(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPA_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_IEP_SKILL_MASTER");
        return vDT;
    }

    public void DelIepactivity(String IEPS_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPA_ID", "IEPA_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_IEP_SKILL_MASTER");
    }

    public DataTable GetIepMASTER(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPS_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_SKILL_MASTER");
        return vDT;
    }

    public DataTable GetAge(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("AGRP_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_AGE_GRP_MASTER");
        return vDT;
    }

    public void DelAge(String AGRP_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("AGRP_ID", "AGRP_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_AGE_GRP_MASTER");
    }

    public DataTable GetDis(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DIS_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DIS_MASTER");
        return vDT;
    }

    public void DelDis(String DIS_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("DIS_ID", "DIS_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DIS_MASTER");
    }

    public DataTable GetDisCat(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DCAT_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DIS_CAT_MASTER");
        return vDT;
    }

    public void DelDisCat(String DCAT_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("DCAT_ID", "DCAT_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DIS_CAT_MASTER");
    }

    public DataTable GetDisCatSub(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DSCAT_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DIS_SUBCAT_MASTER");
        return vDT;
    }

    public void DelDisCatSub(String DSCAT_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("DSCAT_ID", "DSCAT_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DIS_SUBCAT_MASTER");
    }

    public DataTable GetDisObsc(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DOBS_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DIS_OBSV_MASTER");
        return vDT;
    }

    public void DelDisObsc(String DOBS_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("DOBS_ID", "DOBS_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DIS_OBSV_MASTER");
    }

    public DataTable GetAgegrpdis(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("AGDM_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_AGDIS_MASTER");
        return vDT;
    }

    public void DelAgegrpdis(String AGDM_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("AGDM_ID", "AGDM_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_AGDIS_MASTER");
    }

    public DataTable GetParent(ATSession pATSession)
    {
        String vID = pATSession.UserName;
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string url2 = HttpContext.Current.Request.Url.Query;
        string url22 = HttpContext.Current.Request.QueryString["id"];
        if (url2 != "")
        {
            Hashtable vHashtable23 = new Hashtable();
            vHashtable23.Add("CUSTID", url22);
            DataTable vDT23 = DBManager.Get(vHashtable23, "GET_CUST_ID");
            DataRow vDR23 = RetDR(DBManager.Get(vHashtable23, "GET_CUST_ID"));
            return vDT23;
        }
        if (pATSession.UserType == "ORGANIZATION")
        {
            String vID2 = pATSession.Login;
            String USER_ID = null;
            String CUSTID = null;

            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("USR_LOGIN", vID2);
            DataRow vDR5 = RetDR(DBManager.Get(vHashtable5, "GET_USER"));
            if (vDR5 != null)
            {
                USER_ID = vDR5["USR_ORGANIZATION_NAME"].ToString();
                Hashtable vHashtable3 = new Hashtable();
                vHashtable3.Add("CUST_ORGANIZATION_NAME", USER_ID);
                //DataRow vDR15 = RetDR(DBManager.Get(vHashtable3, "GET_CUSTOMERByORG"));

                //CUSTID = vDR15["CUST_ID"].ToString();
                //Hashtable vHashtable13 = new Hashtable();
                //vHashtable13.Add("CUST_ID", CUSTID);
                DataTable vDT3 = DBManager.Get(vHashtable3, "GET_PATIENT_BYORG");
                return vDT3;
            }
        }
        else if (pATSession.UserType == "Doctor")
        {
            String vID2 = pATSession.Login;
            String USER_ID = null;
            String CUSTID = null;
            String USERLOGIN = null;

            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("USR_LOGIN", vID2);
            DataRow vDR5 = RetDR(DBManager.Get(vHashtable5, "GET_USR_LOGIN_ID"));
            if (vDR5 != null)
            {
                USER_ID = vDR5["USR_ORGANIZATION_NAME"].ToString();
                USERLOGIN = vDR5["USR_LOGIN"].ToString();
                Hashtable vHashtable3 = new Hashtable();
                vHashtable3.Add("CUST_ORGANIZATION_NAME", USER_ID);
                vHashtable3.Add("MOBILE", USERLOGIN);
                DataRow vDR15 = RetDR(DBManager.Get(vHashtable3, "GET_CUSTMOBILE"));
                if (USER_ID != "")
                {
                    CUSTID = vDR15["CUST_ID"].ToString();
                    Hashtable vHashtable13 = new Hashtable();
                    vHashtable13.Add("CUST_ID", CUSTID);
                    DataTable vDT3 = DBManager.Get(vHashtable13, "GET_PTP_CUSTID");
                    return vDT3;
                }
                else
                {
                    
                }
            }
        }
        else if (pATSession.UserType == "Paediatrician")
        {
            String vID2 = pATSession.Login;
            String USER_ID = null;
            String CUSTID = null;
            String USERLOGIN = null;

            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("USR_LOGIN", vID2);
            DataRow vDR5 = RetDR(DBManager.Get(vHashtable5, "GET_USR_LOGIN_ID"));
            if (vDR5 != null)
            {
                USER_ID = vDR5["USR_ORGANIZATION_NAME"].ToString();
                USERLOGIN = vDR5["USR_LOGIN"].ToString();
                Hashtable vHashtable3 = new Hashtable();
                vHashtable3.Add("CUST_ORGANIZATION_NAME", USER_ID);
                vHashtable3.Add("MOBILE", USERLOGIN);
                DataRow vDR15 = RetDR(DBManager.Get(vHashtable3, "GET_CUSTMOBILE"));
                if (USER_ID != "")
                {
                    CUSTID = vDR15["CUST_ID"].ToString();
                    Hashtable vHashtable13 = new Hashtable();
                    vHashtable13.Add("CUST_ID", CUSTID);
                    DataTable vDT3 = DBManager.Get(vHashtable13, "GET_PTP_CUSTID");
                    return vDT3;
                }
                else
                {

                }
            }
        }
        else if (pATSession.UserType == "Patient")
        {
            String vID2 = pATSession.Login;
            String USER_ID = null;
            String CUSTID = null;
            String USERLOGIN = null;

            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("PTP_MOBILE", vID2);
            DataTable vDT3 = DBManager.Get(vHashtable5, "GET_PARENT_PATIENT_DETAIL");
            return vDT3;
        }
        else if (pATSession.UserType == "Parent")
        {
            String vID2 = pATSession.Login;
            String USER_ID = null;
            String CUSTID = null;
            String USERLOGIN = null;

            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("PTP_MOBILE", vID2);
            DataTable vDT3 = DBManager.Get(vHashtable5, "GET_PARENT_DETAIL");
            return vDT3;
        }
        else if (pATSession.UserType == "Therapist")
        {
            String vID2 = pATSession.Login;
            String USER_ID = null;
            String CUSTID = null;
            String USERLOGIN = null;

            Hashtable vHashtable5 = new Hashtable();
            vHashtable5.Add("USR_LOGIN", vID2);
            DataRow vDR5 = RetDR(DBManager.Get(vHashtable5, "GET_USR_LOGIN_ID"));
            if (vDR5 != null)
            {
                USER_ID = vDR5["USR_ORGANIZATION_NAME"].ToString();
                USERLOGIN = vDR5["USR_LOGIN"].ToString();
                Hashtable vHashtable3 = new Hashtable();
                vHashtable3.Add("CUST_ORGANIZATION_NAME", USER_ID);
                vHashtable3.Add("MOBILE", USERLOGIN);
                DataRow vDR15 = RetDR(DBManager.Get(vHashtable3, "GET_CUSTMOBILE"));
                if (USER_ID != "")
                {
                    CUSTID = vDR15["CUST_ID"].ToString();
                    Hashtable vHashtable13 = new Hashtable();
                    vHashtable13.Add("CUST_ID", CUSTID);
                    DataTable vDT3 = DBManager.Get(vHashtable13, "GET_PTP_CUSTID");
                    return vDT3;
                }
                else
                {

                }
            }
        }
        //else if (pATSession.UserType == "ADMIN")
        {
            Hashtable vHashtable = new Hashtable();
            vHashtable.Add("PTP_ID", "0");
            vHashtable.Add("TYPE", "GETALL");
            DataTable vDT = DBManager.Get(vHashtable, "GET_PATIENT_DETAIL");
            return vDT;
        }
    }

    protected DataRow RetDR(DataTable vDataTable)
    {
        if (vDataTable.Rows.Count > 0)
            return vDataTable.Rows[0];
        else
            return null;
    }

    public void DelParent(String PTP_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", "PTP_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_PERSONAL");
    }

    public DataTable GetParentMental(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTM_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PT_MENTAL");
        return vDT;
    }

    public DataTable GetParentMentalNEW(String PTP_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTM_ID", "0");
        vHashtable.Add("PTP_ID", PTP_ID);
        vHashtable.Add("TYPE", "GET");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PT_MENTAL");
        return vDT;
    }

    public void DelParentMental(String PTM_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTM_ID", PTM_ID);
        vHashtable.Add("PTP_ID", "0");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_PT_MENTAL");
    }

    public DataTable GetCondition(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("COND_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_COND_MASTER");
        return vDT;
    }

    public void DelCondition(String COND_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("COND_ID", "COND_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_COND_MASTER");
    }

    public DataTable GetPatientFHisNEW(String PTP_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTFH_ID", "0");
        vHashtable.Add("PTP_ID", PTP_ID);
        vHashtable.Add("TYPE", "GET");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PT_FAMILY_HIST");
        return vDT;
    }

    public DataTable GetPatientFHis(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTFH_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PT_FAMILY_HIST");
        return vDT;
    }

    public void DelPatientFHis(String PTFH_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTFH_ID", "PTFH_ID");
        vHashtable.Add("PTP_ID", "0");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_PT_FAMILY_HIST");
    }

    public DataTable GetPatientScreen(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTS_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PT_SCREEN");
        return vDT;
    }

    public void DelPatientScreen(String PTS_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("PTS_ID", "PTS_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_PT_SCREEN");
    }

    public DataTable GetScreen(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("SCTP_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_SCT_MASTER");
        return vDT;
    }

    public void DelScreen(String SCTP_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("SCTP_ID", "SCTP_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_SCT_MASTER");
    }

    public DataTable GetAGEDISORDER(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("ID", "0");
        DataTable vDT = DBManager.Get(vHashtable, "GET_AGDIS_DETAIL");
        return vDT;
    }

    public void DelAGEDISORDER(String AGDD_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("AGDD_ID", "AGDD_ID");
        DBManager.ExecDel(vHashtable, "GET_AGDIS_DETAIL");
    }

    public DataTable GetCOUNTRY(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("COUNTRY_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_COUNTRY_MASTER");
        return vDT;
    }

    public void DelCOUNTRY(String COUNTRY_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("COUNTRY_ID", "COUNTRY_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_COUNTRY_MASTER");
    }

    public DataTable GetAssessment(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("ASE_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_ASSESS_MASTER_NEW");
        return vDT;
    }

    public void DelAssessment(String ASE_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("ASE_ID", "ASE_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_ASSESS_MASTER_NEW");
    }

    public DataTable GetSeverity(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("SGM_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_SEVERITY_GROUP_MASTER");
        return vDT;
    }

    public void DelSeverity(String SGM_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("SGM_ID", "SGM_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_SEVERITY_GROUP_MASTER");
    }

    public DataTable GetIEPdisorder(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPDT_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_IEPDT_MASTER");
        return vDT;
    }

    public void DelIEPdisorder(String IEPDT_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("IEPDT_ID", "IEPDT_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_IEPDT_MASTER");
    }

    public DataTable GetAllPatient(string PTAD_ID)
    {
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("PTAD_ID", PTAD_ID);
        DataTable vDt = DBManager.Get(vHashTable, "GETPTP_ID");

        return vDt;
    }

    public DataTable GetEva(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("EVA_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_EVALUATION_MASTER");
        return vDT;
    }

    public void DelEva(String EVA_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("EVA_ID", "EVA_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_EVALUATION_MASTER");
    }

    public DataTable GetADHD(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("ADHD_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_ADHD_MASTER");
        return vDT;
    }

    public void DelADHD(String ADHD_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("ADHD_ID", "ADHD_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_ADHD_MASTER");
    }

    public DataTable GetDEVELOPMENTAL(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DEVE_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DEVELOPMENTAL_MASTER");
        return vDT;
    }

    public void DelDEVELOPMENTAL(String DEVE_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("DEVE_ID", "DEVE_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DEVELOPMENTAL_MASTER");
    }

    public DataTable GetFRAGILE(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("FRA_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_FRAGILE_MASTER");
        return vDT;
    }

    public void DelFRAGILE(String FRA_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("FRA_ID", "FRA_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_FRAGILE_MASTER");
    }

    public DataTable GetGLOBAL(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("GLOBAL_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_GLOBAL_MASTER");
        return vDT;
    }

    public void DelGLOBAL(String GLOBAL_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("GLOBAL_ID", "GLOBAL_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_GLOBAL_MASTER");
    }

    public DataTable GetINT(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("INTE_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_INTELLECTUAL_MASTER");
        return vDT;
    }

    public void DelINT(String INTE_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("INTE_ID", "INTE_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_INTELLECTUAL_MASTER");
    }

    public DataTable GetDISABILITY(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DISA_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DISABILITY_MASTER");
        return vDT;
    }

    public void DelDISABILITY(String DISA_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DISA_ID", "DISA_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DISABILITY_MASTER");
    }

    public DataTable GetLEARNDISABILITY(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("LEAR_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_LEARNING_MASTER");
        return vDT;
    }

    public void DelLEARNDISABILITY(String LEAR_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("LEAR_ID", "LEAR_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_LEARNING_MASTER");
    }

    public DataTable GetSPEECH(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("SPEC_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_SPEECH_MASTER");
        return vDT;
    }

    public void DelSPEECH(String SPEC_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("SPEC_ID", "SPEC_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_SPEECH_MASTER");
    }

    public DataTable GetDOWNSYNDROME(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DOWN_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DOWN_SYNDROME_MASTER");
        return vDT;
    }

    public void DelDOWNSYNDROME(String DOWN_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DOWN_ID", "DOWN_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DOWN_SYNDROME_MASTER");
    }

    public DataTable GetSENSORY(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("SEN_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_SENSORY_MASTER");
        return vDT;
    }

    public void DelSENSORY(String SEN_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("SEN_ID", "SEN_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_SENSORY_MASTER");
    }

    public void DelADHDRATING(String PTP_ID)
    {
        Hashtable vHashtable2 = new Hashtable();
        vHashtable2.Add("PTP_ID", "PTP_ID");
        DBManager.ExecDel(vHashtable2, "GET_PT_ADHD");
    }

    public DataTable GetEVADIS(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("EVADIS_DISID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_EVALUATION_DISORDER");
        return vDT;
    }

    public void DelEVADIS(String EVADIS_DISID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("EVADIS_DISID", "EVADIS_DISID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_EVALUATION_DISORDER");
    }

    public DataTable GetCerebal(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CEREBAL_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_CEREBAL_PALSY_MASTER");
        return vDT;
    }

    public void DelCerebal(String CEREBAL_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CEREBAL_ID", "CEREBAL_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_CEREBAL_PALSY_MASTER");
    }

    public DataTable GetIEPMAPPING(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPMD_IEPMID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_IEP_MAPPING_ID");
        return vDT;
    }

    public void DelIEPMAPPING(String IEPM_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("IEPM_ID", "IEPM_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_IEP_MAPPING");
    }

    public DataTable GetIEPPROGRESS(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", "PTP_ID");
        DataTable vDT = DBManager.Get(vHashtable, "GET_IEP_PATIENT_PTPID");
        return vDT;
    }
}