using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPassport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }
            
        }

        public ActionResult About()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Contact()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}