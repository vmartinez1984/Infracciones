using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infracciones.Administracion.Controllers
{
    public class BoletaDeSancionController : Controller
    {
        // GET: BoletaDeSancion
        public ActionResult Index()
        {
            return View();
        }

        // GET: BoletaDeSancion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BoletaDeSancion/Create
        public ActionResult Create()
        {
            ViewBag.ListaDeArticulos = ArticuloBl.GetAll();
            ViewBag.ListaDeIncisos = IncisoBl.GetAll();

            return View();
        }

        // POST: BoletaDeSancion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BoletaDeSancion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BoletaDeSancion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BoletaDeSancion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BoletaDeSancion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
