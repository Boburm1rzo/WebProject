using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ChartData> chartData = new List<ChartData>
            {
                new ChartData { xValue = "2014", yValue = 21 },
                new ChartData { xValue = "2015", yValue = 24 },
                new ChartData { xValue = "2016", yValue = 36 },
                new ChartData { xValue = "2017", yValue = 38 },
                new ChartData { xValue = "2018", yValue = 54 },
                new ChartData { xValue = "2019", yValue = 57 },
                new ChartData { xValue = "2020", yValue = 70 },
                new ChartData { xValue = "2021", yValue = 75 },
                new ChartData { xValue = "2022", yValue = 78 },
                new ChartData { xValue = "2023", yValue = 90 },
                new ChartData { xValue = "2024", yValue = 93 },
            };

            ViewBag.dataSource = chartData;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class ChartData
    {
        public string xValue;
        public double yValue;
    }
}
