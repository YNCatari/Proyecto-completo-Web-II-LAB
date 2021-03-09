namespace ProyectoReservaFrontEnd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
