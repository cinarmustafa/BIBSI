namespace BIBSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7520172 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Ilanlar", "SehirId");
            CreateIndex("dbo.Ilanlar", "IlceId");
            CreateIndex("dbo.Ilanlar", "MahalleId");
            AddForeignKey("dbo.Ilanlar", "IlceId", "dbo.Ilceler", "Id");
            AddForeignKey("dbo.Ilanlar", "MahalleId", "dbo.Mahalleler", "Id");
            AddForeignKey("dbo.Ilanlar", "SehirId", "dbo.Sehirler", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ilanlar", "SehirId", "dbo.Sehirler");
            DropForeignKey("dbo.Ilanlar", "MahalleId", "dbo.Mahalleler");
            DropForeignKey("dbo.Ilanlar", "IlceId", "dbo.Ilceler");
            DropIndex("dbo.Ilanlar", new[] { "MahalleId" });
            DropIndex("dbo.Ilanlar", new[] { "IlceId" });
            DropIndex("dbo.Ilanlar", new[] { "SehirId" });
        }
    }
}
