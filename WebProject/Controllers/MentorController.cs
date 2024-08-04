using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities;
using University.Stores;

namespace University.Controllers
{
    public class MentorController : Controller
    {
        private readonly MentorStore _store;
        public MentorController()
        {
            _store = new MentorStore();
        }
        // GET: MentorController
        public ActionResult Index()
        {
            var mentors = _store.Get();

            return View(mentors);
        }

        // GET: MentorController/Details/5
        public ActionResult Details(int id)
        {
            var mentor = _store.GetById(id);

            return View(mentor);
        }

        // GET: MentorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MentorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mentor mentor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }
                _store.Add(mentor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MentorController/Edit/5
        public ActionResult Edit(int id)
        {
            var mentor = _store.GetById(id);

            return View(mentor);
        }

        // POST: MentorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Mentor mentor)
        {
            try
            {
                _store.Update(mentor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MentorController/Delete/5
        public ActionResult Delete(int id)
        {
            var mentor = _store.GetById(id);

            return View(mentor);
        }

        // POST: MentorController/Delete/5
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
