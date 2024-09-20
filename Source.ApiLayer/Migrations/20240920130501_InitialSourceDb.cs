using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.ApiLayer.Migrations
{
    public partial class InitialSourceDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "mstSource",
                columns: table => new
                {
                    SourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoruceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstSource", x => x.SourceId);
                    table.ForeignKey(
                        name: "FK_mstSource_mstProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "mstProduct",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_mstSource_ProductId",
                table: "mstSource",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mstSource");

        }
    }
}
