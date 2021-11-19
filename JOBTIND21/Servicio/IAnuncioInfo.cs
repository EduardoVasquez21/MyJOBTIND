using JOBTIND21.Data.Base;
using JOBTIND21.Data.ViewModels;
using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Servicio
{
    public interface IAnuncioInfo: IEntityBase<InfoAnuncio>
    {
        InfoAnuncio GetinfoById(int id);
        InfoDropDown GetNewInfoValues();

        void AddInfo(InfoAnuncioViewModel data);
        void UpdateInfo(InfoAnuncioViewModel data);
        void DeleteInfo(InfoAnuncioViewModel data);
    }
}
