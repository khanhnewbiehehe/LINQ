using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public DateTime birthday { get; set; }
        public int departmentID { get; set; }
        public double salary { get; set; }

        public Employee() { }

        public Employee(int id, string name, int age, DateTime birthday, int departmentID, double salary)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.birthday = birthday;
            this.departmentID = departmentID;
            this.salary = salary;
        }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee() {id = 1, name = "A", birthday = DateTime.ParseExact("20/12/2000", "dd/MM/yyyy", null), departmentID = 1, salary = 10000000},
                new Employee() {id = 2, name = "B", birthday = DateTime.ParseExact("10/06/1998", "dd/MM/yyyy", null), departmentID = 2, salary = 15000000}, 
                new Employee() {id = 3, name = "C", birthday = DateTime.ParseExact("12/08/1990", "dd/MM/yyyy", null), departmentID = 3, salary = 32000000},
                new Employee() {id = 4, name = "D", birthday = DateTime.ParseExact("30/10/1997", "dd/MM/yyyy", null), departmentID = 1, salary = 20000000},
                new Employee() {id = 5, name = "E", birthday = DateTime.ParseExact("21/06/2001", "dd/MM/yyyy", null), departmentID = 2, salary = 6000000}
            };
        }
    }
}
