using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AcentyShop.Models;
using AcentyShop.ViewModels;

namespace AcentyShop.Controllers
{
    public class AccountController : Controller
    {
        AcentyShopDataContext db = new AcentyShopDataContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LoginV()
        {
            return PartialView();
        }

        public ActionResult RegisterV()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserVM lg)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tài khoản đã tồn tại
                bool existsUsername = db.NguoiDungs.Any(x => x.TenTaiKhoan == lg.Username);

                if (existsUsername)
                {
                    return Json(new { success = false, message = "Tài khoản đã tồn tại" });
                }

                if (lg.Password != lg.ConfirmPassword)
                {
                    return Json(new { success = false, message = "Mật khẩu và xác nhận mật khẩu không khớp" });
                }

                try
                {
                    

                    // Tạo NguoiDung
                    NguoiDung u = new NguoiDung()
                    {
                        TenTaiKhoan = lg.Username,
                        MatKhau = lg.Password,
                        IdVaiTro = 4,
                        TonTai = true
                    };

                    db.NguoiDungs.InsertOnSubmit(u);
                    db.SubmitChanges();

                    // Lấy IdNguoiDung mới được tạo
                    long newUserId = u.IdNguoiDung;

                    // Thêm bản ghi vào bảng tương ứng
                    
                    KhachHang kh = new KhachHang()
                    {
                        IdNguoiDung = newUserId,
                        TenKhachHang = lg.Username,
                        Email = lg.Email
                    };
                    db.KhachHangs.InsertOnSubmit(kh);
                   

                    db.SubmitChanges();

                    return Json(new
                    {
                        success = true,
                        message = "Đăng ký thành công"
                    });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Đã xảy ra lỗi: " + ex.Message
                    });
                }
            }
            else
            {
                // Trả về lỗi validation nếu ModelState không hợp lệ
                var validationErrors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { success = false, validationErrors });
            }
            //return RedirectToAction("ResetPassword", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login(string userName, string password)
        {
            if (ModelState.IsValid)
            {

                var count = db.NguoiDungs.Count(x => x.TenTaiKhoan == userName && x.MatKhau == password);
                if (count > 0)
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                    return Json(new { success = true, UN = userName });
                }
                else
                {
                    return Json(new { success = false, message = "Đăng nhập thất bại!" });

                }

            }
            else
            {
                var validationErrors = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { success = false, validationErrors });
            }
        }


        public string[] GetRolesForUser(string userName)
        {
            var role = (from nguoiDung in db.NguoiDungs
                        join vaiTro in db.VaiTros on nguoiDung.IdVaiTro equals vaiTro.IdVaiTro
                        where nguoiDung.TenTaiKhoan == userName
                        select vaiTro.TenVaiTro).FirstOrDefault();
            return string.IsNullOrEmpty(role) ? new string[0] : new string[] { role };
        }
        public JsonResult CheckAuthentication()
        {
            if (User.Identity.IsAuthenticated)
            {
                var roles = GetRolesForUser(User.Identity.Name.ToString());

                return Json(new
                {
                    isAuthenticated = true,
                    isInRoleKH = roles.Contains("Khách hàng"),
                    isInRoleNV = roles.Contains("Nhân viên"),
                    isInRoleQL = roles.Contains("Quản lý"),
                    isInRoleAdmin = roles.Contains("Admin"),
                    redirectUrlNV = Url.Action("DashBoard", "NVHome", new { area = "NhanVien" }),
                    redirectUrl = Url.Action("Dashboard", "Account"),
                    redirectUrlKT = Url.Action("FavoritePostPartial", "FavoritePost"),
                    redirectUrlAdmin = Url.Action("DashBoard", "AdminHome", new { area = "Admin" })
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    isAuthenticated = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RoleAndNamePartial()
        {
            string username = User.Identity.Name.ToString();
            if (!string.IsNullOrEmpty(username))
            {
                ViewBag.Roles = GetRolesForUser(username)[0];
                if (ViewBag.Roles == "Admin")
                {
                    ViewBag.EmployeeName = "Phạm Yến Nhi";
                }
                else if (ViewBag.Roles == "Nhân viên" ||ViewBag.Roles == "Quản lí" )
                {
                    ViewBag.EmployeeName = (from nguoiDung in db.NguoiDungs
                                            join nhanVien in db.NhanViens on nguoiDung.IdNguoiDung equals nhanVien.IdNguoiDung
                                            where nguoiDung.TenTaiKhoan == username
                                            select nhanVien.TenNhanVien).FirstOrDefault();
                }
                //else if (ViewBag.Roles == "Quản lý")
                //{
                //    ViewBag.EmployeeName = (from nguoiDung in db.NguoiDungs
                //                            join nct in db.NhanViens on nguoiDung.IdNguoiDung equals nct.IdNguoiDung
                //                            where nguoiDung.TenTaiKhoan == username
                //                            select nct.TenNhanVien).FirstOrDefault();
                //}
                else
                {
                    ViewBag.EmployeeName = (from nguoiDung in db.NguoiDungs
                                            join nt in db.KhachHangs on nguoiDung.IdNguoiDung equals nt.IdNguoiDung
                                            where nguoiDung.TenTaiKhoan == username
                                            select nt.TenKhachHang).FirstOrDefault();
                }


            }
            else
            {
                ViewBag.Roles = string.Empty;
                ViewBag.EmployeeName = string.Empty;
            }
            return PartialView();
        }

        public JsonResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return Json(new { success = true, redirectUrl = "/" });
        }
    }
}