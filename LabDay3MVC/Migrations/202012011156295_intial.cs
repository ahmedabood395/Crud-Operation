namespace LabDay3MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(maxLength: 50),
                        loc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        hiredate = c.DateTime(nullable: false),
                        address = c.String(),
                        salary = c.Int(),
                        dept_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.dept_id)
                .Index(t => t.dept_id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        loc = c.String(maxLength: 50),
                        discription = c.String(),
                        dept_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.dept_id)
                .Index(t => t.dept_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "dept_id", "dbo.Departments");
            DropForeignKey("dbo.Employees", "dept_id", "dbo.Departments");
            DropIndex("dbo.Projects", new[] { "dept_id" });
            DropIndex("dbo.Employees", new[] { "dept_id" });
            DropTable("dbo.Projects");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
