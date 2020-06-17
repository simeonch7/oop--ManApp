using System;
using System.Collections.Generic;
using AppKit;
using Foundation;
using System.Text.RegularExpressions;


namespace MngApp
{
    public partial class ViewController : NSViewController
    { 

        private readonly Company currentCompany = new Company(0);

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void ChangePositionDropDown(NSObject sender)
        {
            if (EmployeePosition.TitleOfSelectedItem == "Manager")
            {
                LevelTextField.Hidden = false;
                SalaryTextField.Hidden = false;
            }
            else if (EmployeePosition.TitleOfSelectedItem == "Employee")
            {
                LevelTextField.Hidden = true;
                SalaryTextField.Hidden = false;

            }
            else if (EmployeePosition.TitleOfSelectedItem == "Intern")
            {
                LevelTextField.Hidden = true;
                SalaryTextField.Hidden = true;
            }
        }

        partial void BudgetButton(NSObject sender)
        {
            Match matchBudget = RegexClass.rgxSalary.Match(BudgetTextField.StringValue);

            if (matchBudget.Success)
            {
                currentCompany.Budget = BudgetTextField.IntValue;
                BudgetLabel.StringValue = "Budget left: " + currentCompany.GetBudgetLeft().ToString();
            }
            else
            {
                AddFuncs.AlertFunc("Please enter a valid budget!");
            }
        }

        partial void AddEmployeeButton(NSObject sender)
        {
            if (EmployeePosition.TitleOfSelectedItem == "Manager")
            {
                Match matchName = RegexClass.rgxName.Match(NameTextField.StringValue);
                Match matchSalary = RegexClass.rgxSalary.Match(SalaryTextField.StringValue);

                if (matchName.Success && matchSalary.Success)
                {
                    if (LevelTextField.StringValue == "")
                    {
                        Manager manager = new Manager(AddFuncs.IDGenerator(),
                           NameTextField.StringValue, Int32.Parse(SalaryTextField.StringValue));

                        if (currentCompany.Hire(manager) == true)
                        {
                            isAddingSuccessfulLabel.StringValue = "Added successfully - ID : " + manager.Id;
                            BudgetLabel.StringValue = "Budget left: " + currentCompany.GetBudgetLeft().ToString();
                        }
                        else
                        {
                            isAddingSuccessfulLabel.StringValue = "Not enough budget left!";
                            AddFuncs.startID--;
                        }
                    }
                    else
                    {
                        Match matchLevel = RegexClass.rgxLevel.Match(LevelTextField.StringValue);
                        if (matchLevel.Success)
                        {


                            Manager manager = new Manager(AddFuncs.IDGenerator(), NameTextField.StringValue,
                               SalaryTextField.IntValue, Int32.Parse(LevelTextField.StringValue));

                            if (currentCompany.Hire(manager) == true)
                            {
                                isAddingSuccessfulLabel.StringValue = "Added successfully - ID : " + manager.Id;
                                BudgetLabel.StringValue = "Budget left: " + currentCompany.GetBudgetLeft().ToString();
                            }
                            else
                            {
                                isAddingSuccessfulLabel.StringValue = "Not enough budget left!";
                                AddFuncs.startID--;
                            };
                        }
                        else
                        {
                            AddFuncs.AlertFunc("You have entered an invalid level (min. 1, max. 9)");
                        }
                    }
                }
                else
                {
                    AddFuncs.AlertFunc("You have entered either invalid name or salary, please double-check");
                }
            }
            else if (EmployeePosition.TitleOfSelectedItem == "Employee")
            {
                Match matchName = RegexClass.rgxName.Match(NameTextField.StringValue);
                Match matchSalary = RegexClass.rgxSalary.Match(SalaryTextField.StringValue);

                if (matchName.Success && matchSalary.Success)
                {
                    Employee employee = new Employee(AddFuncs.IDGenerator(), NameTextField.StringValue,
                    Int32.Parse(SalaryTextField.StringValue));
                    if (currentCompany.Hire(employee) == true)
                    {
                        isAddingSuccessfulLabel.StringValue = "Added successfully - ID : " + employee.Id;
                        BudgetLabel.StringValue = "Budget left: " + currentCompany.GetBudgetLeft().ToString();

                    }
                    else
                    {
                        isAddingSuccessfulLabel.StringValue = "Not enough budget left!";
                        AddFuncs.startID--;
                    }
                }
                else
                {
                    AddFuncs.AlertFunc("You have entered either invalid name or salary, please double-check");
                }
            }
            else if (EmployeePosition.TitleOfSelectedItem == "Intern")
            {

                Match matchName = RegexClass.rgxName.Match(NameTextField.StringValue);

                if (matchName.Success)
                {
                    Intern intern = new Intern(AddFuncs.IDGenerator(), NameTextField.StringValue);
                    currentCompany.Hire(intern);
                    isAddingSuccessfulLabel.StringValue = "Added successfully - ID : " + intern.Id;
                    BudgetLabel.StringValue = "Budget left: " + currentCompany.GetBudgetLeft().ToString();
                }
                else
                {
                    AddFuncs.AlertFunc("Please enter a valid name!");
                }
            }
        }

        partial void RemoveByIDButton(NSObject sender)
        {
            foreach (Intern intern in currentCompany.AllEmployees)
            {
                if (intern.Id == IDRemoveTextField.IntValue)
                {
                    currentCompany.Fire(intern);
                    break;
                }
            }
            BudgetLabel.StringValue = "Budget left: " + currentCompany.GetBudgetLeft().ToString();
        }

        partial void CloseCompanyButton(NSObject sender)
        {
            currentCompany.Close();
            BudgetLabel.StringValue = "Budget left: " + currentCompany.GetBudgetLeft().ToString();
        }


        partial void ListEmployeesButton(NSObject sender)
        {
            
            AllEmployeesLabel.StringValue = Builder.BuildAllEmployeesLabel(currentCompany.AllEmployees).ToString();
        }

        partial void ExportXMLButton(NSObject sender)
        {
            List<Manager> managers = new List<Manager>();
            foreach (Intern manager in currentCompany.AllEmployees)
            {
                if (manager is Manager) managers.Add((Manager)manager);
            }

            List<Employee> employees = new List<Employee>();
            foreach (Intern employee in currentCompany.AllEmployees)
            {
                if (!(employee is Manager) && (employee is Employee)) employees.Add((Employee)employee);
            }

            List<Intern> interns = new List<Intern>();
            foreach (Intern intern in currentCompany.AllEmployees)
            {
                if (!(intern is Manager) && !(intern is Employee)) interns.Add(intern);
            }

            AddFuncs.ExportIntern(interns);
            AddFuncs.ExportEmployee(employees);
            AddFuncs.ExportManager(managers);

        }

        partial void ImportXMLButton(NSObject sender)
        {
            currentCompany.ImportEmployees();
        }

        partial void FilterByLevelButton(NSObject sender)
        {
            List<Manager> managers = new List<Manager>();
            managers = currentCompany.GetManagersWithLevel(LevelToFilterTextField.IntValue);
            FilteredManagersLabel.StringValue = Builder.BuildFilteredManagersLabel(managers).ToString();
        }
    }
}