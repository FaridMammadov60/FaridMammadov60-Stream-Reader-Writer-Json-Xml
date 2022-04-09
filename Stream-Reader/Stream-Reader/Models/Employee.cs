using System;

namespace Stream_Reader.Models
{
    internal class Employee
    {
        #region Fields
        static int _id;
        string _name;
        float _salary;
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
        public float Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 0)
                {
                S1: Console.WriteLine("Maaş sıfırdan kiçik ola bilməz yenidən cəhd edin");
                    float sal = float.Parse(Console.ReadLine());
                    if (sal < 0)
                    {
                        goto S1;
                    }
                    _salary = sal;
                    return;
                }
                _salary = value;
            }
        }
        #endregion

        #region Constructor
        public Employee()
        {

        }
        public Employee(string name, float salary)
        {
            _id++;
            Id = _id;
            this.Name = name;
            this.Salary = salary;
        }
        #endregion

        #region Method
        public void ShowInfo()
        {
            Console.WriteLine($"-----------EMPLOYEEEEEEE------------\n" +
                $"Employee ID: {Id}\n" +
                $"Employee name: {Name}\n" +
                $"Employee salary: {Salary}\n" +
                $"----------------END------------------");
            Console.WriteLine();
        }
        #endregion
    }
}
