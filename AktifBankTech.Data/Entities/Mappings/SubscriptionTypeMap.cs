using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities.Mappings
{
    public class SubscriptionTypeMap : EntityTypeConfiguration<SubscriptionType>
    {
        public SubscriptionTypeMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .IsRequired();

            this.Property(x => x.TypeName)
                .IsRequired()
                .HasMaxLength(150);

            //One to many relationship between SubscriptionType and Subscriptions
            this.HasMany(u => u.Subscriptions)
                .WithRequired(a => a.SubscriptionType)
                .HasForeignKey(a => a.SubscriptionTypeId);

            this.ToTable("SubscriptionTypes");

            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.TypeName).HasColumnName("TypeName");
        }


    }
}
