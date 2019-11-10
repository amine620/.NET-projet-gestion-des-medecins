namespace siteweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medcines",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        prenom = c.String(),
                        Sexeid = c.Int(nullable: false),
                        Villeid = c.Int(nullable: false),
                        Specialiteid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Sexes", t => t.Sexeid, cascadeDelete: true)
                .ForeignKey("dbo.Specialites", t => t.Specialiteid, cascadeDelete: true)
                .ForeignKey("dbo.Villes", t => t.Villeid, cascadeDelete: true)
                .Index(t => t.Sexeid)
                .Index(t => t.Villeid)
                .Index(t => t.Specialiteid);
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Specialites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Villes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medcines", "Villeid", "dbo.Villes");
            DropForeignKey("dbo.Medcines", "Specialiteid", "dbo.Specialites");
            DropForeignKey("dbo.Medcines", "Sexeid", "dbo.Sexes");
            DropIndex("dbo.Medcines", new[] { "Specialiteid" });
            DropIndex("dbo.Medcines", new[] { "Villeid" });
            DropIndex("dbo.Medcines", new[] { "Sexeid" });
            DropTable("dbo.Villes");
            DropTable("dbo.Specialites");
            DropTable("dbo.Sexes");
            DropTable("dbo.Medcines");
        }
    }
}
