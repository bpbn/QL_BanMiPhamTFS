using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANCUOIKYLTW.Models;

namespace DOANCUOIKYLTW.Controllers
{
    public class SanPhamController : Controller
    {
        QLMyPhamDataContext db = new QLMyPhamDataContext();
        public ActionResult showProduct()
        {
            return View(db.SANPHAMs.ToList());
        }
        //
        public ActionResult SearchSanPham(string keyword)
        {
            var products = db.SANPHAMs.Where(x => x.TENSP.ToLower().Contains(keyword.ToLower())).ToList();
            if(products.Count<=0)
            {
                ViewBag.TB = "Không tìm thấy "+keyword+" bạn đang tìm";
            }
            return View(products);
        }
        public ActionResult DetailSanPham(string id)
        {

            ViewBag.Comment = db.DANHGIAs.FirstOrDefault(x => x.MASP == id).BINHLUAN;
            if(ViewBag.Comment==null)
            {
                ViewBag.Comment = "Chưa có bình luận";
            }
            return View(db.SANPHAMs.FirstOrDefault(x=>x.MASP==id));
        }
        // GET: /SanPham/
        public ActionResult Index()
        {
            return View();
        }
	}
}