using GraphQL_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL_Data.Mappings
{
    public static class PacienteMapping
    {
        public static void Map(this EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("PACIENTES");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(200).IsRequired(true);
            builder.Property(p => p.Peso).HasColumnName("PESO").IsRequired(true);
            builder.Property(p => p.Altura).HasColumnName("ALTURA").IsRequired(true);
            builder.Property(p => p.Idade).HasColumnName("IDADE").HasMaxLength(3).IsRequired(true);
            builder.Property(p => p.ClinicaId).HasColumnName("CLINICA_ID").IsRequired(true);

            builder.HasOne(p => p.Clinica)
                .WithMany(p => p.Pacientes)
                .HasForeignKey(p => p.ClinicaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
