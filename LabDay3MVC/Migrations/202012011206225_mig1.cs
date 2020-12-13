namespace LabDay3MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "loc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "loc", c => c.Int(nullable: false));
        }
    }
}
