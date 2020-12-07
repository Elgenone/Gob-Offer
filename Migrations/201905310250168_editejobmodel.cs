namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editejobmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "userid");
            AddForeignKey("dbo.Jobs", "userid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.Jobs", new[] { "userid" });
            DropColumn("dbo.Jobs", "userid");
        }
    }
}
