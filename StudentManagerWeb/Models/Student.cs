using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerWeb.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { set; get; }
        public string Email { set; get; }
    }
}
