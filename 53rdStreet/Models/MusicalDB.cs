
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _53rdStreet.Models
{
    public class MusicalDB : DbContext
    {
        public MusicalDB() : base("MusicalDBConnectionString") { }

        public virtual DbSet<Musical> Musical { get; set; }
        public virtual DbSet<Cast> Actor { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Soundtrack> Song { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<CastMusical> CastMusical { get; set; }

    }
}