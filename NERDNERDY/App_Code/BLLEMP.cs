using System;
using System.Collections;
using System.Data;

public class BLLEMP
{
    public DataTable GetEMP(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("EMP_ID", pATSession.EMP_ID);
        DataTable vDT = null;
        vDT = DBManager.Get(new Hashtable(), "GET_EMP");
        return vDT;
    }

    public void DelEMP(String EMP_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("EMP_ID", EMP_ID);
        DBManager.ExecDel(vHashtable, "DEL_EMP");
    }
}