using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPoliselo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Infra.Data.Mapping
{
    public class DishMap : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dish");

            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.Period)
                .WithMany(c => c.Dishes)
                .HasForeignKey(c => c.PeriodId)
                .HasPrincipalKey(c => c.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Description)
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
