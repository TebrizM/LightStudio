using LightStudio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Configurations
{
    public class ReklamConfiguration : IEntityTypeConfiguration<Reklam>
    {
        public void Configure(EntityTypeBuilder<Reklam> builder)
        {
                 builder
                .Property(x => x.Title)
                .HasMaxLength(30);
                 builder
              .Property(x => x.Title2)
              .HasMaxLength(30);
                 builder
              .Property(x => x.Info)
              .HasMaxLength(300);
                 builder
              .Property(x => x.Title3)
              .HasMaxLength(30);
                 builder
               .Property(x => x.Contact)
               .HasMaxLength(30);
                 builder
               .Property(x => x.Image)
               .IsRequired(true)
               .HasMaxLength(150);
        }
    }
}
