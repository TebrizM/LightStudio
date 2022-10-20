using LightStudio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Data.Configurations
{
    public class SettingsConfiguration : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.
                Property(x => x.Key)
                .HasMaxLength(25)
                .IsRequired(true);

            builder
                .Property(x => x.Value)
                .HasMaxLength(200)
                .IsRequired(true);
        }
    }
}
