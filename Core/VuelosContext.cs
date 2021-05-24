namespace Core
{
    using System.Data.Entity;
    using TypesConfigurations;
    using Model;

    public partial class VuelosContext : DbContext
    {
        public VuelosContext()
            : base("name=VuelosContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                            <VuelosContext,
                            Core.Migrations.Configuration>("VuelosContext"));
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public static VuelosContext Create()
        {
            // Database.SetInitializer<ApplicationDbContext>(null);
            Database.SetInitializer<VuelosContext>(new MigrateDatabaseToLatestVersion<VuelosContext, Migrations.Configuration>());
            return new VuelosContext();
        }

        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new FlightTypeConfiguration());
            modelBuilder.Configurations.Add(new CityTypeConfiguration());

            modelBuilder.Entity<Flight>().ToTable("Flights");
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Passenger>().ToTable("Passenger");

        }

    }
}
