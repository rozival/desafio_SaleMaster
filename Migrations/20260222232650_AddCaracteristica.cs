using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleMasterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCaracteristica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caracteristica_Cor",
                table: "Produtos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Caracteristica_Marca",
                table: "Produtos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Caracteristica_Material",
                table: "Produtos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Caracteristica_Tamanho",
                table: "Produtos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caracteristica_Cor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Caracteristica_Marca",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Caracteristica_Material",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Caracteristica_Tamanho",
                table: "Produtos");
        }
    }
}
