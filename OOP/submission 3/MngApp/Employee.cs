using System.Text.RegularExpressions;

namespace MngApp
{
    public class Employee : Intern
    {
        protected int salary;

        public Employee(int Id, string Name, int Salary) : base(Id, Name)
        {
            this.salary = Salary;
        }

        public Employee()
        {
        }

        public int Salary
        {
            get => salary;
            set
            {
                Match matchSalary = RegexClass.rgxSalary.Match(value.ToString());

                if (matchSalary.Success)
                    salary = value;
                else
                    AddFuncs.AlertFunc("You have entered invalid salary, please double-check");
            }
        }

        public override string GetMyRank()
        {
            return "I am an employee!";
        }
    }
}
