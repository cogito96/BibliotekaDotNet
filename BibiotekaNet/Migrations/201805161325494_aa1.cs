namespace BibiotekaNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Klients", "UlicaKlienta", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Klients", "UlicaKlienta", c => c.String());
        }
    }
}
