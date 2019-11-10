namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medcines", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medcines", "Password", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
