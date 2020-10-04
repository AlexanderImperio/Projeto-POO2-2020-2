namespace POO2RestAPI.Models.ProjetoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estado")]
    public partial class Estado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estado()
        {
            Municipios = new HashSet<Municipio>();
        }

        [Key]
        public int IdEstado { get; set; }

        public int IdRegiao { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [StringLength(2)]
        public string SiglaUF { get; set; }

        public string RegiaoBrasil { get; set; }

        public DateTime DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipios { get; set; }

        public virtual Regiao Regiao { get; set; }
    }
}
