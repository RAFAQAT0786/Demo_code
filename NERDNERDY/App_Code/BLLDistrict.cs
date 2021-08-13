using System;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for BLLDistrict
/// </summary>
public class BLLDistrict
{
    public DataTable GetDistrict(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        DataTable vDT = DBManager.Get(vHashtable, "GET_DISTRICT");
        return vDT;
    }

    public void DelDistrict(String Dist_id)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DIST_ID", Dist_id);
        DBManager.ExecDel(vHashtable, "DEL_DISTRICT");
    }
}