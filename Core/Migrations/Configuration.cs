namespace Core.Migrations
{
    using Core.Model;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VuelosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VuelosContext context)
        {
            //  This method will be called after migrating to the latest version.

            var city = new City()
            {
                Name = "Buenos Aires",
                IATACode = "AEP"
            };
            var dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Madrid",
                IATACode = "MAD"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Barcelona",
                IATACode = "BCN"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Bogota",
                IATACode = "BOG"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Santiago de Chile",
                IATACode = "SCL"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Cartagena",
                IATACode = "CTG"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Bilbao",
                IATACode = "BIO"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Granada",
                IATACode = "GRX"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Ibiza",
                IATACode = "IBZ"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Malaga",
                IATACode = "AGP"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Sevilla",
                IATACode = "SVQ"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);
            city = new City()
            {
                Name = "Caracas",
                IATACode = "CCS"
            };
            dbCity = context.Cities.FirstOrDefault(x => x.Name == city.Name);
            if (dbCity == null)
                context.Cities.Add(city);

            var flight = new Flight()
            {
                ArrivalStationId = 2,
                Currency = "EUR",
                DepartureDate = new DateTime(2021, 5, 21, 18, 0, 0),
                DepartureStationId = 1,
                FlightNumber = "568",
                Price = 865,
                DurationHour = 14
            };
            var dbFlight = context.Flights.FirstOrDefault(x => x.FlightNumber == flight.FlightNumber && x.Currency == flight.Currency);
            if (dbFlight == null)
                context.Flights.Add(flight);
            flight = new Flight()
            {
                ArrivalStationId = 3,
                Currency = "EUR",
                DepartureDate = new DateTime(2021, 5, 22, 13, 0, 0),
                DepartureStationId = 1,
                FlightNumber = "532",
                Price = 836,
                DurationHour = 17
            };
            dbFlight = context.Flights.FirstOrDefault(x => x.FlightNumber == flight.FlightNumber && x.Currency == flight.Currency);
            if (dbFlight == null)
                context.Flights.Add(flight);
            flight = new Flight()
            {
                ArrivalStationId = 2,
                Currency = "ARS",
                DepartureDate = new DateTime(2021, 5, 21, 18, 0, 0),
                DepartureStationId = 1,
                FlightNumber = "568",
                Price = 107200,
                DurationHour = 14
            };
            dbFlight = context.Flights.FirstOrDefault(x => x.FlightNumber == flight.FlightNumber && x.Currency == flight.Currency);
            if (dbFlight == null)
                context.Flights.Add(flight);
            flight = new Flight()
            {
                ArrivalStationId = 3,
                Currency = "EUR",
                DepartureDate = new DateTime(2021, 5, 22, 9, 0, 0),
                DepartureStationId = 2,
                FlightNumber = "112",
                Price = 50,
                DurationHour = 2f
            };
            dbFlight = context.Flights.FirstOrDefault(x => x.FlightNumber == flight.FlightNumber && x.Currency == flight.Currency);
            if (dbFlight == null)
                context.Flights.Add(flight);
            flight = new Flight()
            {
                ArrivalStationId = 3,
                Currency = "EUR",
                DepartureDate = new DateTime(2021, 5, 22, 12, 0, 0),
                DepartureStationId = 2,
                FlightNumber = "114",
                Price = 55,
                DurationHour = 1.9f
            };
            dbFlight = context.Flights.FirstOrDefault(x => x.FlightNumber == flight.FlightNumber && x.Currency == flight.Currency);
            if (dbFlight == null)
                context.Flights.Add(flight);
            flight = new Flight()
            {
                ArrivalStationId = 3,
                Currency = "EUR",
                DepartureDate = new DateTime(2021, 5, 22, 14, 0, 0),
                DepartureStationId = 2,
                FlightNumber = "117",
                Price = 48,
                DurationHour = 1.8f
            };
            dbFlight = context.Flights.FirstOrDefault(x => x.FlightNumber == flight.FlightNumber && x.Currency == flight.Currency);
            if (dbFlight == null)
                context.Flights.Add(flight);

            context.SaveChanges();

        }
    }
}
