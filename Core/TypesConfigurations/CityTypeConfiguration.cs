using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Core.TypesConfigurations
{
    public class CityTypeConfiguration : EntityTypeConfiguration<City>
    {
        public CityTypeConfiguration()
        {
            ToTable("Cities");
            HasKey(x => x.Id);

            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.IATACode).HasMaxLength(3).IsRequired();

        }

    }

}
