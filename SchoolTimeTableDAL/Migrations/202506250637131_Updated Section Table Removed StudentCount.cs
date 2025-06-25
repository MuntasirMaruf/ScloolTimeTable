namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSectionTableRemovedStudentCount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sections", "StudentCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sections", "StudentCount", c => c.Int(nullable: false));
        }
    }
}
