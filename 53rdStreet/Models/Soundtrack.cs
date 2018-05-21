﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _53rdStreet.Models
{
    public class Soundtrack
    {
        [Key]
        public int ID_Song { get; set; }
        public string SongName { get; set; }
        public string Duration { get; set; }

        //atributo, da tabela Musical, que será referênciado na tabela Soundtrack
        [ForeignKey("Musical")]
        public int MusicalFK { get; set; }
        //chama, neste caso, o musical da tabela Musical
        public virtual Musical Musical { get; set; }
    }
}