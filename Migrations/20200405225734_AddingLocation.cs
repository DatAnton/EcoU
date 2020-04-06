using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoU.Migrations
{
    public partial class AddingLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Town = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CleaningPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanName = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    PlanDate = table.Column<DateTime>(nullable: false),
                    Describing = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    MainPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CleaningPlan_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningPlan_CreatorId",
                table: "CleaningPlan",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningPlan");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
