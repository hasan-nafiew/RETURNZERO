namespace PointOfSaleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordanigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Contact = c.String(),
                        Address = c.String(nullable: false),
                        Image = c.Binary(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Organizations");
        }
    }
}
