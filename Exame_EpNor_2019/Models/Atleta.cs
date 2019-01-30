using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exame_EpNor_2019.Models
{
    public class Atleta
    {
        public int AtletaId { get; set; }

        [Display(Name = " Nome")]
        [Required]
        public string Nome { get; set; }

        public virtual ICollection<ProvasAtletismo> ProvasAtletismos { get; set; }
    }
}