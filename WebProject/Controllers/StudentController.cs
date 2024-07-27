using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities;
using WebProject.Store;

namespace WebProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentStore _store;
        public StudentController()
        {
            _store = new StudentStore();
        }
        public ActionResult Index(string? search)
        {
            var students = _store.Get(search);
            return View(students);
        }

        public ActionResult Details(int id)
        {
            var student = _store.GetById(id);
            return View(student);
        }

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

        public ActionResult Edit(int id)
        {
            var student = _store.GetById(id);
            return View(student);
        }

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

        public ActionResult Delete(int id)
        {
            var student = _store.GetById(id);
            return View(student);
        }

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
