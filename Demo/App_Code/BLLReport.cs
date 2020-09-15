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
/// Summary description for BLLReport
/// </summary>
public class BLLReport
{
	public BLLReport()
	{
	}
    public DataTable GetAllDwrDetail(string emp_id,string from_date,string to_date)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", emp_id);
        vHashTable.Add("FROM_DATE", from_date);
        vHashTable.Add("TO_DATE", to_date);
        vDt = DBManager.Get(vHashTable, "GETALLDWR");

        return vDt;
    }

    public DataTable GetAllDwrDetail1(string id, string from_date, string to_date)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("ID", id);
        vHashTable.Add("FROM_DATE", from_date);
        vHashTable.Add("TO_DATE", to_date);
        vDt = DBManager.Get(vHashTable, "GETALLDWR1");

        return vDt;
    }

    public DataTable GetAllDwrDetail5(string id, string FROM_MONTH, string TO_MONTH)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("ID", id);
        vHashTable.Add("FROM_MONTH", FROM_MONTH);
        vHashTable.Add("TO_MONTH", TO_MONTH);
        vDt = DBManager.Get(vHashTable, "GETALLDWR5");

        return vDt;
    }

    public bool ExistRoute(Hashtable vHashTable)
    {
        bool flag = true;
        DataTable vDt = DBManager.Get(vHashTable, "CHECKROUTE");
        if (vDt.Rows.Count > 0)
        {
            flag = false;
        }
        return flag;
    }
    public string GetRouteByDwr_id(string DWR_ID)
    {
       string route_id="";
       Hashtable vHashTable = new Hashtable();
        vHashTable.Add("@DWR_ID", DWR_ID);
        DataTable vDt = DBManager.Get(vHashTable, "GET_ROUTE_ID_BY_DWRID");
        if (vDt.Rows.Count > 0)
            route_id = vDt.Rows[0][0].ToString();

        return route_id;
    }
    public DataTable GetAllVDWRDetail(string DWR_ID)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("DWR_ID", DWR_ID);
        vDt = DBManager.Get(vHashTable, "GETALLVDWRBYDWR_ID");
        return vDt;
    }

    public DataTable GetAllPOBByDWR_Id(string DWR_ID)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("DWR_ID", DWR_ID);
        vDt = DBManager.Get(vHashTable, "GetPOBByDWRID");
        return vDt;
    }
    public DataRow GetEmpById(string EMP_ID)
    {
        DataTable vDt = new DataTable();
        DataRow vDr = null;
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("ID", EMP_ID);
        vDt = DBManager.Get(vHashTable, "get_emp_id");
        if (vDt.Rows.Count > 0)
         vDr = vDt.Rows[0];
        return vDr;
    }
    public DataRow GetEmpById5(string VSO_ID)
    {
        DataTable vDt = new DataTable();
        DataRow vDr = null;
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("ID", VSO_ID);
        vDt = DBManager.Get(vHashTable, "get_emp_id5");
        if (vDt.Rows.Count > 0)
            vDr = vDt.Rows[0];
        return vDr;
    }
    public string GetVSoById(string Vso_Id)
    {
        string vsoname = "";
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("VSO_ID", Vso_Id);
        vDt = DBManager.Get(vHashTable, "GetVsoById");
        if (vDt.Rows.Count > 0)
        vsoname = vDt.Rows[0]["VSOHQ_NAME"].ToString();
        return vsoname;
    }
    public string GetAreaById(String Area_id)
    {
        string name = "";
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("Area_Id", Area_id);
        vDt = DBManager.Get(vHashTable, "GetAreaById");
        if (vDt.Rows.Count > 0)
        name = vDt.Rows[0]["arhq_name"].ToString();
        return name;
    }
    public string GetDesignationById(String Des_id)
    {
        string name = "";
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("Des_Id", Des_id);
        vDt = DBManager.Get(vHashTable, "GetDesignationById");
        if (vDt.Rows.Count > 0)
        name = vDt.Rows[0]["DES_NAME"].ToString();
        return name;
    }
    public string GetSunday(string Month)
    {
        int sunday = 0;
        int Days = DateTime.DaysInMonth(DateTime.Now.Year, Int16.Parse(Month));
        DateTime Date = DateTime.Parse("01/" + Month + "/" + DateTime.Now.Year.ToString());
        for (int i = 0; i < Days; i++)
        {
            if (Date.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                sunday++;
        }
        return sunday.ToString();
    }
    public string GetTOTALSunday(string Month,string YEAR)
    {
        int sunday = 0;
        int Days = DateTime.DaysInMonth(Int16.Parse(YEAR), Int16.Parse(Month));
        DateTime Date = DateTime.Parse("01/" + Month + "/" + YEAR);
        for (int i = 0; i < Days; i++)
        {
            if (Date.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                sunday++;
        }
        return sunday.ToString();
    }
    public string GetRouteById(String Route_Id)
    {
        String Stations="";
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("ROUTE_ID", Route_Id);
        vDt = DBManager.Get(vHashTable, "GETROUTEBYID");
        if (vDt.Rows.Count > 0)
        {
            foreach (DataRow vDr in vDt.Rows)
                Stations += vDr["STA_NAME"].ToString()+", ";
        }
        return Stations;
    }
    public DataTable GetMonthPlanByEmpMonth(String Emp_id, String Month,String Year)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_id);
        vHashTable.Add("MONTH", Month);
        vHashTable.Add("YEAR", Year);
        vDt = DBManager.Get(vHashTable, "GETMONTHPLANBYEMP_MONTH");
        return vDt;
    }
    public String GetStationNameBySTA_Id(string Sta_id)
    {
        String STA_NAME = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("STA_ID", Sta_id);
        DataTable vDt = DBManager.Get(vHashTable, "GETSTATIONBYSTA_ID");
        if (vDt.Rows.Count > 0)
        {
            STA_NAME = vDt.Rows[0]["STA_NAME"].ToString();
        }
        return STA_NAME;
    }
    public String GetStationIDBySTA_Name(string Sta_Name)
    {
        String STA_ID = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("STA_NAME", Sta_Name);
        DataTable vDt = DBManager.Get(vHashTable, "GETSTATIONBYSTA_NAME");
        if (vDt.Rows.Count > 0)
        {
            STA_ID = vDt.Rows[0]["STA_ID"].ToString();
        }
        return STA_ID;
    }
    public String GetEmpRegionalByEmp_Id(string Emp_Id)
    {
        String RegionalID = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_Id);
        DataTable vDt = DBManager.Get(vHashTable, "GetEmpRegionIDByEmpId");
        if (vDt.Rows.Count > 0)
        {
            RegionalID = vDt.Rows[0]["EMP_REGIONAL_ID"].ToString();
        }
        return RegionalID;
    }
    public String GetEmpZONEByEmp_Id(string Emp_Id)
    {
        String ZONEID = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_Id);
        DataTable vDt = DBManager.Get(vHashTable, "GetEmpZONEIDByEmpId");
        if (vDt.Rows.Count > 0)
        {
            ZONEID = vDt.Rows[0]["EMP_ZONE_ID"].ToString();
        }
        return ZONEID;
    }
    public String GetEmpRegionalNameByEmp_Id(string Emp_Id)
    {
        String RegionalNAME = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_Id);
        DataTable vDt = DBManager.Get(vHashTable, "GetEmpRegionByEmpId");
        if (vDt.Rows.Count > 0)
        {
            RegionalNAME = vDt.Rows[0]["REGHQ_NAME"].ToString();
        }
        return RegionalNAME;
    }
    public String GetEmpZONENameByEmp_Id(string Emp_Id)
    {
        String ZONENAME = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_Id);
        DataTable vDt = DBManager.Get(vHashTable, "GetEmpZONEByEmpId");
        if (vDt.Rows.Count > 0)
        {
            ZONENAME = vDt.Rows[0]["ZONE_NAME"].ToString();
        }
        return ZONENAME;
    }
    //public String GetEmpAreaByEmp_Id(string Emp_Id)
    //{
    //    String AreaId = "";
    //    Hashtable vHashTable = new Hashtable();
    //    vHashTable.Add("EMP_ID", Emp_Id);
    //    DataTable vDt = DBManager.Get(vHashTable, "GetEmpAreaIDByEmpId");
    //    if (vDt.Rows.Count > 0)
    //    {
    //        AreaId = vDt.Rows[0]["EMP_AREA_ID"].ToString();
    //    }
    //    return AreaId;
    //}
    public String GetEmpZone_IdByREGHQ_Id(string REGHQ_id)
    {
        String REGHQId = "";    
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("REGHQ_id", REGHQ_id);
        DataTable vDt = DBManager.Get(vHashTable, "GetEmpZoneIDByREGHQ_Id");
        if (vDt.Rows.Count > 0)
        {
            REGHQId = vDt.Rows[0]["REGHQ_ZONE_ID"].ToString();
        }
        return REGHQId;
    }
    public DataTable GetdwrByEmp_ID(String Emp_id)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_id);
        vDt = DBManager.Get(vHashTable, "GetdwrByEmp");
        return vDt;
    }
    public DataTable GetdwrBySMByEmp_ID(String Emp_id)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_id);
        vDt = DBManager.Get(vHashTable, "GetdwrBySM");
        return vDt;
    }
    public DataTable GetWorkedWithByEmp_ID(String Emp_id)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_id);
        vDt = DBManager.Get(vHashTable, "GetWorkedWithEmp");
        return vDt;
    }
    public DataTable GetWorkedWithRSMByEmp_ID(String Emp_id)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_id);
        vDt = DBManager.Get(vHashTable, "GetWorkedWithRSMEmp");
        return vDt;
    }
    public DataTable GetWorkedWithSMByEmp_ID(String Emp_id)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_id);
        vDt = DBManager.Get(vHashTable, "GetWorkedWith_SMEmp");
        return vDt;
    }
     public DataTable GetWorkedWithByID(String Emp_id)
    {
        DataTable vDt = new DataTable();
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_id);
        vDt = DBManager.Get(vHashTable, "GetWorkedWith");
        return vDt;
    }
    public String GetKmsByGradeEmp_id(string Emp_Id)
    {
        String KMS = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_Id);
        DataTable vDt = DBManager.Get(vHashTable, "GetKMs");
        if (vDt.Rows.Count > 0)
        {
            KMS = vDt.Rows[0]["KMS"].ToString();
        }
        return KMS;
    }
    public String GetFarebyVDWRDate_EmpType(String date, string usertype, string TransportMode)
    {
        String KMS = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("UPTO_DATE", date);
        vHashTable.Add("DACategory", usertype);
        vHashTable.Add("TRANSTYPE", TransportMode);
        DataTable vDt = DBManager.Get(vHashTable, "GetPerKMRate");
        if (vDt.Rows.Count > 0)
        {
            KMS = vDt.Rows[0]["KMS"].ToString();
        }
        return KMS;
    }
    public String GetDAByTourType(string Emp_Id,string type)
    {
        String RS = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_Id);
        vHashTable.Add("TYPE", type);
        DataTable vDt = DBManager.Get(vHashTable, "GetDAByTourType");
        if (vDt.Rows.Count > 0)
        {
            RS = vDt.Rows[0][0].ToString();
        }
        return RS;
    }
    public String GetDAByTourTypeNeW(string Emp_Id, string type, string date, string USER)
    {
        String RS = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", Emp_Id);
        vHashTable.Add("TYPE", type);
        vHashTable.Add("UPTO_DATE", date.ToString());
        vHashTable.Add("DACategory", USER);
        DataTable vDt = DBManager.Get(vHashTable, "GetDAByTourType_NEW");
        if (vDt.Rows.Count > 0)
        {
            RS = vDt.Rows[0][0].ToString();
        }
        return RS;
    }
    public String GetDAByTourTypeNeW5(string Id, string type, string date, string USER)
    {
        String RS = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("ID", Id);
        vHashTable.Add("TYPE", type);
        vHashTable.Add("UPTO_DATE", date.ToString());
        vHashTable.Add("DACategory", USER);
        DataTable vDt = DBManager.Get(vHashTable, "GetDAByTourType_NEW5");
        if (vDt.Rows.Count > 0)
        {
            RS = vDt.Rows[0][0].ToString();
        }
        return RS;
    }
    public String GetVDWRFrom_STAByDWR(String DWR_ID)
    {
        String FROMSTA_ID = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("DWR_ID", DWR_ID);
        DataTable vDt = DBManager.Get(vHashTable, "GETVDWRFROM_STA");
        if (vDt.Rows.Count > 0)
        {
            FROMSTA_ID = vDt.Rows[0]["VDWR_TO_STATION"].ToString();
        }
        return FROMSTA_ID;
    }
    public String GetVso_idByEmp_id(String emp_id)
    {
        String VSO_ID = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_ID", emp_id);
        DataTable vDt = DBManager.Get(vHashTable, "VSO_IDBYEMP_ID");
        if (vDt.Rows.Count > 0)
        {
            VSO_ID = vDt.Rows[0]["EMP_VSO_ID"].ToString();
        }
        return VSO_ID;
    }
    public String GetNameByCode(String Emp_code)
    {
        string Name = "";
        Hashtable vHashTable = new Hashtable();
        vHashTable.Add("EMP_CODE", Emp_code);
        DataTable vDt = DBManager.Get(vHashTable, "GETEMPNAMEBYCODE");
        if (vDt.Rows.Count > 0)
        {
            Name = vDt.Rows[0]["EMP_NAME"].ToString();
        }
        return Name;
    }
    public bool ExistSample(Hashtable vHashTable)
    {
        bool flag = true;
        DataTable vDt = DBManager.Get(vHashTable, "CHECKPRODSAMPLE");
        if (vDt.Rows.Count > 0)
        {
            flag = false;
        }
        return flag;
    }
    public bool ExistSamp(Hashtable vHashTable)
    {
        bool flag = true;
        DataTable vDt = DBManager.Get(vHashTable, "CHECKPRODSAMP");
        if (vDt.Rows.Count > 0)
        {
            flag = false;
        }
        return flag;
    }
     public bool ExistPOB(Hashtable vHashTable)
    {
        bool flag = true;
        DataTable vDt = DBManager.Get(vHashTable, "CHECKPOB");
        if (vDt.Rows.Count > 0)
        {
            flag = false;
        }
        return flag;
    }
     //public bool ExistMonthPlan(Hashtable vHashTable)
     //{
     //    bool flag = false;
     //    DataSet vDS = DBManager.GetDataSet(vHashTable, "CHECKMONTHPLAN");
     //    if (vDS.Tables[0].Rows.Count > 0 && vDS.Tables[1].Rows.Count > 0)
     //    {
     //        flag = true;
     //    }
     //    return flag;
     //}
     public bool ExistCDWR(Hashtable vHashTable)
     {
         bool flag = true;
         DataTable vDt = DBManager.Get(vHashTable, "CHECKCDWR");
         if (vDt.Rows.Count > 0)
         {
             flag = false;
         }
         return flag;
     }
     public Hashtable CreateRouteKMSHashTable(DataTable vRouteData)
     {
         Hashtable vHashTable = new Hashtable();
         foreach (DataRow vDr in vRouteData.Rows)
         {
             if(vHashTable.Contains(vDr["R_TO"].ToString())==false)
                 vHashTable.Add(vDr["R_TO"].ToString(), vDr["R_DISTANCE"].ToString());
         }
         return vHashTable;
     }
     public bool ExistDWR(Hashtable vHashTable)
     {
         bool flag = true;
         DataTable vDt = DBManager.Get(vHashTable, "CHECKDWR_DETAIL");
         if (vDt.Rows.Count > 0)
         {
             flag = false;
         }
         return flag;
     }
     public string GetEmpDesignationById(string DES_ID)
     {
         String Designation = "";
         DataTable vDt = new DataTable();        
         Hashtable vHashTable = new Hashtable();
         vHashTable.Add("ID", DES_ID);
         vDt = DBManager.Get(vHashTable, "GET_DESIGNATIONNAMEBY_ID");
         if (vDt.Rows.Count > 0)
         {
             Designation = vDt.Rows[0]["DES_NAME"].ToString();
         }
         return Designation;

        
     }
   
}
