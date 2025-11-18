using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcentyShop.Models;
using AcentyShop.Areas.NhanVien.ViewModel;
using AcentyShop.Areas.NhanVien.ViewModels;
namespace AcentyShop.Areas.NhanVien.Controllers
{

    public class CategoriesController : Controller
    {
        AcentyShopDataContext db = new AcentyShopDataContext();

        // GET: NhanVien/Categories
        public ActionResult GetAllCate(string cateSearchType, string cateSearchInput, string sortCol, string sortType, int page = 1)
        {
            IEnumerable<CategoriesVM> query = null;
            if (!string.IsNullOrEmpty(cateSearchType) && !string.IsNullOrEmpty(cateSearchInput))
            {
                query = db.LoaiSanPhams
                        .Where(c => c.TenLoaiSP.Contains(cateSearchInput))
                        .Select(lsp => new CategoriesVM
                        {
                            Category = lsp,

                        });
            }
            else
            {
                query = from lsp in db.LoaiSanPhams
                        orderby lsp.IdLoaiSP descending
                        select new CategoriesVM
                        {
                            Category = lsp,
                        };
            }
            int NoOfRecordPerPage = 12;
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
                    case "nameCategory":
                        if (sortType == "ASC")
                            query = query.OrderBy(x => x.TenLoaiSP);
                        else if (sortType == "DESC")
                            query = query.OrderByDescending(x => x.TenLoaiSP);
                        else return HttpNotFound();
                        break;
                    case "nameParentCategory":
                        if (sortType == "ASC")
                            query = query.OrderBy(x => x.TenLoaiSPCha);
                        else if (sortType == "DESC")
                            query = query.OrderByDescending(x => x.TenLoaiSPCha);
                        else return HttpNotFound();
                        break;
                    default:
                        return HttpNotFound();
                }
            }
            return View(query);
        }



        public ActionResult GetLoaiSanPham(int parentId)
        {
            // Retrieve child types based on the selected parent type (parentId)
            var childTypes = db.LoaiSanPhams.Where(pt => pt.IdLoaiSPCha == parentId).ToList();

            var childItems = childTypes.Select(pt => new SelectListItem
            {
                Value = pt.IdLoaiSP.ToString(),
                Text = pt.TenLoaiSP.ToString()
            });

            return Json(childItems, JsonRequestBehavior.AllowGet);
        }
    }
}