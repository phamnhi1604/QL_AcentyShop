using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcentyShop.Models;

namespace AcentyShop.Areas.NhanVien.Controllers
{
    public class NVHomeController : Controller
    {
        AcentyShopDataContext db = new AcentyShopDataContext();

        // GET: NhanVien/NVHome
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}