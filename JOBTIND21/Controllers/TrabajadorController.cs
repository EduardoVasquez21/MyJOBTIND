using JOBTIND21.Data.ViewModels;
using JOBTIND21.Dominio;
using JOBTIND21.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Controllers
{
    public class TrabajadorController : Controller
    {
        private readonly ILogger<TrabajadorController> _logger;
        private IUserTrabajador iusertrabajador;
        private IPerfilTrabajador iperfiltrabajador;

        public TrabajadorController(ILogger<TrabajadorController> logger, IUserTrabajador iusertrabajador, IPerfilTrabajador iperfiltrabajador)
        {
            this.iusertrabajador = iusertrabajador;
            this.iperfiltrabajador = iperfiltrabajador;
            _logger = logger;
        }

        public IActionResult DescripcionVist()
        {
            var descripcionuno = iperfiltrabajador.GetAll().Where(e => e.State == true);
            return View(descripcionuno);

        }

        public IActionResult WorkerVist()
        {
            var worker = iusertrabajador.GetAll();

            return View(worker);
        }


        public IActionResult AddTrabajador()
        {
            ViewBag.State = "AddTrabajador";
            ViewBag.Titulo = "Add Worker";
            return View("AddTrabajador");
        }

        [HttpPost]
        public IActionResult AddTrabajador([Bind("Id,Name,LastName,Age,Email,Password")] UserTrabajador t)
        {
            if (ModelState.IsValid)
            {
                iusertrabajador.Save(t);
                return RedirectToAction("WorkerList");
            }
            else
            {
                return View(t);
            }

        }

        public IActionResult UpdateWorker(int id)
        {
            ViewBag.State = "UpdateWorker";
            ViewBag.Title = "Update Worker";
            var UserTEdit = iusertrabajador.GetById(id);
            if (UserTEdit == null)
                return View("Error");
            return View(UserTEdit);
        }


        [HttpPost]
        public IActionResult UpdateWorker(int id, [Bind("Id,Name,LastName,Age,Email,Password")] UserTrabajador t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            iusertrabajador.Update(id, t);
            return RedirectToAction("WorkerList");

        }

        public IActionResult GetAll()
        {
            var DandoFormatoJsonTrabajador = iusertrabajador.GetAll();

            return Json(new { data = DandoFormatoJsonTrabajador });
        }

        public IActionResult WorkerList()
        {
            var worker = iusertrabajador.GetAll();

            return View(worker);
        }


        //ApartadoDescripcion

        public IActionResult Descripcion()
        {
            var descripcion = iperfiltrabajador.GetAll().Where(e => e.State == true);
            return View(descripcion);
        }

        public IActionResult AddDescription()
        {
            var PerfilDropDown = iperfiltrabajador.GetNewPerfilValues();
            ViewBag.Trabajador = new SelectList(PerfilDropDown.UserTrabajador, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddDescription(PerfilTrabajadorViewModel perfil)
        {
            if (!ModelState.IsValid)
            {
                var perfildata = iperfiltrabajador.GetNewPerfilValues();
                ViewBag.Trabajador = new SelectList(perfildata.UserTrabajador, "Id", "Name");

                return View(perfil);
            }
            iperfiltrabajador.AddPerfil(perfil);
            return RedirectToAction(nameof(Descripcion));

        }

        public IActionResult UpdateDescription(int id)
        {
            var perfil = iperfiltrabajador.GetPerfilById(id);
            if (perfil == null)
                return View("Error");

            var request = new PerfilTrabajadorViewModel()
            {
                Id = perfil.Id,
                UserTrabajadorID = perfil.UserTrabajadorID,
                DUI = perfil.DUI,
                Telephone=perfil.Telephone,
                CVLink=perfil.CVLink,
                Descripcion=perfil.Descripcion,


            };

            var perfildata = iperfiltrabajador.GetNewPerfilValues();
            ViewBag.Trabajador = new SelectList(perfildata.UserTrabajador, "Id", "Name");


            return View(request);
        }

        [HttpPost]
        public IActionResult UpdateDescription(int id, PerfilTrabajadorViewModel perfil)
        {
            if (id != perfil.Id)
                return View("Error");

            if (!ModelState.IsValid)
            {

                var perfildata = iperfiltrabajador.GetNewPerfilValues();
                ViewBag.Trabajador = new SelectList(perfildata.UserTrabajador, "Id", "Name");
            }

            iperfiltrabajador.UpdatePerfil(perfil);
            return RedirectToAction(nameof(Descripcion));

        }

        public IActionResult DeleteDescription(int id)
        {
            var perfil = iperfiltrabajador.GetPerfilById(id);
            if (perfil == null)
                return View("Error");

            var request = new PerfilTrabajadorViewModel()
            {
                Id = perfil.Id,
                UserTrabajadorID=perfil.UserTrabajadorID,
                DUI = perfil.DUI,
                Telephone = perfil.Telephone,
                CVLink = perfil.CVLink,
                Descripcion = perfil.Descripcion,
                State = perfil.State = false
            };

            iperfiltrabajador.DeletePerfil(request);
            return RedirectToAction(nameof(Descripcion));
        }

        public IActionResult SeeMore(int id)
        {
            var perfil = iperfiltrabajador.GetPerfilById(id);
            if (perfil == null)
                return View("Error");

            var request = new PerfilTrabajadorViewModel()
            {
                Id = perfil.Id,
                UserTrabajadorID = perfil.UserTrabajadorID,
                DUI = perfil.DUI,
                Telephone = perfil.Telephone,
                CVLink = perfil.CVLink,
                Descripcion = perfil.Descripcion,


            };

            var perfildata = iperfiltrabajador.GetNewPerfilValues();
            ViewBag.Trabajador = new SelectList(perfildata.UserTrabajador, "Id", "Name");


            return View(request);
        }
    }
}
