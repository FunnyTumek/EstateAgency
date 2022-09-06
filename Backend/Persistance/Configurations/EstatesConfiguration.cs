using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class EstatesConfiguration : IEntityTypeConfiguration<Estates>
    {
        public void Configure(EntityTypeBuilder<Estates> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.FlatArea).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.IfBought).IsRequired();
            builder.Property(x => x.AddedDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
        }
    }
}
