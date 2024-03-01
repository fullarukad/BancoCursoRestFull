using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ClientConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.FechaNacimiento)
                .IsRequired();

            builder.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(p => p.Email)                
                .HasMaxLength(100);

            builder.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.edad);

            builder.Property(p => p.CreatedBy)                
                .HasMaxLength(30);

            builder.Property(p => p.LastModifiedBy)
                .HasMaxLength(30);
        }
    }
}
