namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
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
        //METODO LISTAR
        public List<cliente> Listar()
        {
            var ayucliente = new List<cliente>();
            try
            {
                using (var db = new ModelHotel())
                {
                    ayucliente = db.cliente.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ayucliente;
        }
        public cliente Obtener(int id)
        {
            var ayucliente = new cliente();
            try
            {
                using (var db = new ModelHotel())
                {
                    ayucliente = db.cliente
                                .Where(x => x.idcliente == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ayucliente;
        }
        public List<cliente> Buscar(string criterio)
        {
            var ayucliente = new List<cliente>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelHotel())
                {
                    ayucliente = db.cliente
                                     .Where(x => x.numero_documento.Contains(criterio) || x.nombres == criterio || x.apellidos == criterio || x.telefono.Contains(criterio))
                                     .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ayucliente;

        }
        public void Guardar()
        {
            try
            {
                using (var db = new ModelHotel())
                {
                    if (this.idcliente > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;//existe
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;//nuevo registro
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

                    if (this.estado.Equals("A"))
                    { this.estado = "I"; }
                    else { this.estado = "A"; }

                    db.Entry(this).State = EntityState.Modified;//existe
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
