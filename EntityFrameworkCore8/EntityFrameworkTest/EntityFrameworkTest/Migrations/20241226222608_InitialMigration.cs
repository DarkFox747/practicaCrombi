using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuarios",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ObraSocialId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ObraSociales",
                columns: table => new
                {
                    IdObraSocial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraSociales", x => x.IdObraSocial);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ObraSocialId",
                table: "Usuarios",
                column: "ObraSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_ObraSociales_ObraSocialId",
                table: "Usuarios",
                column: "ObraSocialId",
                principalTable: "ObraSociales",
                principalColumn: "IdObraSocial",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_ObraSociales_ObraSocialId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "ObraSociales");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ObraSocialId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ObraSocialId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "Phone");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUsuarios",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
