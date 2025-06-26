namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClassSectionsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassSections", "StudentCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassSections", "StudentCount");
        }
    }
}
