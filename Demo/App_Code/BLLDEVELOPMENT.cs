using System;
using System.Collections;
using System.Data;

public class BLLDEVELOPMENT
{
    public DataTable GetDevelopment(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("DEV_ID", "0");
        vHashtable.Add("TYPE", "GETALL");
        DataTable vDT = DBManager.Get(vHashtable, "GET_DEVELOPMENT_MASTER");
        return vDT;
    }

    public void DelDevelopment(String DEV_ID)
    {
        Hashtable vHashtable = new Hashtable();

        vHashtable.Add("DEV_ID", "DEV_ID");
        vHashtable.Add("TYPE", "DEL");
        DBManager.ExecDel(vHashtable, "GET_DEVELOPMENT_MASTER");
    }
}