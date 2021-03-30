using Infracciones.BusinessLayer;
using Infracciones.Dto;
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

        [HttpPost]
        public ActionResult Index(BoletaDeSancion boletaDeSancion)
        {
            List<BoletaDeSancion> lista;

            lista = BoletaDeSancionBl.Get(boletaDeSancion.Placa);

            return View("ListaDeSanciones", lista);
        }

        // GET: BoletaDeSancion/Details/5
        public ActionResult Details(int id)
        {
            BoletaDeSancion boletaDeSancion;

            boletaDeSancion = BoletaDeSancionBl.Get(id);

            return View(boletaDeSancion);
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
        public ActionResult Create(BoletaDeSancion boleta)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                boleta.UsuarioId = (Session["Usuario"] as Usuario).Id;
                if (ModelState.IsValid)
                {
                    BoletaDeSancionBl.Add(boleta);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ListaDeArticulos = ArticuloBl.GetAll();
                    ViewBag.ListaDeIncisos = IncisoBl.GetAll();
                    return View(boleta);
                }
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
