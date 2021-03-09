namespace ProyectoWebReservaHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class reportes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idreportes { get; set; }

        public int idpago { get; set; }

        public int idconsumo { get; set; }

        public int idtrabajador { get; set; }

        public int idcliente { get; set; }

        public DateTime fecha { get; set; }

        public virtual pago pago { get; set; }
    }
}
