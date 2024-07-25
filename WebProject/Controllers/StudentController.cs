using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
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
        public ActionResult Index()
        {
            return View(_store.Get(""));
        }

        public ActionResult Details(int id)
        {
            return View(_store.GetById(id));
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
