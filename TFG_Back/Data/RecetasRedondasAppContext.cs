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
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Paso> Pasos { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngredientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<RecetasPaso> recetasPasos { get; set; }
        public DbSet<Alergeno> Alergenos { get; set; }
        public DbSet<UsuarioCategoria> UsuarioCategorias { get; set; }
        public DbSet<Votacion> Votaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de claves primarias
            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Ingrediente>().HasKey(i => i.IdIngrediente);
            modelBuilder.Entity<MenuSemanal>().HasKey(ms => ms.IdMenuSemanal);
            modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
            modelBuilder.Entity<Receta>().HasKey(r => r.IdReceta);
            modelBuilder.Entity<Paso>().HasKey(p => p.IdPaso);
            modelBuilder.Entity<RecetaIngrediente>().HasKey(ri => ri.IdRecetaIngrediente);
            modelBuilder.Entity<Favorito>().HasKey(f => f.IdFavorito);
            modelBuilder.Entity<Alergeno>().HasKey(a => a.IdAlergeno);
            modelBuilder.Entity<UsuarioCategoria>().HasKey(uc => uc.IdUsuarioCategoria);
            modelBuilder.Entity<Votacion>().HasKey(v => v.Id);
            modelBuilder.Entity<Comentario>().HasKey(c => c.Id);


            // Definir la relación muchos a muchos entre Usuario e Ingrediente

            modelBuilder.Entity<Alergeno>()
                .HasOne(a => a.Usuarios)
                .WithMany(u => u.Alergenos)
                .HasForeignKey(au => au.IdUsuario);

            modelBuilder.Entity<Alergeno>()
                .HasOne(a => a.Ingredientes)
                .WithMany(i => i.Alergenos)
                .HasForeignKey(a => a.IdIngrediente);



            modelBuilder.Entity<RecetaIngrediente>()
                .HasOne(ri => ri.Receta)
                .WithMany(r => r.recetaIngredientes) 
                .HasForeignKey(ri => ri.IdReceta);

            modelBuilder.Entity<RecetaIngrediente>()
                .HasOne(ri => ri.Ingrediente)
                .WithMany(i => i.recetaIngredientes)  
                .HasForeignKey(ri => ri.IdIngrediente);

            // Configuración de relaciones
            modelBuilder.Entity<Receta>()
                .HasMany(r => r.Pasos)
                .WithOne(p => p.Receta)
                .HasForeignKey(p => p.IdReceta); 

            // Configuración para RecetasPaso
            modelBuilder.Entity<RecetasPaso>()
                .HasKey(rp => new { rp.IdReceta, rp.IdPaso });

            // Relación entre RecetasPaso y Receta
            modelBuilder.Entity<RecetasPaso>()
                .HasOne(rp => rp.Receta)
                .WithMany() 
                .HasForeignKey(rp => rp.IdReceta)
                .OnDelete(DeleteBehavior.Restrict);  

            // Relación entre RecetasPaso y Paso
            modelBuilder.Entity<RecetasPaso>()
                .HasOne(rp => rp.Paso)
                .WithMany() 
                .HasForeignKey(rp => rp.IdPaso)
                .OnDelete(DeleteBehavior.Restrict); 

            // Relación Favorito
            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Usuario)
                .WithMany(u => u.Favoritos)
                .HasForeignKey(f => f.IdUsuario);

            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Receta)
                .WithMany()
                .HasForeignKey(f => f.IdReceta);


            // Relación entre MenuSemanal y Receta
            modelBuilder.Entity<MenuSemanal>()
                .HasOne(m => m.Receta)             
                .WithMany()                         
                .HasForeignKey(m => m.IdReceta)      
                .OnDelete(DeleteBehavior.Cascade);   

            // Relación entre MenuSemanal y Usuario
            modelBuilder.Entity<MenuSemanal>()
                .HasOne(m => m.Usuario)              
                .WithMany()                          
                .HasForeignKey(m => m.IdUsuario)     
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relación entre Usuario y UsuarioCategoria

            modelBuilder.Entity<UsuarioCategoria>()
                .HasOne(uc => uc.Usuario)
                .WithMany(u => u.UsuarioCategorias) 
                .HasForeignKey(uc => uc.IdUsuario); 

            modelBuilder.Entity<UsuarioCategoria>()
                .HasOne(uc => uc.Categoria) 
                .WithMany(c => c.UsuarioCategorias) 
                .HasForeignKey(uc => uc.IdCategoria); 

            //Votacion
            modelBuilder.Entity<Votacion>()
                .HasOne(v => v.Usuario)
                .WithMany(u => u.Votaciones)
                .HasForeignKey(v => v.UsuarioId);

            modelBuilder.Entity<Votacion>()
                .HasOne(v => v.Receta)
                .WithMany(r => r.Votaciones)
                .HasForeignKey(v => v.RecetaId);

            //Comentarios
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Receta)
                .WithMany(r => r.Comentarios)
                .HasForeignKey(c => c.RecetaId);
            // Datos de ejemplo (se pueden ajustar según sea necesario)
            
            modelBuilder.Entity<Categoria>().HasData(
     new Categoria { IdCategoria = 1, NombreCategoria = "Carnes", Descripcion = "Platos deliciosos de carne", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/carne.webp?updatedAt=1726218723472", Puntuacion = 4.5m },
     new Categoria { IdCategoria = 2, NombreCategoria = "Arroces", Descripcion = "Platos variados con arroz", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/arroz.png?updatedAt=1726218452623", Puntuacion = 4.8m },
    new Categoria { IdCategoria = 3, NombreCategoria = "Guisos", Descripcion = "Guisos tradicionales y caseros", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/guisos.png?updatedAt=1726218800757", Puntuacion = 4.7m },
    new Categoria { IdCategoria = 4, NombreCategoria = "Mariscos", Descripcion = "Platos exquisitos de mariscos", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/marisco.webp?updatedAt=1726218800789", Puntuacion = 4.6m },
    new Categoria { IdCategoria = 5, NombreCategoria = "Pescados", Descripcion = "Platos frescos de pescados", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/pescado.png?updatedAt=1726218801946", Puntuacion = 4.7m },
    new Categoria { IdCategoria = 6, NombreCategoria = "Pastas", Descripcion = "Platos deliciosos de pasta", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/pasta.png?updatedAt=1726218800772", Puntuacion = 4.5m },
    new Categoria { IdCategoria = 7, NombreCategoria = "Ensaladas", Descripcion = "Frescas y saludables ensaladas", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/carne.webp?updatedAt=1726218723472", Puntuacion = 4.6m },
    new Categoria { IdCategoria = 8, NombreCategoria = "Sopas", Descripcion = "Reconfortantes sopas y cremas", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/sopa.png?updatedAt=1726218800718f", Puntuacion = 4.7m },
    new Categoria { IdCategoria = 9, NombreCategoria = "Pizzas", Descripcion = "Variedad de pizzas caseras", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/pizza.png?updatedAt=1726218802077", Puntuacion = 4.8m },
    new Categoria { IdCategoria = 10, NombreCategoria = "Sandwiches", Descripcion = "Creativos y deliciosos sandwiches", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/sandwitches.png?updatedAt=1726218800723", Puntuacion = 4.5m },
    new Categoria { IdCategoria = 11, NombreCategoria = "Verduras", Descripcion = "Platos saludables de verduras", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/verduras.png?updatedAt=1726218800742", Puntuacion = 4.6m },
    new Categoria { IdCategoria = 12, NombreCategoria = "Salsas", Descripcion = "Salsas para acompañar tus platos", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/salsas.png?updatedAt=1726218800564", Puntuacion = 4.7m },
    new Categoria { IdCategoria = 13, NombreCategoria = "Postres", Descripcion = "Dulces y sabrosos postres", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/postres.png?updatedAt=1726218800753", Puntuacion = 4.8m },
    new Categoria { IdCategoria = 14, NombreCategoria = "Bebidas", Descripcion = "Bebidas refrescantes y cócteles", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/bebidas.png?updatedAt=1726218678224", Puntuacion = 4.7m },
    new Categoria { IdCategoria = 15, NombreCategoria = "Legumbres", Descripcion = "Platos tradicionales de legumbres", Especial = false, FechaCreacion = DateTime.Now, Icono = "https://ik.imagekit.io/Mariocanizares/legumbres.png?updatedAt=1726218800787", Puntuacion = 4.6m }
);

            modelBuilder.Entity<Receta>().HasData(
  new Receta { IdReceta = 1, Nombre = "Ensalada César", IdCategoria = 1, Descripcion = "Ensalada fresca con aderezo César", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/ensalada.jpg?updatedAt=1727169325456", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = false, TiempoPreparacion = 20 },
  new Receta { IdReceta = 2, Nombre = "Paella", IdCategoria = 2, Descripcion = "Arroz tradicional español con mariscos", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/arroz-marisco.jpg?updatedAt=1727169389258", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 60 },
  new Receta { IdReceta = 3, Nombre = "Tiramisú", IdCategoria = 3, Descripcion = "Postre italiano con café y mascarpone", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/tiramisu.jpg?updatedAt=1727169422091", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 30 },
  new Receta { IdReceta = 4, Nombre = "Pasta Carbonara", IdCategoria = 4, Descripcion = "Pasta con salsa cremosa de huevo y panceta", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/carbonara.jpg?updatedAt=1727169452310", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 25 },
  new Receta { IdReceta = 5, Nombre = "Sushi", IdCategoria = 5, Descripcion = "Rollos de arroz y pescado crudo", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/sushi.jpg?updatedAt=1727169470676", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 50 },
  new Receta { IdReceta = 6, Nombre = "Pizza Margherita", IdCategoria = 6, Descripcion = "Pizza clásica con tomate, mozzarella y albahaca", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/pizza.jpg?updatedAt=1727169491728", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 40 },
  new Receta { IdReceta = 7, Nombre = "Guacamole", IdCategoria = 1, Descripcion = "Aguacate triturado con cebolla, tomate y limón", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/guacamole.jpg?updatedAt=1727169511551", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = true, TiempoPreparacion = 10 },
  new Receta { IdReceta = 8, Nombre = "Lasaña", IdCategoria = 4, Descripcion = "Capas de pasta, carne y salsa de tomate", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/lasagna.jpg?updatedAt=1727169528673", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 90 },
  new Receta { IdReceta = 9, Nombre = "Tacos de Pollo", IdCategoria = 2, Descripcion = "Tacos rellenos de pollo, cebolla y cilantro", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/tacos.jpg?updatedAt=1727169541523", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 30 },
  new Receta { IdReceta = 10, Nombre = "Brownies", IdCategoria = 3, Descripcion = "Deliciosos brownies de chocolate", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/brownies.jpg?updatedAt=1727169556237", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 45 },
  new Receta { IdReceta = 11, Nombre = "Sopa de Lentejas", IdCategoria = 1, Descripcion = "Sopa nutritiva de lentejas", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/lentejas.jpg?updatedAt=1727169570913", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = true, TiempoPreparacion = 35 },
  new Receta { IdReceta = 12, Nombre = "Chili con Carne", IdCategoria = 2, Descripcion = "Guiso picante de carne y frijoles", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/chili.jpg?updatedAt=1727169584071", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 50 },
  new Receta { IdReceta = 13, Nombre = "Baba Ganoush", IdCategoria = 1, Descripcion = "Dip de berenjena asada", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/baba-ganoush.jpg?updatedAt=1727169596850", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = true, TiempoPreparacion = 20 },
  new Receta { IdReceta = 14, Nombre = "Crepes", IdCategoria = 3, Descripcion = "Deliciosos crepes dulces o salados", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/crepes.jpg?updatedAt=1727169607858", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 30 },
  new Receta { IdReceta = 15, Nombre = "Pollo al Curry", IdCategoria = 2, Descripcion = "Pollo cocido en salsa de curry", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/pollo-curry.jpg?updatedAt=1727169619493", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 40 },
  new Receta { IdReceta = 16, Nombre = "Galletas de Chocolate", IdCategoria = 3, Descripcion = "Galletas crujientes de chocolate", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/galletas-chocolate.jpg?updatedAt=1727169630571", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = false, TiempoPreparacion = 25 },
  new Receta { IdReceta = 17, Nombre = "Quiche de Verduras", IdCategoria = 4, Descripcion = "Tarta salada con verduras y queso", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/quiche.jpg?updatedAt=1727169642129", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 50 },
  new Receta { IdReceta = 18, Nombre = "Muffins de Arándano", IdCategoria = 3, Descripcion = "Muffins esponjosos con arándanos", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/muffins.jpg?updatedAt=1727169653441", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 35 },
  new Receta { IdReceta = 19, Nombre = "Batido Verde", IdCategoria = 1, Descripcion = "Batido saludable de espinacas y plátano", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/batido-verde.jpg?updatedAt=1727169666491", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = true, TiempoPreparacion = 15 },
  new Receta { IdReceta = 20, Nombre = "Salmón al Horno", IdCategoria = 2, Descripcion = "Salmón asado con hierbas", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/salmon.jpg?updatedAt=1727169677362", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 30 },
  new Receta { IdReceta = 21, Nombre = "Pancakes", IdCategoria = 3, Descripcion = "Pancakes esponjosos con jarabe de arce", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/pancakes.jpg?updatedAt=1727169687612", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = false, TiempoPreparacion = 20 },
  new Receta { IdReceta = 22, Nombre = "Gazpacho", IdCategoria = 1, Descripcion = "Sopa fría de tomate", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/gazpacho.jpg?updatedAt=1727169697098", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = true, TiempoPreparacion = 15, TemaCocina = "Verano" },
  new Receta { IdReceta = 23, Nombre = "Croquetas", IdCategoria = 4, Descripcion = "Bolas fritas rellenas de bechamel", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/croquetas.jpg?updatedAt=1727169707360", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 45 },
  new Receta { IdReceta = 24, Nombre = "Pudín de Chía", IdCategoria = 3, Descripcion = "Pudín saludable con semillas de chía", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/pudin-chia.jpg?updatedAt=1727169717454", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = true, TiempoPreparacion = 15 },
  new Receta { IdReceta = 25, Nombre = "Ceviche", IdCategoria = 2, Descripcion = "Pescado marinado en jugo de limón", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/ceviche.jpg?updatedAt=1727169726708", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 30 },
  new Receta { IdReceta = 26, Nombre = "Huevos Rancheros", IdCategoria = 4, Descripcion = "Huevos con salsa de tomate y frijoles", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/huevos-rancheros.jpg?updatedAt=1727169737304", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = false, TiempoPreparacion = 25 },
  new Receta { IdReceta = 27, Nombre = "Pimientos Rellenos", IdCategoria = 4, Descripcion = "Pimientos rellenos de carne y arroz", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/pimientos-rellenos.jpg?updatedAt=1727169746992", FechaCreacion = DateTime.Now, NivelDificultad = 3, EsVegano = false, TiempoPreparacion = 50 },
  new Receta { IdReceta = 28, Nombre = "Zanahorias Asadas", IdCategoria = 1, Descripcion = "Zanahorias asadas con miel y especias", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/zanahorias.jpg?updatedAt=1727169756553", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = true, TiempoPreparacion = 30 },
  new Receta { IdReceta = 29, Nombre = "Pasta al Pesto", IdCategoria = 4, Descripcion = "Pasta con salsa pesto fresca", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/pasta-pesto.jpg?updatedAt=1727169765990", FechaCreacion = DateTime.Now, NivelDificultad = 2, EsVegano = true, TiempoPreparacion = 20 },
  new Receta { IdReceta = 30, Nombre = "Batido de Fresa", IdCategoria = 1, Descripcion = "Batido refrescante de fresa", Imagen = "https://ik.imagekit.io/Mariocanizares/Recetas/batido-fresa.jpg?updatedAt=1727169775184", FechaCreacion = DateTime.Now, NivelDificultad = 1, EsVegano = true, TiempoPreparacion = 10 }
);
            modelBuilder.Entity<Ingrediente>().HasData(
    new Ingrediente { IdIngrediente = 1, NombreIngrediente = "Lechuga", Calorias = 15, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(1) },
    new Ingrediente { IdIngrediente = 2, NombreIngrediente = "Tomate", Calorias = 18, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(1) },
    new Ingrediente { IdIngrediente = 3, NombreIngrediente = "Queso", Calorias = 300, ContieneAlergenos = true, TipoAlergeno = "Lactosa", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddDays(10) },
    new Ingrediente { IdIngrediente = 4, NombreIngrediente = "Pan", Calorias = 265, ContieneAlergenos = true, TipoAlergeno = "Gluten", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddDays(5) },
    new Ingrediente { IdIngrediente = 5, NombreIngrediente = "Pollo", Calorias = 239, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddDays(3) },
    new Ingrediente { IdIngrediente = 6, NombreIngrediente = "Huevo", Calorias = 155, ContieneAlergenos = true, TipoAlergeno = "Huevo", UnidadMedida = "unidad", FechaExpiracion = DateTime.Now.AddDays(7) },
    new Ingrediente { IdIngrediente = 7, NombreIngrediente = "Pimiento", Calorias = 20, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(1) },
    new Ingrediente { IdIngrediente = 8, NombreIngrediente = "Aceite de oliva", Calorias = 884, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "ml", FechaExpiracion = DateTime.Now.AddMonths(6) },
    new Ingrediente { IdIngrediente = 9, NombreIngrediente = "Azúcar", Calorias = 387, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddYears(1) },
    new Ingrediente { IdIngrediente = 10, NombreIngrediente = "Sal", Calorias = 0, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddYears(2) },
    new Ingrediente { IdIngrediente = 11, NombreIngrediente = "Harina", Calorias = 364, ContieneAlergenos = true, TipoAlergeno = "Gluten", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(3) },
    new Ingrediente { IdIngrediente = 12, NombreIngrediente = "Leche", Calorias = 42, ContieneAlergenos = true, TipoAlergeno = "Lactosa", UnidadMedida = "ml", FechaExpiracion = DateTime.Now.AddDays(5) },
    new Ingrediente { IdIngrediente = 13, NombreIngrediente = "Mantequilla", Calorias = 717, ContieneAlergenos = true, TipoAlergeno = "Lactosa", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddDays(15) },
    new Ingrediente { IdIngrediente = 14, NombreIngrediente = "Cebolla", Calorias = 40, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(1) },
    new Ingrediente { IdIngrediente = 15, NombreIngrediente = "Ajo", Calorias = 149, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(2) },
    new Ingrediente { IdIngrediente = 16, NombreIngrediente = "Perejil", Calorias = 36, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(1) },
    new Ingrediente { IdIngrediente = 17, NombreIngrediente = "Pimienta negra", Calorias = 251, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddYears(2) },
    new Ingrediente { IdIngrediente = 18, NombreIngrediente = "Orégano", Calorias = 306, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddYears(2) },
    new Ingrediente { IdIngrediente = 19, NombreIngrediente = "Vino tinto", Calorias = 85, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "ml", FechaExpiracion = DateTime.Now.AddMonths(12) },
    new Ingrediente { IdIngrediente = 20, NombreIngrediente = "Miel", Calorias = 304, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddYears(3) },
    new Ingrediente { IdIngrediente = 21, NombreIngrediente = "Almendras", Calorias = 575, ContieneAlergenos = true, TipoAlergeno = "Frutos secos", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(6) },
    new Ingrediente { IdIngrediente = 22, NombreIngrediente = "Chocolate", Calorias = 546, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(4) },
    new Ingrediente { IdIngrediente = 23, NombreIngrediente = "Manzana", Calorias = 52, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddMonths(1) },
    new Ingrediente { IdIngrediente = 24, NombreIngrediente = "Nuez moscada", Calorias = 525, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddYears(1) },
    new Ingrediente { IdIngrediente = 25, NombreIngrediente = "Espinacas", Calorias = 23, ContieneAlergenos = false, TipoAlergeno = "", UnidadMedida = "g", FechaExpiracion = DateTime.Now.AddDays(7) }
            );



            modelBuilder.Entity<RecetaIngrediente>().HasData(
    new RecetaIngrediente { IdRecetaIngrediente = 1, IdReceta = 1, IdIngrediente = 1, }, // Lechuga para Ensalada César
    new RecetaIngrediente { IdRecetaIngrediente = 2, IdReceta = 1, IdIngrediente = 2, }, // Queso parmesano
    new RecetaIngrediente { IdRecetaIngrediente = 3, IdReceta = 1, IdIngrediente = 3, }, // Aderezo César
    new RecetaIngrediente { IdRecetaIngrediente = 4, IdReceta = 2, IdIngrediente = 4,  }, // Arroz para Paella
    new RecetaIngrediente { IdRecetaIngrediente = 5, IdReceta = 2, IdIngrediente = 5, }, // Mariscos
    new RecetaIngrediente { IdRecetaIngrediente = 6, IdReceta = 2, IdIngrediente = 6,  }, // Azafrán
    new RecetaIngrediente { IdRecetaIngrediente = 7, IdReceta = 3, IdIngrediente = 7, }, // Mascarpone para Tiramisú
    new RecetaIngrediente { IdRecetaIngrediente = 8, IdReceta = 3, IdIngrediente = 8, }, // Café
    new RecetaIngrediente { IdRecetaIngrediente = 9, IdReceta = 3, IdIngrediente = 9,  }, // Cacao en polvo
    new RecetaIngrediente { IdRecetaIngrediente = 10, IdReceta = 4, IdIngrediente = 10,  }, // Pasta
    new RecetaIngrediente { IdRecetaIngrediente = 11, IdReceta = 4, IdIngrediente = 11, }, // Panceta
    new RecetaIngrediente { IdRecetaIngrediente = 12, IdReceta = 5, IdIngrediente = 12,  }, // Arroz para Sushi
    new RecetaIngrediente { IdRecetaIngrediente = 13, IdReceta = 5, IdIngrediente = 13}, // Pescado crudo
    new RecetaIngrediente { IdRecetaIngrediente = 14, IdReceta = 6, IdIngrediente = 14,  }, // Masa de pizza para Pizza Margherita
    new RecetaIngrediente { IdRecetaIngrediente = 15, IdReceta = 6, IdIngrediente = 15, }, // Mozzarella
    new RecetaIngrediente { IdRecetaIngrediente = 16, IdReceta = 6, IdIngrediente = 16,}, // Albahaca
    new RecetaIngrediente { IdRecetaIngrediente = 17, IdReceta = 7, IdIngrediente = 17 }, // Aguacate para Guacamole
    new RecetaIngrediente { IdRecetaIngrediente = 18, IdReceta = 7, IdIngrediente = 18,  }, // Tomate
    new RecetaIngrediente { IdRecetaIngrediente = 19, IdReceta = 7, IdIngrediente = 19,  }, // Jugo de limón
    new RecetaIngrediente { IdRecetaIngrediente = 20, IdReceta = 8, IdIngrediente = 20,  }, // Carne molida para Lasaña
    new RecetaIngrediente { IdRecetaIngrediente = 21, IdReceta = 8, IdIngrediente = 21, }, // Queso ricotta
    new RecetaIngrediente { IdRecetaIngrediente = 22, IdReceta = 9, IdIngrediente = 22,  }, // Pollo para Tacos de Pollo
    new RecetaIngrediente { IdRecetaIngrediente = 23, IdReceta = 9, IdIngrediente = 23,  }, // Cilantro
    new RecetaIngrediente { IdRecetaIngrediente = 24, IdReceta = 10, IdIngrediente = 24,  }, // Chocolate para Brownies
    new RecetaIngrediente { IdRecetaIngrediente = 25, IdReceta = 10, IdIngrediente = 25,  } // Harina
    // Añade más ingredientes y recetas según sea necesario.
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

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { IdUsuario = 1, Nombre = "Admin", Correo = "mario@gmail.com", Contrasena = "MarioX8", FechaRegistro = DateTime.Now, Rol = true }
            );
        }
    }
}
