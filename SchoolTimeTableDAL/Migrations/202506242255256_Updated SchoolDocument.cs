namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSchoolDocument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolDocuments", "UploadDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SchoolDocuments", "UploadedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolDocuments", "UploadedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.SchoolDocuments", "UploadDate");
        }
    }
}
