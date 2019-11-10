namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.rendez_vous", new[] { "user_Id" });
            DropColumn("dbo.rendez_vous", "UserId");
            RenameColumn(table: "dbo.rendez_vous", name: "user_Id", newName: "UserId");
            AlterColumn("dbo.rendez_vous", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.rendez_vous", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.rendez_vous", new[] { "UserId" });
            AlterColumn("dbo.rendez_vous", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.rendez_vous", name: "UserId", newName: "user_Id");
            AddColumn("dbo.rendez_vous", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.rendez_vous", "user_Id");
        }
    }
}
