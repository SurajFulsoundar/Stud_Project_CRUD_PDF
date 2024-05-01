using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stud_Project_CRUD_PDF.Models;
using Stud_Project_CRUD_PDF.Services;

namespace Stud_Project_CRUD_PDF.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices services;
        public StudentController(IStudentServices services)
        {
            this.services = services;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var result = services.GetAllStudent();
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(string Accept, string SearchBy)
        {
            var students = services.GetStudentByTitle(Accept, SearchBy);
            return View("Index", students);
        } 

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var result = services.GetStudentById(id);
            return View(result);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                int res = services.AddStudent(student);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex) 
            {
                return View();
            }
            finally
            {
                RedirectToAction(nameof(Index));
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = services.GetStudentById(id);
            return View(result);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int result = services.updateStudent(student);

                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View();
            }
           
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = services.GetStudentById(id);
            return View(result);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = services.DeleteStudent(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
