using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class IEP_ExcelBulk : BasePage
{
    private ATSession vATSession;
    private DataTable dt;
    private SqlCommand cmd;
    private DataSet ds;

    private DataTable Dt;

    private string image_path;
    private SqlConnection vMySQLConnection;

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
            DataColumn DCAT_ID = new DataColumn();
            DCAT_ID.DataType = Type.GetType("System.String");
            DCAT_ID.ColumnName = "DCAT_ID";
            dt.Columns.Add(DCAT_ID);

            DataColumn DSCAT_ID = new DataColumn();
            DSCAT_ID.DataType = Type.GetType("System.String");
            DSCAT_ID.ColumnName = "DSCAT_ID";
            dt.Columns.Add(DSCAT_ID);

            DataColumn IEPMD_TEXT = new DataColumn();
            IEPMD_TEXT.DataType = Type.GetType("System.String");
            IEPMD_TEXT.ColumnName = "IEPMD_TEXT";
            dt.Columns.Add(IEPMD_TEXT);

            DataColumn IEPMD_DESC = new DataColumn();
            IEPMD_DESC.DataType = Type.GetType("System.String");
            IEPMD_DESC.ColumnName = "IEPMD_DESC";
            dt.Columns.Add(IEPMD_DESC);

            ViewState["datagrid"] = dt;
            BindGrid();

            try
            {
                ValidateUserAccess();
                if (vID != null)
                {
                    Hashtable vHashtable = new Hashtable();
                    DataTable dt1 = DBManager.Get(vHashtable, "SELECT * FROM  PRODUCT_BARCODES;");
                    DataRow vDR = RetDR(DBManager.Get(vHashtable, "SELECT * FROM  PRODUCT_BARCODES"));
                    if (vDR != null)
                    {
                        PRODUCT_CODE_TXT.Text = vDR["PROD_CODE"].ToString();
                        PRODUCT_CODE_TXT.Enabled = false;
                    }
                }
                else
                    ShowMsg("Invalid Product Barcode ID");
            }
            catch (Exception xe) { ShowMsg(xe); }
        }
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
    }

    private void ImporttoDatatable()
    {
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "Delete")
        {
            Label PROD_BARCODE = (Label)GridView1.Rows[index].FindControl("PROD_BARCODE");
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["PROD_BARCODE"].Equals(PRODUCT_BARCODE_TXT.Text))
                {
                    drow.Delete();
                    dt.AcceptChanges();

                    BindGrid();
                    break;
                }
            }
        }
    }

    public DataTable RemoveDuplicate(DataTable dt, string column)
    {
        Hashtable hash = new Hashtable();
        ArrayList aList = new ArrayList();
        foreach (DataRow row in dt.Rows)
        {
            if (hash.Contains(row[column]))
                aList.Add(row);
            else
                hash.Add(row[column], string.Empty);
        }

        foreach (DataRow Row in aList)
            dt.Rows.Remove(Row);

        return dt;
    }

    private void InsertData()
    {
    }

    protected DataTable BindDatatable()
    {
        String vID1 = Request.QueryString["ID"];
        DataTable dt = GetDatafromDatabase();
        return dt;
    }

    protected DataTable GetDatafromDatabase()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection("Data Source=49.50.77.154;Database=NERDNERDY;UID=sa;Pwd=M@inTer@Hero$2509#"))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select DCAT_NAME AS CATEGORY FROM DIS_CAT_MASTER", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }
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

    protected void btnIpload_Click(object sender, EventArgs e)
    {
        String vID1 = Request.QueryString["ID"];
        ImporttoDatatable();
    }

    protected void SAVE_Click(object sender, EventArgs e)
    {
        String vID1 = Request.QueryString["ID"];
        InsertData();
        Response.Redirect("Product.aspx");
    }

    private void BindGrid()
    {
        DataTable dt = (DataTable)ViewState["datagrid"];
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void Clear()
    {
    }
}