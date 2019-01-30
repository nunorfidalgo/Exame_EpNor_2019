using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exame_EpNor_2019.Models
{
    public class ExameDbContext : DbContext
    {
        public ExameDbContext() : base("name=DefaultConnection") { }

        public DbSet<ProvasAtletismo> ProvasAtletismos { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
    }
}