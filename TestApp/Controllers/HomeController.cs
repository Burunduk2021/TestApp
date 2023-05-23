using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Models;

namespace TestApp.Controllers
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
            List<VacancyVM> model = CreateTestModel();
            return View(model);
        }

        //get partial for AJAX
        [HttpPost]
        public IActionResult GetPartialOnlySelectedVacancy(string selectedVac, int selectedId)
        {
            List<VacancyVM> model = CreateTestModel();
            model.RemoveAll(vac => vac.Name != selectedVac);
            return PartialView("_partial.VacancyTable", model);
        }

        //get partial for AJAX
        [HttpPost]
        public IActionResult GetPartialWithAllVacancies(string selectedVac, int selectedId)
        {
            List<VacancyVM> model = CreateTestModel();
            return PartialView("_partial.VacancyTable", model);
        }


        public IActionResult About()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //private method
        private List<VacancyVM> CreateTestModel()
        {
            List<VacancyVM> model = new();
            VacancyVM vac1 = new VacancyVM() { 
                                     Name = "Test1",
                                     Description = "Test1",
                                     Salary = 2000,
                                     NeedDegree = true,           
                                    };
            model.Add(vac1);
            VacancyVM vac2 = new VacancyVM()
            {
                Name = "Test2",
                Description = "Test2",
                Salary = 100,
                NeedDegree = false,
            };
            model.Add(vac2);
            VacancyVM vac3 = new VacancyVM()
            {
                Name = "Test",
                Description = "Test",
                Salary = 1500,
                NeedDegree = true,
            };
            model.Add(vac3);

            return model;
        }


    }
}