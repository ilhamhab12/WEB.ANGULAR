namespace Bootcamp.Angular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Suppliers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Suppliers_Id)
                .Index(t => t.Suppliers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Suppliers_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "Suppliers_Id" });
            DropTable("dbo.Items");
        }
    }
}
