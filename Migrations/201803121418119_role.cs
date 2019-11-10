namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medcines", "photo", c => c.String());
            AlterColumn("dbo.Medcines", "nom", c => c.String(nullable: false));
            AlterColumn("dbo.Medcines", "prenom", c => c.String(nullable: false));
            AlterColumn("dbo.Medcines", "Adresse", c => c.String(nullable: false));
            AlterColumn("dbo.Medcines", "Telephone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medcines", "Telephone", c => c.String());
            AlterColumn("dbo.Medcines", "Adresse", c => c.String());
            AlterColumn("dbo.Medcines", "prenom", c => c.String());
            AlterColumn("dbo.Medcines", "nom", c => c.String());
            DropColumn("dbo.Medcines", "photo");
        }
    }
}
