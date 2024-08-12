using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_ECommerce.Infra.Migrations
{
    /// <inheritdoc />
    public partial class fisr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ECommerce_TB001_Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    DataCriação = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusCliente = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECommerce_TB001_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ECommerce_TB001_Clientes");
        }
    }
}
