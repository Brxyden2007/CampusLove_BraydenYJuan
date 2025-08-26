using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusLove_BraydenYJuan.src.Shared.Configurations
{
    public class InteresesConfig : IEntityTypeConfiguration<Interes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Interes> builder)
        {
            builder.ToTable("intereses");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.Property(i => i.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
