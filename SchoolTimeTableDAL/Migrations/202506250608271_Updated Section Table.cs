namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSectionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "Capacity");
        }
    }
}
