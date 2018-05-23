using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _53rdStreet.Models
{
    public class Cast
    {
        public Cast()
        {
            ListMusical = new HashSet<CastMusical>();
            
        }

        [Key]
        public int ID_Actor { get; set;}
        public string Name { get; set; }
        public string Image { get; set; }



        public virtual ICollection<CastMusical> ListMusical { get; set; }
 


        //atributo, da tabela Musical, que será referênciado na tabela Cast
        //[ForeignKey("Musical")]
        //public int MusicalFK { get; set; }
        //chama, neste caso, o musical da tabela Musical
        //public virtual Musical Musical { get; set; }

    }
}