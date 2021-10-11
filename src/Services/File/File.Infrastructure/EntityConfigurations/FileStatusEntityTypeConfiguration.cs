using File.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace File.Infrastructure.EntityConfigurations
{
    public class FileStatusEntityTypeConfiguration : IEntityTypeConfiguration<FileStatus>
    {
        public void Configure(EntityTypeBuilder<FileStatus> builder)
        {
            builder.ToTable("file_status")
                .HasKey(b => b.Id);

            builder.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
