using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteGS_Shop.Controllers
{
    public class HienThiController : Controller
    {
        // GET: HienThi
        public ActionResult Index()
        {
            return View();
        }
        //Menu
        public PartialViewResult Menu()
        {
            return PartialView();
        }
        //Menu trang Người Bán
        public PartialViewResult MenuNB()
        {
            return PartialView();
        }
    }
}