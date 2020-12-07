namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catagorydb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.catagories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        catagoryname = c.String(nullable: false),
                        catagorydesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.catagories");
        }
    }
}
