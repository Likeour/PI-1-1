namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LotCatigories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    LotPost_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LotPosts", t => t.LotPost_Id)
                .Index(t => t.LotPost_Id);

            CreateTable(
                "dbo.LotPosts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    StartPrice = c.Double(nullable: false),
                    BuyPrice = c.Double(nullable: false),
                    CurrentPrice = c.Double(nullable: false),
                    PostedByID = c.String(maxLength: 128),
                    AnteCostId = c.String(),
                    Discription = c.String(),
                    Image = c.Binary(),
                    CreatedDate = c.DateTime(nullable: false, storeType: "date"),
                    StartDate = c.DateTime(nullable: false, storeType: "date"),
                    SalesDate = c.DateTime(nullable: false, storeType: "date"),
                    LotCatigorieId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PostedByID)
                .Index(t => t.PostedByID);

        }
        
        public override void Down()
        {
        }
    }
}
