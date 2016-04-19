using System;
using DAL;
using BLL;

public partial class AddEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnYES_Click(object sender, EventArgs e)
    {
        Employee emp = new Employee();

        emp.LastName = txtLName.Text;
        emp.FirstName = txtFName.Text;
        emp.Title = txtTitle.Text;
        emp.Address = txtAddress.Text;
        emp.City = txtCity.Text;
        emp.Region = txtRegion.Text;
        emp.PostalCode = txtCode.Text;
        emp.Extension = txtExtension.Text;
        emp.Salary = txtSalary.Text;
        emp.Department = txtDept.Text;
        emp.Supervisor = txtSupervisor.Text;
        emp.Tenure = txtTenure.Text;

        EmployeeHandler empHandler = new EmployeeHandler();

        if (empHandler.AddNewEmployee(emp) == true)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btnNO_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
