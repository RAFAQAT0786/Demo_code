using System;
using System.Configuration;//ConfigurationManager
using System.Data;
using System.Data.SqlClient;
using System.IO; //FileStream
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;

public class ATCommon
{
    

    public static String GetMonthNumber(string MonthName)
    {
        return EnumHelper.EnumStringToInt<Month>(MonthName).ToString();
    }

    public static string GetListControlValues(ListControl checklist)
    {
        string selectedValues = "";
        foreach (ListItem item in checklist.Items)
        {
            if (item.Selected)
            {
                if (checklist.Items.Count > 1)
                    selectedValues += item.Value + ",";
                else
                    selectedValues = item.Value;
            }
        }
        selectedValues = selectedValues.TrimEnd(',');
        return selectedValues;
    }

    public static void AddColumnInDataTable(DataTable dataTable, string columnName, string dataType)
    {
        DataColumn dataColumn = new DataColumn();
        dataColumn.DataType = Type.GetType(dataType);
        dataColumn.ColumnName = columnName;
        dataTable.Columns.Add(dataColumn);
    }

    public static DateTime FormatToDate(TextBox textBox)
    {
        string[] dates = textBox.Text.Split('/');
        DateTime date_text = DateTime.Parse(string.Format("{0}/{1}/{2}", dates[1], dates[0], dates[2]));
        return date_text;
    }

    public static string FormatDate(TextBox textBox)
    {
        string month, day;
        string[] date = textBox.Text.Split('/');
        if (int.Parse(date[0]) < 10)
        {
            month = "0" + date[0];
        }
        else
            month = date[0];
        if (int.Parse(date[1]) < 10)
        {
            day = "0" + date[1];
        }
        else
            day = date[1];
        return string.Format("{0}/{1}/{2}", month, day, date[2]);
    }

    public static string FormatDateUI(TextBox textBox)
    {
        string month, day;
        string[] date = textBox.Text.Split('/');
        if (int.Parse(date[0]) < 10)
        {
            month = "0" + date[0];
        }
        else
            month = date[0];
        if (int.Parse(date[1]) < 10)
        {
            day = "0" + date[1];
        }
        else
            day = date[1];
        return string.Format("{0}/{1}/{2}", day, month, date[2]);
    }

    public static void SendMail(String pTo, String pSub, String pBody, ATApp pApp)
    {
        MailMessage vMailMessage = new MailMessage("info@nerdnerdy.in", pTo + ",info@nerdnerdy.in", pSub, pBody);
        SmtpClient vSmtpClient = new SmtpClient("webmail.nerdnerdy.in");
        vSmtpClient.Credentials = new NetworkCredential("info@nerdnerdy.in", "Re@dyToFly$18378#");
        vSmtpClient.Send(vMailMessage);
        //MailMessage vMailMessage = new MailMessage("info@dev.nerdnerdy.com", pTo + ",info@dev.nerdnerdy.com", pSub, pBody);
        //SmtpClient vSmtpClient = new SmtpClient("devmail.nerdnerdy.in");
        //vSmtpClient.Credentials = new NetworkCredential("info@dev.nerdnerdy.com", "nerdnerdy@123");
        //vSmtpClient.Send(vMailMessage);
        //vSmtpClient.EnableSsl = false;
    }
    public static String WhereDate(GrayMatterSoft.GMDatePicker pGMDate) //used in WHERE CLAUSE
    {
        return pGMDate.Date.ToString("MMddyyyy");
    }

    public static String WhereDate(DateTime pGMDate) //used in WHERE CLAUSE
    {
        return pGMDate.ToString("MMddyyyy");
    }

    public static byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream img = new MemoryStream();
        imageIn.Save(img, System.Drawing.Imaging.ImageFormat.Gif);
        return img.ToArray();
    }

    public static String datediff(string from, string to) //used in WHERE CLAUSE
    {
        DateTime fromdate = DateTime.Parse(from);
        DateTime todate = DateTime.Parse(to);
        TimeSpan tm = todate.Subtract(fromdate);
        return tm.TotalDays.ToString();
    }

    public static String coutdays(string from, string to) //used in WHERE CLAUSE
    {
        string days = "";
        string nodate = datediff(from, to);
        DateTime fromdate = DateTime.Parse(from);

        for (int i = 0; i <= int.Parse(nodate); i++)
        {
            DateTime date = fromdate.AddDays(i);
            days += date.DayOfWeek + ",";
        }

        return days;
    }

    public static SqlConnection GetConnection()
    {
        SqlConnection vConnection = null;
        try
        {
            String vConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            vConnection = new SqlConnection(vConnectionString);
            vConnection.Open();
        }
        catch (Exception xe) { xe.ToString(); }
        return vConnection;
    }

    public static void FillDrpDown(ListControl pDropDown, System.Data.DataTable pDataTable, String pFirstItem, String pTextField, String pValueField, String pFirstValue)
    {
        pDropDown.Items.Clear();
        if (pFirstItem != "")
        {
            System.Web.UI.WebControls.ListItem vListItem = new System.Web.UI.WebControls.ListItem("-- " + pFirstItem + " --", pFirstValue);
            pDropDown.Items.Add(vListItem);
        }

        foreach (DataRow vDr in pDataTable.Rows)
        {
            System.Web.UI.WebControls.ListItem vListItem = new System.Web.UI.WebControls.ListItem(vDr[pTextField].ToString().Trim(), vDr[pValueField].ToString().Trim());
            pDropDown.Items.Add(vListItem);
        }
    }

    public static void FillSearchCMB(ListControl pDropDown, System.Data.DataTable pDataSet, String pFirstItem, String pTextField, String pValueField, String pFirstValue)
    {
        pDropDown.Items.Clear();
        if (pFirstItem != "")
        {
            System.Web.UI.WebControls.ListItem vListItem1 = new System.Web.UI.WebControls.ListItem("-- " + pFirstItem + " --", pFirstValue);
            pDropDown.Items.Add(vListItem1);
            System.Web.UI.WebControls.ListItem vListItem2 = new System.Web.UI.WebControls.ListItem("All", "0");
            pDropDown.Items.Add(vListItem2);
        }
        pDropDown.AppendDataBoundItems = true;
        pDropDown.DataSource = pDataSet;
        pDropDown.DataTextField = pTextField;
        pDropDown.DataValueField = pValueField;
        pDropDown.DataBind();
    }

    public static void FillCUSTOMER(ListControl pDropDown, System.Data.DataTable pDataSet, String pFirstItem, String pTextField, String pValueField, String pFirstValue)
    {
        pDropDown.Items.Clear();
        if (pFirstItem != "")
        {
            System.Web.UI.WebControls.ListItem vListItem = new System.Web.UI.WebControls.ListItem("-- " + pFirstItem + " --", pFirstValue);
            pDropDown.Items.Add(vListItem);
        }

        for (int i = 0; i < pDataSet.Rows.Count; i++)
        {
            pDropDown.Items.Add(new ListItem(pDataSet.Rows[i]["CUST_NAME"].ToString().Replace("_", " "), pDataSet.Rows[i]["CUST_ID"].ToString()));
        }
    }

    public static void FillCDWR(ListControl pDropDown, System.Data.DataTable pDataSet, String pFirstItem, String pTextField, String pValueField, String pFirstValue)
    {
        pDropDown.Items.Clear();
        pDropDown.AppendDataBoundItems = true;
        pDropDown.DataSource = pDataSet;
        pDropDown.DataTextField = pTextField;
        pDropDown.DataValueField = pValueField;
        pDropDown.DataBind();
    }

    public static void BindGrid(String pQry, Repeater pControl)
    {
        DataTable vDataTable = (pQry != "" ? RetDT(pQry) : null);
        pControl.DataSource = vDataTable;
        pControl.DataBind();
    }

    public static void BindGrid(String pQry, GridView pControl)
    {
        DataTable vDataTable = RetDT(pQry);
        DataRow vDR = null;
        if (vDataTable.Rows.Count == 0)
        {
            vDR = vDataTable.NewRow();
            vDataTable.Rows.Add(vDR);
        }
        pControl.DataSource = vDataTable;
        pControl.DataBind();
        if (vDR != null)
        {
            pControl.Rows[0].Visible = false;
        }
    }

    public static System.Data.DataTable RetDT(String pQry)
    {
        using (SqlConnection vConnection = ATCommon.GetConnection())
        {
            SqlDataAdapter vDataAdapter = new SqlDataAdapter(pQry, vConnection);
            DataSet vDataSet = new DataSet();
            vDataAdapter.Fill(vDataSet);
            return vDataSet.Tables[0].Copy();
        }
    }

    public static DataRow RetDR(String pQry)
    {
        DataTable vDT = RetDT(pQry);
        DataRow vDR = null;
        if (vDT.Rows.Count > 0)
            vDR = vDT.Rows[0];
        return vDR;
    }

}