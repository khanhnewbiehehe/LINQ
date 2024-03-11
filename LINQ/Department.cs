using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
     public class Department
    {
        public int id { get; set; }
        public string name { get; set; }

        public Department() { }

        public Department(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static List<Department> GetDepartments()
        {
            return new List<Department>()
            {
                new Department() { id = 1, name = "IT"},
                new Department() { id = 2, name = "HR"},
                new Department() { id = 3, name = "Marketing"}
            };
        }

    }
}
