namespace PointOfSaleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        ParentId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(),
                        Date = c.DateTime(nullable: false),
                        ItemParentsID = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemParentsID)
                .Index(t => t.ItemParentsID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        CostPrice = c.Double(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(),
                        Date = c.DateTime(nullable: false),
                        ItemCategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId, cascadeDelete: true)
                .Index(t => t.ItemCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemCategoryId", "dbo.ItemCategories");
            DropForeignKey("dbo.ItemCategories", "ItemParentsID", "dbo.ItemCategories");
            DropForeignKey("dbo.ExpenseItems", "CategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.ExpenseCategories", "ParentId", "dbo.ExpenseCategories");
            DropIndex("dbo.Items", new[] { "ItemCategoryId" });
            DropIndex("dbo.ItemCategories", new[] { "ItemParentsID" });
            DropIndex("dbo.ExpenseItems", new[] { "CategoryId" });
            DropIndex("dbo.ExpenseCategories", new[] { "ParentId" });
            DropTable("dbo.Items");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseCategories");
        }
    }
}
