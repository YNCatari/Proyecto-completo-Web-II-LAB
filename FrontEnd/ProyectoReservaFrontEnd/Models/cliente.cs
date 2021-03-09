namespace ProyectoReservaFrontEnd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            reserva = new HashSet<reserva>();
        }

        [Key]
        public int idcliente { get; set; }

        [Required]
        [StringLength(20)]
        public string tipo_documento { get; set; }

        [Required]
        [StringLength(20)]
        public string numero_documento { get; set; }

        [Required]
        [StringLength(40)]
        public string nombres { get; set; }

        [Required]
        [StringLength(40)]
        public string apellidos { get; set; }

        [Required]
        [StringLength(150)]
        public string direccion { get; set; }

        [Required]
        [StringLength(15)]
        public string telefono { get; set; }

        [Required]
        [StringLength(45)]
        public string email { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reserva { get; set; }


        //METODO Guardar
       
        public void Guardar()
        {
            try
            {
                using (var db = new ModelHotel())
                {
                    if (this.idcliente > 0)
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
        public cliente Obtener(int id=0)
        {
            var ayucliente = new cliente();
            try
            {
                using (var db = new ModelHotel())
                {
                    ayucliente = db.cliente.Where(x => x.numero_documento == id.ToString()).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ayucliente;
        }
        public cliente Obteneridcliente (int id = 0)
        {
            var ayucliente = new cliente();
            try
            {
                using (var db = new ModelHotel())
                {
                    ayucliente = db.cliente.Where(x => x.idcliente == id).SingleOrDefault();
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
