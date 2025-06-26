namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassSectionSubjectTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSectionSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassSectionId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassSectionSubjects");
        }
    }
}
