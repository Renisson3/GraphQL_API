using GraphQL_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL_Data.Mappings
{
    public static class MedicoMapping
    {
        public static void Map(this EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("MEDICOS");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(200).IsRequired(true);
            builder.Property(p => p.Crm).HasColumnName("CRM").HasMaxLength(20).IsRequired(true);
            builder.Property(p => p.ClinicaId).HasColumnName("CLINICA_ID").IsRequired(true);

            builder.HasOne(p => p.Clinica)
                .WithMany(p => p.Medicos)
                .HasForeignKey(p => p.ClinicaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
