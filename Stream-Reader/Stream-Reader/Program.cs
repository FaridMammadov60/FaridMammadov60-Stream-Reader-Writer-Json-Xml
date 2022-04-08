using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Stream_Reader.Models;

namespace Stream_Reader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\farid\Desktop\New folder (2)\ConsoleApp1\ConsoleApp1/Files";
            string path2 = @"C:\Users\farid\Desktop\New folder (2)\ConsoleApp1\ConsoleApp1/Files/Database.json";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path2))
            {
                File.Create(path2);
            }
            #region Menyu
            Console.WriteLine($"1. Add employee\n" +
                $"2. Get employee by id\n" +
                $"3. Remove employee\n" +
                $"0. Quit");
            Console.Write("Enter to menyu number: ");
            int menyu = Convert.ToInt32(Console.ReadLine());
            Department department = new Department("KKHI");

            switch (menyu)
            {
                case 0:
                    break;
                case 1:
                    
                    Employee employee = new Employee("Farid Mammadov", 1200f);
                    department.AddEmployee(employee);
                    string addJson = JsonConvert.SerializeObject(department);
                    using (StreamWriter sw = new StreamWriter(path2))
                    {
                        sw.WriteLine(addJson);
                    }
                    string result1;
                    using (StreamReader sr = new StreamReader(path2))
                    {
                        result1 = sr.ReadToEnd();
                    }
                    Console.WriteLine(result1);
                    break;
                case 2:
                    using (StreamReader sr = new StreamReader(path2))
                    {
                        result1 = sr.ReadToEnd();
                    }
                    Console.WriteLine(result1);
                    Department dep = JsonConvert.DeserializeObject<Department>(result1);

                    foreach (var item in dep.Employees)
                    {
                        Console.WriteLine(item.Name);
                    }
                    //department.GetEmployeeById(1);               

                    break;
                case 3:

                    /*
                     3-cü əməliyyatda isə yenə 2 ci əməliyyatdakı kimi database.json oxunacaq 
                    deserialize olunacaq department obyektinə həmin idli employee tapılacaq və
                    listdən silinəcək daha sonra həmin depatment yenidən obyekti
                    serialize olunacaq json-a və database.json file-na yazılacaq. 
                     */

                    break;
                default:
                    break;
            }
            #endregion

            #region Test
            //StreamWriter sw = new StreamWriter(path1);
            //sw.WriteLine("Farid");
            //sw.Close();
            //using (StreamWriter sw = new StreamWriter(path1))
            //{
            //    sw.WriteLine("Farid Mammadov 1991");
            //}
            //string result;
            //using (StreamReader sr = new StreamReader(path1))
            //{
            //    result = sr.ReadToEnd();
            //}
            //Console.WriteLine(result);
            #endregion
        }
    }
}
