using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTour.DAL.Migrations
{
    public partial class Init_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", nullable: true),
                    FoundingDate = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "varchar(255)", nullable: true),
                    LikeCount = table.Column<int>(nullable: false),
                    MainImageURI = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sights_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sights_CategoryId",
                table: "Sights",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sights");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
