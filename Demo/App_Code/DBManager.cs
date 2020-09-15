//using MySqlConnector;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public class DBManager
{
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

    public static String GetMax(Hashtable pParameterValues, String pQueryCode)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                AddParameters(pParameterValues, ref vSqlCommand);

                object Max = vSqlCommand.ExecuteScalar();
                int MaxNum = Convert.ToInt16(Max);
                return MaxNum.ToString();
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static void ExecInsUpsol(Hashtable vhash, string v)
    {
        throw new NotImplementedException();
    }

    public static DataTable Get(Hashtable pParameterValues, String pQueryCode)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);

                vSqlCommand.CommandType = CommandType.StoredProcedure;
                vSqlCommand.CommandTimeout = 0;
                AddParameters(pParameterValues, ref vSqlCommand);

                DataTable vDataTable = new DataTable();
                vDataTable.Load(vSqlCommand.ExecuteReader());
                return vDataTable;
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static string Get_CODE(string pQueryCode)
    {
        string code = "";
        SqlConnection vSqlConnection = DBManager.GetConnection();
        try
        {
            SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
            vSqlCommand.CommandType = CommandType.StoredProcedure;
            object num = vSqlCommand.ExecuteScalar();
            if (!num.Equals(DBNull.Value))
                num = Convert.ToInt32(num) + 1;
            else
                num = 1;
            code = num.ToString();
        }
        catch (SqlException xe)
        {
            throw new Exception(xe.ToString());
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
        finally { vSqlConnection.Close(); }
        return code;
    }

    public static DataTable GetOutput(Hashtable pParameterValues, String pQueryCode, ref int Total)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                AddParameters(pParameterValues, ref vSqlCommand);

                DataTable vDataTable = new DataTable();
                vDataTable.Load(vSqlCommand.ExecuteReader());
                if (pParameterValues.Contains("Total") == true)
                    Total = (int)vSqlCommand.Parameters["Total"].Value;
                return vDataTable;
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static DataSet GetDataSet(Hashtable pParameterValues, String pQueryCode)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                AddParameters(pParameterValues, ref vSqlCommand);

                DataSet vDataSet = new DataSet();
                SqlDataAdapter vDa = new SqlDataAdapter(vSqlCommand);
                vDa.Fill(vDataSet);
                return vDataSet;
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static Boolean Exist(Hashtable pParameterValues, String pQueryCode)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                AddParameters(pParameterValues, ref vSqlCommand);
                Object o = vSqlCommand.ExecuteScalar();
                Boolean vVal = ((int)o == 0 ? true : false);
                return vVal;
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static object GET_PHOTO(string ID, String pQueryCode)
    {
        object PHOTO = null;
        SqlConnection vSqlConnection = DBManager.GetConnection();
        try
        {
            SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
            vSqlCommand.CommandType = CommandType.StoredProcedure;
            vSqlCommand.Parameters.Add(new SqlParameter("ID", ID));
            PHOTO = vSqlCommand.ExecuteScalar();
        }
        catch (SqlException xe)
        {
            throw new Exception(xe.ToString());
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
        finally { vSqlConnection.Close(); }
        return PHOTO;
    }

    public static string EMP_CODE()
    {
        string code = "";
        SqlConnection vSqlConnection = DBManager.GetConnection();
        try
        {
            SqlCommand vSqlCommand = new SqlCommand("GET_EMP_CODE", vSqlConnection);
            vSqlCommand.CommandType = CommandType.StoredProcedure;
            object num = vSqlCommand.ExecuteScalar();
            if (!num.Equals(DBNull.Value))
                num = Convert.ToInt32(num) + 1;
            else
                num = 1;
            code = num.ToString();
        }
        catch (SqlException xe)
        {
            throw new Exception(xe.ToString());
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
        finally { vSqlConnection.Close(); }
        return code;
    }

    public static void DeleteadminRec(string VID, String pQueryCode)
    {
        SqlConnection vSqlConnection = DBManager.GetConnection();
        try
        {
            SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
            vSqlCommand.CommandType = CommandType.StoredProcedure;
            vSqlCommand.Parameters.Add(new SqlParameter("CUST_ID", VID));
            vSqlCommand.ExecuteNonQuery();
        }
        catch (SqlException xe)
        {
            throw new Exception(xe.ToString());
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
        finally { vSqlConnection.Close(); }
    }

    public static void ExecDel(Hashtable pParameterValues, String pQueryCode)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                AddParameters(pParameterValues, ref vSqlCommand);
                vSqlCommand.ExecuteNonQuery();
            }
        }
        catch (SqlException xe)
        {
            throw new Exception(xe.ToString());
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static bool ExecInsUpsReturn(Hashtable pParameterValues, String pQueryCode, ATSession pATSession)
    {
        bool flag = false;
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator vEnumerator = pParameterValues.GetEnumerator();
                AddParameters(pParameterValues, ref vSqlCommand);
                SqlParameter vSqlParameter = new SqlParameter();
                vSqlParameter.ParameterName = "last_user";
                vSqlParameter.Value = pATSession.Login;
                vSqlParameter.Direction = ParameterDirection.Input;
                vSqlParameter.SqlDbType = SqlDbType.VarChar;
                vSqlCommand.Parameters.Add(vSqlParameter);
                vSqlCommand.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
        return flag;
    }

    public static void ExecInsUps(Hashtable pParameterValues, String pQueryCode, ATSession pATSession)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator vEnumerator = pParameterValues.GetEnumerator();
                AddParameters(pParameterValues, ref vSqlCommand);

                SqlParameter vSqlParameter = new SqlParameter();
                vSqlParameter.ParameterName = "last_user";
                vSqlParameter.Value = pATSession.Login;
                vSqlParameter.Direction = ParameterDirection.Input;
                vSqlParameter.SqlDbType = SqlDbType.VarChar;
                vSqlCommand.Parameters.Add(vSqlParameter);
                vSqlCommand.ExecuteNonQuery();
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static DataTable ExecInsUpsGet(Hashtable pParameterValues, String pQueryCode, String pProcedure, ATSession pATSession)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator vEnumerator = pParameterValues.GetEnumerator();
                AddParameters(pParameterValues, ref vSqlCommand);

                SqlParameter vSqlParameter = new SqlParameter();
                vSqlParameter.ParameterName = "last_user";
                vSqlParameter.Value = pATSession.Login;
                vSqlParameter.Direction = ParameterDirection.Input;
                vSqlParameter.SqlDbType = SqlDbType.VarChar;
                vSqlCommand.Parameters.Add(vSqlParameter);
                SqlParameter vSqlParamReturn = new SqlParameter("@Return", SqlDbType.Int);
                vSqlParamReturn.Direction = ParameterDirection.Output;
                vSqlCommand.Parameters.Add(vSqlParamReturn);
                vSqlCommand.ExecuteNonQuery();
                String vReturn = vSqlParamReturn.Value.ToString();
                Hashtable vHT = new Hashtable();
                vHT.Add("ID", vReturn);
                DataTable vDataTable = Get(vHT, pProcedure);
                return vDataTable;
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static string ExecInsUpsGetId(Hashtable pParameterValues, String pQueryCode, ATSession pATSession)
    {
        try
        {
            using (SqlConnection vSqlConnection = DBManager.GetConnection())
            {
                SqlCommand vSqlCommand = new SqlCommand(pQueryCode, vSqlConnection);
                vSqlCommand.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator vEnumerator = pParameterValues.GetEnumerator();
                AddParameters(pParameterValues, ref vSqlCommand);

                SqlParameter vSqlParameter = new SqlParameter();
                vSqlParameter.ParameterName = "last_user";
                vSqlParameter.Value = pATSession.Login;
                vSqlParameter.Direction = ParameterDirection.Input;
                vSqlParameter.SqlDbType = SqlDbType.VarChar;
                vSqlCommand.Parameters.Add(vSqlParameter);
                SqlParameter vSqlParamReturn = new SqlParameter("@Return", SqlDbType.Int);
                vSqlParamReturn.Direction = ParameterDirection.Output;
                vSqlCommand.Parameters.Add(vSqlParamReturn);
                vSqlCommand.ExecuteNonQuery();
                String vReturn = vSqlParamReturn.Value.ToString();
                return vReturn;
            }
        }
        catch (Exception xe)
        {
            throw new Exception(xe.ToString());
        }
    }

    public static void AddParameters(Hashtable pParameterValues, ref SqlCommand pSqlCommand)
    {
        IDictionaryEnumerator vEnumerator = pParameterValues.GetEnumerator();
        while (vEnumerator.MoveNext())
        {
            String vKey = vEnumerator.Key.ToString();

            object vInfo = vEnumerator.Value;
            SqlParameter vSqlParameter = new SqlParameter();
            vSqlParameter.ParameterName = vKey;
            vSqlParameter.Value = vInfo;
            if (vSqlParameter.ParameterName == "EMP_DEP_ID" || vSqlParameter.ParameterName == "EMP_DEP_ID" || vSqlParameter.ParameterName == "EMP_DES_ID")// || vSqlParameter.ParameterName == "CDWR_ID" || vSqlParameter.ParameterName == "CDWR_CUST_ID" || vSqlParameter.ParameterName == "CDWR_VDWR_ID")
            {
                vSqlParameter.Direction = ParameterDirection.Input;
                vSqlParameter.SqlDbType = SqlDbType.Int;
            }
            else if (vSqlParameter.ParameterName == "EMP_PHOTO" || vSqlParameter.ParameterName == "CUST_PHOTO")
            {
                vSqlParameter.Direction = ParameterDirection.Input;
                vSqlParameter.SqlDbType = SqlDbType.Image;
            }
            else if (vSqlParameter.ParameterName == "TST_DEATIL")
            {
                vSqlParameter.Direction = ParameterDirection.Input;
                vSqlParameter.SqlDbType = SqlDbType.Structured;
            }
            else
            {
                vSqlParameter.Direction = ParameterDirection.Input;
                vSqlParameter.SqlDbType = SqlDbType.VarChar;
            }

            pSqlCommand.Parameters.Add(vSqlParameter);
        }
    }


    //MY SQL CONNECTION 

    //public static MySqlConnection GetMyConnection()
    //{
    //    MySqlConnection vMyConnection = null;
    //    try
    //    {
    //        String vConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
    //        vMyConnection = new MySqlConnection(vConnectionString);
    //        vMyConnection.Open();
    //    }
    //    catch (Exception xe) { xe.ToString(); }
    //    return vMyConnection;
    //}

    //public static DataTable GetMysql(Hashtable pParameterValues, String pQueryCode)
    //{
    //    try
    //    {
    //        using (MySqlConnection vMySqlConnection = DBManager.GetMyConnection())
    //        {
    //            MySqlCommand vMySqlCommand = new MySqlCommand(pQueryCode, vMySqlConnection);

    //            vMySqlCommand.CommandType = CommandType.StoredProcedure;
    //            vMySqlCommand.CommandTimeout = 0;
    //            AddParameters(pParameterValues, ref vMySqlCommand);

    //            DataTable vDataTable = new DataTable();
    //            vDataTable.Load(vMySqlCommand.ExecuteReader());
    //            return vDataTable;
    //        }
    //    }
    //    catch (Exception xe)
    //    {
    //        throw new Exception(xe.ToString());
    //    }
    //}

    //---- MYSQL Connection for Master Database
    public static MySqlConnection vGetMySQLConnection()
    {
        MySqlConnection vMySQLConnection = null;
        try
        {
            String vMySQLConnectionString = ConfigurationManager.ConnectionStrings["ConMySQL"].ConnectionString;
            vMySQLConnection = new MySqlConnection(vMySQLConnectionString);
            vMySQLConnection.Open();
        }
        catch (Exception xe) { xe.ToString(); }
        return vMySQLConnection;
    }
    public static DataTable GetMasterData(Hashtable pParameterValues, String pQueryCode)
    {

        try
        {
            using (MySqlConnection vMySQLConnection = DBManager.vGetMySQLConnection())
            {
                MySqlCommand vMySqlCommand = new MySqlCommand(pQueryCode, vMySQLConnection);

                vMySqlCommand.CommandType = CommandType.Text;
                vMySqlCommand.CommandTimeout = 0;
                //AddParameters(pParameterValues, ref vMySqlCommand);

                DataTable vDataTable = new DataTable();
                vDataTable.Load(vMySqlCommand.ExecuteReader());
                return vDataTable;
            }
        }
        catch (Exception xe)
        {
            //pTraceLog.WriteLog("ExecSP: " + xe);
            throw new Exception(xe.ToString());
        }
    }
    public static void ExecMySQLInsUps(Hashtable pParameterValues, String pQueryCode, ATSession pATSession)
    {
        try
        {
            using (MySqlConnection vMySqlConnection = DBManager.vGetMySQLConnection())
            {
                MySqlCommand vMySqlCommand = new MySqlCommand(pQueryCode, vMySqlConnection);
                vMySqlCommand.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator vEnumerator = pParameterValues.GetEnumerator();
                AddParameters(pParameterValues, ref vMySqlCommand);

                MySqlParameter vMySqlParameter = new MySqlParameter();
                vMySqlParameter.ParameterName = "LASTUSER";
                vMySqlParameter.Value = pATSession.Login;
                vMySqlParameter.Direction = ParameterDirection.Input;
                vMySqlParameter.MySqlDbType = MySqlDbType.VarChar;
                vMySqlCommand.Parameters.Add(vMySqlParameter);
                vMySqlCommand.ExecuteNonQuery();
            }
        }
        catch (Exception xe)
        {
            //pTraceLog.WriteLog("ExecSP: " + xe);
            throw new Exception(xe.ToString());
        }
    }
    public static DataTable ExecInsUpsMyGet(Hashtable pParameterValues, String pQueryCode, String pProcedure, ATSession pATSession)
    {
        try
        {
            using (MySqlConnection vMySqlConnection = DBManager.vGetMySQLConnection())
            {
                MySqlCommand vMySqlCommand = new MySqlCommand(pQueryCode, vMySqlConnection);
                vMySqlCommand.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator vEnumerator = pParameterValues.GetEnumerator();
                AddParameters(pParameterValues, ref vMySqlCommand);

                MySqlParameter vMySqlParameter = new MySqlParameter();
                vMySqlParameter.ParameterName = "last_user";
                vMySqlParameter.Value = pATSession.Login;
                vMySqlParameter.Direction = ParameterDirection.Input;
                vMySqlParameter.MySqlDbType = MySqlDbType.VarChar;
                vMySqlCommand.Parameters.Add(vMySqlParameter);
                MySqlParameter vMySqlParamReturn = new MySqlParameter("@Return", MySqlDbType.Int24);
                vMySqlParamReturn.Direction = ParameterDirection.Output;
                vMySqlCommand.Parameters.Add(vMySqlParamReturn);
                vMySqlCommand.ExecuteNonQuery();
                String vReturn = vMySqlParamReturn.Value.ToString();
                Hashtable vHT = new Hashtable();
                vHT.Add("ID", vReturn);
                DataTable vDataTable = Get(vHT, pProcedure);
                return vDataTable;
            }
        }
        catch (Exception xe)
        {
            //pTraceLog.WriteLog("ExecSP: " + xe);
            throw new Exception(xe.ToString());
        }
    }
    public static void AddParameters(Hashtable pParameterValues, ref MySqlCommand vMySqlCommand)
    {
        IDictionaryEnumerator vEnumerator = pParameterValues.GetEnumerator();
        while (vEnumerator.MoveNext())
        {
            String vKey = vEnumerator.Key.ToString();

            object vInfo = vEnumerator.Value;//String[] vInfo = (String[])vEnumerator.Value;
            MySqlParameter vMySqlParameter = new MySqlParameter();
            vMySqlParameter.ParameterName = vKey;
            vMySqlParameter.Value = vInfo;//vSqlParameter.ParameterName == "Total" ||output
            vMySqlParameter.Direction = ParameterDirection.Input;
            vMySqlParameter.MySqlDbType = MySqlDbType.VarChar;
            vMySqlCommand.Parameters.Add(vMySqlParameter);
        }
    }


}