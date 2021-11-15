using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.ViewModels
{
    public class PerfilEDropDown
    {
        public PerfilEDropDown()
        {

            Empresa = new List<Empresa>();
        }

        public List<Empresa> Empresa { get; set; }
    }
}
