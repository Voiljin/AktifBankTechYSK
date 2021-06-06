using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .IsRequired();

            this.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(x => x.TCNo)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(x => x.TaxNumber)
                .IsOptional()
                .HasMaxLength(150);

            this.Property(x => x.RoleId)
                .IsRequired();

            this.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(x => x.IsActive)
                .IsRequired();

            //One to many relationship between User and Subscriptions
            this.HasMany(u => u.Subscriptions)
                .WithRequired(a => a.User)
                .HasForeignKey(a => a.UserId);

            this.ToTable("Users");

            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.FirstName).HasColumnName("FirstName");
            this.Property(x => x.LastName).HasColumnName("LastName");
            this.Property(x => x.TCNo).HasColumnName("TCNo");
            this.Property(x => x.TaxNumber).HasColumnName("TaxNumber");
            this.Property(x => x.RoleId).HasColumnName("RoleId");
            this.Property(x => x.Password).HasColumnName("Password");
            this.Property(x => x.IsActive).HasColumnName("IsActive");
        }
    }
}
