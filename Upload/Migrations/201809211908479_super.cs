namespace Upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class super : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "Imagem_ArquivoId", "dbo.Arquivoes");
            DropIndex("dbo.Produtoes", new[] { "Imagem_ArquivoId" });
            AddColumn("dbo.Produtoes", "Imagem", c => c.String());
            DropColumn("dbo.Produtoes", "Imagem_ArquivoId");
            DropTable("dbo.Arquivoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Arquivoes",
                c => new
                    {
                        ArquivoId = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        TipoArquivo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArquivoId);
            
            AddColumn("dbo.Produtoes", "Imagem_ArquivoId", c => c.Int());
            DropColumn("dbo.Produtoes", "Imagem");
            CreateIndex("dbo.Produtoes", "Imagem_ArquivoId");
            AddForeignKey("dbo.Produtoes", "Imagem_ArquivoId", "dbo.Arquivoes", "ArquivoId");
        }
    }
}
