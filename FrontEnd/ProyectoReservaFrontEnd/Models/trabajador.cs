namespace ProyectoReservaFrontEnd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("trabajador")]
    public partial class trabajador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trabajador()
        {
            reserva = new HashSet<reserva>();
        }

        [Key]
        public int idtrabajador { get; set; }

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

        public decimal sueldo { get; set; }

        [Required]
        [StringLength(20)]
        public string codigo { get; set; }

        [Required]
        [StringLength(20)]
        public string password { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int idtipo_trabajador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reserva { get; set; }

        public virtual tipo_trabajador tipo_trabajador { get; set; }

        public trabajador Obtener(int id)
        {
            var usuario = new trabajador();
            try
            {
                using (var db = new ModelHotel())
                {
                    usuario = db.trabajador.Include("tipo_trabajador")
                        .Where(x => x.idtrabajador == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }
    }
}
