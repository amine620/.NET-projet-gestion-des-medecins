namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medcines", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Medcines", "UserId");
            AddForeignKey("dbo.Medcines", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medcines", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Medcines", new[] { "UserId" });
            DropColumn("dbo.Medcines", "UserId");
        }
    }
}
