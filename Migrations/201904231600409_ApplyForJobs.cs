namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyForJobs : DbMigration
    {
        internal string userid;

        public object jobid { get; internal set; }

        public override void Up()
        {
            CreateTable(
                "dbo.ApplyJobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        message = c.String(),
                        ApplyTime = c.DateTime(nullable: false),
                        jobid = c.Int(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jobs", t => t.jobid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.jobid)
                .Index(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyJobs", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyJobs", "jobid", "dbo.Jobs");
            DropIndex("dbo.ApplyJobs", new[] { "userid" });
            DropIndex("dbo.ApplyJobs", new[] { "jobid" });
            DropTable("dbo.ApplyJobs");
        }
    }
}
