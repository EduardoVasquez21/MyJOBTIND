using JOBTIND21.Data.Base;
using JOBTIND21.Data.ViewModels;
using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Servicio
{
    public interface IPerfilEmpresa : IEntityBase<PerfilEmpresa>
    {
        PerfilEmpresa GetPerfilEById(int id);
         PerfilEDropDown GetNewPerfilEValues();

        void AddPerfilE(PerfilEmpresaViewModels data);
        void UpdatePerfilE(PerfilEmpresaViewModels data);
        void DeletePerfilE(PerfilEmpresaViewModels data);
    }
}
