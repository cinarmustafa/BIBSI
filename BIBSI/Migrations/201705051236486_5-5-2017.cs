namespace BIBSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _552017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ilanlar", "YasAraligi_Minimum", c => c.Byte(nullable: false));
            AddColumn("dbo.Ilanlar", "YasAraligi_Maksimum", c => c.Byte(nullable: false));
            AddColumn("dbo.Ilanlar", "YasAraligi_Net", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ilanlar", "YasAraligi_Net");
            DropColumn("dbo.Ilanlar", "YasAraligi_Maksimum");
            DropColumn("dbo.Ilanlar", "YasAraligi_Minimum");
        }
    }
}
