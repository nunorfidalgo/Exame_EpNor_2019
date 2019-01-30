using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exame_EpNor_2019.Models
{
    public class ProvasAtletismo
    {
        public int ProvasAtletismoId { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Display(Name = "Designação da Prova")]
        public string Designacao { get; set; }

        [Display(Name = "Local")]
        public string Local { get; set; }

        [Display(Name = "Distância")]
        public int Distancia { get; set; }

        [Display(Name = "Nome do Vencedor")]
        public string Vencedor { get; set; }

        public virtual ICollection<Atleta> Atletas { get; set; }
    }
}