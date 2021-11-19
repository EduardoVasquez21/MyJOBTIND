using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.ViewModels
{
    public class InfoDropDown
    {
        public InfoDropDown()
        {
            Anuncio = new List<Anuncio>();
        }

        public List<Anuncio> Anuncio { get; set; }

    }
}
