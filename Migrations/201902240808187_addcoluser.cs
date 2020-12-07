namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoluser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "usertype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "usertype");
        }
    }
}
