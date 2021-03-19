using Infracciones.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infracciones.Administracion.Controllers
{
    public class IncisoController : Controller
    {
        // GET: Inciso/Index/FraccionId
        public ActionResult Index(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            List<Inciso> lista;

            lista = IncisoBl.GetAll(id);
            ViewBag.Fraccion = FraccionBl.Get(id);

            return View(lista);
        }

        // GET: Inciso/Details/5
        public ActionResult Details(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            Inciso inciso;

            inciso = IncisoBl.Get(id);
            ViewBag.Fraccion = FraccionBl.Get(inciso.FraccionId);

            return View(inciso);
        }

        // GET: Inciso/Create
        public ActionResult Create(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            ViewBag.Fraccion = FraccionBl.Get(id);

            return View();
        }

        // POST: Inciso/Create
        [HttpPost]
        public ActionResult Create(Inciso inciso)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                inciso.UsuarioIdAlta = (Session["Usuario"] as Usuario).Id;
                if (ModelState.IsValid)
                {
                    IncisoBl.Add(inciso);
                    return RedirectToAction($"Details/{inciso.FraccionId}", "Fraccion");
                }
                else
                {
                    ViewBag.Fraccion = FraccionBl.Get(inciso.FraccionId);
                    return View(inciso);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Inciso/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            Inciso inciso;

            inciso = IncisoBl.Get(id);
            ViewBag.Fraccion = FraccionBl.Get(inciso.FraccionId);

            return View(inciso);
        }

        // POST: Inciso/Edit/5
        [HttpPost]
        public ActionResult Edit(Inciso inciso)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");
                if (ModelState.IsValid)
                {
                    IncisoBl.Update(inciso);
                    return RedirectToAction($"Details/{inciso.FraccionId}", "Fraccion");
                }
                else
                {
                    ViewBag.Fraccion = FraccionBl.Get(inciso.FraccionId);
                    return View(inciso);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Inciso/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            Inciso inciso;

            inciso = IncisoBl.Get(id);
            ViewBag.Fraccion = FraccionBl.Get(inciso.FraccionId);

            return View(inciso);
        }

        // POST: Inciso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");
                Usuario usuario;
                Inciso inciso;

                usuario = (Session["Usuario"] as Usuario);
                inciso = IncisoBl.Get(id);
                IncisoBl.Delete(id, usuario.Id);

                return RedirectToAction($"Details/{inciso.FraccionId}", "Fraccion");
            }
            catch
            {
                return View();
            }
        }
    }
}
