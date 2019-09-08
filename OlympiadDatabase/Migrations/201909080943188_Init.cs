namespace OlympiadDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Olympiads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TypeID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.OlympTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.OlympTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OlympResults",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OlympID = c.Int(nullable: false),
                        SportTypeID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        OlympiadType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Olympiads", t => t.OlympID, cascadeDelete: true)
                .ForeignKey("dbo.OlympTypes", t => t.OlympiadType_ID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.SportTypes", t => t.SportTypeID, cascadeDelete: true)
                .Index(t => t.OlympID)
                .Index(t => t.SportTypeID)
                .Index(t => t.CityID)
                .Index(t => t.PersonID)
                .Index(t => t.OlympiadType_ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 70),
                        SecondName = c.String(nullable: false, maxLength: 70),
                        ThirdName = c.String(nullable: false, maxLength: 70),
                        CountryID = c.Int(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhotoPath = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.SportTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OlympResults", "SportTypeID", "dbo.SportTypes");
            DropForeignKey("dbo.OlympResults", "PersonID", "dbo.People");
            DropForeignKey("dbo.People", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.OlympResults", "OlympiadType_ID", "dbo.OlympTypes");
            DropForeignKey("dbo.OlympResults", "OlympID", "dbo.Olympiads");
            DropForeignKey("dbo.OlympResults", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Olympiads", "TypeID", "dbo.OlympTypes");
            DropForeignKey("dbo.Olympiads", "CountryID", "dbo.Countries");
            DropIndex("dbo.People", new[] { "CountryID" });
            DropIndex("dbo.OlympResults", new[] { "OlympiadType_ID" });
            DropIndex("dbo.OlympResults", new[] { "PersonID" });
            DropIndex("dbo.OlympResults", new[] { "CityID" });
            DropIndex("dbo.OlympResults", new[] { "SportTypeID" });
            DropIndex("dbo.OlympResults", new[] { "OlympID" });
            DropIndex("dbo.Olympiads", new[] { "CountryID" });
            DropIndex("dbo.Olympiads", new[] { "TypeID" });
            DropTable("dbo.SportTypes");
            DropTable("dbo.People");
            DropTable("dbo.OlympResults");
            DropTable("dbo.OlympTypes");
            DropTable("dbo.Olympiads");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
