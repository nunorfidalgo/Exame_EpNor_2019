namespace Exame_EpNor_2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atletas",
                c => new
                    {
                        AtletaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AtletaId);
            
            CreateTable(
                "dbo.ProvasAtletismoes",
                c => new
                    {
                        ProvasAtletismoId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Designacao = c.String(),
                        Local = c.String(),
                        Distancia = c.Int(nullable: false),
                        Vencedor = c.String(),
                    })
                .PrimaryKey(t => t.ProvasAtletismoId);
            
            CreateTable(
                "dbo.ProvasAtletismoAtletas",
                c => new
                    {
                        ProvasAtletismo_ProvasAtletismoId = c.Int(nullable: false),
                        Atleta_AtletaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProvasAtletismo_ProvasAtletismoId, t.Atleta_AtletaId })
                .ForeignKey("dbo.ProvasAtletismoes", t => t.ProvasAtletismo_ProvasAtletismoId, cascadeDelete: true)
                .ForeignKey("dbo.Atletas", t => t.Atleta_AtletaId, cascadeDelete: true)
                .Index(t => t.ProvasAtletismo_ProvasAtletismoId)
                .Index(t => t.Atleta_AtletaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProvasAtletismoAtletas", "Atleta_AtletaId", "dbo.Atletas");
            DropForeignKey("dbo.ProvasAtletismoAtletas", "ProvasAtletismo_ProvasAtletismoId", "dbo.ProvasAtletismoes");
            DropIndex("dbo.ProvasAtletismoAtletas", new[] { "Atleta_AtletaId" });
            DropIndex("dbo.ProvasAtletismoAtletas", new[] { "ProvasAtletismo_ProvasAtletismoId" });
            DropTable("dbo.ProvasAtletismoAtletas");
            DropTable("dbo.ProvasAtletismoes");
            DropTable("dbo.Atletas");
        }
    }
}
