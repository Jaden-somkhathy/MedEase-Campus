namespace MedEase_Campus_Clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PatientId", c => c.String(maxLength: 128));
            AddColumn("dbo.Appointments", "DoctorId", c => c.String(maxLength: 128));
            AddColumn("dbo.Appointments", "Status", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "PatientId");
            CreateIndex("dbo.Appointments", "DoctorId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropColumn("dbo.Appointments", "Status");
            DropColumn("dbo.Appointments", "DoctorId");
            DropColumn("dbo.Appointments", "PatientId");
        }
    }
}
