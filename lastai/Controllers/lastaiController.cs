using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lastai.Models;
using System.Data;
using System.Data.Entity;

namespace lastai.Controllers
{
    public class lastaiController : Controller
    {
        private lastaiEntities db = new lastaiEntities();



        // GET information from the database and view it on index page

        public ActionResult Index(string searchString)
        {
            // return View(db.MovieTables.ToList());

            // create drop down list
            

            var programmer = from m in db.lastaiTables
                         select m;


            //title search
            if (!String.IsNullOrEmpty(searchString))
            {
                programmer = programmer.Where(s => s.Short_Description.Contains(searchString));
            }
            return View(programmer);


        }


        //add details to the database
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Name, Picture, Nationality, Born, Quote, Profession, Title, Short_Description, Long_Description")]lastaiTable programmer)
        {
            if (ModelState.IsValid)
            {

                //add database code

                db.lastaiTables.Add(programmer);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(programmer);
        }

        //view details of a particular programmer
        public ActionResult Details(int? id)
        {
            lastaiTable programmer = db.lastaiTables.Find(id);
            if (id != null)
            {

            }
            return View(programmer);
        }

        //edit information page
        public ActionResult Edit(int? id)
        {
            lastaiTable movie = db.lastaiTables.Find(id);
            if (id != null)
            {

            }
            return View(movie);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name, Picture, Nationality, Born, Quote, Profession, Title, Short_Description, Long_Description")]lastaiTable programmer)
        {
            if (ModelState.IsValid)
            {

                //update database code

                db.Entry(programmer).State = EntityState.Modified;
                db.SaveChanges();



            }
            return View(programmer);
        }

        //delete information
        public ActionResult Delete(int? id)
        {
            lastaiTable movie = db.lastaiTables.Find(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //find the movie again
            lastaiTable movie = db.lastaiTables.Find(id);

            //delete it from the database
            db.lastaiTables.Remove(movie);
            db.SaveChanges();

            //return to the index page
            return RedirectToAction("Index");

        }
    }
}