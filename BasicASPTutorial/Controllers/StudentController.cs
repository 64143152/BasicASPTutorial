using System.Collections.Generic;
using BasicASPTutorial.Data;
using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASPTutorial.Controllers
{
    public class StudentController : Controller
    {

        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //Student s1 = new();
            //s1.Id = 1;
            //s1.Name = "Waranyu";
            //s1.Score = 100;

            //var s2 = new Student();
            //s2.Id = 2;
            //s2.Name = "โจโจ้";
            //s2.Score = 50;

            //Student s3 = new Student();
            //s3.Id = 3;
            //s3.Name = "เจน";
            //s3.Score = 65;

            //List<Student> allStudent = new List<Student>();
            //allStudent.Add(s1);
            //allStudent.Add(s2);
            //allStudent.Add(s3);

            IEnumerable <Student> allStudent = _db.Students;

            return View(allStudent);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
