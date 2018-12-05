namespace MyFilters.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtblFilterNameGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFilterNameGroup",
                c => new
                    {
                        FilterId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilterId, t.FilterValueId })
                .ForeignKey("dbo.tblFilterNames", t => t.FilterId, cascadeDelete: true)
                .ForeignKey("dbo.tblFiltersValues", t => t.FilterValueId, cascadeDelete: true)
                .Index(t => t.FilterId)
                .Index(t => t.FilterValueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFilterNameGroup", "FilterValueId", "dbo.tblFiltersValues");
            DropForeignKey("dbo.tblFilterNameGroup", "FilterId", "dbo.tblFilterNames");
            DropIndex("dbo.tblFilterNameGroup", new[] { "FilterValueId" });
            DropIndex("dbo.tblFilterNameGroup", new[] { "FilterId" });
            DropTable("dbo.tblFilterNameGroup");
        }
    }
}
