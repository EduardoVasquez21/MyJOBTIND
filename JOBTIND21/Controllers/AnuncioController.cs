using JOBTIND21.Data.ViewModels;
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
    public class AnuncioController : Controller
    {
        private readonly ILogger<AnuncioController> _logger;
        private IUsuario iusuario;
        private IEmpresa iempresa;
        private IAnuncio ianuncio;

        public AnuncioController(ILogger<AnuncioController> logger, IUsuario iusuario, IEmpresa iempresa, IAnuncio ianuncio)
        {
            this.iusuario = iusuario;
            this.iempresa = iempresa;
            this.ianuncio = ianuncio;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var anuncio = ianuncio.GetAll().Where(e => e.Estado == true);
            return View(anuncio);
        }

        public IActionResult SaveAnuncio()
        {
            var AnuncioDropDown = ianuncio.GetNewEnrollmentValues();
            ViewBag.Usuario = new SelectList(AnuncioDropDown.Usuario, "Id", "Nombres");
            ViewBag.Empresa = new SelectList(AnuncioDropDown.Empresa, "Id", "NombreEmpresa");
            return View();
        }

        [HttpPost]
        public IActionResult SaveAnuncio(AnuncioViewModel anuncio)
        {
            if (!ModelState.IsValid)
            {
                var AnunData = ianuncio.GetNewEnrollmentValues();
                ViewBag.Usuario = new SelectList(AnunData.Usuario, "Id", "Nombres");
                ViewBag.Empresa = new SelectList(AnunData.Empresa, "Id", "NombreEmpresa");
                return View(anuncio);
            }
            ianuncio.AddAnuncio(anuncio);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult UpdateAnuncio(int id)
        {
            var anuncio = ianuncio.GetEnrollmentById(id);
            if (anuncio == null)
                return View("Error");

            var request = new AnuncioViewModel()
            {
                Id = anuncio.Id,
                UsuarioID = anuncio.UsuarioID,
                EmpresaID = anuncio.EmpresaID,
                Categoria = anuncio.Categoria,
                Anuncios = anuncio.Anuncios,
            };

            var AnunData = ianuncio.GetNewEnrollmentValues();
            ViewBag.Usuario = new SelectList(AnunData.Usuario, "Id", "Nombres");
            ViewBag.Empresa = new SelectList(AnunData.Empresa, "Id", "NombreEmpresa");


            return View(request);
        }

        [HttpPost]
        public IActionResult UpdateAnuncio(int id, AnuncioViewModel anuncio)
        {
            if (id != anuncio.Id)
                return View("Error");

            if (!ModelState.IsValid)
            {
                //var AnuncioData = ianuncio.GetNewEnrollmentValues();
                var AnunData = ianuncio.GetNewEnrollmentValues();
                ViewBag.Usuario = new SelectList(AnunData.Usuario, "Id", "Nombres");
                ViewBag.Empresa = new SelectList(AnunData.Empresa, "Id", "NombreEmpresa");
            }

            ianuncio.UpdateAnuncio(anuncio);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult DeleteAnuncio(int id)
        {
            var anuncio = ianuncio.GetEnrollmentById(id);
            if (anuncio == null)
                return View("Error");

            var request = new AnuncioViewModel()
            {
                Id = anuncio.Id,
                UsuarioID = anuncio.UsuarioID,
                EmpresaID = anuncio.EmpresaID,
                Categoria = anuncio.Categoria,
                Estado = anuncio.Estado = false
            };

            ianuncio.DeleteAnuncio(request);
            return RedirectToAction(nameof(Index));
        }



    }
}
