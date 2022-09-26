using Microsoft.AspNetCore.Mvc;
using NEWHOUSE2022.Models;
using System.Diagnostics;

namespace NEWHOUSE2022.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
