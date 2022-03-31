namespace MvcRedFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Theater",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movie", "TheaterId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "TheaterId");
            DropTable("dbo.Theater");
        }
    }
}
