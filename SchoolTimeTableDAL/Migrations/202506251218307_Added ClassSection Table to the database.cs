﻿namespace SchoolTimeTableDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassSectionTabletothedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassSections");
        }
    }
}
