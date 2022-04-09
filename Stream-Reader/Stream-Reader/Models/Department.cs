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
                _employees=value;
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
            foreach (var item in Employees)
            {
                if (item.Id==employee.Id)
                {
                    Console.WriteLine("This ID already existed");
                    return;
                }
            }
            Employees.Add(employee);
            
            Console.WriteLine("The operation was performed successfully");
            Console.WriteLine("-----------------------------");          
        }

        public void GetEmployeeById(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("ID is null");
                return;
            }            
            
            if (Employees.Find(m => m.Id == id).Id == id)
            {
                Employees.Find(m => m.Id == id).ShowInfo();
                return;
            }
            Console.WriteLine("No information found");
        }

        public void RemoveEmployee(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("ID is null");
                return;
            }            
            if (Employees.Find(e => e.Id == id).Id == id)
            {
                Employees.Remove(Employees.Find(e => e.Id == id));
                Console.WriteLine("The operation was performed successfully");
            }
            Console.WriteLine("No information found");

        }
        public void AllEmployee()
        {
            foreach (var item in Employees)
            {
                item.ShowInfo();
            }
        }
        #endregion
    }
}
