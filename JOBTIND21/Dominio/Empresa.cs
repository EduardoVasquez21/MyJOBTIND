using JOBTIND21.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Dominio
{
    public class Empresa:IBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nombre_Empresa")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string NombreEmpresa { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public int TelefonoEmp { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string EmailEmp { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string ContraseñaEmp { get; set; }

        [Display(Name = "Vacante")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Vacante { get; set; }


        public ICollection<Anuncio> Anuncio { get; set; }

    }
}
