namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("habitacion")]
    public partial class habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public habitacion()
        {
            reserva = new HashSet<reserva>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idhabitacion { get; set; }

        [Required]
        [StringLength(4)]
        public string numero { get; set; }

        [Required]
        [StringLength(4)]
        public string piso { get; set; }

        [Required]
        [StringLength(200)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(200)]
        public string caracteristicas { get; set; }

        public decimal precio_diario { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int idtipo_habitacion { get; set; }

        public virtual tipo_habitacion tipo_habitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reserva { get; set; }

        public List<habitacion> Listar()
        {
            var habitacion = new List<habitacion>();
            try
            {
                using (var db = new ModelHotel())
                {
                    habitacion = db.habitacion.Include("tipo_habitacion").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return habitacion;
        }
        public List<habitacion> ListarDiponibles()
        {
            var habitacion = new List<habitacion>();
            try
            {
                using (var db = new ModelHotel())
                {
                    habitacion = db.habitacion.Include("tipo_habitacion").Where(x => x.estado == "3" || x.estado == "4").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return habitacion;
        }
        public List<habitacion> Buscar(string criterio)
        {
            var usuario = new List<habitacion>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelHotel())
                {
                    usuario = db.habitacion.Include("tipo_habitacion")
                        .Where(x => x.numero.Contains(criterio) || x.piso.Contains(criterio) || x.descripcion.Contains(criterio) || /*x.precio_diario == Convert.ToDecimal(criterio) ||*/ x.estado == estado
                        || x.tipo_habitacion.descripcion.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }

        public habitacion Obtener(int id)
        {
            var habitacion = new habitacion();
            try
            {
                using (var db = new ModelHotel())
                {
                    habitacion = db.habitacion.Include("tipo_habitacion").Where(x => x.idhabitacion == id)
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
                    if (this.idhabitacion > 0)
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
        public void Eliminar()
        {
            try
            {
                using (var db = new ModelHotel())
                {

                    db.Entry(this).State = EntityState.Deleted;

                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
