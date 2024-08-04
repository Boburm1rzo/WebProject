using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities;
using University.Stores;

namespace University.Controllers
{
    public class GroupController : Controller
    {
        private readonly GroupStore _store;
        public GroupController()
        {
            _store = new GroupStore();
        }
        // GET: GroupController
        public ActionResult Index()
        {
            var groups = _store.Get();

            return View(groups);

        }

        // GET: GroupController/Details/5
        public ActionResult Details(int id)
        {
            var group = _store.GetById(id);

            return View(group);
        }

        // GET: GroupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group group)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                _store.Add(group);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Edit/5
        public ActionResult Edit(int id)
        {
            var group = _store.GetById(id);

            return View(group);
        }

        // POST: GroupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Group group)
        {
            try
            {
                _store.Update(group);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Delete/5
        public ActionResult Delete(int id)
        {
            var group = _store.GetById(id);

            return View(group);
        }

        // POST: GroupController/Delete/5
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
