namespace CardsForSquanchies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCardsTableToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FrontText = c.String(nullable: false, maxLength: 255),
                        BackText = c.String(nullable: false, maxLength: 255),
                        CardCommand = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cards");
        }
    }
}
