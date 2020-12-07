namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jobtitle = c.String(),
                        jobdesc = c.String(),
                        jobimage = c.String(),
                        catagoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.catagories", t => t.catagoryid, cascadeDelete: true)
                .Index(t => t.catagoryid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "catagoryid", "dbo.catagories");
            DropIndex("dbo.Jobs", new[] { "catagoryid" });
            DropTable("dbo.Jobs");
        }
    }
}
