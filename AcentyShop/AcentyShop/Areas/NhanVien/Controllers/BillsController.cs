using AcentyShop.Models;
using AcentyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcentyShop.Areas.NhanVien.Controllers
{
    public class BillsController : Controller
    {
        // GET: NhanVien/Bills
        AcentyShopDataContext db = new AcentyShopDataContext();
        public ActionResult GetAll(string sortCol, string sortType, int page = 1)
        {
            IEnumerable<HoaDonVM> query = null;

            query = from hoaDon in db.HoaDons
                    orderby hoaDon.IdHoaDon descending
                    select new HoaDonVM
                    {
                        HoaDon = hoaDon,
                        TongTien = db.func_TongTienHoaDon(hoaDon.IdHoaDon),
                        ListChiTietHoaDon = db.ChiTietHoaDons.Where(ct => ct.IdHoaDon == hoaDon.IdHoaDon).ToList(),
                    };


            // Paging
            int NoOfRecordPerPage = 10;
            int NoOfPages = (int)Math.Ceiling((double)query.Count() / NoOfRecordPerPage);
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.STT = (page - 1) * NoOfRecordPerPage + 1;
            ViewBag.NoOfPages = NoOfPages;
            query = query.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage);
            if (!string.IsNullOrEmpty(sortCol) && !string.IsNullOrEmpty(sortType))
            {
                switch (sortCol)
                {
                    case "IdKhachHang":
                        if (sortType == "ASC")
                            query = query.OrderBy(x => x.HoaDon.IdNhanVien);
                        else if (sortType == "DESC")
                            query = query.OrderByDescending(x => x.HoaDon.IdNhanVien);
                        else return HttpNotFound();
                        break;
                    case "TongTien":
                        if (sortType == "ASC")
                            query = query.OrderBy(x => x.TongTien);
                        else if (sortType == "DESC")
                            query = query.OrderByDescending(x => x.TongTien);
                        else return HttpNotFound();
                        break;
                    //case "ThoiGianDat":
                    //    if (sortType == "ASC")
                    //        query = query.OrderBy(x => x.HoaDon.ThoiGianDatHang);
                    //    else if (sortType == "DESC")
                    //        query = query.OrderByDescending(x => x.DonHang.ThoiGianDatHang);
                    //    else return HttpNotFound();
                    //    break;
                    //case "TrangThai":
                    //    if (sortType == "ASC")
                    //        query = query.OrderBy(x => x.DonHang.TrangThaiDonHang);
                    //    else if (sortType == "DESC")
                    //        query = query.OrderByDescending(x => x.DonHang.TrangThaiDonHang);
                    //    else return HttpNotFound();
                    //    break;
                    default:
                        return HttpNotFound();
                }
            }

            return View(query);
        }
    }
}