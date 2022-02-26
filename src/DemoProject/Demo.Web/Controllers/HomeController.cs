using Autofac;
using Demo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Demo.Web.Controllers
{
    [Authorize(Policy = "CommonPermission")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILifetimeScope _scope;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            var model = _scope.Resolve<ProductCreateModel>();

            return View(model);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(ProductCreateModel model)
        {
            model.Resolve(_scope);

            if(ModelState.IsValid)
            {
               await model.CreateAsync();
            }

            return RedirectToAction(nameof(Table));
        }

        [Authorize(Policy = "CommonPermission")]
        public IActionResult Table()
        {
            var model = _scope.Resolve<ProductTableModel>();

            return View(model);
        }
        public async Task<JsonResult> GetData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<ProductTableModel>();
            var data = await model.GetProductDataAsyns(dataTableModel);

            return Json(data);
        }

        [Authorize(Roles = "SuperAdmin, Manager")]
        public async Task< IActionResult> Edit(int id)
        {
            var model = _scope.Resolve<ProductEditModel>();

            if (ModelState.IsValid)
            {
                await model.LoadDataAsync(id);
            }

            return View(model);
        }

        [Authorize(Roles = "SuperAdmin, Manager")]
        [HttpPost, ValidateAntiForgeryToken ]
        public async Task<IActionResult> Edit(ProductEditModel model)
        {
            model.Resolve(_scope);

            if (ModelState.IsValid)
            {
                await model.UpdateAsync();
            }

            return RedirectToAction(nameof(Table));
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = _scope.Resolve<ProductTableModel>();

            if (ModelState.IsValid)
            {
                await model.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Table));
        }

        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }
    }
}