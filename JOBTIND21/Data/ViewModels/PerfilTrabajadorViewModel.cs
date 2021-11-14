using JOBTIND21.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.ViewModels
{
    public class PerfilTrabajadorViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "TrabId")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public int UserTrabajadorID { get; set; }


        [Display(Name = "DUI")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string DUI { get; set; }


        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Telephone { get; set; }


        [Display(Name = "CVLink")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string CVLink { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Descripcion { get; set; }

        public bool State { get; set; }

        public UserTrabajador UserTrabajador { get; set; }
    }
}
