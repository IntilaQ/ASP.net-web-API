namespace Sessiongrp45.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        DepartementId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        DepartementId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departements", t => t.DepartementId)
                .Index(t => t.DepartementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartementId", "dbo.Departements");
            DropIndex("dbo.Employees", new[] { "DepartementId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departements");
        }
    }
}
