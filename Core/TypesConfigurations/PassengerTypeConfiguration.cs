using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Core.TypesConfigurations
{
    public class PassengerTypeConfiguration: EntityTypeConfiguration<Passenger>
    {
        public PassengerTypeConfiguration()
        {
            ToTable("Passenger");
            HasKey(x => x.Id);

            Property(x => x.CellNumber).HasMaxLength(10).IsRequired();
            Property(x => x.Email).IsRequired();
            Property(x => x.Lastname).IsRequired();
            Property(x => x.Name).IsRequired();

        }

    }

}
