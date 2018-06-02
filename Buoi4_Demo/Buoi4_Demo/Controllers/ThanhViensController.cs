using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Buoi4_Demo.Models;

namespace Buoi4_Demo.Controllers
{
    public class ThanhViensController : Controller
    {
        private QuanLyThanhVienEntities db = new QuanLyThanhVienEntities();

        // GET: ThanhViens
        public ActionResult Index()
        {
            var thanhViens = db.ThanhViens.Include(t => t.LoaiThanhVien);
            return View(thanhViens.ToList());
        }

        [HttpPost]
        public ActionResult Search(string keyword="")
        {
            var thanhViens = db.usp_Tim_ThanhVien_TheoTen(keyword);

            return View("Index", thanhViens.ToList());  
        }

        // GET: ThanhViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // GET: ThanhViens/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiThanhVien = new SelectList(db.LoaiThanhViens, "MaLoaiThanhVien", "TenLoaiThanhVien");
            return View();
        }

        // POST: ThanhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.usp_Them_ThanhVien(thanhVien.TaiKhoan, thanhVien.MatKhau, thanhVien.HoTen, thanhVien.Email, thanhVien.DiaChi, thanhVien.SoDienThoai, thanhVien.MaLoaiThanhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiThanhVien = new SelectList(db.LoaiThanhViens, "MaLoaiThanhVien", "TenLoaiThanhVien", thanhVien.MaLoaiThanhVien);
            return View(thanhVien);
        }

        // GET: ThanhViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiThanhVien = new SelectList(db.LoaiThanhViens, "MaLoaiThanhVien", "TenLoaiThanhVien", thanhVien.MaLoaiThanhVien);
            return View(thanhVien);
        }

        // POST: ThanhViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.usp_Sua_ThanhVien(thanhVien.TaiKhoan, thanhVien.MatKhau, thanhVien.HoTen, thanhVien.Email, thanhVien.DiaChi, thanhVien.SoDienThoai, thanhVien.MaLoaiThanhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiThanhVien = new SelectList(db.LoaiThanhViens, "MaLoaiThanhVien", "TenLoaiThanhVien", thanhVien.MaLoaiThanhVien);
            return View(thanhVien);
        }

        // GET: ThanhViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // POST: ThanhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //ThanhVien thanhVien = db.ThanhViens.Find(id);
            //db.ThanhViens.Remove(thanhVien);
            db.usp_Xoa_ThanhVien(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
