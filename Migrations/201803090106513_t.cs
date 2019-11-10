namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medcines", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Medcines", "Adresse", c => c.String());
            AddColumn("dbo.Medcines", "Telephone", c => c.String());
            AddColumn("dbo.Medcines", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Medcines", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medcines", "ConfirmPassword");
            DropColumn("dbo.Medcines", "Password");
            DropColumn("dbo.Medcines", "Telephone");
            DropColumn("dbo.Medcines", "Adresse");
            DropColumn("dbo.Medcines", "Email");
        }
    }
}
