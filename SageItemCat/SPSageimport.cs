using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class SPSageimport
{
    private SPSageimport()
    {

    }

    public static DataTable insert(string tCLAXX, string tCLCOD)
    {
        using (SqlConnection connGetDistrict = ConnectionProvider.GetConnection())
        {
            try
            {
                SqlCommand cmdDistrict = new SqlCommand("InsertProductClassMastercustom", connGetDistrict);
                cmdDistrict.CommandType = CommandType.StoredProcedure;
                cmdDistrict.CommandTimeout = 250;
                //cmdDistrict.Parameters.Add("@flag", SqlDbType.Char).Value = "UpdateData";
                cmdDistrict.Parameters.Add("@Code", SqlDbType.NVarChar).Value = tCLCOD;
                cmdDistrict.Parameters.Add("@Description", SqlDbType.NVarChar).Value = tCLAXX;

                SqlDataAdapter da = new SqlDataAdapter(cmdDistrict);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (connGetDistrict.State == ConnectionState.Open)
                    connGetDistrict.Close();
            }
        }
    }
}