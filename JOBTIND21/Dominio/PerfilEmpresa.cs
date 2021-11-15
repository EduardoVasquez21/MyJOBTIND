using JOBTIND21.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Dominio
{
    public class PerfilEmpresa :IBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmpresaID { get; set; }
        public string DepartamentoOperario { get; set; }

        public string DescripcionEmpresa { get; set; }

        public Empresa Empresa { get; set; }

        public bool States { get; set; }
    }
}
