namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("tipo_habitacion")]
    public partial class tipo_habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_habitacion()
        {
            habitacion = new HashSet<habitacion>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idtipo_habitacion { get; set; }

        [Required]
        [StringLength(200)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<habitacion> habitacion { get; set; }


        public List<tipo_habitacion> Listar()
        {
            var tipohabitacion = new List<tipo_habitacion>();
            try
            {
                using (var db = new ModelHotel())
                {
                    tipohabitacion = db.tipo_habitacion.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipohabitacion;
        }
        public List<tipo_habitacion> Buscar(string criterio)
        {
            var tipohabitacion = new List<tipo_habitacion>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelHotel())
                {
                    tipohabitacion = db.tipo_habitacion
                        .Where(x =>x.idtipo_habitacion.Equals(criterio) || x.descripcion.Contains(criterio) || x.estado == estado)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipohabitacion;
        }
        public tipo_habitacion Obtener(int id)
        {
            var tipohabitacion = new tipo_habitacion();
            try
            {
                using (var db = new ModelHotel())
                {
                    tipohabitacion = db.tipo_habitacion
                        .Where(x => x.idtipo_habitacion == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipohabitacion;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new ModelHotel())
                {
                    if (this.idtipo_habitacion > 0)
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
