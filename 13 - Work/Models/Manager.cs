using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13___Work.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
