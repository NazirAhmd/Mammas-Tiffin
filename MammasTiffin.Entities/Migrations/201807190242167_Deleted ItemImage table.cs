namespace MammasTiffin.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedItemImagetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Menu.Items", "ImageId", "Menu.ItemImages");
            DropIndex("Menu.Items", new[] { "ImageId" });
            DropColumn("Menu.Items", "ImageId");
            DropTable("Menu.ItemImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "Menu.ItemImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(nullable: false, maxLength: 200, unicode: false),
                        ImageSize = c.Int(nullable: false),
                        ImageData = c.Binary(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        RowVersionStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Menu.Items", "ImageId", c => c.Int(nullable: false));
            CreateIndex("Menu.Items", "ImageId");
            AddForeignKey("Menu.Items", "ImageId", "Menu.ItemImages", "Id");
        }
    }
}
