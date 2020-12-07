namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "bonus", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Jobs", "pay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "pay");
            DropColumn("dbo.Jobs", "bonus");
        }
    }
}
