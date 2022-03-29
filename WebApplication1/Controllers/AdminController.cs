using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    [CustomAuthorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Sehirs");
        }        


        //[Yetkilendirme("Admin")]
        public ActionResult Admin()
        {
            return RedirectToAction("Index", "Sehirs");
        }
    }
}