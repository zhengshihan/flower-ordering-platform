using FlowerWebsite_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerWebsite_API
{
    public class FlowerEntityConfig :IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.ToTable("T_Flowers");
        }
    }
}
