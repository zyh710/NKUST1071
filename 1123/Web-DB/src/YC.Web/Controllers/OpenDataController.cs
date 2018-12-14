using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YC.Database;

namespace YC.Web.Controllers
{
    public class OpenDataController : Controller
    {
        public IActionResult Index()
        {
            OpenDataDbContext db = new OpenDataDbContext();

            List<YC.Models.OpenData> models = db.OpenData.ToList();

            return View(models);
        }
    }
}