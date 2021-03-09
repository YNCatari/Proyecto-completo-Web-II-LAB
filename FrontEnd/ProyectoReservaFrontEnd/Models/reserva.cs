namespace ProyectoReservaFrontEnd.Models
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

        public void GuardarReserva()
        {
            try
            {
                using (var db = new ModelHotel())
                {
                    if (this.idreserva > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public reserva ObtenerReserva(int idcliente = 0, int idhabitacion =0 , string fechaing = "")
        {
            var ayucliente = new reserva();
            try
            {
                using (var db = new ModelHotel())
                {
                    //ayucliente = db.reserva.Include("cliente").Where(x => x.idreserva == id).SingleOrDefault();
                    ayucliente = db.reserva.Include("cliente").Where(x => x.idcliente == idcliente && x.idhabitacion == idhabitacion && x.fecha_ingreso == Convert.ToDateTime(fechaing)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ayucliente;
        }

        public reserva Obtener(int id = 0)
        {
            var ayucliente = new reserva();
            try
            {
                using (var db = new ModelHotel())
                {
                    ayucliente = db.reserva.Include("habitacion").Include("trabajador").Include("cliente").Where(x => x.idreserva == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ayucliente;
        }
    }
}
