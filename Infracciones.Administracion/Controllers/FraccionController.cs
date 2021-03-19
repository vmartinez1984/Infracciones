using Infracciones.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infracciones.Administracion.Controllers
{
    public class FraccionController : Controller
    {
        // GET: Fraccion
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        // GET: Fraccion/Details/5
        public ActionResult Details(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            Fraccion fraccion;

            fraccion = FraccionBl.Get(id);
            ViewBag.FraccionId = fraccion.Id;
            ViewBag.ListaDeincisos = IncisoBl.GetAll(id);

            return View(fraccion);
        }

        // GET: Fraccion/Create/{articuloId}
        public ActionResult Create(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            ViewBag.Articulo = ArticuloBl.Get(id);

            return View();
        }

        // POST: Fraccion/Create
        [HttpPost]
        public ActionResult Create(Fraccion fraccion)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                fraccion.UsuarioIdAlta = (Session["Usuario"] as Usuario).Id;
                if (ModelState.IsValid)
                {
                    FraccionBl.Add(fraccion);
                    return RedirectToAction($"Details/{fraccion.ArticuloId}", "Articulo");
                }
                else
                {
                    ViewBag.Articulo = ArticuloBl.Get(fraccion.ArticuloId);
                    return View(fraccion);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Fraccion/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            Fraccion fraccion;

            fraccion = FraccionBl.Get(id);

            return View(fraccion);
        }

        // POST: Fraccion/Edit/5
        [HttpPost]
        public ActionResult Edit(Fraccion fraccion)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");
                if (ModelState.IsValid)
                {
                    FraccionBl.Update(fraccion);
                    return RedirectToAction($"Details/{fraccion.ArticuloId}","Articulo");
                }
                else
                {
                    return View(fraccion);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Fraccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");
            //if (id is null)
            //   return RedirectToAction($"Details/{fraccion.ArticuloId}", "Articulo");

            Fraccion fraccion;

            fraccion = FraccionBl.Get((int)id);

            return View(fraccion);
        }

        // POST: Fraccion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                Usuario usuario;
                Fraccion fraccion;

                usuario = (Session["Usuario"] as Usuario);
                fraccion = FraccionBl.Get(id);
                FraccionBl.Delete(id, usuario.Id);

                return RedirectToAction($"Details/{fraccion.ArticuloId}", "Articulo");
            }
            catch
            {
                return View();
            }
        }
    }
}
