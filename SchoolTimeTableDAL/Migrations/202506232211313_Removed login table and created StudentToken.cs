namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedlogintableandcreatedStudentToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TokenStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.Logins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Roll = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserType = c.Int(nullable: false),
                        LastLogged = c.DateTime(nullable: false),
                        UserStatus = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TokenStudents", "UserId", "dbo.Students");
            DropIndex("dbo.TokenStudents", new[] { "UserId" });
            DropTable("dbo.TokenStudents");
        }
    }
}
