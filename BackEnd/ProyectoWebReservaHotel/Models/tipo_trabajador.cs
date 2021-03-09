namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("tipo_trabajador")]
    public partial class tipo_trabajador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_trabajador()
        {
            trabajador = new HashSet<trabajador>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idtipo_trabajador { get; set; }

        [Required]
        [StringLength(200)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trabajador> trabajador { get; set; }

        public List<tipo_trabajador> Listar()
        {
            var tipotrabajador = new List<tipo_trabajador>();
            try
            {
                using (var db = new ModelHotel())
                {
                    tipotrabajador = db.tipo_trabajador.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipotrabajador;
        }
        public tipo_trabajador Obtener(int id)
        {
            var tipotrabajador = new tipo_trabajador();
            try
            {
                using (var db = new ModelHotel())
                {
                    tipotrabajador = db.tipo_trabajador
                        .Where(x => x.idtipo_trabajador == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipotrabajador;
        }
        public List<tipo_trabajador> Buscar(string criterio)
        {
            var tipotrabajador = new List<tipo_trabajador>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelHotel())
                {
                    tipotrabajador = db.tipo_trabajador
                        .Where(x => x.descripcion.Contains(criterio) || x.estado == estado)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipotrabajador;
        }
        public void Guardar()
        {
            try
            {
                using (var db = new ModelHotel())
                {
                    if (this.idtipo_trabajador > 0)
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
