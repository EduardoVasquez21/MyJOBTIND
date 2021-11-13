using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.ViewModels
{
    public class AnuncioDropDown
    {
        public AnuncioDropDown()
        {
            Usuario = new List<Usuario>();
            Empresa = new List<Empresa>();
        }

        public List<Usuario> Usuario { get; set; }
        public List<Empresa> Empresa { get; set; }
    }
}
