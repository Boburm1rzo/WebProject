using Microsoft.AspNetCore.Mvc;
using University.Domain.Entities;
using WebProject.Extensions;
using WebProject.Store;
using WebProject.ViewModels.Course;

namespace WebProject.Controllers;

public class SubjectsController : Controller
{
    private readonly CoursesStore _courseStore;

    public SubjectsController()
    {
        _courseStore = new CoursesStore();
    }

    public ActionResult Index(string? search)
    {
        var subjects = _courseStore.Get(search);
        var subjectViews = subjects.Select(x => x.ToView());

        ViewBag.Search = search;

        return View(subjectViews);
    }

    public ActionResult Details(int id)
    {
        var subject = _courseStore.GetById(id);
        var subjectView = subject.ToView();

        return View(subjectView);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateCourseView course)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var entity = course.ToEntity();
            _courseStore.Add(entity);
            return RedirectToAction(nameof(Details), new { id = entity.Id });
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Edit(int id)
    {
        var subject = _courseStore.GetById(id);
        var subjectView = subject.ToUpdateView();

        return View(subjectView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, UpdateCourseView view)
    {
        try
        {
            var entity = view.ToEntity();
            _courseStore.Update(entity);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Delete(int id)
    {
        var subject = _courseStore.GetById(id);
        return View(subject);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            _courseStore.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
