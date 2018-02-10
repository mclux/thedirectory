using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheDirectory.Controllers
{
    public class ListingCategoryController : Controller
    {
        // GET: ListingCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }
    }
}