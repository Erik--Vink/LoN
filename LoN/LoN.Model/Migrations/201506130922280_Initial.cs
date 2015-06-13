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
                "dbo.Ninjas",
                c => new
                    {
                        NinjaId = c.Int(nullable: false, identity: true),
                        Budget = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.NinjaId);
            
            CreateTable(
                "dbo.NinjaEquips",
                c => new
                    {
                        Ninja_NinjaId = c.Int(nullable: false),
                        Equip_EquipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ninja_NinjaId, t.Equip_EquipId })
                .ForeignKey("dbo.Ninjas", t => t.Ninja_NinjaId, cascadeDelete: true)
                .ForeignKey("dbo.Equips", t => t.Equip_EquipId, cascadeDelete: true)
                .Index(t => t.Ninja_NinjaId)
                .Index(t => t.Equip_EquipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NinjaEquips", "Equip_EquipId", "dbo.Equips");
            DropForeignKey("dbo.NinjaEquips", "Ninja_NinjaId", "dbo.Ninjas");
            DropForeignKey("dbo.Equips", "CategoryId", "dbo.Categories");
            DropIndex("dbo.NinjaEquips", new[] { "Equip_EquipId" });
            DropIndex("dbo.NinjaEquips", new[] { "Ninja_NinjaId" });
            DropIndex("dbo.Equips", new[] { "CategoryId" });
            DropTable("dbo.NinjaEquips");
            DropTable("dbo.Ninjas");
            DropTable("dbo.Equips");
            DropTable("dbo.Categories");
        }
    }
}
