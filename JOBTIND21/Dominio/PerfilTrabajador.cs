using JOBTIND21.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Dominio
{
    public class PerfilTrabajador:IBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserTrabajadorID { get; set; }

        public string DUI { get; set; }

        public string Telephone { get; set; }
        public string CVLink { get; set; }

        public string Descripcion { get; set; }

        public UserTrabajador UserTrabajador { get; set; }

        public bool State { get; set; }
    }
}
