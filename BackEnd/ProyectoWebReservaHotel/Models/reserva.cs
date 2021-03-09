namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("reserva")]
    public partial class reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reserva()
        {
            consumo = new HashSet<consumo>();
            pago = new HashSet<pago>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idreserva { get; set; }

        public int idhabitacion { get; set; }

        public int idcliente { get; set; }

        public int idtrabajador { get; set; }

        [Required]
        [StringLength(30)]
        public string tipo_reserva { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_ingreso { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_salida { get; set; }

        public decimal costo_alojamiento { get; set; }

        [Required]
        [StringLength(255)]
        public string observacion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual cliente cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consumo> consumo { get; set; }

        public virtual habitacion habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pago> pago { get; set; }

        public virtual trabajador trabajador { get; set; }


        public List<reserva> Listar()
        {
            var habitacion = new List<reserva>();
            try
            {
                using (var db = new ModelHotel())
                {
                    habitacion = db.reserva.Include("habitacion").Include("trabajador").Include("cliente").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return habitacion;
        }

        public List<reserva> Buscar(string criterio)
        {
            var usuario = new List<reserva>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelHotel())
                {
                    usuario = db.reserva.Include("habitacion").Include("trabajador").Include("cliente")
                        .Where(x => x.tipo_reserva.Contains(criterio) /*||  x.costo_alojamiento == Convert.ToDecimal(criterio)*/ || x.estado == estado
                        || x.cliente.nombres.Contains(criterio) || x.trabajador.nombres.Contains(criterio)||x.habitacion.numero.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }

        public reserva Obtener(int id)
        {
            var habitacion = new reserva();
            try
            {
                using (var db = new ModelHotel())
                {
                    habitacion = db.reserva.Include("habitacion").Include("trabajador").Include("cliente").Where(x => x.idreserva == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return habitacion;
        }
        public void Guardar()
        {
            try
            {
                using (var db = new ModelHotel())
                {
                    if (this.idreserva > 0)
                    {
                        db.Entry(this).State = EntityState.Modified; //existe
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added; //nuevo registro
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //highchart
        public List<reserva> ObtenerReservas()
        {
            var habitacion = new List<reserva>();
            try
            {
                using (var db = new ModelHotel())
                {
                    habitacion = db.reserva.Include("habitacion").Include("trabajador").Include("cliente").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return habitacion;

        }
        public List<reserva> ListarReservasPorConfirmar()
        {
            var habitacion = new List<reserva>();
            try
            {
                using (var db = new ModelHotel())
                {
                    habitacion = db.reserva.Include("habitacion").Include("trabajador").Include("cliente").Where(x => x.estado == "2").Where(x => x.tipo_reserva == "Online")
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return habitacion;
        }
        public List<reserva> ListarReservasfinal()
        {
            var habitacion = new List<reserva>();
            try
            {
                using (var db = new ModelHotel())
                {
                    habitacion = db.reserva.Include("habitacion").Include("trabajador").Include("cliente").Where(x => x.tipo_reserva == "Presencial" || ((x.estado == "3"|| x.estado == "4"||x.estado == "5")&& x.tipo_reserva == "Online"))
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return habitacion;
        }
    }
}
