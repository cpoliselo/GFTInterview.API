using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAPoliselo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Infra.Data.Mapping
{
    public class SearchLogMap : IEntityTypeConfiguration<SearchLog>
    {
        public void Configure(EntityTypeBuilder<SearchLog> builder)
        {
            builder.ToTable("SearchLog");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.SearchKey)
              .HasColumnType("varchar(255)")
              .IsRequired();

            builder.Property(e => e.Result)
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
