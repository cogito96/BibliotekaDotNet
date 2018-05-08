namespace BibiotekaNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bazadanych : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Egzemplarzs",
                c => new
                    {
                        EgzemplarzID = c.Int(nullable: false, identity: true),
                        StanKsiazki = c.String(),
                        KsiazkaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EgzemplarzID)
                .ForeignKey("dbo.Ksiazkas", t => t.KsiazkaID, cascadeDelete: true)
                .Index(t => t.KsiazkaID);
            
            CreateTable(
                "dbo.Ksiazkas",
                c => new
                    {
                        KsiazkaID = c.Int(nullable: false, identity: true),
                        Tytuł = c.String(nullable: false),
                        Opis = c.String(),
                        DataWydania = c.DateTime(nullable: false),
                        DataDodaniaDoSystemu = c.DateTime(nullable: false),
                        NazwaKategorii = c.String(nullable: false),
                        ImieAutor = c.String(),
                        NazwiskoAutor = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.KsiazkaID);
            
            CreateTable(
                "dbo.Klients",
                c => new
                    {
                        KlientID = c.Int(nullable: false, identity: true),
                        ImieKlienta = c.String(nullable: false),
                        NazwiskoKlienta = c.String(nullable: false),
                        MiastoKlienta = c.String(nullable: false),
                        UlicaKlienta = c.String(),
                        EmailKlienta = c.String(nullable: false),
                        NumerTelefonuKlienta = c.Int(nullable: false),
                        LoginKlient = c.String(nullable: false),
                        HasloKlienta = c.String(nullable: false),
                        PESEL = c.Long(nullable: false),
                        PotwierdzenieRejestracji = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.KlientID);
            
            CreateTable(
                "dbo.Wypozyczenies",
                c => new
                    {
                        WypozyczenieID = c.Int(nullable: false, identity: true),
                        DataWypozyczenia = c.DateTime(nullable: false),
                        DataZwrotu = c.DateTime(nullable: false),
                        StatusWypozyczenia = c.String(),
                        EgzemplarzID = c.Int(nullable: false),
                        KlientID = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.WypozyczenieID)
                .ForeignKey("dbo.Egzemplarzs", t => t.EgzemplarzID, cascadeDelete: true)
                .ForeignKey("dbo.Klients", t => t.KlientID, cascadeDelete: true)
                .Index(t => t.EgzemplarzID)
                .Index(t => t.KlientID);
            
            CreateTable(
                "dbo.Pracowniks",
                c => new
                    {
                        PracownikID = c.Int(nullable: false, identity: true),
                        ImiePracownika = c.String(nullable: false),
                        NazwiskoPracownika = c.String(nullable: false),
                        PESELPracownika = c.Double(nullable: false),
                        LoginPracownika = c.String(nullable: false),
                        HasloPracownika = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PracownikID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wypozyczenies", "KlientID", "dbo.Klients");
            DropForeignKey("dbo.Wypozyczenies", "EgzemplarzID", "dbo.Egzemplarzs");
            DropForeignKey("dbo.Egzemplarzs", "KsiazkaID", "dbo.Ksiazkas");
            DropIndex("dbo.Wypozyczenies", new[] { "KlientID" });
            DropIndex("dbo.Wypozyczenies", new[] { "EgzemplarzID" });
            DropIndex("dbo.Egzemplarzs", new[] { "KsiazkaID" });
            DropTable("dbo.Pracowniks");
            DropTable("dbo.Wypozyczenies");
            DropTable("dbo.Klients");
            DropTable("dbo.Ksiazkas");
            DropTable("dbo.Egzemplarzs");
        }
    }
}
