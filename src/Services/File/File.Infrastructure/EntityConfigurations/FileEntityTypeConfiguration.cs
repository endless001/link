using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FileEntity = File.Domain.AggregatesModel.File;

namespace File.Infrastructure.EntityConfigurations
{
    public class FileEntityTypeConfiguration : IEntityTypeConfiguration<FileEntity>
    {
        public void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            builder.ToTable("file")
                .HasKey(b => b.Id);
            builder.Property(a => a.UserId).HasColumnName("user_id");
            builder.Property(a => a.FileHash).HasColumnName("file_hash");
            builder.Property(a => a.FileName).HasColumnName("file_name");
            builder.Property(a => a.FileSize).HasColumnName("file_size");
            builder.Property(a => a.IsDirectory).HasColumnName("is_directory");
            builder.Property(a => a.ParentPath).HasColumnName("parent_path");
            builder.Property(a => a.CreateTime).HasColumnName("create_time");
            builder.Property(a => a.UpdateTime).HasColumnName("update_time");


            builder.Property<int>("_fileStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("file_statusid")
                .IsRequired();

            builder.Property<int>("_fileTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("file_typeid")
                .IsRequired();

            builder.HasOne(o => o.FileType)
               .WithMany()
               .HasForeignKey("_fileTypeId");

            builder.HasOne(o => o.FileStatus)
               .WithMany()
               .HasForeignKey("_fileStatusId");


        }
    }
}
