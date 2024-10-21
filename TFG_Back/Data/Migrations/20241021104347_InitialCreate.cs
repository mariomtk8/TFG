﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecetasRedondas.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especial = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuntuacionPromedio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IdIngrediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreIngrediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calorias = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContieneAlergenos = table.Column<bool>(type: "bit", nullable: false),
                    TipoAlergeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IdIngrediente);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    IdReceta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsVegano = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelDificultad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TiempoPreparacion = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.IdReceta);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Pasos",
                columns: table => new
                {
                    IdPaso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasos", x => x.IdPaso);
                    table.ForeignKey(
                        name: "FK_Pasos_Recetas_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Recetas",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetaIngredientes",
                columns: table => new
                {
                    IdRecetaIngrediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAñadido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsOpcional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaIngredientes", x => x.IdRecetaIngrediente);
                    table.ForeignKey(
                        name: "FK_RecetaIngredientes_Ingredientes_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaIngredientes_Recetas_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Recetas",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alergenos",
                columns: table => new
                {
                    IdAlergeno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    IngredientesIdIngrediente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergenos", x => x.IdAlergeno);
                    table.ForeignKey(
                        name: "FK_Alergenos_Ingredientes_IngredientesIdIngrediente",
                        column: x => x.IngredientesIdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente");
                    table.ForeignKey(
                        name: "FK_Alergenos_Usuarios_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    IdFavorito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    FechaFavorito = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.IdFavorito);
                    table.ForeignKey(
                        name: "FK_Favoritos_Recetas_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Recetas",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenusSemanales",
                columns: table => new
                {
                    IdMenuSemanal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    NumSemana = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenusSemanales", x => x.IdMenuSemanal);
                    table.ForeignKey(
                        name: "FK_MenusSemanales_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recetasPasos",
                columns: table => new
                {
                    IdPaso = table.Column<int>(type: "int", nullable: false),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    IdRecetasPaso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recetasPasos", x => new { x.IdReceta, x.IdPaso });
                    table.ForeignKey(
                        name: "FK_recetasPasos_Pasos_IdPaso",
                        column: x => x.IdPaso,
                        principalTable: "Pasos",
                        principalColumn: "IdPaso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_recetasPasos_Recetas_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Recetas",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiasMenu",
                columns: table => new
                {
                    IdDiaMenu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    TipoComida = table.Column<bool>(type: "bit", nullable: false),
                    IdMenuSemanal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasMenu", x => x.IdDiaMenu);
                    table.ForeignKey(
                        name: "FK_DiasMenu_MenusSemanales_IdMenuSemanal",
                        column: x => x.IdMenuSemanal,
                        principalTable: "MenusSemanales",
                        principalColumn: "IdMenuSemanal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiasMenu_Recetas_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Recetas",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Descripcion", "Especial", "FechaCreacion", "Icono", "NombreCategoria", "PuntuacionPromedio" },
                values: new object[,]
                {
                    { 1, "Platos deliciosos de carne", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3125), "https://ik.imagekit.io/Mariocanizares/carne.webp?updatedAt=1726218723472", "Carnes", 4.5m },
                    { 2, "Platos variados con arroz", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3198), "https://ik.imagekit.io/Mariocanizares/arroz.png?updatedAt=1726218452623", "Arroces", 4.8m },
                    { 3, "Guisos tradicionales y caseros", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3202), "https://ik.imagekit.io/Mariocanizares/guisos.png?updatedAt=1726218800757", "Guisos", 4.7m },
                    { 4, "Platos exquisitos de mariscos", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3205), "https://ik.imagekit.io/Mariocanizares/marisco.webp?updatedAt=1726218800789", "Mariscos", 4.6m },
                    { 5, "Platos frescos de pescados", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3209), "https://ik.imagekit.io/Mariocanizares/pescado.png?updatedAt=1726218801946", "Pescados", 4.7m },
                    { 6, "Platos deliciosos de pasta", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3212), "https://ik.imagekit.io/Mariocanizares/pasta.png?updatedAt=1726218800772", "Pastas", 4.5m },
                    { 7, "Frescas y saludables ensaladas", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3215), "https://ik.imagekit.io/Mariocanizares/carne.webp?updatedAt=1726218723472", "Ensaladas", 4.6m },
                    { 8, "Reconfortantes sopas y cremas", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3218), "https://ik.imagekit.io/Mariocanizares/sopa.png?updatedAt=1726218800718f", "Sopas", 4.7m },
                    { 9, "Variedad de pizzas caseras", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3221), "https://ik.imagekit.io/Mariocanizares/pizza.png?updatedAt=1726218802077", "Pizzas", 4.8m },
                    { 10, "Creativos y deliciosos sandwiches", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3224), "https://ik.imagekit.io/Mariocanizares/sandwitches.png?updatedAt=1726218800723", "Sandwiches", 4.5m },
                    { 11, "Platos saludables de verduras", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3229), "https://ik.imagekit.io/Mariocanizares/verduras.png?updatedAt=1726218800742", "Verduras", 4.6m },
                    { 12, "Salsas para acompañar tus platos", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3232), "https://ik.imagekit.io/Mariocanizares/salsas.png?updatedAt=1726218800564", "Salsas", 4.7m },
                    { 13, "Dulces y sabrosos postres", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3236), "https://ik.imagekit.io/Mariocanizares/postres.png?updatedAt=1726218800753", "Postres", 4.8m },
                    { 14, "Bebidas refrescantes y cócteles", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3239), "https://ik.imagekit.io/Mariocanizares/bebidas.png?updatedAt=1726218678224", "Bebidas", 4.7m },
                    { 15, "Platos tradicionales de legumbres", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3242), "https://ik.imagekit.io/Mariocanizares/legumbres.png?updatedAt=1726218800787", "Legumbres", 4.6m }
                });

            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "IdIngrediente", "Calorias", "ContieneAlergenos", "FechaExpiracion", "NombreIngrediente", "TipoAlergeno", "UnidadMedida" },
                values: new object[,]
                {
                    { 1, 15m, false, new DateTime(2024, 11, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(4007), "Lechuga", "", "g" },
                    { 2, 130m, false, new DateTime(2025, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(4021), "Arroz", "", "g" },
                    { 3, 2m, false, new DateTime(2025, 4, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(4025), "Café", "", "ml" }
                });

            migrationBuilder.InsertData(
                table: "Recetas",
                columns: new[] { "IdReceta", "Descripcion", "EsVegano", "FechaCreacion", "IdCategoria", "Imagen", "NivelDificultad", "Nombre", "TiempoPreparacion" },
                values: new object[,]
                {
                    { 1, "Ensalada fresca con aderezo César", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3713), 1, "https://ik.imagekit.io/Mariocanizares/Recetas/ensalada.jpg?updatedAt=1727169325456", 1m, "Ensalada César", 20 },
                    { 2, "Arroz tradicional español con mariscos", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3728), 2, "https://ik.imagekit.io/Mariocanizares/Recetas/arroz-marisco.jpg?updatedAt=1727169389258", 2m, "Paella", 60 },
                    { 3, "Postre italiano con café y mascarpone", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3733), 3, "https://ik.imagekit.io/Mariocanizares/Recetas/tiramisu.jpg?updatedAt=1727169422091", 3m, "Tiramisú", 30 },
                    { 4, "Pasta con salsa cremosa de huevo y panceta", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3736), 4, "https://ik.imagekit.io/Mariocanizares/Recetas/carbonara.jpg?updatedAt=1727169452310", 2m, "Pasta Carbonara", 25 },
                    { 5, "Rollos de arroz y pescado crudo", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3740), 5, "https://ik.imagekit.io/Mariocanizares/Recetas/sushi.jpg?updatedAt=1727169470676", 3m, "Sushi", 50 },
                    { 6, "Pizza clásica con tomate, mozzarella y albahaca", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3744), 6, "https://ik.imagekit.io/Mariocanizares/Recetas/pizza.jpg?updatedAt=1727169491728", 2m, "Pizza Margherita", 40 },
                    { 7, "Aguacate triturado con cebolla, tomate y limón", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3749), 1, "https://ik.imagekit.io/Mariocanizares/Recetas/guacamole.jpg?updatedAt=1727169511551", 1m, "Guacamole", 10 },
                    { 8, "Capas de pasta, carne y salsa de tomate", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3753), 4, "https://ik.imagekit.io/Mariocanizares/Recetas/lasagna.jpg?updatedAt=1727169528673", 3m, "Lasaña", 90 },
                    { 9, "Tacos rellenos de pollo, cebolla y cilantro", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3756), 2, "https://ik.imagekit.io/Mariocanizares/Recetas/tacos.jpg?updatedAt=1727169541523", 2m, "Tacos de Pollo", 30 },
                    { 10, "Deliciosos brownies de chocolate", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3759), 3, "https://ik.imagekit.io/Mariocanizares/Recetas/brownies.jpg?updatedAt=1727169556237", 2m, "Brownies", 45 },
                    { 11, "Sopa nutritiva de lentejas", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3763), 1, "https://ik.imagekit.io/Mariocanizares/Recetas/lentejas.jpg?updatedAt=1727169570913", 1m, "Sopa de Lentejas", 35 },
                    { 12, "Guiso picante de carne y frijoles", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3768), 2, "https://ik.imagekit.io/Mariocanizares/Recetas/chili.jpg?updatedAt=1727169584071", 3m, "Chili con Carne", 50 },
                    { 13, "Dip de berenjena asada", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3771), 1, "https://ik.imagekit.io/Mariocanizares/Recetas/baba-ganoush.jpg?updatedAt=1727169596850", 2m, "Baba Ganoush", 20 },
                    { 14, "Deliciosos crepes dulces o salados", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3777), 3, "https://ik.imagekit.io/Mariocanizares/Recetas/crepes.jpg?updatedAt=1727169607858", 2m, "Crepes", 30 },
                    { 15, "Pollo cocido en salsa de curry", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3781), 2, "https://ik.imagekit.io/Mariocanizares/Recetas/pollo-curry.jpg?updatedAt=1727169619493", 3m, "Pollo al Curry", 40 },
                    { 16, "Galletas crujientes de chocolate", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3784), 3, "https://ik.imagekit.io/Mariocanizares/Recetas/galletas-chocolate.jpg?updatedAt=1727169630571", 1m, "Galletas de Chocolate", 25 },
                    { 17, "Tarta salada con verduras y queso", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3846), 4, "https://ik.imagekit.io/Mariocanizares/Recetas/quiche.jpg?updatedAt=1727169642129", 3m, "Quiche de Verduras", 50 },
                    { 18, "Muffins esponjosos con arándanos", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3852), 3, "https://ik.imagekit.io/Mariocanizares/Recetas/muffins.jpg?updatedAt=1727169653441", 2m, "Muffins de Arándano", 35 },
                    { 19, "Batido saludable de espinacas y plátano", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3857), 1, "https://ik.imagekit.io/Mariocanizares/Recetas/batido-verde.jpg?updatedAt=1727169666491", 1m, "Batido Verde", 15 },
                    { 20, "Salmón asado con hierbas", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3862), 2, "https://ik.imagekit.io/Mariocanizares/Recetas/salmon.jpg?updatedAt=1727169677362", 2m, "Salmón al Horno", 30 },
                    { 21, "Pancakes esponjosos con jarabe de arce", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3865), 3, "https://ik.imagekit.io/Mariocanizares/Recetas/pancakes.jpg?updatedAt=1727169687612", 1m, "Pancakes", 20 },
                    { 22, "Sopa fría de tomate", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3869), 1, "https://ik.imagekit.io/Mariocanizares/Recetas/gazpacho.jpg?updatedAt=1727169697098", 2m, "Gazpacho", 15 },
                    { 23, "Bolas fritas rellenas de bechamel", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3872), 4, "https://ik.imagekit.io/Mariocanizares/Recetas/croquetas.jpg?updatedAt=1727169707360", 3m, "Croquetas", 45 },
                    { 24, "Pudín saludable con semillas de chía", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3877), 3, "https://ik.imagekit.io/Mariocanizares/Recetas/pudin-chia.jpg?updatedAt=1727169717454", 1m, "Pudín de Chía", 15 },
                    { 25, "Pescado marinado en jugo de limón", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3881), 2, "https://ik.imagekit.io/Mariocanizares/Recetas/ceviche.jpg?updatedAt=1727169726708", 3m, "Ceviche", 30 },
                    { 26, "Huevos con salsa de tomate y frijoles", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3885), 4, "https://ik.imagekit.io/Mariocanizares/Recetas/huevos-rancheros.jpg?updatedAt=1727169737304", 2m, "Huevos Rancheros", 25 },
                    { 27, "Pimientos rellenos de carne y arroz", false, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3888), 4, "https://ik.imagekit.io/Mariocanizares/Recetas/pimientos-rellenos.jpg?updatedAt=1727169746992", 3m, "Pimientos Rellenos", 50 },
                    { 28, "Zanahorias asadas con miel y especias", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3891), 1, "https://ik.imagekit.io/Mariocanizares/Recetas/zanahorias.jpg?updatedAt=1727169756553", 1m, "Zanahorias Asadas", 30 },
                    { 29, "Pasta con salsa pesto fresca", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3897), 4, "https://ik.imagekit.io/Mariocanizares/Recetas/pasta-pesto.jpg?updatedAt=1727169765990", 2m, "Pasta al Pesto", 20 },
                    { 30, "Batido refrescante de fresa", true, new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(3902), 1, "https://ik.imagekit.io/Mariocanizares/Recetas/batido-fresa.jpg?updatedAt=1727169775184", 1m, "Batido de Fresa", 10 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Contrasena", "Correo", "FechaRegistro", "Nombre", "Rol" },
                values: new object[] { 1, "MarioX8", "mario@gmail.com", new DateTime(2024, 10, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(4112), "Admin", true });

            migrationBuilder.InsertData(
                table: "Pasos",
                columns: new[] { "IdPaso", "Descripcion", "IdReceta", "ImagenUrl", "Numero" },
                values: new object[,]
                {
                    { 1, "Lavar y trocear la lechuga.", 1, "https://ik.imagekit.io/Mariocanizares/Recetas/ensalada.jpg?updatedAt=1727169325456", 1 },
                    { 2, "Agregar el aderezo César y mezclar bien.", 1, "https://example.com/imagen2.jpg", 2 },
                    { 3, "Servir y disfrutar.", 1, "https://example.com/imagen3.jpg", 3 },
                    { 4, "Cocinar el arroz en caldo de pescado.", 2, "https://ik.imagekit.io/Mariocanizares/Recetas/arroz-marisco.jpg?updatedAt=1727169389258", 1 },
                    { 5, "Agregar los mariscos y verduras.", 2, "https://example.com/imagen5.jpg", 2 },
                    { 6, "Cocinar a fuego lento hasta que el arroz esté listo.", 2, "https://example.com/imagen6.jpg", 3 },
                    { 7, "Preparar el café y dejar enfriar.", 3, "https://ik.imagekit.io/Mariocanizares/Recetas/tiramisu.jpg?updatedAt=1727169422091", 1 },
                    { 8, "Mezclar el mascarpone con azúcar.", 3, "https://example.com/imagen8.jpg", 2 },
                    { 9, "Montar los ingredientes en capas.", 3, "https://example.com/imagen9.jpg", 3 }
                });

            migrationBuilder.InsertData(
                table: "RecetaIngredientes",
                columns: new[] { "IdRecetaIngrediente", "Cantidad", "EsOpcional", "FechaAñadido", "IdIngrediente", "IdReceta", "Notas" },
                values: new object[,]
                {
                    { 1, 100m, false, new DateTime(2024, 11, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(4063), 1, 1, "" },
                    { 2, 200m, false, new DateTime(2024, 11, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(4071), 2, 2, "" },
                    { 3, 50m, false, new DateTime(2024, 11, 21, 12, 43, 47, 94, DateTimeKind.Local).AddTicks(4075), 3, 3, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergenos_IngredientesIdIngrediente",
                table: "Alergenos",
                column: "IngredientesIdIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_Alergenos_UsuariosIdUsuario",
                table: "Alergenos",
                column: "UsuariosIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DiasMenu_IdMenuSemanal",
                table: "DiasMenu",
                column: "IdMenuSemanal");

            migrationBuilder.CreateIndex(
                name: "IX_DiasMenu_IdReceta",
                table: "DiasMenu",
                column: "IdReceta");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdReceta",
                table: "Favoritos",
                column: "IdReceta");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdUsuario",
                table: "Favoritos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_MenusSemanales_IdUsuario",
                table: "MenusSemanales",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pasos_IdReceta",
                table: "Pasos",
                column: "IdReceta");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_IdIngrediente",
                table: "RecetaIngredientes",
                column: "IdIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_IdReceta",
                table: "RecetaIngredientes",
                column: "IdReceta");

            migrationBuilder.CreateIndex(
                name: "IX_recetasPasos_IdPaso",
                table: "recetasPasos",
                column: "IdPaso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergenos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "DiasMenu");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "RecetaIngredientes");

            migrationBuilder.DropTable(
                name: "recetasPasos");

            migrationBuilder.DropTable(
                name: "MenusSemanales");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Pasos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Recetas");
        }
    }
}
