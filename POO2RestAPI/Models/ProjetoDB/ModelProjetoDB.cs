namespace POO2RestAPI.Models.ProjetoDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelProjetoDB : DbContext
    {

        /// <summary>
        /// 
        /// </summary>
        public ModelProjetoDB()
            : base("name=ModelProjetoDB")
        {
        }

        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Regiao> Regioes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.SiglaUF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.RegiaoBrasil)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Municipios)
                .WithRequired(e => e.Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Municipio>()
                .Property(e => e.SiglaUF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Regiao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Regiao>()
                .HasMany(e => e.Estados)
                .WithRequired(e => e.Regiao)
                .WillCascadeOnDelete(false);
        }
    }
}
