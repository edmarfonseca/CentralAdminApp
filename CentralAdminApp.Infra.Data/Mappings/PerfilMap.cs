using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CentralAdminApp.Domain.Entities;

namespace CentralAdminApp.Infra.Data.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("TB_PERFIL");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(t => t.SistemaId)
                .HasColumnName("SISTEMA_ID")
                .IsRequired();


            builder.HasIndex(t => new { t.Nome, t.SistemaId })
                .IsUnique();

            builder.HasOne(t => t.Sistema) //Perfil TEM 1 Sistema
                .WithMany(t => t.Perfis) //Sistema TEM MUITOS Perfil
                .HasForeignKey(t => t.SistemaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}