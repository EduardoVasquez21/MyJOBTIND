using JOBTIND21.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Dominio
{
    public class Usuario:IBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Apellidos { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        [Range(18, int.MaxValue, ErrorMessage = "Lo sentimos, debes ser mayor de edad.")]
        public int Edad { get; set; }


        [Display(Name = "Dui")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string DUI { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Contraseña { get; set; }

        public ICollection<Anuncio> Anuncio { get; set; }
    }
}
