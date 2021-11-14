using JOBTIND21.Dominio;
using JOBTIND21.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private IUsuario iusuario;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuario iusuario)
        {
            this.iusuario = iusuario;
            _logger = logger;
        }
        public IActionResult SaveUser()
        {
            ViewBag.State = "SaveUser";
            ViewBag.Titulo = "Add";
            return View("SaveUser");
        }

        [HttpPost]
        public IActionResult SaveUser([Bind("Id,Nombres,Apellidos,Edad,DUI,Telefono,Email,Contraseña")] Usuario u)
        {
            if (ModelState.IsValid)
            {
                iusuario.Save(u);
                return RedirectToAction("UserList");
            }
            else
            {
                return View(u);
            }

        }

        public IActionResult UpdateUser(int id)
        {
            ViewBag.State = "UpdateUser";
            ViewBag.Title = "Update User";
            var UserEdit = iusuario.GetById(id);
            if (UserEdit == null)
                return View("Error");
            return View(UserEdit);
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, [Bind("Id,Nombres,Apellidos,Edad,DUI,Telefono,Email,Contraseña")] Usuario u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            iusuario.Update(id, u);
            return RedirectToAction("UserList");

        }


        public IActionResult GetAll()
        {
            var DandoFormatoJsonUser = iusuario.GetAll();

            return Json(new { data = DandoFormatoJsonUser });
        }

        public IActionResult UserList()
        {
            var users = iusuario.GetAll();

            return View(users);
        }
    }
}
