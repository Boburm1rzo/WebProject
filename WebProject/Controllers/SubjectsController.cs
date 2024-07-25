using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using WebProject.Store;

namespace WebProject.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly SubjectsStore _subjectsStore;
        public SubjectsController()
        {
            _subjectsStore = new SubjectsStore();
        }
        public ActionResult Index(string? search)
        {
            var subjects = _subjectsStore.Get(search);
            ViewBag.Subjects = subjects;

            return View(subjects);
        }

        public ActionResult Details(int id)
        {
            return View(_subjectsStore.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                _subjectsStore.Add(subject);
                return RedirectToAction(nameof(Details), new {id = subject.Id});
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var subject = _subjectsStore.GetById(id);
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Subject subject)
        {
            try
            {
                _subjectsStore.Update(subject);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var subject = _subjectsStore.GetById(id);
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _subjectsStore.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
