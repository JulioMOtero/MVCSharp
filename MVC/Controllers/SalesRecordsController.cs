using Microsoft.AspNetCore.Mvc;
using MVC.Services;

namespace MVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordsService;

        public SalesRecordsController(SalesRecordService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? min, DateTime? max)
        {

            if (!min.HasValue)
            {
                min = new DateTime(DateTime.Now.Year,1,1);
            }
            if (!max.HasValue)
            {
                min = DateTime.Now;
            }
            ViewData["min"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["max"] = max.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordsService.FindByDateAsync(min, max);
            return  View(result);
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
