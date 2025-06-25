namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSectionTableAddedStudentCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "StudentCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "StudentCount");
        }
    }
}
