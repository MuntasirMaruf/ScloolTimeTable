namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Password", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Teachers", "Password", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Password");
            DropColumn("dbo.Students", "Password");
        }
    }
}
