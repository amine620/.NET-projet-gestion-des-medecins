namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ksksni : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medcines", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medcines", "ConfirmPassword", c => c.String());
        }
    }
}
