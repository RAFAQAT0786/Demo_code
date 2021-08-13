using System;

[Serializable]
public class ATSession
{
    private String vCustID, vLogin, vPwd, vCompany, vPCID, vPCName, vSCID, vSCCode, vSCName, vSCAddr, vEmp_Id, vPtp_Id, vUserName, vUserType, vEMT_ID, vTicketID, vReferedUrl, vLOG_ID, vPTP_ID;
    private static string vFinYear;

    public ATSession(String pLogin, String pPwd, String pCompany, String pUserName, String pUserType, String pFinYear, String pEmp_Id, String pPtp_Id, String pCustId)
    {
        vLogin = pLogin;
        vPwd = pPwd; // used in changed password
        vCompany = pCompany;
        vEmp_Id = pEmp_Id;
        vPtp_Id = pPtp_Id;
        vUserName = pUserName;//top header
        vUserType = pUserType;
        vFinYear = pFinYear;
        vCustID = pCustId;
    }

    public String Login { get { return vLogin; } }
    public String Pwd { set { vPwd = value; } get { return vPwd; } }
    public String Company { get { return vCompany; } }
    public String UserName { get { return vUserName; } }
    public String EMP_ID { set { vEmp_Id = value; } get { return vEmp_Id; } }

    public String PTP_ID { set { vPtp_Id = value; } get { return vPtp_Id; } }

    public String CUST_ID { set { vCustID = value; } get { return vCustID; } }
    public String UserType { get { return vUserType; } }
    public static String FinYear { get { return vFinYear; } }
    public String EMT_ID { set { vEMT_ID = value; } get { return vEMT_ID; } }
    public String TICKET_ID { set { vTicketID = value; } get { return vTicketID; } }
    public String ReferedUrl { set { vReferedUrl = value; } get { return vReferedUrl; } }
    public String LOG_ID { set { vLOG_ID = value; } get { return vLOG_ID; } }
}

public class ATApp
{
    private String vCName, vCAddr, vCContact, vCEmail;

    public ATApp(String pCName, String pCAddr, String pCContact, String pCEmail)
    {
        vCName = pCName;
        vCAddr = pCAddr;
        vCContact = pCContact;
        vCEmail = pCEmail;
    }

    public String CName { get { return vCName; } }
    public String CAddr { get { return vCAddr; } }
    public String CContact { get { return vCContact; } }
    public String CEmail { get { return vCEmail; } }
}