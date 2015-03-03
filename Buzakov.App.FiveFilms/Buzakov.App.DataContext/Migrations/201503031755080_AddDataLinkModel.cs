namespace Buzakov.App.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataLinkModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropTable("dbo.DataLinks");
        }
    }
}
