using System;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for BLLPROFILE
/// </summary>
public class BLLPROFILE
{
    public DataTable GetParentProfileNEW(String PTP_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTF_ID", "0");
        vHashtable.Add("PTP_ID", PTP_ID);
        vHashtable.Add("TYPE", "GET");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PT_PROFILE");
        return vDT;
    }

    public DataTable GetParentProfile(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTF_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PT_PROFILE");
        return vDT;
    }

    public DataTable DELParentProfile(String PTF_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTF_ID", "PTF_ID");
        vHashtable.Add("PTP_ID", "0");
        vHashtable.Add("TYPE", "GET");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PT_PROFILE");
        return vDT;
    }
}