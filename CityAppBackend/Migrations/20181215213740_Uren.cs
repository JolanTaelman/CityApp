using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityAppBackend.Migrations
{
    public partial class Uren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uren",
                columns: table => new
                {
                    UrenId = table.Column<Guid>(nullable: false),
                    Openingsuren = table.Column<DateTime>(nullable: false),
                    Sluitingsuren = table.Column<DateTime>(nullable: false),
                    Dag = table.Column<string>(nullable: true),
                    BusinessId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uren", x => x.UrenId);
                    table.ForeignKey(
                        name: "FK_Uren_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uren_BusinessId",
                table: "Uren",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uren");
        }
    }
}
