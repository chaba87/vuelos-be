using Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace Core.TypesConfigurations
{
    public class BookingTypeConfiguration: EntityTypeConfiguration<Booking>
    {
        public BookingTypeConfiguration()
        {
            ToTable("Booking");
            HasKey(x => x.Id);

            Property(x => x.BookingNumber).HasMaxLength(10).IsRequired();

            HasRequired(e => e.Passenger).WithMany().HasForeignKey(e => e.PassengerId).WillCascadeOnDelete(false);
            HasRequired(e => e.Flight).WithMany().HasForeignKey(e => e.FlightId).WillCascadeOnDelete(false);

        }

    }

}
