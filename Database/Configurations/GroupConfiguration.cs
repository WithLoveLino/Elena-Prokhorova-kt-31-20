using Microsoft.EntityFrameworkCore;
using ProkhorovaKT_31_20.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProkhorovaKT_31_20.Database.Helpers;

namespace ProkhorovaKT_31_20.Database.Configurations
{
    public class GroupConfiguration:IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(p => p.GroupID)
                .HasName($"pk_{TableName}_group_id");

            builder.Property(p => p.GroupID)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.GroupID)
                .HasColumnName("group_id")
                .HasComment("ID группы");

            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType(ColumnType.String).HasMaxLength(50)
                .HasComment("Название группы");

            builder.ToTable(TableName);
        }
    }
    
}
