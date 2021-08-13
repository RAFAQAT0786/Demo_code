using System;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for BLLState
/// </summary>
public class BLLState
{
    public DataTable GetState(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        DataTable vDT = DBManager.Get(vHashtable, "GET_STATE");
        return vDT;
    }

    public void DelState(String STATE_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("STATE_ID", STATE_ID);
        DBManager.ExecDel(vHashtable, "DEL_STATE");
    }

    public DataTable GetCity(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        DataTable vDT = DBManager.Get(vHashtable, "GET_CITY");
        return vDT;
    }

    public void DelCity(String CITY_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CITY_ID", CITY_ID);
        DBManager.ExecDel(vHashtable, "DEL_CITY");
    }
}