using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebsiteGS_Shop.Models;

namespace WebsiteGS_Shop.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        WebsiteGSShopEntities db = new WebsiteGSShopEntities();
        public ActionResult DangNhap()
        {
            KhachHang kh = (KhachHang)Session["tk"];
            if (kh != null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            String sTaiKhoan = f["Name"].ToString();
            String sMatKhau = f["password"].ToString();
            KhachHang kh = db.KhachHang.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (kh != null)
            {
                Session["tk"] = kh;
                return Redirect("/Home/Index");
            }  
            else if (sTaiKhoan == "")
            {
                ViewBag.TaiKhoan = "Vui lòng nhập tài khoản !";
            }  
            else if (sMatKhau == "")
            {
                ViewBag.MatKhau = "Vui lòng nhập mật khẩu !";
            }
            else
            {
                ViewBag.TKMK = "<div class='alert alert-danger'>Sai tài khoản hoặc mật khẩu !</div>";
            }    
            return View();
        }
        //Đăng Xuất
        public ActionResult DangXuat()
        {
            Session["tk"] = null;
            return Redirect("/DangNhap/DangNhap");
        }
        //Đăng nhập Người Bán
        public ActionResult DangNhapNB()
        {
            NguoiBan nb = (NguoiBan)Session["nb"];
            if (nb != null)
            {
                return Redirect("/DangNhap/DangNhap");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapNB(FormCollection f)
        {
            String sTaiKhoan1 = f["taikhoan"].ToString();
            String sMatKhau1 = f["matkhau"].ToString();
            NguoiBan nb = db.NguoiBan.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan1 && n.MatKhau == sMatKhau1);
            if (nb != null)
            {
                Session["nb"] = nb;
                return Redirect("/Home/LayoutNB");
            }
            else if (sTaiKhoan1 == "")
            {
                ViewBag.TaiKhoan = "Vui lòng nhập tài khoản !";
            }
            else if (sMatKhau1 == "")
            {
                ViewBag.MatKhau = "Vui lòng nhập mật khẩu !";
            }
            else
            {
                ViewBag.TKMK = "<div class='alert alert-danger'>Sai tài khoản hoặc mật khẩu !</div>";
            }
            return View();
        }
    }
}