using JOBTIND21.Data;
using JOBTIND21.Data.Base;
using JOBTIND21.Dominio;
using JOBTIND21.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Repositorio
{
    public class EmpresaRepositorio : EntityBaseRepository<Empresa>, IEmpresa
    {
        public EmpresaRepositorio(ApplicationDbContext bd) : base(bd)
        {

        }
    }
}
