using System;
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
                    Visible = table.Column<bool>(type: "bit", nullable: false),
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
                name: "MenuSemanalRecetas",
                columns: table => new
                {
                    IdMenuSemanal = table.Column<int>(type: "int", nullable: false),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSemanalRecetas", x => new { x.IdMenuSemanal, x.IdReceta, x.Fecha });
                });

            migrationBuilder.CreateTable(
                name: "MenusSemanales",
                columns: table => new
                {
                    IdMenuSemanal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenusSemanales", x => x.IdMenuSemanal);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    IdReceta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "RecetaIngredientes",
                columns: table => new
                {
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAñadido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsOpcional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaIngredientes", x => new { x.IdReceta, x.IdIngrediente });
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

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Descripcion", "FechaCreacion", "Icono", "NombreCategoria", "PuntuacionPromedio", "Visible" },
                values: new object[,]
                {
                    { 1, "Platos deliciosos de carne", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(4941), "https://ik.imagekit.io/Mariocanizares/carne.webp?updatedAt=1726218723472", "Carnes", 4.5m, true },
                    { 2, "Platos variados con arroz", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5003), "https://ik.imagekit.io/Mariocanizares/arroz.png?updatedAt=1726218452623", "Arroces", 4.8m, true },
                    { 3, "Guisos tradicionales y caseros", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5007), "https://ik.imagekit.io/Mariocanizares/guisos.png?updatedAt=1726218800757", "Guisos", 4.7m, true },
                    { 4, "Platos exquisitos de mariscos", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5011), "https://ik.imagekit.io/Mariocanizares/marisco.webp?updatedAt=1726218800789", "Mariscos", 4.6m, true },
                    { 5, "Platos frescos de pescados", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5014), "https://ik.imagekit.io/Mariocanizares/pescado.png?updatedAt=1726218801946", "Pescados", 4.7m, true },
                    { 6, "Platos deliciosos de pasta", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5017), "https://ik.imagekit.io/Mariocanizares/pasta.png?updatedAt=1726218800772", "Pastas", 4.5m, true },
                    { 7, "Frescas y saludables ensaladas", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5020), "https://ik.imagekit.io/Mariocanizares/carne.webp?updatedAt=1726218723472", "Ensaladas", 4.6m, true },
                    { 8, "Reconfortantes sopas y cremas", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5022), "https://ik.imagekit.io/Mariocanizares/sopa.png?updatedAt=1726218800718f", "Sopas", 4.7m, true },
                    { 9, "Variedad de pizzas caseras", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5025), "https://ik.imagekit.io/Mariocanizares/pizza.png?updatedAt=1726218802077", "Pizzas", 4.8m, true },
                    { 10, "Creativos y deliciosos sandwiches", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5027), "https://ik.imagekit.io/Mariocanizares/sandwitches.png?updatedAt=1726218800723", "Sandwiches", 4.5m, true },
                    { 11, "Platos saludables de verduras", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5030), "https://ik.imagekit.io/Mariocanizares/verduras.png?updatedAt=1726218800742", "Verduras", 4.6m, true },
                    { 12, "Salsas para acompañar tus platos", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5032), "https://ik.imagekit.io/Mariocanizares/salsas.png?updatedAt=1726218800564", "Salsas", 4.7m, true },
                    { 13, "Dulces y sabrosos postres", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5034), "https://ik.imagekit.io/Mariocanizares/postres.png?updatedAt=1726218800753", "Postres", 4.8m, true },
                    { 14, "Bebidas refrescantes y cócteles", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5037), "https://ik.imagekit.io/Mariocanizares/bebidas.png?updatedAt=1726218678224", "Bebidas", 4.7m, true },
                    { 15, "Platos tradicionales de legumbres", new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5039), "https://ik.imagekit.io/Mariocanizares/legumbres.png?updatedAt=1726218800787", "Legumbres", 4.6m, true }
                });

            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "IdIngrediente", "Calorias", "ContieneAlergenos", "FechaExpiracion", "NombreIngrediente", "TipoAlergeno", "UnidadMedida" },
                values: new object[,]
                {
                    { 1, 15m, false, new DateTime(2024, 10, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5404), "Lechuga", "", "g" },
                    { 2, 130m, false, new DateTime(2025, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5416), "Arroz", "", "g" },
                    { 3, 2m, false, new DateTime(2025, 3, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5419), "Café", "", "ml" }
                });

            migrationBuilder.InsertData(
                table: "MenuSemanalRecetas",
                columns: new[] { "Fecha", "IdMenuSemanal", "IdReceta" },
                values: new object[,]
                {
                    { new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5499), 1, 1 },
                    { new DateTime(2024, 9, 14, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5502), 1, 2 },
                    { new DateTime(2024, 9, 15, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5505), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "MenusSemanales",
                columns: new[] { "IdMenuSemanal", "Descripcion", "FechaFin", "FechaInicio", "IdUsuario" },
                values: new object[] { 1, "Menú semanal de prueba", new DateTime(2024, 9, 20, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5477), new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5474), 1 });

            migrationBuilder.InsertData(
                table: "Recetas",
                columns: new[] { "IdReceta", "Descripcion", "EsVegano", "FechaCreacion", "IdCategoria", "Instrucciones", "NivelDificultad", "Nombre", "TiempoPreparacion" },
                values: new object[,]
                {
                    { 1, "Ensalada fresca con aderezo César", false, new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5331), 1, "Instrucciones para Ensalada César", 1m, "Ensalada César", 20 },
                    { 2, "Arroz tradicional español con mariscos", false, new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5335), 2, "Instrucciones para Paella", 2m, "Paella", 60 },
                    { 3, "Postre italiano con café y mascarpone", false, new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5340), 3, "Instrucciones para Tiramisú", 3m, "Tiramisú", 30 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Contraseña", "Email", "EsAdmin", "FechaRegistro", "Nombre" },
                values: new object[] { 1, "password", "john.doe@example.com", false, new DateTime(2024, 9, 13, 11, 20, 37, 817, DateTimeKind.Local).AddTicks(5457), "John Doe" });

            migrationBuilder.InsertData(
                table: "RecetaIngredientes",
                columns: new[] { "IdIngrediente", "IdReceta", "Cantidad", "EsOpcional", "FechaAñadido", "Notas" },
                values: new object[,]
                {
                    { 1, 1, 100m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { 2, 2, 200m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" },
                    { 3, 3, 50m, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_IdIngrediente",
                table: "RecetaIngredientes",
                column: "IdIngrediente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "MenuSemanalRecetas");

            migrationBuilder.DropTable(
                name: "MenusSemanales");

            migrationBuilder.DropTable(
                name: "RecetaIngredientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Recetas");
        }
    }
}
