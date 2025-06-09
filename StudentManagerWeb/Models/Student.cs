using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerWeb.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Chưa nhập họ tên")]
        public string FullName { get; set; }
        public int Age { set; get; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { set; get; }
    }
}
