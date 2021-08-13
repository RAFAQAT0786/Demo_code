using System;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for BLLDISREPORT
/// </summary>
public class BLLDISREPORT
{
    public DataTable GetReport(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DISO_RET_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DISORDER_RET_MASTER");
        return vDT;
    }

    public void DelReport(String DISO_RET_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("DISO_RET_ID", "DISO_RET_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DISORDER_RET_MASTER");
    }

    public void DelCEREBALRATING(String PTP_ID)
    {
        Hashtable vHashtable2 = new Hashtable();
        vHashtable2.Add("PTP_ID", "PTP_ID");
        DBManager.ExecDel(vHashtable2, "GET_PT_CEREBAL_PALSY");
    }
}