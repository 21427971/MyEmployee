using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyEmployee.Models;
//Msimango KSI
namespace MyEmployee.Controllers
{
    public class PeopleController : Controller
    {
        private Company_KhayelihleEntities1 db = new Company_KhayelihleEntities1();

        // GET: People
        public ActionResult Index()
        {
          var people = db.People.Include(p => p.Role);
          
            return View(people.ToList());
        }

        public async Task<ActionResult> Index2(string searchString)
        {
            var pp = (from c in db.People select c);
            if (!string.IsNullOrEmpty(searchString))
            {
                pp = pp.Where(s => s.Name.Contains(searchString));
            }
            return View(await pp.ToListAsync());
        }
        [HttpPost]
        public string Index(string SearchString, bool notUsed)
        {
            return "From [HttpPost]Index:filter on " + SearchString;
        }


        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.Role_ID = new SelectList(db.Roles, "ID", "Role_Description");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Number,Name,Surname,Contact_Number,IsActive,Created_Date,Email,Role_ID,Salary,Gender,Province")] Person person)
        {
            if (ModelState.IsValid)
            {
              
                if(person.Gender=="Male")
                {
                    person.Gender = "Male";
                }
                else
                    if (person.Gender == "Female")
                {
                    person.Gender  = "Female";

                }
                if(person.Province=="KZN")
                {
                    person.Province = "KZN";
                }
                else
                if (person.Province == "Gauteng")
                {
                    person.Province = "Gauteng";
                }
                if (person.Province == "Limpopo")
                {
                    person.Province = "Limpopo";
                }
                else
                if (person.Province == "MP")
                {
                    person.Province = "MP";
                }
                else
                if (person.Province == "North West")
                {
                    person.Province = "North West";
                }
                else
                if (person.Province == "Eastern Cape")
                {
                    person.Province = "Eastern Cape";
                }
                else
                if (person.Province == "Free State")
                {
                    person.Province = "Free State";
                }

                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Role_ID = new SelectList(db.Roles, "ID", "Role_Description", person.Role_ID);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_ID = new SelectList(db.Roles, "ID", "Role_Description", person.Role_ID);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Number,Name,Surname,Contact_Number,IsActive,Created_Date,Email,Role_ID,Salary,Gender,Province")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role_ID = new SelectList(db.Roles, "ID", "Role_Description", person.Role_ID);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
