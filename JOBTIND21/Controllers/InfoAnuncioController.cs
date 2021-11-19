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
    public class InfoAnuncioController : Controller
    {

        private readonly ILogger<InfoAnuncioController> _logger;
        private IAnuncioInfo ianuncioInfo ;

        public InfoAnuncioController(ILogger<InfoAnuncioController> logger, IAnuncioInfo ianuncioInfo)
        {
            this.ianuncioInfo = ianuncioInfo;
            _logger = logger;
        }

        public IActionResult InformationAnun()
        {
            var anunif = ianuncioInfo.GetAll().Where(e => e.Stado == true);
            return View(anunif);
        }
        public IActionResult AddInfo()
        {
            var InfoDropDown = ianuncioInfo.GetNewInfoValues();
            ViewBag.Info = new SelectList(InfoDropDown.Anuncio, "Id", "Anuncios");
            return View();
        }

        [HttpPost]
        public IActionResult AddInfo(InfoAnuncioViewModel info)
        {
            if (!ModelState.IsValid)
            {
                var infodata = ianuncioInfo.GetNewInfoValues();
                ViewBag.Info = new SelectList(infodata.Anuncio, "Id", "Anuncios");

                return View(info);
            }
            ianuncioInfo.AddInfo(info);
            return RedirectToAction(nameof(InformationAnun));

        }

        public IActionResult UpdateInfo(int id)
        {
            var infoA = ianuncioInfo.GetinfoById(id);
            if (infoA == null)
                return View("Error");

            var requesst = new InfoAnuncioViewModel()
            {
                Id = infoA.Id,

                AnuncioID = infoA.AnuncioID,
                EdadRequerida = infoA.EdadRequerida,
                Requisitos = infoA.Requisitos,
                Horarios = infoA.Horarios,
                Salario = infoA.Salario,
                Lugar = infoA.Lugar,

            };

            var infodata = ianuncioInfo.GetNewInfoValues();
            ViewBag.Info = new SelectList(infodata.Anuncio, "Id", "Anuncios");


            return View(requesst);
        }

        [HttpPost]
        public IActionResult UpdateInfo(int id, InfoAnuncioViewModel infos)
        {
            if (id != infos.Id)
                return View("Error");

            if (!ModelState.IsValid)
            {
                var infodata = ianuncioInfo.GetNewInfoValues();
                ViewBag.Info = new SelectList(infodata.Anuncio, "Id", "Anuncios");
            }

            ianuncioInfo.UpdateInfo(infos);
            return RedirectToAction(nameof(InformationAnun));

        }

        public IActionResult DeleteProfile(int id)
        {
            var infoA = ianuncioInfo.GetinfoById(id);
            if (infoA == null)
                return View("Error");

            var requesst = new InfoAnuncioViewModel()
            {
                Id = infoA.Id,

                AnuncioID = infoA.AnuncioID,
                EdadRequerida = infoA.EdadRequerida,
                Requisitos = infoA.Requisitos,
                Horarios = infoA.Horarios,
                Salario = infoA.Salario,
                Lugar = infoA.Lugar,
                Stado = infoA.Stado=false

            };

            ianuncioInfo.DeleteInfo(requesst);
            return RedirectToAction(nameof(InformationAnun));
        }

        public IActionResult SeeInfo(int id)
        {
            var infoA = ianuncioInfo.GetinfoById(id);
            if (infoA == null)
                return View("Error");

            var requesst = new InfoAnuncioViewModel()
            {
                Id = infoA.Id,

                AnuncioID = infoA.AnuncioID,
                EdadRequerida = infoA.EdadRequerida,
                Requisitos = infoA.Requisitos,
                Horarios = infoA.Horarios,
                Salario = infoA.Salario,
                Lugar = infoA.Lugar,

            };

            var infodata = ianuncioInfo.GetNewInfoValues();
            ViewBag.Info = new SelectList(infodata.Anuncio, "Id", "Anuncios");


            return View(requesst);

        }
    }
}
