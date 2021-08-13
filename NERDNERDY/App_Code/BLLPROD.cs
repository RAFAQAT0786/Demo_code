using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

/// <summary>
/// Summary description for BLLPROD
/// </summary>
public class BLLPROD
{
    public DataTable GetPROD(ATSession pATSession)
    {
        Hashtable vHashtable = new Hashtable();
        DataTable vDT = DBManager.Get(vHashtable, "GET_PRODUCT");
        return vDT;
    }
    public void DelPROD(String PRODM_ID)
    {
        Hashtable vHashtable = new Hashtable();
        vHashtable.Add("PRODM_ID", PRODM_ID);
        DBManager.ExecDel(vHashtable, "DEL_PROD");
    }
    
}

