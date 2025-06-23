namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedLoginTableAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "UserStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "UserStatus");
        }
    }
}
