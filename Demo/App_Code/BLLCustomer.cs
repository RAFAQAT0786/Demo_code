using System;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for BLLCustomer
/// </summary>
public class BLLCustomer
{
    public DataTable GetCustomer(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        DataTable vDT = null;
        if (pATSession.UserType == "ORGANIZATION")
        {
            String vID = pATSession.Login;
            String USER_ID = null;

            Hashtable vHashtable2 = new Hashtable();
            vHashtable2.Add("USR_LOGIN", vID);
            DataRow vDR = RetDR(DBManager.Get(vHashtable2, "GET_USER"));
            if (vDR != null)
            {
                USER_ID = vDR["USR_ORGANIZATION_NAME"].ToString();
                Hashtable vHashtable3 = new Hashtable();
                vHashtable3.Add("CUST_ORGANIZATION_NAME", USER_ID);
                DataTable vDT3 = DBManager.Get(vHashtable3, "GET_CUSTOMERByORG");
                return vDT3;
            }
        }
        else
        {
            vDT = DBManager.Get(new Hashtable(), "GET_CUSTOMERByAdmin");
        }
        return vDT;
    }

    protected DataRow RetDR(DataTable vDataTable)
    {
        if (vDataTable.Rows.Count > 0)
            return vDataTable.Rows[0];
        else
            return null;
    }

    public void DelCustomer(String CUST_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CUST_ID", CUST_ID);
        DBManager.ExecDel(vHashtable, "DEL_Customer");
    }

    public void DelCategory(String CAT_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("CAT_ID", CAT_ID);
        DBManager.ExecDel(vHashtable, "DEL_CUSTCATEGORY");
    }

    public DataTable GetCategory(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        DataTable vDT = DBManager.Get(vHashtable, "GET_CUSTCATEGORY");
        return vDT;
    }
}