using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Mapping
{
    public class UserProductMapping : IEntityTypeConfiguration<UserProduct>
    {
        public void Configure(EntityTypeBuilder<UserProduct> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ProductId });

            builder.HasOne(p => p.Product)
                .WithMany(x => x.UserProduct)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(p => p.User)
               .WithMany(x => x.UserProduct)
               .HasForeignKey(x => x.UserId);

        }
    }
}
