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
    public class EmpresaController : Controller
    {
        private readonly ILogger<EmpresaController> _logger;
        private IEmpresa iempresa;
        private IPerfilEmpresa iperfilEmpresa;

        public EmpresaController(ILogger<EmpresaController> logger, IEmpresa iempresa, IPerfilEmpresa iperfilEmpresa)
        {
            this.iempresa = iempresa;
            this.iperfilEmpresa= iperfilEmpresa;
            _logger = logger;
        }
        public IActionResult SaveEnterprise()
        {
            ViewBag.State = "SaveEnterprise";
            ViewBag.Titulo = "Add";
            return View("SaveEnterprise");
        }

        [HttpPost]
        public IActionResult SaveEnterprise([Bind("Id,NombreEmpresa,TelefonoEmp,EmailEmp,ContraseñaEmp,Vacante")] Empresa e)
        {
            if (ModelState.IsValid)
            {
                iempresa.Save(e);
                return RedirectToAction("CompanyList");
            }
            else
            {
                return View(e);
            }

        }

        public IActionResult EnterpriseUpdate(int id)
        {
            ViewBag.State = "EnterpriseUpdate";
            ViewBag.Title = "Update Course";
            var EnterpriseEdit = iempresa.GetById(id);
            if (EnterpriseEdit == null)
                return View("Error");
            return View(EnterpriseEdit);
        }

        [HttpPost]
        public IActionResult EnterpriseUpdate(int id, [Bind("Id,NombreEmpresa,TelefonoEmp,EmailEmp,ContraseñaEmp,Vacante")] Empresa e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);
            }
            iempresa.Update(id, e);
            return RedirectToAction("CompanyList");

        }


        public IActionResult GetAll()
        {
            var DandoFormatoJsonStudent = iempresa.GetAll();

            return Json(new { data = DandoFormatoJsonStudent });
        }

        public IActionResult CompanyList()
        {
            var companys = iempresa.GetAll();

            return View(companys);
        }

        //Apartado Perfil de la empresa

        public IActionResult Profile()
        {
            var prof = iperfilEmpresa.GetAll().Where(e => e.States == true);
            return View(prof);
        }

        public IActionResult AddProfile()
        {
            var PerfilEDropDown = iperfilEmpresa.GetNewPerfilEValues();
            ViewBag.Empr = new SelectList(PerfilEDropDown.Empresa, "Id", "NombreEmpresa");
            return View();
        }

        [HttpPost]
        public IActionResult AddProfile(PerfilEmpresaViewModels perfilEmp)
        {
            if (!ModelState.IsValid)
            {
                var perfildataE = iperfilEmpresa.GetNewPerfilEValues();
                ViewBag.Empr = new SelectList(perfildataE.Empresa, "Id", "NombreEmpresa");

                return View(perfilEmp);
            }
            iperfilEmpresa.AddPerfilE(perfilEmp);
            return RedirectToAction(nameof(AddProfile));

        }

        public IActionResult UpdateProfile(int id)
        {
            var perfilEM = iperfilEmpresa.GetPerfilEById(id);
            if (perfilEM == null)
                return View("Error");

            var requesst = new PerfilEmpresaViewModels()
            {
                Id = perfilEM.Id,
                EmpresaID = perfilEM.EmpresaID,
                DepartamentoOperario = perfilEM.DepartamentoOperario,
                DescripcionEmpresa = perfilEM.DescripcionEmpresa,

            };

            var perfildataE = iperfilEmpresa.GetNewPerfilEValues();
            ViewBag.Empr = new SelectList(perfildataE.Empresa, "Id", "NombreEmpresa");


            return View(requesst);
        }


        [HttpPost]
        public IActionResult UpdateProfile(int id, PerfilEmpresaViewModels perfil)
        {
            if (id != perfil.Id)
                return View("Error");

            if (!ModelState.IsValid)
            {

                var perfildataE = iperfilEmpresa.GetNewPerfilEValues();
                ViewBag.Empr = new SelectList(perfildataE.Empresa, "Id", "NombreEmpresa");
            }

            iperfilEmpresa.UpdatePerfilE(perfil);
            return RedirectToAction(nameof(Profile));

        }

        public IActionResult DeleteProfile(int id)
        {
            var perfilE = iperfilEmpresa.GetPerfilEById(id);
            if (perfilE == null)
                return View("Error");

            var request = new PerfilEmpresaViewModels()
            {
                Id = perfilE.Id,
                EmpresaID = perfilE.EmpresaID,
                DepartamentoOperario = perfilE.DepartamentoOperario,
                DescripcionEmpresa = perfilE.DescripcionEmpresa,
                States= perfilE.States = false
            };

            iperfilEmpresa.DeletePerfilE(request);
            return RedirectToAction(nameof(Profile));
        }

        public IActionResult GoProfile(int id)
        {
            var perfilEM = iperfilEmpresa.GetPerfilEById(id);
            if (perfilEM == null)
                return View("Error");

            var requesst = new PerfilEmpresaViewModels()
            {
                Id = perfilEM.Id,
                EmpresaID = perfilEM.EmpresaID,
                DepartamentoOperario = perfilEM.DepartamentoOperario,
                DescripcionEmpresa = perfilEM.DescripcionEmpresa,

            };

            var perfildataE = iperfilEmpresa.GetNewPerfilEValues();
            ViewBag.Empr = new SelectList(perfildataE.Empresa, "Id", "NombreEmpresa");


            return View(requesst);
        }
    }
}
