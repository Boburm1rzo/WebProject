using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using University.Domain.Entities;
using University.Mappings;
using University.Stores;

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
}
