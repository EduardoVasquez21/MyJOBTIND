using JOBTIND21.Data.Base;
using JOBTIND21.Data.ViewModels;
using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Servicio
{
    public interface IAnuncio:IEntityBase<Anuncio>
    {
        Anuncio GetEnrollmentById(int id);
        AnuncioDropDown GetNewEnrollmentValues();

        void AddAnuncio(AnuncioViewModel data);
        void UpdateAnuncio(AnuncioViewModel data);
        void DeleteAnuncio(AnuncioViewModel data);

    }
}
