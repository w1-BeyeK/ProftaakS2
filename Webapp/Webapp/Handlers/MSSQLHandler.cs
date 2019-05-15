using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
        private int[] FindParameter(string query)
        {
            if (!query.Contains("@"))
                return new int[2] { -1, -1 };

            int begin = query.IndexOf('@') + 1;
            Regex reg = new Regex(@"^[a-zA-Z]+$");

            int end = 0;
            for(int i = begin + 1; i < query.Length; i++)
            {
                if (!reg.IsMatch(query[i].ToString()))
                {
                    end = i;

                    return new int[2] { begin, end };
                }
            }

            return new int[2] { begin, query.Length };
        }

        private string ReplaceParameter(string query, string name, object value)
        {
            return query = query.Replace($"@{name}", $"'{value.ToString()}'");
        }

        public object ExecuteSelect(string query, object parameter = null)
        {
            try
            {
                if (parameter != null)
                {
                    int[] indexes = FindParameter(query);
                    int length = indexes[1] - indexes[0];
                    string param = query.Substring(indexes[0], length);
                    query = ReplaceParameter(query, param, parameter);
                }

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

                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    query = ReplaceParameter(query, parameter.Key, parameter.Value);
                }

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
