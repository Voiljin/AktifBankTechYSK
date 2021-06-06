using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities.Mappings
{
    public class DepositMap : EntityTypeConfiguration<Deposit>
    {
        public DepositMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
            .IsRequired();

            this.Property(x => x.SubscriptionId)
            .IsRequired();

            this.Property(x => x.Value)
                .IsRequired();

            this.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(50);

            this.ToTable("Deposits");

            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.SubscriptionId).HasColumnName("SubscriptionId");
            this.Property(x => x.Value).HasColumnName("Value");
            this.Property(x => x.Status).HasColumnName("Status");


        }
    }
}
