using System;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for BLLCust_type
/// </summary>
public class BLLCust_type
{
    public DataTable GetCustType(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        DataTable vDT = DBManager.Get(vHashtable, "GET_CUST_TYPE");
        return vDT;
    }

    public void DelCustType(String CUST_TYP_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CUST_TYP_ID", CUST_TYP_ID);
        DBManager.ExecDel(vHashtable, "DEL_CUST_TYPE");
    }
}