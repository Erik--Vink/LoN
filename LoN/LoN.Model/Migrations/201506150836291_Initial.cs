namespace LoN.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Equips",
                c => new
                    {
                        EquipId = c.Int(nullable: false, identity: true),
                        EquipName = c.String(),
                        Price = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Agillity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.NinjaEquips",
                c => new
                    {
                        NinjaId = c.Int(nullable: false),
                        EquipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NinjaId, t.EquipId })
                .ForeignKey("dbo.Equips", t => t.EquipId, cascadeDelete: true)
                .ForeignKey("dbo.Ninjas", t => t.NinjaId, cascadeDelete: true)
                .Index(t => t.NinjaId)
                .Index(t => t.EquipId);
            
            CreateTable(
                "dbo.Ninjas",
                c => new
                    {
                        NinjaId = c.Int(nullable: false, identity: true),
                        Budget = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NinjaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NinjaEquips", "NinjaId", "dbo.Ninjas");
            DropForeignKey("dbo.NinjaEquips", "EquipId", "dbo.Equips");
            DropForeignKey("dbo.Equips", "CategoryId", "dbo.Categories");
            DropIndex("dbo.NinjaEquips", new[] { "EquipId" });
            DropIndex("dbo.NinjaEquips", new[] { "NinjaId" });
            DropIndex("dbo.Equips", new[] { "CategoryId" });
            DropTable("dbo.Ninjas");
            DropTable("dbo.NinjaEquips");
            DropTable("dbo.Equips");
            DropTable("dbo.Categories");
        }
    }
}
