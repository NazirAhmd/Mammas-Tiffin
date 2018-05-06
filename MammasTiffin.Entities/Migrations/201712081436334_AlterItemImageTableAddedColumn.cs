namespace MammasTiffin.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterItemImageTableAddedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("Menu.ItemImages", "DateAndTime", c => c.DateTime(nullable: false));
            AddColumn("Menu.ItemImages", "RowVersionStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"));
        }
        
        public override void Down()
        {
            DropColumn("Menu.ItemImages", "RowVersionStamp");
            DropColumn("Menu.ItemImages", "DateAndTime");
        }
    }
}
