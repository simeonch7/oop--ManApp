using System;
using System.Text.RegularExpressions;

namespace MngApp
{
    public class Intern
    {
        protected int id;
        protected string name;


        public Intern(int Id, string Name)
        {
            this.id = Id;
            this.name = Name;
        }
        public Intern() {
        }

        public int Id
        {
            get => id;
            set {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new ArgumentException("ID cannot be null or empty");
                else
                    id = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                Match matchName = RegexClass.rgxName.Match(value);

                if (matchName.Success)
                    name = value;
                else
                    AddFuncs.AlertFunc("You have entered invalid name, please double-check");

            }
        }

        public virtual string GetMyRank()
        {
            return "I am an intern!";
        }
    }
}
