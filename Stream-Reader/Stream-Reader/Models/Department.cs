using System;
using System.Collections.Generic;

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
            List<Employee> find3 = Employees.FindAll(m => m.Id == employee.Id);
            foreach (var item in find3)
            {
                Console.WriteLine("This ID already existed");
                return;
            }
            Employees.Add(employee);

            Console.WriteLine("The operation was performed successfully");
            Console.WriteLine();
        }

        public void GetEmployeeById(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("ID is null");
                return;
            }
            List<Employee> find = Employees.FindAll(m => m.Id == id);
            
            foreach (var item in find)
            {
                item.ShowInfo();
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
            List<Employee> find2 = Employees.FindAll(m => m.Id == id);
            foreach (var item in find2)
            {
                Employees.Remove(item);
                Console.WriteLine("The operation was performed successfully");
                Console.WriteLine();
                return;
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
