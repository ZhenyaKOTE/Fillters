namespace MyFilters.Migrations
{
    using MyFilters.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyFilters.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyFilters.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            #region InitFilterValue
            FilterValue[] values =
            {
                new FilterValue{Id=1, Name = "Acer" },
                new FilterValue{Id=2, Name = "Apple" },
                new FilterValue{Id=3, Name="HP" },
                new FilterValue{Id=4, Name = "Asus" },
                new FilterValue{Id=5, Name="Lenovo" },
                new FilterValue{Id=6, Name = "MSI" },
                new FilterValue{Id=7, Name = "Dell" },
                new FilterValue{Id=8, Name="128 Гб" },
                new FilterValue{Id=9, Name="256 Гб" },
                new FilterValue{Id=10, Name="512 Гб" },
                new FilterValue{Id=11, Name="1 ТБ" }
            };
            context.FilterValues.AddOrUpdate(x => x.Id, values);
            #endregion

            #region InitFilterName
            FilterName[] names =
            {
                new FilterName{Id=1, Name = "Виробник" },
                new FilterName{Id=2, Name = "Обсяг SSD" },
            };
            context.FilterNames.AddOrUpdate(x => x.Id, names);
            #endregion

            #region FilterNameGroup
            FilterNameGroup[] fngs =
            {
                new FilterNameGroup { FilterNameId = 1, FilterValueId = 1 },
                new FilterNameGroup { FilterNameId = 1, FilterValueId = 2 },
                new FilterNameGroup { FilterNameId = 1, FilterValueId = 3 },
                new FilterNameGroup { FilterNameId = 1, FilterValueId = 4 },
                new FilterNameGroup { FilterNameId = 1, FilterValueId = 5 },
                new FilterNameGroup { FilterNameId = 1, FilterValueId = 6 },
                new FilterNameGroup { FilterNameId = 1, FilterValueId = 7 },
                new FilterNameGroup { FilterNameId = 2, FilterValueId = 8 },
                new FilterNameGroup { FilterNameId = 2, FilterValueId = 9 },
                new FilterNameGroup { FilterNameId = 2, FilterValueId = 10 },
                new FilterNameGroup { FilterNameId = 2, FilterValueId = 11 }
            };
            context.FilterNameGroups.AddOrUpdate(x => new { x.FilterValueId, x.FilterNameId }, fngs);
            #endregion

            #region Products
            Product[] products =
            {
                new Product {
                    Id = 1,
                    Name = "Ноутбук ASUS VivoBook 15 RZ542UF-DM208 (90RZ0IJ2-M04000) Dark Grey",
                    Price=10599,
                    Quantity = 4,
                    DateCreate = DateTime.Now
                },

                new Product
                {
                    Id = 2,
                    Name = "Ноутбук Dell Inspiron 7577 (i757161S3DL-418) Black",
                    Price = 25699,
                    Quantity = 7,
                    DateCreate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "Ноутбук HP 250 G6 (4QW21ES) Dark Ash",
                    Price = 4899,
                    Quantity = 6,
                    DateCreate = DateTime.Now
                },

                new Product
                {
                    Id = 4,
                    Name = "Ноутбук HP ProBook 430 G5 (4QW08ES) Silver",
                    Price = 17654,
                    Quantity = 2,
                    DateCreate = DateTime.Now
                }


            };
            context.Products.AddOrUpdate(x => x.Id, products);
            #endregion

            #region MyRegion
            Filter[] filters =
            {
                new Filter { FilterNameId = 1, FilterValueId = 4, ProductId = 1 }, //Asus
                new Filter { FilterNameId = 1, FilterValueId = 3, ProductId = 3 }, //Hp - 1
                new Filter { FilterNameId = 1, FilterValueId = 3, ProductId = 4 }, //Hp - 2
                new Filter { FilterNameId = 2, FilterValueId = 8, ProductId = 1 }, //Asus - SSD 128GB
                new Filter { FilterNameId = 2, FilterValueId = 9, ProductId = 4 }, //Hp - 2 SSD 256GB
                new Filter { FilterNameId = 1, FilterValueId = 7, ProductId = 2 }, //DELL
                new Filter { FilterNameId = 2, FilterValueId = 10, ProductId = 2 } //DELL SSD 512
            };
            context.Filters.AddOrUpdate(x => new { x.FilterNameId, x.FilterValueId, x.ProductId }, filters);
            #endregion

        }
    }
}
