using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoU.Migrations
{
    public partial class AddingCleaningPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "CleaningPlan",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        PlanName = table.Column<string>(nullable: false),
            //        CreatorId = table.Column<string>(nullable: false),
            //        PlanDate = table.Column<DateTime>(nullable: false),
            //        Describing = table.Column<string>(nullable: false),
            //        Address = table.Column<string>(nullable: false),
            //        MainPhoto = table.Column<string>(nullable: true),
            //        LocationId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CleaningPlan", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CleaningPlan_Location_Id",
            //            column: x => x.LocationId,
            //            principalTable: "Location",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade
            //        );
            //    }
            //);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable("CleaningPlan");
        }
    }
}