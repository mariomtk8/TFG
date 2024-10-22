using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecetasRedondas.Data.Migrations
{
    /// <inheritdoc />
    public partial class atributosNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiasMenu_MenusSemanales_IdMenuSemanal",
                table: "DiasMenu");

            migrationBuilder.AlterColumn<int>(
                name: "IdMenuSemanal",
                table: "DiasMenu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3731));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Ingredientes",
                keyColumn: "IdIngrediente",
                keyValue: 1,
                column: "FechaExpiracion",
                value: new DateTime(2024, 11, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "Ingredientes",
                keyColumn: "IdIngrediente",
                keyValue: 2,
                column: "FechaExpiracion",
                value: new DateTime(2025, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Ingredientes",
                keyColumn: "IdIngrediente",
                keyValue: 3,
                column: "FechaExpiracion",
                value: new DateTime(2025, 4, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "RecetaIngredientes",
                keyColumn: "IdRecetaIngrediente",
                keyValue: 1,
                column: "FechaAñadido",
                value: new DateTime(2024, 11, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "RecetaIngredientes",
                keyColumn: "IdRecetaIngrediente",
                keyValue: 2,
                column: "FechaAñadido",
                value: new DateTime(2024, 11, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4401));

            migrationBuilder.UpdateData(
                table: "RecetaIngredientes",
                keyColumn: "IdRecetaIngrediente",
                keyValue: 3,
                column: "FechaAñadido",
                value: new DateTime(2024, 11, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4103));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 26,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 27,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 28,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 29,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 30,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 10, 22, 12, 38, 22, 261, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.AddForeignKey(
                name: "FK_DiasMenu_MenusSemanales_IdMenuSemanal",
                table: "DiasMenu",
                column: "IdMenuSemanal",
                principalTable: "MenusSemanales",
                principalColumn: "IdMenuSemanal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiasMenu_MenusSemanales_IdMenuSemanal",
                table: "DiasMenu");

            migrationBuilder.AlterColumn<int>(
                name: "IdMenuSemanal",
                table: "DiasMenu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5656));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "Ingredientes",
                keyColumn: "IdIngrediente",
                keyValue: 1,
                column: "FechaExpiracion",
                value: new DateTime(2024, 11, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Ingredientes",
                keyColumn: "IdIngrediente",
                keyValue: 2,
                column: "FechaExpiracion",
                value: new DateTime(2025, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Ingredientes",
                keyColumn: "IdIngrediente",
                keyValue: 3,
                column: "FechaExpiracion",
                value: new DateTime(2025, 4, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "RecetaIngredientes",
                keyColumn: "IdRecetaIngrediente",
                keyValue: 1,
                column: "FechaAñadido",
                value: new DateTime(2024, 11, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "RecetaIngredientes",
                keyColumn: "IdRecetaIngrediente",
                keyValue: 2,
                column: "FechaAñadido",
                value: new DateTime(2024, 11, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "RecetaIngredientes",
                keyColumn: "IdRecetaIngrediente",
                keyValue: 3,
                column: "FechaAñadido",
                value: new DateTime(2024, 11, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 26,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 27,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 28,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 29,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "Recetas",
                keyColumn: "IdReceta",
                keyValue: 30,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 10, 22, 10, 20, 45, 114, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.AddForeignKey(
                name: "FK_DiasMenu_MenusSemanales_IdMenuSemanal",
                table: "DiasMenu",
                column: "IdMenuSemanal",
                principalTable: "MenusSemanales",
                principalColumn: "IdMenuSemanal",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
