namespace Exame_EpNor_2019.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Exame_EpNor_2019.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Exame_EpNor_2019.Models.ExameDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Exame_EpNor_2019.Models.ExameDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var atletas = new List<Atleta>
            {
                new Atleta { Nome = "Filie Pereira" },
                new Atleta { Nome = "José Manuel Fonseca" },
                new Atleta { Nome = "Gonçalo Antunes Pires" },
                new Atleta { Nome = "Filie Pires" },
                new Atleta { Nome = "Nuno Fidalgo" },
                new Atleta { Nome = "Nuno Sousa" },
            };
            atletas.ForEach(s => context.Atletas.AddOrUpdate(a => a.Nome, s));
            context.SaveChanges();

            var provas_atletismo = new List<ProvasAtletismo>
            {
                new ProvasAtletismo { Data = DateTime.Parse("06-01-2019"), Designacao = "Corrida dos Reis", Local = "Moita", Distancia = 8, Vencedor = "Filie Pereira", Atletas = new List<Atleta>() },
                new ProvasAtletismo { Data = DateTime.Parse("14-01-2019"), Designacao = "Trilhos da Lousa", Local = "Lousa-Loures", Distancia = 20, Vencedor = "José Manuel Fonseca", Atletas = new List<Atleta>() },
                new ProvasAtletismo { Data = DateTime.Parse("20-01-2019"), Designacao = "1/2 Maratona Manuela Machado", Local = "Viana do Castelo", Distancia = 21, Vencedor = "N/A", Atletas = new List<Atleta>() },
                new ProvasAtletismo { Data = DateTime.Parse("27-01-2019"), Designacao = "Lousatrail", Local = "Lousã", Distancia = 43, Vencedor = "N/A", Atletas = new List<Atleta>() }
            };
            provas_atletismo.ForEach(s => context.ProvasAtletismos.AddOrUpdate(p => p.Data, s));
            context.SaveChanges();

            AddOrUpdateProvasAtletismoAtletas("Corrida dos Reis", "Filie Pereira");
            AddOrUpdateProvasAtletismoAtletas("Corrida dos Reis", "José Manuel Fonseca");
            AddOrUpdateProvasAtletismoAtletas("Corrida dos Reis", "Gonçalo Antunes Pires");
            AddOrUpdateProvasAtletismoAtletas("Corrida dos Reis", "Filie Pires");
            AddOrUpdateProvasAtletismoAtletas("Corrida dos Reis", "Nuno Sousa");

            AddOrUpdateProvasAtletismoAtletas("Trilhos da Lousa", "Filie Pereira");
            AddOrUpdateProvasAtletismoAtletas("Trilhos da Lousa", "José Manuel Fonseca");
            AddOrUpdateProvasAtletismoAtletas("Trilhos da Lousa", "Gonçalo Antunes Pires");
            AddOrUpdateProvasAtletismoAtletas("Trilhos da Lousa", "Filie Pires");
            AddOrUpdateProvasAtletismoAtletas("Trilhos da Lousa", "Nuno Fidalgo");

            AddOrUpdateProvasAtletismoAtletas("1/2 Maratona Manuela Machado", "Filie Pires");
            AddOrUpdateProvasAtletismoAtletas("1/2 Maratona Manuela Machado", "Filie Pereira");
            AddOrUpdateProvasAtletismoAtletas("1/2 Maratona Manuela Machado", "Gonçalo Antunes Pires");

            void AddOrUpdateProvasAtletismoAtletas(string designacao, string nome)
            {
                var provas = context.ProvasAtletismos.SingleOrDefault(c => c.Designacao == designacao);
                var atl = provas.Atletas.SingleOrDefault(a => a.Nome == nome);
                if (atl == null)
                    provas.Atletas.Add(context.Atletas.Single(i => i.Nome == nome));
            }

            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("06-01-2019"), "Filie Pereira");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("06-01-2019"), "José Manuel Fonseca");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("06-01-2019"), "Gonçalo Antunes Pires");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("06-01-2019"), "Filie Pires");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("06-01-2019"), "Nuno Sousa");

            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("14-01-2019"), "Filie Pereira");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("14-01-2019"), "José Manuel Fonseca");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("14-01-2019"), "Gonçalo Antunes Pires");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("14-01-2019"), "Filie Pires");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("14-01-2019"), "Nuno Fidalgo");

            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("20-01-2019"), "Filie Pires");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("20-01-2019"), "Filie Pereira");
            //AddOrUpdateProvasAtletismoAtletas(context, DateTime.Parse("20-01-2019"), "Gonçalo Antunes Pires");

            //void AddOrUpdateProvasAtletismoAtletas(DbContext cont, DateTime data_prova, string nome)
            //{
            //    var crs = context.ProvasAtletismos.SingleOrDefault(c => c.Data == data_prova);
            //    var inst = crs.Atletas.SingleOrDefault(a => a.Nome == nome);
            //    if (inst == null)
            //        crs.Atletas.Add(context.Atletas.Single(i => i.Nome == nome));
            //}
            context.SaveChanges();
        }
    }
}
