using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPoliselo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Infra.Data.Mapping
{
    public class PeriodMap : IEntityTypeConfiguration<Period>
    {
        public void Configure(EntityTypeBuilder<Period> builder)
        {
            builder.ToTable("Period");

            builder.HasKey(c => c.Id);

            builder
               .HasMany(c => c.Dishes)
               .WithOne(c => c.Period)
               .HasForeignKey(c => c.PeriodId)
               .HasPrincipalKey(c => c.Id)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Name)
               .HasColumnType("varchar(255)")
               .IsRequired();

            builder.Property(e => e.CreatedDate)
              .HasColumnType("datetime")
              .IsRequired();

            builder.Property(e => e.UpdatedDate)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(e => e.Active)
               .HasColumnType("bit")
               .IsRequired();
        }
    }
}
