using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(255);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(50); 

            // shadow property 
            builder.Property<DateTime>("CreatedAt")
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();
        }
    }
}
