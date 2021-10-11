using File.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace File.Infrastructure.EntityConfigurations
{
    public class FileTypeEntityTypeConfiguration : IEntityTypeConfiguration<FileType>
    {
        public void Configure(EntityTypeBuilder<FileType> builder)
        {
            builder.ToTable("file_type")
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
