using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    class SqlDBHelper
    {
        //Connection string for MySql DB with account information.
        const string CONNECTION_STRING = @"Server=localhost;Uid=testAccount;Pwd=password;Database=employee";

        /// <summary>
        /// This function will be used to execute R(CRUD) operation of parameterless commands
        /// 
        /// </summary>
        /// <param name="CommandName">Command name</param>
        /// <param name="cmdType">Command Type</param>
        /// <returns>Table Data</returns>
        internal static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            DataTable table = null;
            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }

                        con.Close();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return table;
        }
        /***
        /// <summary>
        /// This function will be used to execute CUD(CRUD) operation of parameterized commands
        /// 
        /// </summary>
        /// <param name="CommandName">Command Name</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="pars">Parameters</param>
        /// <returns>Boolean</returns>
        internal static bool ExecuteNonQuery(string CommandName, CommandType cmdType, MySqlParameter[] pars)
        {
            int result = 0;

            using (MySqlConnection con = new MySqlConnection(CONNECTION_STRING))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        result = cmd.ExecuteNonQuery();

                        con.Close();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return (result > 0);
        }***/
    }
}
