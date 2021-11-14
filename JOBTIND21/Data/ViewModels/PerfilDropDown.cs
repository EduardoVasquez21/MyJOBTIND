using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.ViewModels
{
    public class PerfilDropDown
    {
        public PerfilDropDown()
        {
            UserTrabajador = new List<UserTrabajador>();

        }

        public List<UserTrabajador> UserTrabajador { get; set; }

    }
}
