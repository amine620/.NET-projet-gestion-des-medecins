namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.rendez_vous",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                        Medcineid = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medcines", t => t.Medcineid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.Medcineid)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.rendez_vous", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.rendez_vous", "Medcineid", "dbo.Medcines");
            DropIndex("dbo.rendez_vous", new[] { "user_Id" });
            DropIndex("dbo.rendez_vous", new[] { "Medcineid" });
            DropTable("dbo.rendez_vous");
        }
    }
}
