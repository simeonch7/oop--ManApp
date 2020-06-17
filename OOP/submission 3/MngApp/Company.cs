using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AppKit;

namespace MngApp
{
    public class Company
    {
        public int Budget { get; set; }

        /*(thanks to polymorphism i can treat every derived class as the
        base one and add an object of derived class to a list of base class)*/
        public List<Intern> AllEmployees = new List<Intern>();

        public Company(int Budget)
        {
            this.Budget = Budget;
        }

        public bool Hire(Intern e)
        {
            if (e is Employee)
            {
                if (GetBudgetLeft() >= ((Employee)e).Salary)
                {
                    AllEmployees.Add(e);
                    return true;
                }
            }
            else
            {
                AllEmployees.Add(e);
                return true;
            }

            return false;
        }


        public void Fire(Intern intern)
        {
            AllEmployees.Remove(intern);
        }


        public bool IsHired(Intern intern)
        {
            return AllEmployees.Contains(intern);
        }

        /**
         * Closes the company. Sets the budget to 0 and fires all employees
         */
        public void Close()
        {
            AllEmployees.Clear();
            Budget = 0;
        }

        public double GetBudgetLeft()
        {
            int tempBudget = Budget;
            //either employee or manager (as intern does not receive salary)

            foreach (Intern intern in AllEmployees)
            {
                if (intern is Employee)
                {
                    tempBudget -= ((Employee)intern).Salary;
                }
            }
            return tempBudget;
        }

        public List<Manager> GetManagersWithLevel(int level)
        {
            List<Manager> managers = new List<Manager>();
            foreach (Intern intern in AllEmployees)
            {
                if (intern is Manager)
                {

                    if (((Manager)intern).Level == level)
                    {
                        managers.Add((Manager)intern);
                    }

                }
            }
            return managers;
        }

        public void ImportEmployees()
        {
            var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseFiles = true;
            dlg.AllowsMultipleSelection = true;
            dlg.CanChooseDirectories = false;
            dlg.AllowedFileTypes = new string[] { "xml" };

            if (dlg.RunModal() == 1)
            {
                for (int i = 0; i < dlg.Urls.Length; i++)
                {
                    var url = dlg.Urls[i];
                    var filePath = url.ToString().Substring(7);
                    if (filePath.Contains("ExportedDataIntern"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Intern>));

                        using (FileStream stream = File.OpenRead(filePath))
                        {
                            List<Intern> dezerializedList = (List<Intern>)serializer.Deserialize(stream);
                            foreach (var item in dezerializedList)
                            {
                                AllEmployees.Add(item);
                            }
                        }

                    }
                    if (filePath.Contains("ExportedDataEmployee"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));

                        using (FileStream stream = File.OpenRead(filePath))
                        {
                            List<Employee> dezerializedList = (List<Employee>)serializer.Deserialize(stream);
                            foreach (var item in dezerializedList)
                            {
                                AllEmployees.Add(item);
                            }
                        }

                    }
                    if (filePath.Contains("ExportedDataManager"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Manager>));

                        using (FileStream stream = File.OpenRead(filePath))
                        {
                            List<Manager> dezerializedList = (List<Manager>)serializer.Deserialize(stream);
                            foreach (var item in dezerializedList)
                            {
                                AllEmployees.Add(item);
                            }
                        }
                    }
                    AllEmployees.Sort((x, y) => x.Id.CompareTo(y.Id));
                }
            }
        }

    }
}