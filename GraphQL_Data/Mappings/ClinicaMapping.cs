using GraphQL_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL_Data.Mappings
{
    public static class ClinicaMapping
    {
        public static void Map(this EntityTypeBuilder<Clinica> builder)
        {
            builder.ToTable("CLINICAS");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(200).IsRequired(true);
        }
    }
}
