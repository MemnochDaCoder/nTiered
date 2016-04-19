using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class EmployeeHandler
    {
        // Handle to the Employee DBAccess class
        EmployeeDBStatements.SQLstatements employeeDb = null;

        public EmployeeHandler()
        {
            employeeDb = new EmployeeDBStatements.SQLstatements();
        }

        /// <summary>
        /// Returns the list of employees, no logic.
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployeeList()
        {
            return employeeDb.GetEmployeeList();
        }

        /// <summary>
        /// Updates the DB according to data from the EmployeeDBAccess class
        /// by passing the eID.
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool UpdateEmployee(Employee employee)
        {
            return employeeDb.UpdateEmployee(employee);
        }

        /// <summary>
        /// Returns the employee data by empID.
        /// 
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public Employee GetEmployeeDetails(int empID)
        {
            return employeeDb.GetEmployeeDetails(empID);
        }

        /// <summary>
        /// Deletes the a row in the DB by the eID passed.
        /// 
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int empID)
        {
            return employeeDb.DeleteEmployee(empID);
        }

        /// <summary>
        /// Adds a new employee.
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddNewEmployee(Employee employee)
        {
            return employeeDb.AddNewEmployee(employee);
        }
    }
}
