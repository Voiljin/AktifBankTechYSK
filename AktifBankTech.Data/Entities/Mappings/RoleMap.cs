using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Data.Entities.Mappings
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .IsRequired();

            this.Property(x => x.RoleName)
                .IsRequired()
                .HasMaxLength(50);

            this.ToTable("Roles");

            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.RoleName).HasColumnName("RoleName");
        }
    }
}
