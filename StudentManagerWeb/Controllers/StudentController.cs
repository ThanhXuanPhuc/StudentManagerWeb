using Microsoft.AspNetCore.Mvc;
using StudentManagerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var studentList = _db.Students.ToList();
            var avgAge = _db.Students.Average(x=>x.Age);
            ViewBag.Avg_Age = avgAge;
            return View(studentList);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();

                TempData["success"] = "Inserted success";
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Update(int id)
        {
            var student = _db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                var existsStudent = _db.Students.Find(student.Id);
                if (existsStudent == null)
                {
                    return NotFound();
                }
                existsStudent.FullName = student.FullName;
                existsStudent.Age = student.Age;
                existsStudent.Email = student.Email;
                _db.SaveChanges();

                TempData["success"] = "Updated success";
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var existsStudent = _db.Students.Find(id);
                if (existsStudent == null)
                {
                    return NotFound();
                }
                _db.Students.Remove(existsStudent);
                _db.SaveChanges();

                TempData["success"] = "Deleted success";
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}