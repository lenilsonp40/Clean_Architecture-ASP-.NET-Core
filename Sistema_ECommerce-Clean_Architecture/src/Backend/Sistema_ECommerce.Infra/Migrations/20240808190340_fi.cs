using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_ECommerce.Infra.Migrations
{
    /// <inheritdoc />
    public partial class fi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCriação",
                table: "ECommerce_TB001_Clientes",
                newName: "DataCreate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCreate",
                table: "ECommerce_TB001_Clientes",
                newName: "DataCriação");
        }
    }
}
