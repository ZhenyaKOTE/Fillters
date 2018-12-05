namespace MyFilters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblFilters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFilter",
                c => new
                    {
                        FilterNameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilterNameId, t.FilterValueId, t.ProductId })
                .ForeignKey("dbo.tblFilterNames", t => t.FilterNameId, cascadeDelete: true)
                .ForeignKey("dbo.tblFiltersValues", t => t.FilterValueId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.FilterNameId)
                .Index(t => t.FilterValueId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFilter", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.tblFilter", "FilterValueId", "dbo.tblFiltersValues");
            DropForeignKey("dbo.tblFilter", "FilterNameId", "dbo.tblFilterNames");
            DropIndex("dbo.tblFilter", new[] { "ProductId" });
            DropIndex("dbo.tblFilter", new[] { "FilterValueId" });
            DropIndex("dbo.tblFilter", new[] { "FilterNameId" });
            DropTable("dbo.tblFilter");
        }
    }
}
