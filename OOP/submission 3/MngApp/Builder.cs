using System.Collections.Generic;
using System.Text;

namespace MngApp
{
    public static class Builder
    {
        public static StringBuilder BuildFilteredManagersLabel(List<Manager> managers)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var manager in managers)
            {
                sb.Append("EmpID: " + manager.Id + ", Name: " + manager.Name + ", Salary: " + manager.Salary + "\n");
            }
            return sb;
        }

        public static StringBuilder BuildAllEmployeesLabel(List<Intern> AllEmployees)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var emp in AllEmployees)
            {
                // String role = emp.ToString();
                // role = role.Substring(7);
                if (emp is Manager)
                {
                    sb.Append("EmpID: " + emp.Id + ", Name: " + emp.Name + ", Role: "
                        + ((Manager)emp).GetMyRank() + ", Salary: " + ((Employee)emp).Salary
                        + ", Level: " + ((Manager)emp).Level + "\n");
                }
                else if (emp is Employee)
                {
                    sb.Append("EmpID: " + emp.Id + ", Name: " + emp.Name + ", Role: "
                        + ((Employee)emp).GetMyRank() + ", Salary: " + ((Employee)emp).Salary + "\n");
                }
                else
                {
                    sb.Append("EmpID: " + emp.Id + ", Name: " + emp.Name +
                        ", Role: " + ((Intern)emp).GetMyRank() + "\n");
                }
            }
                return sb;
        }
    }
}
