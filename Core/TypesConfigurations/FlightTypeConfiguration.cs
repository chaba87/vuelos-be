using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Core.TypesConfigurations
{
    public class FlightTypeConfiguration: EntityTypeConfiguration<Flight>
    {
        public FlightTypeConfiguration()
        {
            ToTable("Flights");
            HasKey(x => x.Id);

            Property(x => x.Currency).HasMaxLength(5).IsRequired();
            Property(x => x.DepartureDate).IsRequired();
            Property(x => x.FlightNumber).HasMaxLength(10).IsRequired();
            Property(x => x.Price).IsRequired();
            Property(x => x.DurationHour).IsRequired();
            Property(x => x.ArrivalStation).HasMaxLength(3).IsOptional();
            Property(x => x.DepartureStation).HasMaxLength(3).IsOptional();

            HasRequired(e => e.ArrivalCity).WithMany().HasForeignKey(e => e.ArrivalStationId).WillCascadeOnDelete(false);
            HasRequired(e => e.DepartureCity).WithMany().HasForeignKey(e => e.DepartureStationId).WillCascadeOnDelete(false);

        }

    }
}
