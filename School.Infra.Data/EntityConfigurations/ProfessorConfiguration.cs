using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Data.EntityConfigurations;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.DocumentNumber)
            .HasMaxLength(11)
            .IsRequired();

        //Se a tabela Professor não tiver dados, então cria
        builder.HasData(new Professor("Akira", "12345678900", Domain.Enums.EContractType.Temporary));
    }
}
