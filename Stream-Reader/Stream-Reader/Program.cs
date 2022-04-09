using Newtonsoft.Json;
using Stream_Reader.Models;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Stream_Reader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Azərbaycan dilinin oxunması və yazılması üçün 
                #region AZ-language
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;
                #endregion
                #region Create folder and file
                string path2 = @"C:\Users\farid\Desktop\P322\Task\FaridMammadov60-Stream-Reader-Writer-Json-Xml\Stream-Reader\Stream-Reader\Files\Database.json";

                if (!File.Exists(path2))
                {
                    File.Create(path2);
                }
                using (StreamWriter swe = new StreamWriter(path2))
                {
                    swe.WriteLine("Farid Mammadov 1991");
                }
                string result;
                using (StreamReader srr = new StreamReader(path2))
                {
                    result = srr.ReadToEnd();
                }
                #endregion

                #region Create department
                Console.WriteLine("Office is created");
                Console.Write("Enter the name of the office for the employee: ");
                string office = Console.ReadLine();
                Department department = new Department(office);
            #endregion
            #region Menyu
            L1: Console.WriteLine($"1. Add employee\n" +
                $"2. Get employee by id\n" +
                $"3. Remove employee\n" +
                $"4. Get all employee\n" +
                $"0. Quit");
                Console.Write("Enter to menyu number: ");
                var menyu = Convert.ToInt32(Console.ReadLine());
                #endregion

                switch (menyu)
                {
                    case 0:
                        Console.WriteLine("Thanks");
                        Thread.Sleep(5000);
                        break;
                    case 1:
                        #region AddEmployee and serialize
                        Console.Clear();
                        Console.Write("Enter to employee name: ");

                        string name = Console.ReadLine();

                        Console.Write("Enter to employee salary: ");
                        float salary = float.Parse(Console.ReadLine());

                        Employee employee = new Employee(name, salary);
                        department.AddEmployee(employee);
                        string addJson = JsonConvert.SerializeObject(department);

                        using (StreamWriter sw = new StreamWriter(path2))
                        {
                            sw.WriteLine(addJson);
                        }
                        #endregion
                        goto L1;
                    case 2:
                        #region GetEmployeeId and deserialize
                        Console.Clear();
                        Console.Write("ID select: ");
                        int ib = Convert.ToInt32(Console.ReadLine());
                        using (StreamReader sr = new StreamReader(path2))
                        {
                            result = sr.ReadToEnd();
                        }
                        Console.WriteLine(result);
                        Department dep = JsonConvert.DeserializeObject<Department>(result);
                        department.GetEmployeeById(ib);
                        #endregion
                        goto L1;
                    case 3:
                        #region Remove and deserialize and serialize
                        Console.Clear();
                        using (StreamReader sr = new StreamReader(path2))
                        {
                            result = sr.ReadToEnd();
                        }
                        Console.WriteLine(result);
                        Department dep2 = JsonConvert.DeserializeObject<Department>(result);
                        Console.Write("ID select: ");
                        int ir = Convert.ToInt32(Console.ReadLine());
                        department.RemoveEmployee(ir);
                        string addJson2 = JsonConvert.SerializeObject(department);

                        using (StreamWriter sw = new StreamWriter(path2))
                        {
                            sw.WriteLine(addJson2);
                        }
                        #endregion
                        goto L1;
                    case 4:
                        Console.Clear();
                        department.AllEmployee();
                        goto L1;
                    default:
                        Console.WriteLine("The number was entered incorrectly");
                        goto L1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
