using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyEmployee.Models;

namespace MyEmployee.Controllers
{
    public class RegistersController : Controller
    {
        private Company_KhayelihleEntities1 db = new Company_KhayelihleEntities1();

        // GET: Registers
        public ActionResult Index()
        {
            var registers = db.Registers.Include(r => r.Register2).Include(r => r.Register2);
            return View(registers.ToList());
        }

        // GET: Registers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            ViewBag.RegID = new SelectList(db.Registers, "RegID", "Username");
            ViewBag.RegID = new SelectList(db.Registers, "RegID", "Username");
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegID,Username,Password")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Registers.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegID = new SelectList(db.Registers, "RegID", "Username", register.RegID);
            ViewBag.RegID = new SelectList(db.Registers, "RegID", "Username", register.RegID);
            return View(register);
        }

        // GET: Registers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegID = new SelectList(db.Registers, "RegID", "Username", register.RegID);
            ViewBag.RegID = new SelectList(db.Registers, "RegID", "Username", register.RegID);
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegID,Username,Password")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegID = new SelectList(db.Registers, "RegID", "Username", register.RegID);
            ViewBag.RegID = new SelectList(db.Registers, "RegID", "Username", register.RegID);
            return View(register);
        }

        // GET: Registers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Register register = db.Registers.Find(id);
            db.Registers.Remove(register);
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
