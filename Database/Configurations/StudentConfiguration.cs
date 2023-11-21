using Microsoft.EntityFrameworkCore;
using ProkhorovaKT_31_20.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProkhorovaKT_31_20.Database.Helpers;

namespace ProkhorovaKT_31_20.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.StudentID)
                .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentID)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentID)
                .HasColumnName("student_id")
                .HasComment("ID студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество");

            builder.Property(p => p.GroupID)
                .IsRequired()
                .HasColumnName("f_group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID группы");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupID)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupID, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Group)
                .AutoInclude();
        }

    }
}
