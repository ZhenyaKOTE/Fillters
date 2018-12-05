namespace MyFilters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtblProductsRenamepropertyFilterIdtoFilterNameId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.tblFilterNameGroup", name: "FilterId", newName: "FilterNameId");
            RenameIndex(table: "dbo.tblFilterNameGroup", name: "IX_FilterId", newName: "IX_FilterNameId");
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblProducts");
            RenameIndex(table: "dbo.tblFilterNameGroup", name: "IX_FilterNameId", newName: "IX_FilterId");
            RenameColumn(table: "dbo.tblFilterNameGroup", name: "FilterNameId", newName: "FilterId");
        }
    }
}
