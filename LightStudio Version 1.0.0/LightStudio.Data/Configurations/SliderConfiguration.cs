using LightStudio.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
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
             .Property(x => x.Image)
            .IsRequired(true)
            .HasMaxLength(150);
        }
    }
}
