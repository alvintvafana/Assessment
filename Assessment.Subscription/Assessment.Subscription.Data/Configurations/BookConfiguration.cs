using Assessment.Subscription.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Subscription.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Domain.Entities.Subscription>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Subscription> builder)
        {
            builder.HasKey(a => a.SubsciptionId);
        }
    }

}
