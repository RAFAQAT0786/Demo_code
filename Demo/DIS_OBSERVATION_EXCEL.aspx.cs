using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public partial class DIS_OBSERVATION_EXCEL : BasePage
{
    private ATSession vATSession;
    private DataTable dt;
    private SqlCommand cmd;
    private DataSet ds;

    private DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        vATSession = (ATSession)Session["User"];
        if (vATSession == null)
            Response.Redirect("Default.aspx");
        String vID = Request.QueryString["ID"];
        if (!IsPostBack)
        {
        }
    }

    private void ImporttoDatatable()

    {
        try

        {
            if (FlUploadcsv.HasFile)

            {
                string FileName = FlUploadcsv.FileName;

                string path = string.Concat(Server.MapPath("~/ExcelReports/" + FlUploadcsv.FileName));

                FlUploadcsv.PostedFile.SaveAs(path);

                OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", OleDbcon);

                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);

                ds = new DataSet();

                objAdapter1.Fill(ds);

                Dt = ds.Tables[0];
                Dt = RemoveDuplicate(Dt, "DOBS_DESC");
                GridView1.Caption = Path.GetFileName(path);
                GridView1.DataSource = Dt;
                GridView1.DataBind();
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please select the file";
            }
        }
        catch (Exception ex)

        {
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
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            Label DOBS_DESC = (gvrow.Cells[0].FindControl("DOBS_DESC") as Label);

            ATSession atSession;
            String vID2 = Request.QueryString["ID"];
            string constr1;
            IFormatProvider culture = new CultureInfo("fr-Fr", true);

            constr1 = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr1);
            con.Open();
            string sql = "INSERT INTO DIS_OBSV_MASTER(DOBS_DESC,DEL_STATUS,TIME_STAMP,LAST_USER)";
            sql += "VALUES('" + DOBS_DESC.Text + "','" + 'N' + "','" + DateTime.Now + "','" + vATSession.Login + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    protected DataTable BindDatatable()
    {
        String vID1 = Request.QueryString["ID"];
        DataTable dt = new DataTable();
        dt.Columns.Add("DOBS_DESC", typeof(string));
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
        ImporttoDatatable();
    }

    protected void SAVE_Click(object sender, EventArgs e)
    {
        InsertData();
        BindGrid();
    }

    private void BindGrid()
    {
        DataSet ds = new DataSet();
        string cmdstr = "Select * from DIS_OBSV_MASTER";
        string constr1;
        IFormatProvider culture = new CultureInfo("fr-Fr", true);

        constr1 = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, constr1);
        SqlConnection con = new SqlConnection(constr1);
        con.Open();
        adp.Fill(ds);

        GridView1.DataSource = ds;
        GridView1.DataBind();
        ds.Dispose();
        con.Close();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        string constr1;
        IFormatProvider culture = new CultureInfo("fr-Fr", true);
        constr1 = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(constr1);
        con.Open();
        string query = "Select * from DIS_OBSV_MASTER";
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Excelfiledemo");
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        con.Close();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["excelconn"].ToString()))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select DOBS_DESC from DIS_OBSV_MASTER where id=@id", con);
            cmd.Parameters.AddWithValue("id", GridView1.SelectedRow.Cells[1].Text);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = dr["type"].ToString();
                // to open file prompt Box open or Save file
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["Name"].ToString());

                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["data"]);
                Response.End();
            }
        }
    }

    public void Clear()
    {
    }

    protected void existence_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (TXTID.Value == "0")
        {
            DataTable Dt = DBManager.Get(new Hashtable(), "EXISTDISOBSVMASTER");
            foreach (DataRow DR in Dt.Rows)
            {
                if (DR["DOBS_DESC"].ToString().Equals(args.Value))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }
    }
}