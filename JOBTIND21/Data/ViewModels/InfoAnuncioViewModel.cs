using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.ViewModels
{
    public class InfoAnuncioViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Anuncio")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public int AnuncioID { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string EdadRequerida { get; set; }

        [Display(Name = "Requisitos")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Requisitos { get; set; }

        [Display(Name = "Horarios")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Horarios { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Salario { get; set; }

        [Display(Name = "LugarDeTrabajo")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Lugar { get; set; }


        public bool Stado { get; set; }
    }
}
