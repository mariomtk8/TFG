using Microsoft.EntityFrameworkCore;
using System;

namespace RecetasRedondas.Models
{
    public class RecetasRedondasAppContext : DbContext
    {
        public RecetasRedondasAppContext(DbContextOptions<RecetasRedondasAppContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<MenuSemanal> MenusSemanales { get; set; }
        public DbSet<MenuSemanalReceta> MenuSemanalRecetas { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Paso> Pasos { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngredientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de claves primarias
            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.IdCategoria);

            modelBuilder.Entity<Ingrediente>()
                .HasKey(i => i.IdIngrediente);

            modelBuilder.Entity<MenuSemanal>()
                .HasKey(ms => ms.IdMenuSemanal);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario);

            modelBuilder.Entity<Receta>()
                .HasKey(r => r.IdReceta);

            // Configuración de relaciones muchos a muchos
            modelBuilder.Entity<MenuSemanalReceta>()
                .HasKey(msr => new { msr.IdMenuSemanal, msr.IdReceta, msr.Fecha });

            modelBuilder.Entity<RecetaIngrediente>()
                .HasKey(ri => new { ri.IdReceta, ri.IdIngrediente });

            modelBuilder.Entity<RecetaIngrediente>()
                .HasOne<Receta>()
                .WithMany()
                .HasForeignKey(ri => ri.IdReceta);

            modelBuilder.Entity<RecetaIngrediente>()
                .HasOne<Ingrediente>()
                .WithMany()
                .HasForeignKey(ri => ri.IdIngrediente);
            
             modelBuilder.Entity<Paso>()
        .HasKey(p => p.IdPaso); // Clave primaria para Paso

    // Configuración de relaciones
    modelBuilder.Entity<Receta>()
        .HasMany(r => r.Pasos)
        .WithOne(p => p.Receta) // Relación uno a muchos
        .HasForeignKey(p => p.IdReceta) // Establecer clave foránea
        .OnDelete(DeleteBehavior.Cascade);

            // Datos de ejemplo (se pueden ajustar según sea necesario)
            modelBuilder.Entity<Categoria>().HasData(
    new Categoria { IdCategoria = 1, NombreCategoria = "Carnes", Descripcion = "Platos deliciosos de carne", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/carne.webp?updatedAt=1726218723472", PuntuacionPromedio = 4.5m },
    new Categoria { IdCategoria = 2, NombreCategoria = "Arroces", Descripcion = "Platos variados con arroz", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/arroz.png?updatedAt=1726218452623", PuntuacionPromedio = 4.8m },
    new Categoria { IdCategoria = 3, NombreCategoria = "Guisos", Descripcion = "Guisos tradicionales y caseros", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/guisos.png?updatedAt=1726218800757", PuntuacionPromedio = 4.7m },
    new Categoria { IdCategoria = 4, NombreCategoria = "Mariscos", Descripcion = "Platos exquisitos de mariscos", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/marisco.webp?updatedAt=1726218800789", PuntuacionPromedio = 4.6m },
    new Categoria { IdCategoria = 5, NombreCategoria = "Pescados", Descripcion = "Platos frescos de pescados", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/pescado.png?updatedAt=1726218801946", PuntuacionPromedio = 4.7m },
    new Categoria { IdCategoria = 6, NombreCategoria = "Pastas", Descripcion = "Platos deliciosos de pasta", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/pasta.png?updatedAt=1726218800772", PuntuacionPromedio = 4.5m },
    new Categoria { IdCategoria = 7, NombreCategoria = "Ensaladas", Descripcion = "Frescas y saludables ensaladas", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/carne.webp?updatedAt=1726218723472", PuntuacionPromedio = 4.6m },
    new Categoria { IdCategoria = 8, NombreCategoria = "Sopas", Descripcion = "Reconfortantes sopas y cremas", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/sopa.png?updatedAt=1726218800718f", PuntuacionPromedio = 4.7m },
    new Categoria { IdCategoria = 9, NombreCategoria = "Pizzas", Descripcion = "Variedad de pizzas caseras", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/pizza.png?updatedAt=1726218802077", PuntuacionPromedio = 4.8m },
    new Categoria { IdCategoria = 10, NombreCategoria = "Sandwiches", Descripcion = "Creativos y deliciosos sandwiches", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/sandwitches.png?updatedAt=1726218800723", PuntuacionPromedio = 4.5m },
    new Categoria { IdCategoria = 11, NombreCategoria = "Verduras", Descripcion = "Platos saludables de verduras", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/verduras.png?updatedAt=1726218800742", PuntuacionPromedio = 4.6m },
    new Categoria { IdCategoria = 12, NombreCategoria = "Salsas", Descripcion = "Salsas para acompañar tus platos", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/salsas.png?updatedAt=1726218800564", PuntuacionPromedio = 4.7m },
    new Categoria { IdCategoria = 13, NombreCategoria = "Postres", Descripcion = "Dulces y sabrosos postres", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/postres.png?updatedAt=1726218800753", PuntuacionPromedio = 4.8m },
    new Categoria { IdCategoria = 14, NombreCategoria = "Bebidas", Descripcion = "Bebidas refrescantes y cócteles", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/bebidas.png?updatedAt=1726218678224", PuntuacionPromedio = 4.7m },
    new Categoria { IdCategoria = 15, NombreCategoria = "Legumbres", Descripcion = "Platos tradicionales de legumbres", Visible = true, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/legumbres.png?updatedAt=1726218800787", PuntuacionPromedio = 4.6m }
);

              modelBuilder.Entity<Receta>().HasData(
                new Receta { IdReceta = 1, Nombre = "Ensalada César", IdCategoria = 1, Descripcion = "Ensalada fresca con aderezo César", Imagen ="https://ik.imagekit.io/Mariocanizares/Recetas/ensalada.jpg?updatedAt=1727169325456", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = false, TiempoPreparacion = 20 },
                new Receta { IdReceta = 2, Nombre = "Paella", IdCategoria = 2, Descripcion = "Arroz tradicional español con mariscos", Imagen ="https://ik.imagekit.io/Mariocanizares/Recetas/arroz-marisco.jpg?updatedAt=1727169389258", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 60 },
                new Receta { IdReceta = 3, Nombre = "Tiramisú", IdCategoria = 3, Descripcion = "Postre italiano con café y mascarpone", Imagen ="https://ik.imagekit.io/Mariocanizares/Recetas/tiramisu.jpg?updatedAt=1727169422091", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 30 }
            );

            // Datos de ejemplo para pasos
            modelBuilder.Entity<Paso>().HasData(
                new Paso { IdPaso = 1, IdReceta = 1, Numero = 1, Descripcion = "Lavar y trocear la lechuga.", ImagenUrl = "https://ik.imagekit.io/Mariocanizares/Recetas/ensalada.jpg?updatedAt=1727169325456" },
                new Paso { IdPaso = 2, IdReceta = 1, Numero = 2, Descripcion = "Agregar el aderezo César y mezclar bien.", ImagenUrl = "https://example.com/imagen2.jpg" },
                new Paso { IdPaso = 3, IdReceta = 1, Numero = 3, Descripcion = "Servir y disfrutar.", ImagenUrl = "https://example.com/imagen3.jpg" },

                new Paso { IdPaso = 4, IdReceta = 2, Numero = 1, Descripcion = "Cocinar el arroz en caldo de pescado.", ImagenUrl = "https://ik.imagekit.io/Mariocanizares/Recetas/arroz-marisco.jpg?updatedAt=1727169389258" },
                new Paso { IdPaso = 5, IdReceta = 2, Numero = 2, Descripcion = "Agregar los mariscos y verduras.", ImagenUrl = "https://example.com/imagen5.jpg" },
                new Paso { IdPaso = 6, IdReceta = 2, Numero = 3, Descripcion = "Cocinar a fuego lento hasta que el arroz esté listo.", ImagenUrl = "https://example.com/imagen6.jpg" },

                new Paso { IdPaso = 7, IdReceta = 3, Numero = 1, Descripcion = "Preparar el café y dejar enfriar.", ImagenUrl = "https://ik.imagekit.io/Mariocanizares/Recetas/tiramisu.jpg?updatedAt=1727169422091" },
                new Paso { IdPaso = 8, IdReceta = 3, Numero = 2, Descripcion = "Mezclar el mascarpone con azúcar.", ImagenUrl = "https://example.com/imagen8.jpg" },
                new Paso { IdPaso = 9, IdReceta = 3, Numero = 3, Descripcion = "Montar los ingredientes en capas.", ImagenUrl = "https://example.com/imagen9.jpg" }
            );


            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente { IdIngrediente = 1, NombreIngrediente = "Lechuga", Calorias = 15, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(1) },
                new Ingrediente { IdIngrediente = 2, NombreIngrediente = "Arroz", Calorias = 130, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddYears(1) },
                new Ingrediente { IdIngrediente = 3, NombreIngrediente = "Café", Calorias = 2, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "ml", FechaExpiracion = DateTime.Now.AddMonths(6)}
            );

            modelBuilder.Entity<RecetaIngrediente>().HasData(
                new RecetaIngrediente { IdReceta = 1, IdIngrediente = 1, Cantidad = 100, EsOpcional = false, Notas = "" },
                new RecetaIngrediente { IdReceta = 2, IdIngrediente = 2, Cantidad = 200, EsOpcional = false, Notas = "" },
                new RecetaIngrediente { IdReceta = 3, IdIngrediente = 3, Cantidad = 50, EsOpcional = false, Notas = "" }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { IdUsuario = 1, Nombre = "John Doe", Email = "john.doe@example.com", Contraseña = "password", FechaRegistro = DateTime.Now, EsAdmin = false, }
            );

            modelBuilder.Entity<MenuSemanal>().HasData(
                new MenuSemanal { IdMenuSemanal = 1, IdUsuario = 1, FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(7), Descripcion = "Menú semanal de prueba" }
            );

            modelBuilder.Entity<MenuSemanalReceta>().HasData(
                new MenuSemanalReceta { IdMenuSemanal = 1, IdReceta = 1, Fecha = DateTime.Now },
                new MenuSemanalReceta { IdMenuSemanal = 1, IdReceta = 2, Fecha = DateTime.Now.AddDays(1) },
                new MenuSemanalReceta { IdMenuSemanal = 1, IdReceta = 3, Fecha = DateTime.Now.AddDays(2) }
            );
        }
    }
}
