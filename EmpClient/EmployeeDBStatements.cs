using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class EmployeeDBStatements
    {
        public class SQLstatements
        {
            private MySqlConnection _connection;
            private String _server;
            private String _DB;
            private String _UID;
            private String _PWD;

            public SQLstatements()
            {
                Init();
            }

            /// <summary>
            /// Initialize connection string.
            /// </summary>
            private void Init()
            {
                _server = "localhost";
                _DB = "employee";
                _UID = "testAccount";
                _PWD = "password";
                string connectionString;
                connectionString = "SERVER=" + _server + ";" + "DATABASE=" +
                _DB + ";" + "UID=" + _UID + ";" + "PASSWORD=" + _PWD + ";";

                _connection = new MySqlConnection(connectionString);
            }

            /// <summary>
            /// Open DB connection.
            /// </summary>
            /// <returns>Boolean</returns>
            private bool OpenConnection()
            {
                try
                {
                    _connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    //When handling errors, you can manage your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            Console.WriteLine("Cannot connect to server.  Contact administrator");
                            //MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            Console.WriteLine("Invalid username/password, please try again");
                            //MessageBox.Show("Invalid username/password, please try again");
                            break;
                    }
                    return false;
                }
            }

            //Close connection
            private bool CloseConnection()
            {
                try
                {
                    _connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    //MessageBox.Show(ex.Message);
                    return false;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="employee"></param>
            /// <returns></returns>
            public bool DeleteEmployee(int empID)
            {
                string query = "DELETE FROM edata where emID = " + "'" + empID + "'";
                int result = 0;

                try
                {

                    //Open Connection
                    if (this.OpenConnection())
                    {
                        //Create Mysql Command
                        MySqlCommand cmd = new MySqlCommand(query, _connection);
                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();
                    }

                    if (result > 0)
                        return true;

                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            /***
            public bool UpdateEmployee(Employee employee)
            {
                MySqlParameter[] parameters = new MySqlParameter[]
                {
                new MySqlParameter("in_emID", employee.EmployeeID),
                new MySqlParameter("in_lastname", employee.LastName),
                new MySqlParameter("in_firstname", employee.FirstName),
                new MySqlParameter("in_title", employee.Title),
                new MySqlParameter("in_address", employee.Address),
                new MySqlParameter("in_city", employee.City),
                new MySqlParameter("in_region", employee.Region),
                new MySqlParameter("in_postal", employee.PostalCode),
                new MySqlParameter("in_country", employee.Country),
                new MySqlParameter("in_ext", employee.Extension),
                new MySqlParameter("in_salary", employee.Salary),
                new MySqlParameter("in_dept", employee.Department),
                new MySqlParameter("in_sup", employee.Supervisor),
                new MySqlParameter("in_tenure", employee.Tenure)
                };

                return SqlDBHelper.ExecuteNonQuery("UpdateEmployee", CommandType.StoredProcedure, parameters);
            }

            ***/
            /// <summary>
            /// Updates the DB with the input data.
            /// 
            /// </summary>
            /// <param name="employee"></param>
            /// <returns></returns>
            public bool UpdateEmployee(DAL.Employee employee)
            {
                int result = 0;
                String query = "UPDATE employee.edata SET address='" + employee.Address + "', salary='" + employee.Salary + "', dept='" + employee.Department +
                    "', supervisor='" + employee.Supervisor + "', tenure='" + employee.Tenure + "', lastName='" + employee.LastName + "', firstName='" + employee.FirstName +
                    "', title='" + employee.Title + "', city='" + employee.City + "', region='" + employee.Region + "', postalCode='" + employee.PostalCode +
                    "', country='" + employee.Country + "', extension='" + employee.Extension + "' WHERE emID=" + employee.EmployeeID;

                //Open Connection
                if (this.OpenConnection())
                {
                    //Create Mysql Command
                    MySqlCommand cmd = new MySqlCommand(query, _connection);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();
                    //close Connection
                    this.CloseConnection();
                }

                if (result == 1)
                    return true;
                return false;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="employee"></param>
            /// <returns></returns>
            public bool AddNewEmployee(DAL.Employee employee)
            {
                String query =
                    "INSERT INTO `employee`.`edata` (`address`, `salary`, `dept`, `supervisor`, `tenure`, `lastName`, `firstName`, `title`, `city`, `region`, `postalCode`, `country`, `extension`) VALUES ('" + employee.Address + "', '" + employee.Salary +
                    "', '" + employee.Department + "', '" + employee.Supervisor + "', '" + employee.Tenure + "', '" +
                    employee.LastName + "', '" + employee.FirstName + "', '" + employee.Title + "', '" + employee.City +
                    "', '" + employee.Region + "', '" + employee.PostalCode + "', '" + employee.Country + "', '" +
                    employee.Extension + "')";

                try
                {
                    //open connection
                    if (this.OpenConnection() == true)
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, _connection);

                        //Execute command
                        cmd.ExecuteNonQuery();

                        //close connection
                        this.CloseConnection();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Connects to the DB using a Stored Procedure to return a list of
            /// employees that can be displayed.
            /// </summary>
            /// <returns>List</returns>
            public List<DAL.Employee> GetEmployeeList()
            {
                List<DAL.Employee> listEmployees = null;

                //Lets get the list of all employees in a datataable
                using (DataTable table = DAL.SqlDBHelper.ExecuteSelectCommand("GetEmployeeList", CommandType.StoredProcedure))
                {
                    //check if any record exist or not
                    if (table.Rows.Count > 0)
                    {
                        //Lets go ahead and create the list of employees
                        listEmployees = new List<DAL.Employee>();

                        //Now lets populate the employee details into the list of employees
                        foreach (DataRow row in table.Rows)
                        {
                            DAL.Employee employee = new DAL.Employee();
                            employee.EmployeeID = Convert.ToInt32(row["emID"]);
                            employee.LastName = row["lastName"].ToString();
                            employee.FirstName = row["firstName"].ToString();
                            employee.Title = row["title"].ToString();
                            employee.Address = row["address"].ToString();
                            employee.City = row["city"].ToString();
                            employee.Region = row["region"].ToString();
                            employee.PostalCode = row["postalCode"].ToString();
                            employee.Country = row["country"].ToString();
                            employee.Salary = row["salary"].ToString();
                            employee.Department = row["dept"].ToString();
                            employee.Supervisor = row["supervisor"].ToString();
                            employee.Tenure = row["tenure"].ToString();

                            listEmployees.Add(employee);
                        }
                    }
                }

                return listEmployees;
            }

            public Employee GetEmployeeDetails(int employeeID)
            {
                string query = "SELECT * FROM edata WHERE emID=" + employeeID;

                //Create a list to store the result
                ArrayList list = new ArrayList();
                Employee employee = null;

                //Open connection
                if (this.OpenConnection())
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, _connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            list.Add(dataReader[i]);
                        }
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //Lets go ahead and create the list of employees
                    employee = new Employee();

                    //Now lets populate the employee details into the list of employees                                     
                    employee.EmployeeID = Convert.ToInt32(list[0]);
                    employee.LastName = list[1].ToString();
                    employee.FirstName = list[2].ToString();
                    employee.Title = list[3].ToString();
                    employee.Address = list[4].ToString();
                    employee.City = list[5].ToString();
                    employee.Region = list[6].ToString();
                    employee.PostalCode = list[7].ToString();
                    employee.Country = list[8].ToString();
                    employee.Extension = list[9].ToString();
                    employee.Salary = list[10].ToString();
                    employee.Department = list[11].ToString();
                    employee.Supervisor = list[12].ToString();
                    employee.Tenure = list[13].ToString();

                    //return list to be displayed
                    return employee;
                }
                else
                {
                    return employee;
                }
            }
        }
    }
}
