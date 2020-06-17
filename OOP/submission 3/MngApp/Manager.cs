using System.Text.RegularExpressions;

namespace MngApp
{
    public class Manager : Employee
    {
        private int level;

        public Manager(int Id, string Name, int Salary, int Level) : base(Id, Name, Salary)
        {
            this.level = Level;
        }

        public Manager()
        {
        }

        //if no level is specified, manager is created of level 1
        public Manager(int Id, string Name, int Salary) : base(Id, Name, Salary)
        {
            level = 1;
        }

        public int Level
        {
            get => level;
            set
            {
                Match matchLevel = RegexClass.rgxLevel.Match(value.ToString());

                if (matchLevel.Success)
                    salary = value;
                else
                    AddFuncs.AlertFunc("You have entered invalid level, please double-check (min 1, max 9)");
            }
        }

        public override string GetMyRank()
        {
            return "I am a manager!";
        }
    }
}
