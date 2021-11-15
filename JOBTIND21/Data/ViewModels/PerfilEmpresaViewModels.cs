using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.ViewModels
{
    public class PerfilEmpresaViewModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public int EmpresaID { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string DepartamentoOperario { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string DescripcionEmpresa { get; set; }

        public bool States { get; set; }

        public Empresa Empresa { get; set; }
    }
}
