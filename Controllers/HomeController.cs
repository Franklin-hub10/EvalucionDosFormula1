using Microsoft.AspNetCore.Mvc;
using FormulaUno.Services;

namespace FormulaUno.Controllers
{
    public class HomeController : Controller
    {
        private readonly F1Service _f1;
        private const int DefaultPageSize = 10;

        public HomeController(F1Service f1) => _f1 = f1;

        public async Task<IActionResult> Index(int page = 1, int pageSize = DefaultPageSize)
        {
            var vm = await _f1.GetDriversPageAsync(page, pageSize);
            return View(vm);
        }

        public async Task<IActionResult> Details(string id)
        {
            var d = await _f1.GetDriverAsync(id);
            if (d is null) return NotFound();
            return View(d);
        }
    }
}
