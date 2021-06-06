using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities.Mappings
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .IsRequired();

            this.Property(x => x.UserId)
                .IsRequired();

            this.Property(x => x.SubscriptionTypeId)
                .IsRequired();

            this.Property(x => x.IsActive)
                .IsRequired();

            //One to many relationship between Subscription and Invoices
            this.HasMany(u => u.Invoices)
                .WithRequired(a => a.Subscription)
                .HasForeignKey(a => a.SubscriptionId);

            this.HasMany(u => u.Deposits)
                .WithRequired(a => a.Subscription)
                .HasForeignKey(a => a.SubscriptionId);

            this.ToTable("Subscriptions");

            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.UserId).HasColumnName("UserId");
            this.Property(x => x.SubscriptionTypeId).HasColumnName("SubscriptionTypeId");
            this.Property(x => x.IsActive).HasColumnName("IsActive");
        }
    }
}
