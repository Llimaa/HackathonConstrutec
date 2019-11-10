using PR.Infra.Infra;
using System.Data;
using System.Data.SqlClient;

namespace PR.API.Context
{
    public class MSSQLDB : IDB
    {
        SqlConnection con;
        string strcon;
        public MSSQLDB(IDBConfiguration configuration)
        {
            strcon = configuration.ConnectionString;
        }
        public void Dispose()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Dispose();
        }

        public IDbConnection GetCon()
        {
            if (con == null || con.State != ConnectionState.Open)
                con = new SqlConnection(strcon);

            con.Open();
            return con;
        }
    }
}
