namespace Upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Quantidade = c.Int(nullable: false),
                        Imagem_ArquivoId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Arquivoes", t => t.Imagem_ArquivoId)
                .Index(t => t.Imagem_ArquivoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Imagem_ArquivoId", "dbo.Arquivoes");
            DropIndex("dbo.Produtoes", new[] { "Imagem_ArquivoId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Arquivoes");
        }
    }
}
