namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("pago")]
    public partial class pago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pago()
        {
            reportes = new HashSet<reportes>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idpago { get; set; }

        public int idreserva { get; set; }

        [Required]
        [StringLength(20)]
        public string tipo_comprobante { get; set; }

        [Required]
        [StringLength(12)]
        public string num_comprobante { get; set; }

        public decimal igv { get; set; }

        public decimal total_pago { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_emision { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_pago { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual reserva reserva { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reportes> reportes { get; set; }

        public void Guardar()
        {
            try
            {
                using (var db = new ModelHotel())
                {
                    db.Entry(this).State = EntityState.Added; //nuevo registro
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<pago> ObtenerPago()
        {
            var pago = new List<pago>();
            try
            {
                using (var db = new ModelHotel())
                {
                    pago = db.pago.Include("reserva").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return pago;

        }
        public pago ObtenerPagoReserva(int id)
        {
            var pago = new pago();
            try
            {
                using (var db = new ModelHotel())
                {
                    pago = db.pago.Include("reserva").Where(x => x.idreserva == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return pago;
        }
    }
}
