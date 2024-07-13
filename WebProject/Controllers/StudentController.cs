using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using WebProject.Views.Stores;

namespace WebProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentStore _store;
        public StudentController()
        {
            _store = new StudentStore();
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(_store.GetAllStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_store.GetById(id));
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
                _store.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = _store.GetById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                _store.Update(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_store.GetById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _store.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
