using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Infrastructure;
using Nop.Services;
using Nop.Web.Models;

namespace Nop.Web.Controllers
{
    public class HomeController : Controller
    {

        #region fileds
        private readonly IProductService productService;
        #endregion
        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            //利用EngineContex进行解析
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            ViewBag.result =  this.productService.GetProductById(1);
            ViewBag.result2 = productAttributeService.GetProductAttributeById(1);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
}
