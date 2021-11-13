using JOBTIND21.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Data.ViewModels
{
    public class AnuncioViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Anuncio")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public string Anuncios { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public int UsuarioID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "DATO OBLIGATORIO")]
        public int EmpresaID { get; set; }

        public Categoria? Categoria { get; set; }


        public bool Estado { get; set; }
    }
}
