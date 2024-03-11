using System;
using System.Linq;

namespace LINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Cau 1.");
            var maxSalary = (from e in Employee.GetEmployees() select e.salary).Max();
            var minSalary = (from e in Employee.GetEmployees() select e.salary).Min();
            var averageSalary = (from e in Employee.GetEmployees() select e.salary).Average();
            Console.WriteLine("Max Salary: " + maxSalary);
            Console.WriteLine("Min Salary: " + minSalary);
            Console.WriteLine("Average Salary: " + averageSalary);
            Console.WriteLine();
            Console.WriteLine("Cau 2.");
            Console.WriteLine("Join");
            var employeesByDepartment = from d in Department.GetDepartments()
                                        join e in Employee.GetEmployees()
                                        on d.id equals e.departmentID into eGroup
                                        select new
                                        {
                                            Department = d,
                                            Employee = eGroup
                                        };
            foreach (var department in employeesByDepartment)
            {
                Console.WriteLine(department.Department.name);
                foreach (var employee in department.Employee)
                {
                    Console.WriteLine(" " + employee.name);
                }
                Console.WriteLine();
            }
            Console.WriteLine("GroupJoin");
            var groupJoin = Department.GetDepartments()
                                      .GroupJoin(Employee.GetEmployees(),
                                      d => d.id, e => e.departmentID,
                                      (department, employee) => new
                                      {
                                          Department = department,
                                          Employee = employee
                                      });
            foreach (var department in groupJoin)
            {
                Console.WriteLine("Department: " + department.Department.name);
                foreach (var employee in department.Employee)
                {
                    Console.WriteLine("EmployeeID: " + employee.id + ", EmployeeName: " + employee.name);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Left join");
            var leftJoin = from e in Employee.GetEmployees()
                           join d in Department.GetDepartments()
                           on e.departmentID equals d.id into eGroup
                           from d in eGroup.DefaultIfEmpty()
                           select new
                           {
                               EmployeeName = e.name,
                               DepartmentName = d == null ? "No Department" : d.name
                           };
            foreach (var employee in leftJoin)
            {
                Console.WriteLine(employee.EmployeeName + "-" + employee.DepartmentName);
            }
            Console.WriteLine("Right join");
            var rightJoin = from d in Department.GetDepartments()
                            join e in Employee.GetEmployees()
                            on d.id equals e.departmentID into eGroup
                            from e in eGroup.DefaultIfEmpty()
                            select new
                            {
                                DepartmentName = d.name,
                                EmployeeName = e == null ? "No employees" : e.name
                            };
            foreach (var department in rightJoin)
            {
                Console.WriteLine(department.DepartmentName + "-" + department.EmployeeName);
            }
            Console.WriteLine();
            Console.WriteLine("Cau 3.");
            var maxAge = (from e in Employee.GetEmployees() select e.birthday).Max();
            var minAge = (from e in Employee.GetEmployees() select e.birthday).Min();
            int CalculateAge(DateTime birthday)
            {
                var age = DateTime.Now.Year - birthday.Year;
                if (birthday > DateTime.Now.AddYears(-age))
                    age--;
                return age;
            }
            Console.WriteLine("Max Age: " + CalculateAge(maxAge));
            Console.WriteLine("Min Age: " + CalculateAge(minAge));
        }
    }
}
