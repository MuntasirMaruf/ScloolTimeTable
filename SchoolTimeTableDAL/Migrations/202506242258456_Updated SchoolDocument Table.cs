namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSchoolDocumentTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SchoolDocuments", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolDocuments", "Description", c => c.String(nullable: false, maxLength: 500, unicode: false));
        }
    }
}
