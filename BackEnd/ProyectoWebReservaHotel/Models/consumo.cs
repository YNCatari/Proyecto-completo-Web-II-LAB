namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("consumo")]
    public partial class consumo
    {
        [Key]
        public int idconsumo { get; set; }

        public int idreserva { get; set; }

        public int idproducto { get; set; }

        public decimal cantidad { get; set; }

        public decimal precio_venta { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual reserva reserva { get; set; }

        public virtual producto producto { get; set; }

        public List<consumo> Listar()
        {
            var ayuconsumo = new List<consumo>();
            try
            {
                using (var db = new ModelHotel())
                {
                    ayuconsumo = db.consumo.Include("producto").Include("reserva").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ayuconsumo;
        }
        public consumo Obtener(int id)
        {
            var ayuconsumo = new consumo();
            try
            {
                using (var db = new ModelHotel())
                {
                    ayuconsumo = db.consumo.Include("producto").Include("reserva")
                                .Where(x => x.idconsumo == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ayuconsumo;
        }
        public List<consumo> Buscar(string criterio)
        {
            var ayucliente = new List<consumo>();
            string estado = "";
            if (criterio == "Pagado") estado = "P";
            if (criterio == "Cancelado") estado = "C";
            if (criterio == "Anulado") estado = "A";
            try
            {
                using (var db = new ModelHotel())
                {
                    ayucliente = db.consumo.Include("producto").Include("reserva")
                                     .Where(x => Convert.ToString(x.idconsumo).Contains(criterio) || Convert.ToString(x.idreserva).Contains(criterio))
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
                    if (this.idconsumo > 0)
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
        //highchart
        public List<consumo> ObtenerConsumo()
        {
            var ayuconsumo = new List<consumo>();
            try
            {
                using (var db = new ModelHotel())
                {
                    ayuconsumo = db.consumo.Include("producto").Include("reserva").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ayuconsumo;

        }
    }
}
