using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{

    // Client Code
    public class ThirdPartyBilling
    {
        private ITarget employeeSource;

        public ThirdPartyBilling(ITarget employeeSource)
        {
            this.employeeSource = employeeSource;
        }

        public void ShowEmployeeList()
        {
            List<string> employee = employeeSource.GetEmployeeList();

            Console.WriteLine("Employee List:");
            foreach(var item in  employee)
            {
                Console.WriteLine(item);
            }
        }
    }

    // ITarget Interface
    public interface ITarget
    {
        List<string> GetEmployeeList();
    }

    // Adaptee Class
    public class HRSystem
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];

            employees[0] = new String[] { "100", "Deepak", "Team Lead" };
            employees[1] = new String[] { "101", "Rohit", "Developer" };
            employees[2] = new string[] { "102", "Gautam", "Developer" };
            employees[3] = new String[] { "103", "Dev", "Tester" };

            return employees;
        }   
    }

    // Adapter Class
    public class EmployerAdapter: HRSystem, ITarget
    {
        
        public List<string> GetEmployeeList()
        {
            List<string> employeesList = new List<string>();
            string[][] employees = GetEmployees();
            foreach (string[] employee in employees)
            {
                employeesList.Add(employee[0]);
                employeesList.Add(",");
                employeesList.Add(employee[1]);
                employeesList.Add(",");
                employeesList.Add(",");
                employeesList.Add(employee[2]);
                employeesList.Add("\n");

            }
            return employeesList;
        }
    }
}
