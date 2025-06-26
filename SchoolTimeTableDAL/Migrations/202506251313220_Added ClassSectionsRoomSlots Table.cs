namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassSectionsRoomSlotsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSectionRoomSlots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassSectionId = c.Int(nullable: false),
                        RoomSlotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ClassSectionStudents", "ClassSectionId", c => c.Int(nullable: false));
            DropColumn("dbo.ClassSectionStudents", "ClassId");
            DropColumn("dbo.ClassSectionStudents", "SectionId");
            DropColumn("dbo.ClassSectionStudents", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClassSectionStudents", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.ClassSectionStudents", "SectionId", c => c.Int(nullable: false));
            AddColumn("dbo.ClassSectionStudents", "ClassId", c => c.Int(nullable: false));
            DropColumn("dbo.ClassSectionStudents", "ClassSectionId");
            DropTable("dbo.ClassSectionRoomSlots");
        }
    }
}
