namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingNumber = c.String(),
                        PassengerId = c.Int(nullable: false),
                        FlightId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Passenger", t => t.PassengerId, cascadeDelete: true)
                .Index(t => t.PassengerId)
                .Index(t => t.FlightId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureStation = c.String(maxLength: 3),
                        DepartureStationId = c.Int(nullable: false),
                        ArrivalStation = c.String(maxLength: 3),
                        ArrivalStationId = c.Int(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        FlightNumber = c.String(nullable: false, maxLength: 10),
                        Price = c.Single(nullable: false),
                        Currency = c.String(nullable: false, maxLength: 5),
                        DurationHour = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.ArrivalStationId)
                .ForeignKey("dbo.Cities", t => t.DepartureStationId)
                .Index(t => t.DepartureStationId)
                .Index(t => t.ArrivalStationId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IATACode = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Passenger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lastname = c.String(),
                        CellNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "PassengerId", "dbo.Passenger");
            DropForeignKey("dbo.Booking", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "DepartureStationId", "dbo.Cities");
            DropForeignKey("dbo.Flights", "ArrivalStationId", "dbo.Cities");
            DropIndex("dbo.Flights", new[] { "ArrivalStationId" });
            DropIndex("dbo.Flights", new[] { "DepartureStationId" });
            DropIndex("dbo.Booking", new[] { "FlightId" });
            DropIndex("dbo.Booking", new[] { "PassengerId" });
            DropTable("dbo.Passenger");
            DropTable("dbo.Cities");
            DropTable("dbo.Flights");
            DropTable("dbo.Booking");
        }
    }
}
