using JOBTIND21.Data.Base;
using JOBTIND21.Data.ViewModels;
using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Servicio
{
    public interface IPerfilTrabajador: IEntityBase<PerfilTrabajador>
    {
        PerfilTrabajador GetPerfilById(int id);
        PerfilDropDown GetNewPerfilValues();

        void AddPerfil(PerfilTrabajadorViewModel data);
        void UpdatePerfil(PerfilTrabajadorViewModel data);
        void DeletePerfil(PerfilTrabajadorViewModel data);
    }
}
