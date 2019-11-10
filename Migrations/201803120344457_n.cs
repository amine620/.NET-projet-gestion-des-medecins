namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.rendez_vous", "prenom", c => c.String());
            AddColumn("dbo.rendez_vous", "CNE", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.rendez_vous", "CNE");
            DropColumn("dbo.rendez_vous", "prenom");
        }
    }
}
