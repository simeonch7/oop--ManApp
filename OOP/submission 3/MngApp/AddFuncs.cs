using System;
using System.Collections.Generic;
using System.IO;
using AppKit;

//additional functions

namespace MngApp
{
    static public class AddFuncs
    {

        static public int startID = 1000;

        static public void AlertFunc(string mssg)
        {
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Critical,
                InformativeText = mssg,
                MessageText = "OK",
            };
            alert.RunModal();
        }

        static public int IDGenerator()
        {
            return startID++;
        }
        
        static public void ExportIntern(List<Intern> interns)
        {
            string fileNameIntern = "ExportedDataIntern" + "-" + DateTime.Now.Ticks;
            FileInfo fileIntern = new FileInfo(fileNameIntern + ".xml");
            StreamWriter swIntern = fileIntern.AppendText();
            var writerInterns = new System.Xml.Serialization.XmlSerializer(typeof(List<Intern>));
            writerInterns.Serialize(swIntern, interns);
            swIntern.Dispose();
            swIntern.Close();
            fileIntern.CopyTo("/Users/simeoch/Desktop");
        }

        static public void ExportEmployee(List<Employee> employees)
        {
            string fileNameEmployee = "ExportedDataEmployee" + "-" + DateTime.Now.Ticks;
            FileInfo fileEmployee = new FileInfo(fileNameEmployee + ".xml");
            StreamWriter swEmployee = fileEmployee.AppendText();
            var writerEmployees = new System.Xml.Serialization.XmlSerializer(typeof(List<Employee>));
            writerEmployees.Serialize(swEmployee, employees);
            swEmployee.Dispose();
            swEmployee.Close();
            fileEmployee.CopyTo("/Users/simeoch/Desktop");
        }

        static public void ExportManager(List<Manager> managers)
        {
            string fileNameManager = "ExportedDataManager" + "-" + DateTime.Now.Ticks;
            FileInfo fileManager = new FileInfo(fileNameManager + ".xml");
            StreamWriter swManager = fileManager.AppendText();
            var writerManager = new System.Xml.Serialization.XmlSerializer(typeof(List<Manager>));
            writerManager.Serialize(swManager, managers);
            swManager.Dispose();
            swManager.Close();
            fileManager.CopyTo("/Users/simeoch/Desktop");
        }
    }
}
