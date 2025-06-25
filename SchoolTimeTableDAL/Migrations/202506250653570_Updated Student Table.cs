namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedStudentTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Roll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Roll", c => c.Int(nullable: false));
        }
    }
}
