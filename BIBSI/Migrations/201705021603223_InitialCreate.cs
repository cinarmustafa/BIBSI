namespace BIBSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Basvurular",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsArayanId = c.Int(nullable: false),
                        IlanId = c.Int(nullable: false),
                        BasvuruTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ilanlar", t => t.IlanId)
                .ForeignKey("dbo.IsArayanlar", t => t.IsArayanId)
                .Index(t => t.IsArayanId)
                .Index(t => t.IlanId);
            
            CreateTable(
                "dbo.Ilanlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsTanimi = c.String(),
                        Aciklama = c.String(),
                        IsverenId = c.Int(nullable: false),
                        SektorId = c.Int(nullable: false),
                        PozisyonId = c.Int(nullable: false),
                        MeslekId = c.Int(nullable: false),
                        Cinsiyet = c.Int(nullable: false),
                        AskerlikDurumu = c.Int(nullable: false),
                        YolMasrafi = c.Boolean(nullable: false),
                        SSKMasrafi = c.Boolean(nullable: false),
                        CalismaBicimi = c.Int(nullable: false),
                        EgitimDurumu = c.Int(nullable: false),
                        MaasAraligi_Minimum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaasAraligi_Maksimum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaasAraligi_Net = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deneyim_Periyot = c.Int(nullable: false),
                        Deneyim_Minimum = c.Int(nullable: false),
                        Deneyim_Maksimum = c.Int(nullable: false),
                        Deneyim_Net = c.Int(nullable: false),
                        IlanSuresi_SureTipi = c.Int(nullable: false),
                        IlanSuresi_BaslangicTarihi = c.DateTime(nullable: false),
                        IlanSuresi_BitisTarihi = c.DateTime(nullable: false),
                        IsciSayisi = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IsVerenler", t => t.IsverenId)
                .ForeignKey("dbo.Meslekler", t => t.MeslekId)
                .ForeignKey("dbo.Pozisyonlar", t => t.PozisyonId)
                .ForeignKey("dbo.Sektorler", t => t.SektorId)
                .Index(t => t.IsverenId)
                .Index(t => t.SektorId)
                .Index(t => t.PozisyonId)
                .Index(t => t.MeslekId);
            
            CreateTable(
                "dbo.Fotograflar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Tur = c.Int(nullable: false),
                        Ilan_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ilanlar", t => t.Ilan_Id)
                .Index(t => t.Ilan_Id);
            
            CreateTable(
                "dbo.IsVerenler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        SehirId = c.Int(nullable: false),
                        IlceId = c.Int(nullable: false),
                        MahalleId = c.Int(nullable: false),
                        Adres = c.String(),
                        Telefon1 = c.String(),
                        Telefon2 = c.String(),
                        Email = c.String(),
                        WebAdresi = c.String(),
                        FotografId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fotograflar", t => t.FotografId)
                .ForeignKey("dbo.Ilceler", t => t.IlceId)
                .ForeignKey("dbo.Mahalleler", t => t.MahalleId)
                .ForeignKey("dbo.Sehirler", t => t.SehirId)
                .Index(t => t.SehirId)
                .Index(t => t.IlceId)
                .Index(t => t.MahalleId)
                .Index(t => t.FotografId);
            
            CreateTable(
                "dbo.Ilceler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        SehirId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sehirler", t => t.SehirId)
                .Index(t => t.SehirId);
            
            CreateTable(
                "dbo.Mahalleler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IlceId = c.Int(nullable: false),
                        MahalleAdi = c.String(),
                        PostaKodu = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ilceler", t => t.IlceId)
                .Index(t => t.IlceId);
            
            CreateTable(
                "dbo.Sehirler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sirketler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Unvan = c.String(),
                        FotografId = c.Int(nullable: false),
                        IsVerenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fotograflar", t => t.FotografId)
                .ForeignKey("dbo.IsVerenler", t => t.IsVerenId)
                .Index(t => t.FotografId)
                .Index(t => t.IsVerenId);
            
            CreateTable(
                "dbo.Meslekler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pozisyonlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sektorler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IsArayanlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        EvTelefonu = c.String(),
                        CepTelefonu = c.String(),
                        Cinsiyet = c.Int(nullable: false),
                        AskerlikDurumu = c.Int(nullable: false),
                        DogumTarihi = c.DateTime(nullable: false),
                        SehirId = c.Int(nullable: false),
                        IlceId = c.Int(nullable: false),
                        MahalleId = c.Int(nullable: false),
                        Adres = c.String(),
                        FotografId = c.Int(nullable: false),
                        MaasAraligi_Minimum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaasAraligi_Maksimum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaasAraligi_Net = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EgitimDurumu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fotograflar", t => t.FotografId)
                .ForeignKey("dbo.Ilceler", t => t.IlceId)
                .ForeignKey("dbo.Mahalleler", t => t.MahalleId)
                .ForeignKey("dbo.Sehirler", t => t.SehirId)
                .Index(t => t.SehirId)
                .Index(t => t.IlceId)
                .Index(t => t.MahalleId)
                .Index(t => t.FotografId);
            
            CreateTable(
                "dbo.IsDeneyimleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsArayanId = c.Int(nullable: false),
                        DeneyimAdi = c.String(),
                        BaslangicTarihi = c.DateTime(nullable: false),
                        BitisTarihi = c.DateTime(nullable: false),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IsArayanlar", t => t.IsArayanId)
                .Index(t => t.IsArayanId);
            
            CreateTable(
                "dbo.Kullanicilar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        Parola = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Basvurular", "IsArayanId", "dbo.IsArayanlar");
            DropForeignKey("dbo.IsArayanlar", "SehirId", "dbo.Sehirler");
            DropForeignKey("dbo.IsArayanlar", "MahalleId", "dbo.Mahalleler");
            DropForeignKey("dbo.IsDeneyimleri", "IsArayanId", "dbo.IsArayanlar");
            DropForeignKey("dbo.IsArayanlar", "IlceId", "dbo.Ilceler");
            DropForeignKey("dbo.IsArayanlar", "FotografId", "dbo.Fotograflar");
            DropForeignKey("dbo.Basvurular", "IlanId", "dbo.Ilanlar");
            DropForeignKey("dbo.Ilanlar", "SektorId", "dbo.Sektorler");
            DropForeignKey("dbo.Ilanlar", "PozisyonId", "dbo.Pozisyonlar");
            DropForeignKey("dbo.Ilanlar", "MeslekId", "dbo.Meslekler");
            DropForeignKey("dbo.Ilanlar", "IsverenId", "dbo.IsVerenler");
            DropForeignKey("dbo.Sirketler", "IsVerenId", "dbo.IsVerenler");
            DropForeignKey("dbo.Sirketler", "FotografId", "dbo.Fotograflar");
            DropForeignKey("dbo.IsVerenler", "SehirId", "dbo.Sehirler");
            DropForeignKey("dbo.IsVerenler", "MahalleId", "dbo.Mahalleler");
            DropForeignKey("dbo.IsVerenler", "IlceId", "dbo.Ilceler");
            DropForeignKey("dbo.Ilceler", "SehirId", "dbo.Sehirler");
            DropForeignKey("dbo.Mahalleler", "IlceId", "dbo.Ilceler");
            DropForeignKey("dbo.IsVerenler", "FotografId", "dbo.Fotograflar");
            DropForeignKey("dbo.Fotograflar", "Ilan_Id", "dbo.Ilanlar");
            DropIndex("dbo.IsDeneyimleri", new[] { "IsArayanId" });
            DropIndex("dbo.IsArayanlar", new[] { "FotografId" });
            DropIndex("dbo.IsArayanlar", new[] { "MahalleId" });
            DropIndex("dbo.IsArayanlar", new[] { "IlceId" });
            DropIndex("dbo.IsArayanlar", new[] { "SehirId" });
            DropIndex("dbo.Sirketler", new[] { "IsVerenId" });
            DropIndex("dbo.Sirketler", new[] { "FotografId" });
            DropIndex("dbo.Mahalleler", new[] { "IlceId" });
            DropIndex("dbo.Ilceler", new[] { "SehirId" });
            DropIndex("dbo.IsVerenler", new[] { "FotografId" });
            DropIndex("dbo.IsVerenler", new[] { "MahalleId" });
            DropIndex("dbo.IsVerenler", new[] { "IlceId" });
            DropIndex("dbo.IsVerenler", new[] { "SehirId" });
            DropIndex("dbo.Fotograflar", new[] { "Ilan_Id" });
            DropIndex("dbo.Ilanlar", new[] { "MeslekId" });
            DropIndex("dbo.Ilanlar", new[] { "PozisyonId" });
            DropIndex("dbo.Ilanlar", new[] { "SektorId" });
            DropIndex("dbo.Ilanlar", new[] { "IsverenId" });
            DropIndex("dbo.Basvurular", new[] { "IlanId" });
            DropIndex("dbo.Basvurular", new[] { "IsArayanId" });
            DropTable("dbo.Kullanicilar");
            DropTable("dbo.IsDeneyimleri");
            DropTable("dbo.IsArayanlar");
            DropTable("dbo.Sektorler");
            DropTable("dbo.Pozisyonlar");
            DropTable("dbo.Meslekler");
            DropTable("dbo.Sirketler");
            DropTable("dbo.Sehirler");
            DropTable("dbo.Mahalleler");
            DropTable("dbo.Ilceler");
            DropTable("dbo.IsVerenler");
            DropTable("dbo.Fotograflar");
            DropTable("dbo.Ilanlar");
            DropTable("dbo.Basvurular");
        }
    }
}
