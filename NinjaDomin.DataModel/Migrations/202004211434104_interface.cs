namespace NinjaDomin.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _interface : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clans", "DataModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clans", "DataCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clans", "IsDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ninjas", "DataModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ninjas", "DataCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ninjas", "IsDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.NinjaEquipments", "DataModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.NinjaEquipments", "DataCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.NinjaEquipments", "IsDirty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NinjaEquipments", "IsDirty");
            DropColumn("dbo.NinjaEquipments", "DataCreated");
            DropColumn("dbo.NinjaEquipments", "DataModified");
            DropColumn("dbo.Ninjas", "IsDirty");
            DropColumn("dbo.Ninjas", "DataCreated");
            DropColumn("dbo.Ninjas", "DataModified");
            DropColumn("dbo.Clans", "IsDirty");
            DropColumn("dbo.Clans", "DataCreated");
            DropColumn("dbo.Clans", "DataModified");
        }
    }
}
