namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedSlotTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slots", "StartTime", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Slots", "EndTime", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slots", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Slots", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
