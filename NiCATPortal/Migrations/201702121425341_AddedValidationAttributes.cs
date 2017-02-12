namespace NiCATPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidationAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CVs", "FileName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Homework", "FileName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Literatures", "FileName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Literatures", "FileName", c => c.String());
            AlterColumn("dbo.Homework", "FileName", c => c.String());
            AlterColumn("dbo.CVs", "FileName", c => c.String());
            AlterColumn("dbo.People", "FullName", c => c.String());
            AlterColumn("dbo.People", "password", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
