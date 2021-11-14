using JOBTIND21.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Dominio
{
    public class UserTrabajador:IBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string LastName { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        [Range(18, int.MaxValue, ErrorMessage = "Lo sentimos, debes ser mayor de edad.")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Password { get; set; }

        public ICollection<PerfilTrabajador> PerfilTrabajador { get; set; }
    }
}
