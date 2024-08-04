using Microsoft.AspNetCore.Mvc;
using University.Mappings;
using University.Store;
using University.ViewModels.Student;

namespace University.Controllers
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

            var studentsView = students.Select(x => x.ToView());

            ViewBag.Search = search;

            return View(studentsView);
        }

        public ActionResult Details(int id)
        {
            var student = _store.GetById(id);

            var studentView = student.ToView();

            return View(studentView);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreateView student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                var entity = student.ToEntity();
                _store.Add(entity);

                return RedirectToAction(nameof(Index), new { id = entity.Id });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var student = _store.GetById(id);
            var studentView = student.ToUpdateView();

            return View(studentView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentUpdateView view)
        {
            try
            {
                var entity = view.ToEntity();
                _store.Update(entity);

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
            return View(student.ToView());
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
