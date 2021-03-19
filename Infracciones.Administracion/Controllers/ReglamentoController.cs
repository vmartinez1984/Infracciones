using Infracciones.BusinessLayer;
using Infracciones.Dto;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Infracciones.Administracion.Controllers
{
    public class ReglamentoController : Controller
    {
        // GET: Reglamento
        public ActionResult Index(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            List<Reglamento> lista;

            lista = ReglamentoBl.GetAll(id);

            return View(lista);
        }

        // GET: Reglamento/Details/5
        public ActionResult Details(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            Reglamento reglamento;

            reglamento = ReglamentoBl.Get(id);

            return View(reglamento);
        }

        // GET: Reglamento/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        // POST: Reglamento/Create
        [HttpPost]
        public ActionResult Create(Reglamento   reglamento)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            try
            {
                reglamento.UsuarioIdAlta = (Session["Usuario"] as Usuario).Id;
                if (ModelState.IsValid)
                {
                    ReglamentoBl.Add(reglamento);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(reglamento);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Reglamento/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            Reglamento reglamento;

            reglamento = ReglamentoBl.Get(id);

            return View(reglamento);
        }

        // POST: Reglamento/Edit/5
        [HttpPost]
        public ActionResult Edit(Reglamento reglamento)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            try
            {
                if (ModelState.IsValid)
                {
                    ReglamentoBl.Update(reglamento);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(reglamento);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Reglamento/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Home");

            Reglamento reglamento;

            reglamento = ReglamentoBl.Get(id);

            return View(reglamento);
        }

        // POST: Reglamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (Session["Usuario"] == null)
                    return RedirectToAction("Login", "Home");

                ReglamentoBl.Delete(id, (Session["Usuario"] as Usuario).Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
