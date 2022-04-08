using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream_Reader.Models
{
    internal class Department
    {
        #region Fields
        static int _id;
        string _name;
        List<Employee> _employees;
        #endregion

        #region Properties
        public int Id { get; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
            }
        }
        #endregion

        #region Constructor
        public Department(string name)
        {
            _id++;
            Id = _id;
            this.Name = name;
            List<Employee> employees = new List<Employee>();
            _employees = employees;
        }
        #endregion

        #region Method
        public void AddEmployee(Employee employee)
        {

            int a = Employees.Find(m => m.Id == employee.Id).Id;
            if (employee.Id == a)
            {
                Console.WriteLine("Məlunmat bazda mövcuddur");
                return;
            }

            //Console.WriteLine(e.Id);

            Employees.Add(employee);
            Console.WriteLine("Əməliyyat uğurla icra edildi");
            Console.WriteLine("-----------------------------");
        }

        public void GetEmployeeById(int? id)
        {
            //Console.Write("ID-ni daxil edin: ");

            ////bool idinput = int.TryParse(Console.ReadLine(),ref id);

            //string s = Console.ReadLine();
            //if (s==null)
            //{
            //    throw new NullReferenceException();
            //}
            //string numinput = Console.ReadLine() ?? string.Empty;

            if (id == null)
            {
                Console.WriteLine("ID nulldur");
                return;
            }
            Employee c = Employees.Find(e => e.Id == id);
            if (c.Id == id)
            {
                c.ShowInfo();
                Console.WriteLine("---------------------");
                return;
            }
            Console.WriteLine("Məlumat tapılmadı");
        }

        public void RemoveEmployee(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("ID nulldur");
                return;
            }
            Employee r = Employees.Find(e => e.Id == id);
            if (r.Id == id)
            {
                Employees.Remove(r);
                Console.WriteLine("Əməliyyat uğurla icara edildi");
            }
            Console.WriteLine("Məlumat tapılmadı");

        }
        #endregion
    }
}
