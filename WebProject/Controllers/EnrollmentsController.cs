using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using University.Domain.Entities;
using University.Mappings;
using University.Stores;
using University.ViewModels.Enrollment;

namespace University.Controllers;

public class EnrollmentsController : Controller
{
    private readonly EnrollmentsStore _store;
    private readonly GroupStore _groupStore;

    public EnrollmentsController()
    {
        _store = new EnrollmentsStore();
        _groupStore = new GroupStore();
    }

    public IActionResult Index(string? search, int? groupId)
    {
        var enrollments = _store.Get(search, groupId);

        ViewBag.Search = search;
        ViewBag.Groups = _groupStore.Get();

        var views = enrollments.Select(x => x.ToView());

        return View(views);
    }
    public ActionResult Details(int id)
    {
        var enrollment=_store.GetById(id);
        var enrollmentView=enrollment.ToView();

        return View(enrollmentView);
    }
    public ActionResult Create()
    {
        return View();  
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Enrollment enrollment)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            
            var entity = enrollment.ToGroup();
            _store.Add(enrollment);

            return RedirectToAction(nameof(Details), new {id=entity.Id});
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Edit(int id)
    {
        var entity = _store.GetById(id);
        var enrollmentView = entity.ToView();

        return View(enrollmentView);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id , Enrollment enrollment)
    {
        try
        {
            var entity= _store.GetById(id);
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
        var enrollment= _store.GetById(id);

        return View(enrollment);
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
