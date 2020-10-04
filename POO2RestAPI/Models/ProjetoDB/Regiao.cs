namespace POO2RestAPI.Models.ProjetoDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Regiao")]
    public partial class Regiao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Regiao()
        {
            Estados = new HashSet<Estado>();
        }

        [Key]
        public int IdRegiao { get; set; }

        [Required]
        public string Descricao { get; set; }

        public DateTime DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estado> Estados { get; set; }
    }
}
