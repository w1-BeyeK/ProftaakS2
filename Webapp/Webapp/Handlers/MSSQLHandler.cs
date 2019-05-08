using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;

namespace Webapp.Handlers
{
    public class MSSQLHandler : IHandler
    {
        private readonly string conn;

        public MSSQLHandler(IConfiguration config)
        {
            string connection = config.GetConnectionString("Development");
            conn = connection ?? throw new ArgumentNullException("Missing connection strings");
        }

        public object ExecuteSelect(string query, object parameter = null)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlConnection = new SqlConnection(conn);
                //TODO : Why do you clear him?
                ds.Clear();
                using (SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection))
                {
                    da.Fill(ds);
                }
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object ExecuteSelect(string query, List<KeyValuePair<string, object>> parameters)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlConnection = new SqlConnection(conn);
                ds.Clear();
                using (SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection))
                {
                    da.Fill(ds);
                }
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object ExecuteCommand(string query, List<KeyValuePair<string, object>> parameters = null)
        {
            object value = null;
            SqlConnection sqlConnection = new SqlConnection(conn);
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    SqlParameter param;
                    parameters.ForEach(p =>
                    {
                        param = new SqlParameter
                        {
                            ParameterName = "@" + p.Key,
                            Value = p.Value.ToString()
                        };
                        cmd.Parameters.Add(param);
                    });
                    cmd.Connection.Open();
                    value = cmd.ExecuteScalar();
                    sqlConnection.Close();
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            return value;
        }
    }
}
