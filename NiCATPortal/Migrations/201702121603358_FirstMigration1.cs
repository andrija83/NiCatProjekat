namespace NiCATPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "CV_Id", "dbo.CVs");
            DropIndex("dbo.People", new[] { "CV_Id" });
            AddColumn("dbo.CVs", "Student_Id", c => c.Int());
            CreateIndex("dbo.CVs", "Student_Id");
            AddForeignKey("dbo.CVs", "Student_Id", "dbo.People", "Id");
            DropColumn("dbo.People", "CV_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "CV_Id", c => c.Int());
            DropForeignKey("dbo.CVs", "Student_Id", "dbo.People");
            DropIndex("dbo.CVs", new[] { "Student_Id" });
            DropColumn("dbo.CVs", "Student_Id");
            CreateIndex("dbo.People", "CV_Id");
            AddForeignKey("dbo.People", "CV_Id", "dbo.CVs", "Id");
        }
    }
}
