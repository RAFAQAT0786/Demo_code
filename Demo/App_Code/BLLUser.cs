using System;
using System.Collections;
using System.Data;

public class BLLUser
{
    public DataTable GetUser(ATSession pATSession)
    {
        if (pATSession.UserType == "ORGANIZATION")
        {
            String vID = pATSession.Login;

            Hashtable vHashtable2 = new Hashtable();
            vHashtable2.Add("USR_LOGIN", vID);
            DataRow vDR = RetDR(DBManager.Get(vHashtable2, "GET_USER"));
            DataTable vDT3 = DBManager.Get(vHashtable2, "GET_USER");
            return vDT3;
        }

        Hashtable vHashtable = new Hashtable();
        return DBManager.Get(vHashtable, "GET_USER_INFO");
    }

    public void DelUser(String USR_LOGIN)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("USR_LOGIN", USR_LOGIN);
        DBManager.ExecDel(vHashtable, "DEL_USER");
    }

    protected DataRow RetDR(DataTable vDataTable)
    {
        if (vDataTable.Rows.Count > 0)
            return vDataTable.Rows[0];
        else
            return null;
    }
}