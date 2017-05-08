namespace BIBSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _752017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ilanlar", "SehirId", c => c.Int(nullable: false));
            AddColumn("dbo.Ilanlar", "IlceId", c => c.Int(nullable: false));
            AddColumn("dbo.Ilanlar", "MahalleId", c => c.Int(nullable: false));
            AddColumn("dbo.Ilanlar", "Adres", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ilanlar", "Adres");
            DropColumn("dbo.Ilanlar", "MahalleId");
            DropColumn("dbo.Ilanlar", "IlceId");
            DropColumn("dbo.Ilanlar", "SehirId");
        }
    }
}
