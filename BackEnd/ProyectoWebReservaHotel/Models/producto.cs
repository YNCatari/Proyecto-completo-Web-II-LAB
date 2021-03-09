namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("producto")]
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            consumo = new HashSet<consumo>();
        }

        [Key]
        
        public int idproducto { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string descripcion { get; set; }

        public int cantidad { get; set; }

        public decimal precio { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consumo> consumo { get; set; }


        
        public List<producto> Listar()
        {
            var producto = new List<producto>();
            try
            {
                using (var db = new ModelHotel())
                {
                    producto = db.producto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return producto;
        }
        public producto Obtener(int id)
        {
            var producto = new producto();
            try
            {
                using (var db = new ModelHotel())
                {
                    producto = db.producto
                        .Where(x => x.idproducto == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return producto;
        }
        public List<producto> Buscar(string criterio)
        {
            var producto = new List<producto>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelHotel())
                {
                    producto = db.producto
                        .Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio) || x.estado == estado)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return producto;
        }
        public void Guardar()
        {
            try
            {
                using (var db = new ModelHotel())
                {
                    if (this.idproducto > 0)
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
        //highchart
        public List<producto> ObtenerProductos()
        {
            var producto = new List<producto>();
            try
            {
                using (var db = new ModelHotel())
                {
                    producto = db.producto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return producto;

        }
    }
}
