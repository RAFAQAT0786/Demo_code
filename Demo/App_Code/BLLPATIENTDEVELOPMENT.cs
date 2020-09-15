using System;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for BLLPATIENTDEVELOPMENT
/// </summary>
public class BLLPATIENTDEVELOPMENT
{
    public DataTable GetPatientDevelopment(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PATIENT_DEVELOPMENT");
        return vDT;
    }

    public DataTable GetPatientDevelopmentGet(String PTP_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", PTP_ID);
        vHashtable.Add("TYPE", "GET");
        DataTable vDT = DBManager.Get(vHashtable, "GET_PATIENT_DEVELOPMENT");
        return vDT;
    }

    public void DelPatientDevelopment(String PTDEV_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PTP_ID", "PTP_ID");
        vHashtable.Add("PTDEV_ID", "PTDEV_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_PT_DEVELOPMENT");
    }
}