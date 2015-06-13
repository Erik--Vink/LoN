namespace LoN.Model.Migrations
{
    using LoN.Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LoN.Model.Context.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LoN.Model.Context.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Category.AddOrUpdate(
              
                new Category{ CategoryId = 0, CategoryName = "Head"},
                new Category{ CategoryId = 1, CategoryName = "Shoulders" },
                new Category{ CategoryId = 2, CategoryName = "Chest" },
                new Category{ CategoryId = 3, CategoryName = "Belt" },
                new Category{ CategoryId = 4, CategoryName = "Legs" },
                new Category{ CategoryId = 5, CategoryName = "Boots" }
          
            );

            context.SaveChanges();

            context.Equip.AddOrUpdate(

                new Equip { EquipName = "Bandana", Price = 10, Strength = 5, Intelligence = -2, Agillity = 5, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Head").CategoryId },
                new Equip { EquipName = "Crown", Price = 100, Strength = -5, Intelligence = 25, Agillity = 5, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Head").CategoryId },
                new Equip { EquipName = "Pauldrons", Price = 50, Strength = 25, Intelligence = -3, Agillity = 2, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Shoulders").CategoryId },
                new Equip { EquipName = "Leather pads", Price = 40, Strength = 13, Intelligence = -10, Agillity = 10, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Shoulders").CategoryId },
                new Equip { EquipName = "Iron chest", Price = 50, Strength = 25, Intelligence = -10, Agillity = 10, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Chest").CategoryId },
                new Equip { EquipName = "Steel chest", Price = 50, Strength = 30, Intelligence = -10, Agillity = 15, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Chest").CategoryId },
                new Equip { EquipName = "Yellow belt", Price = 30, Strength = -5, Intelligence = 30, Agillity = 10, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Belt").CategoryId },
                new Equip { EquipName = "Girly Belt", Price = 20, Strength = 5, Intelligence = -3, Agillity = 25, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Belt").CategoryId },
                new Equip { EquipName = "Fuzzy legs", Price = 50, Strength = -50, Intelligence = 40, Agillity = 10, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Legs").CategoryId },
                new Equip { EquipName = "Fancy pants", Price = 5, Strength = 5, Intelligence = -5, Agillity = 30, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Legs").CategoryId },
                new Equip { EquipName = "Swift boots", Price = 50, Strength = 25, Intelligence = -10, Agillity = 10, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Boots").CategoryId },
                new Equip { EquipName = "Jerusalem nikes", Price = 1, Strength = 99, Intelligence = 99, Agillity = 99, CategoryId = context.Category.FirstOrDefault(x => x.CategoryName == "Boots").CategoryId }    

            );
            
        }
    }
}
