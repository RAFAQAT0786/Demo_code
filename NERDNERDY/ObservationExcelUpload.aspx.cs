using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public partial class ObservationExcelUpload : BasePage
{
    private ATSession vATSession;
    private DataTable dt;
    private DataTable dt1;
    private DataTable dt2;
    private string image_path;
    private SqlConnection vMySQLConnection;
    private SqlCommand cmd;
    private DataSet ds;
    private DataTable Dt;

    protected override void OnPreInit(EventArgs e)
    {
        SetMasterPage(Page);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
        if (!IsPostBack)
        {
            dt = new DataTable();
            DataColumn DOBS_DESC = new DataColumn();
            DOBS_DESC.DataType = Type.GetType("System.String");
            DOBS_DESC.ColumnName = "DOBS_DESC";
            dt.Columns.Add(DOBS_DESC);

            dt = new DataTable();
            DataColumn DOBS_ID = new DataColumn();
            DOBS_ID.DataType = Type.GetType("System.String");
            DOBS_ID.ColumnName = "DOBS_ID";
            dt.Columns.Add(DOBS_ID);

            ViewState["datagrid"] = dt;
            BindGrid();

            try
            {
                ValidateUserAccess();
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertData();
        Response.Redirect("ObservationExcelUpload.aspx");
    }

    protected void BindGrid()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void ImporttoDatatable()
    {
        string conStr = "";
        if (FlUploadcsv.HasFile)
        {
            string fileName = Path.GetFileName(FlUploadcsv.FileName);
            string fileExtension = Path.GetExtension(FlUploadcsv.FileName);
            string filePath = string.Concat(Server.MapPath("~/ExcelReports/" + FlUploadcsv.FileName));
            FlUploadcsv.PostedFile.SaveAs(filePath);

            if (fileExtension.Trim() == ".xls")
            {
                conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (fileExtension.Trim() == ".xlsx")
            {
                conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            conStr = String.Format(conStr, filePath);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt1 = new DataTable();
            cmdExcel.Connection = connExcel;

            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            connExcel.Open();
            cmdExcel.CommandText = "SELECT * FROM [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt1);
            connExcel.Close();

            Dt = RemoveDuplicate(dt1, "DESCRIBE");
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            ATSession atSession;
            String vID = Request.QueryString["ID"];
            atSession = (ATSession)HttpContext.Current.Session["A"];
            string strCon = "Server=" + "49.50.77.154" + ";UID=" + "sa" + ";Pwd=" + "M@inTer@Hero$2509#" + ";Database=" + "NERD_NERDNERDY" + "";
            SqlConnection con = new SqlConnection(strCon);
            if (GridView1.Rows.Count >= 1)
            {
                con.Open();
                try
                {
                    string[] Rows = new string[GridView1.Rows.Count];
                    string count = GridView1.Rows.Count.ToString();

                    for (int countRow = 0; countRow < GridView1.Rows.Count; countRow++)
                    {
                        Label DOBS_DESC = (GridView1.Rows[countRow].Cells[0].FindControl("DOBS_DESC") as Label);
                        Rows[countRow] = "'" + DOBS_DESC.Text + "'";
                    }

                    string strSelect = string.Format("SELECT DOBS_DESC FROM DIS_OBSV_MASTER WHERE DOBS_DESC in ({0})", string.Join(", ", Rows));
                    SqlDataAdapter da = new SqlDataAdapter(strSelect, con);
                    DataTable dt2 = new DataTable();
                    da.Fill(dt2);
                    dt1.Merge(dt2);

                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    con.Close();
                }
                catch
                {
                }
            }
            string destinationFile = filePath;
            File.Delete(destinationFile);
        }
    }

    public DataTable RemoveDuplicate(DataTable dt3, string column)
    {
        Hashtable hash = new Hashtable();
        ArrayList aList = new ArrayList();
        foreach (DataRow row in dt3.Rows)
        {
            if (hash.Contains(row[column]))
                aList.Add(row);
            else
                hash.Add(row[column], string.Empty);
        }

        foreach (DataRow Row in aList)
            dt3.Rows.Remove(Row);

        return dt3;
    }

    private void InsertData()
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            Label DOBS_DESC = (gvrow.Cells[0].FindControl("DOBS_DESC") as Label);

            string str;
            ATSession atSession;
            bool readerHasRows = false;
            atSession = (ATSession)HttpContext.Current.Session["A"];
            string MyConnection2 = "Server=" + "49.50.77.154" + ";UID=" + "sa" + ";Pwd=" + "M@inTer@Hero$2509#" + ";Database=" + "NERD_NERDNERDY" + "";
            SqlConnection con = new SqlConnection(MyConnection2);
            con.Open();
            string PROD_NAME1 = DOBS_DESC.Text;
            string cmd = "select DOBS_DESC from DIS_OBSV_MASTER where DOBS_DESC=@PROD_NAME1";
            using (SqlCommand cmd1 = new SqlCommand(cmd, con))
            {
                cmd1.Parameters.AddWithValue("@PROD_NAME1", PROD_NAME1);
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    readerHasRows = (reader != null && reader.HasRows);
                }
            }

            if (readerHasRows)
            {
                string message = "Product Name Already Exists!!";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                string sql = "INSERT INTO DIS_OBSV_MASTER(DOBS_DESC,DEL_STATUS,TIME_STAMP,LAST_USER)";
                sql += "VALUES('" + DOBS_DESC.Text + "','" + 'N' + "','" + DateTime.Now + "','" + "ADMIN" + "')";
                SqlCommand cmd1 = new SqlCommand(sql, con);
                cmd1.ExecuteNonQuery();
            }
            con.Close();
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        String vID1 = Request.QueryString["ID"];
        ImporttoDatatable();
    }

    protected DataTable BindDatatable()
    {
        String vID1 = Request.QueryString["ID"];
        DataTable dt = new DataTable();
        dt.Columns.Add("DESCRIBE", typeof(string));
        return dt;
    }

    protected void btnExcelload_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.ContentType = "application/vnd-ms.excel";
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Sheet1.xls"));
        DataTable dt = BindDatatable();
        string str = string.Empty;
        foreach (DataColumn dtcol in dt.Columns)
        {
            Response.Write(str + dtcol.ColumnName);
            str = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            str = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                Response.Write(str + Convert.ToString(dr[j]));
                str = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }

    public void ObjectDatasource1_Deleted(object source, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            ShowMsg(e.Exception.InnerException.Message);
            e.ExceptionHandled = true;
        }
        else
        {
            ShowMsg(-1);
        }
    }

    protected void existence_ServerValidate(object source, ServerValidateEventArgs args)
    {
    }
}