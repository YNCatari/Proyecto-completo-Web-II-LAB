namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelHotel : DbContext
    {
        public ModelHotel()
            : base("name=ModelHotel1")
        {
        }

        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<consumo> consumo { get; set; }
        public virtual DbSet<habitacion> habitacion { get; set; }
        public virtual DbSet<pago> pago { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<reportes> reportes { get; set; }
        public virtual DbSet<reserva> reserva { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tipo_habitacion> tipo_habitacion { get; set; }
        public virtual DbSet<tipo_trabajador> tipo_trabajador { get; set; }
        public virtual DbSet<trabajador> trabajador { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cliente>()
                .Property(e => e.tipo_documento)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.numero_documento)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.reserva)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<consumo>()
                .Property(e => e.cantidad)
                .HasPrecision(7, 2);

            modelBuilder.Entity<consumo>()
                .Property(e => e.precio_venta)
                .HasPrecision(7, 2);

            modelBuilder.Entity<consumo>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<habitacion>()
                .Property(e => e.numero)
                .IsUnicode(false);

            modelBuilder.Entity<habitacion>()
                .Property(e => e.piso)
                .IsUnicode(false);

            modelBuilder.Entity<habitacion>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<habitacion>()
                .Property(e => e.caracteristicas)
                .IsUnicode(false);

            modelBuilder.Entity<habitacion>()
                .Property(e => e.precio_diario)
                .HasPrecision(7, 2);

            modelBuilder.Entity<habitacion>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<habitacion>()
                .HasMany(e => e.reserva)
                .WithRequired(e => e.habitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pago>()
                .Property(e => e.tipo_comprobante)
                .IsUnicode(false);

            modelBuilder.Entity<pago>()
                .Property(e => e.num_comprobante)
                .IsUnicode(false);

            modelBuilder.Entity<pago>()
                .Property(e => e.igv)
                .HasPrecision(4, 2);

            modelBuilder.Entity<pago>()
                .Property(e => e.total_pago)
                .HasPrecision(9, 2);

            modelBuilder.Entity<pago>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<pago>()
                .HasMany(e => e.reportes)
                .WithRequired(e => e.pago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.precio)
                .HasPrecision(7, 2);

            modelBuilder.Entity<producto>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .HasMany(e => e.consumo)
                .WithRequired(e => e.producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reserva>()
                .Property(e => e.tipo_reserva)
                .IsUnicode(false);

            modelBuilder.Entity<reserva>()
                .Property(e => e.costo_alojamiento)
                .HasPrecision(7, 2);

            modelBuilder.Entity<reserva>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<reserva>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<reserva>()
                .HasMany(e => e.consumo)
                .WithRequired(e => e.reserva)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reserva>()
                .HasMany(e => e.pago)
                .WithRequired(e => e.reserva)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo_habitacion>()
                .HasMany(e => e.habitacion)
                .WithRequired(e => e.tipo_habitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo_trabajador>()
                .HasMany(e => e.trabajador)
                .WithRequired(e => e.tipo_trabajador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.tipo_documento)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.numero_documento)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.sueldo)
                .HasPrecision(7, 2);

            //modelBuilder.Entity<trabajador>()
            //    .Property(e => e.cargo)
            //    .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<trabajador>()
                .HasMany(e => e.reserva)
                .WithRequired(e => e.trabajador)
                .WillCascadeOnDelete(false);
        }
    }
}
