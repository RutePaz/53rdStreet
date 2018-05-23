using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _53rdStreet.Models
{
    public class CastMusical
    {

        ///* public int ID { get; set; } // PK*/, por exigência da Entity Framework

        //chave primária
        [Key]
        public int ID { get; set; }

        //Foreign Keys 
        [ForeignKey("Musical")]
        public int MusicalFK { get; set; }
        public virtual Musical Musical { get; set; }

        [ForeignKey("Cast")]
        public int CastFK { get; set; }
        public virtual Cast Cast { get; set; }

        //atributos
        public string Character { get; set; }
        public string Image { get; set; }


    }
}