namespace POO2RestAPI.Models.ProjetoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Municipio")]
    public partial class Municipio
    {
        [Key]
        public int IdMunicipio { get; set; }

        public int IdEstado { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [StringLength(2)]
        public string SiglaUF { get; set; }

        public DateTime DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }

        public virtual Estado Estado { get; set; }
    }
}
