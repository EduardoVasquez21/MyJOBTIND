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
    public class EmpresaController : Controller
    {
        private readonly ILogger<EmpresaController> _logger;
        private IEmpresa iempresa;

        public EmpresaController(ILogger<EmpresaController> logger, IEmpresa iempresa)
        {
            this.iempresa = iempresa;
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
    }
}
