using JOBTIND21.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBTIND21.Dominio
{
    public class InfoAnuncio:IBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AnuncioID { get; set; }
        public string EdadRequerida { get; set; }
        public string Requisitos { get; set; }

        public string Horarios { get; set; }

        public string Salario { get; set; }

        public string Lugar { get; set; }

        public Anuncio Anuncio { get; set; }

        public bool Stado { get; set; }
    }
}
