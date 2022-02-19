namespace BitcoinBeach.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BitcoinBeach.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BitcoinBeach.Data.ApplicationDbContext context)
        {

            context.Units.AddOrUpdate(n => n.UnitId, new Unit() { UnitId = 1, Title = "[H83] 2BR Condo", Description = "This condo is located near the Golden Beach Bar & the Zonteland Surf shop, also near the Green Waves Restaurante y alojamiento", Address = "3450 Playa El Zonte En, Chiltiupan, El Salvador", Price = 0.003200M, Guests = 4, Beds = 4, Bathrooms = 2 });
            context.Units.AddOrUpdate(n => n.UnitId, new Unit() { UnitId = 2, Title = "[H84] 3BR Condo", Description = "This condo is located near Hotel Michanti, can accomodate up to 10 guests due to each room having multiple bunk beds, has a backyard pool", Address = "Carretera Panamericana KM 53.5, El Zonte entrada Olas Permanentes", Price = 0.004200M, Guests = 10, Beds = 8, Bathrooms = 4 });
            context.Units.AddOrUpdate(n => n.UnitId, new Unit() { UnitId = 3, Title = "[H85] 2BR Guest House", Description = "This guest house is located next door to the Anauakali Guest House and shares a pool with them. Smaller square footage but is a desirable guest house due to the updated furnishings.", Address = "Chiltiupan, Playa El Zonte, Cantón El Zonte Calle Principal, 59 PG-B, Chiltiupán, El Salvador", Price = 0.003800M, Guests = 5, Beds = 3, Bathrooms = 2 });
            context.Units.AddOrUpdate(n => n.UnitId, new Unit() { UnitId = 4, Title = "[H86] 3BR Vacation Villa", Description = "This villa is one of our more luxurious villas boasting updated furnishings, an infinity pool, and complimentary meals. A costlier option for guests.", Address = "FHW5+CGJ, El Zonte, El Salvador", Price = 0.006500M, Guests = 6, Beds = 3, Bathrooms = 3 });
            context.SaveChanges();

            context.Profiles.AddOrUpdate(n => n.ProfileId, new Profile() { ProfileId = 1, FirstName = "Danny", LastName = "Redden", Email = "dannyredden18@gmail.com", PhoneNumber = "6187894207", ProfileType = new Models.ProfileType() { type = Models.AccountType.Renter } });
            context.Profiles.AddOrUpdate(n => n.ProfileId, new Profile() { ProfileId = 2, FirstName = "Maria", LastName = "Gonzalez", Email = "mariagonzalez@gmail.com", PhoneNumber = "+50377435966", ProfileType = new Models.ProfileType() { type = Models.AccountType.Renter }});
            context.Profiles.AddOrUpdate(n => n.ProfileId, new Profile() { ProfileId = 3, FirstName = "Ryan", LastName = "Gonzalez", Email = "ryangonzalez323@yahoo.com", PhoneNumber = "4239089345", ProfileType = new Models.ProfileType() { type = Models.AccountType.Landlord } });
            context.Profiles.AddOrUpdate(n => n.ProfileId, new Profile() { ProfileId = 4, FirstName = "Jim", LastName = "Roberts", Email = "jimroberts231@hotmail.com", PhoneNumber = "3178934589", ProfileType = new Models.ProfileType() { type = Models.AccountType.Renter } });
            context.Profiles.AddOrUpdate(n => n.ProfileId, new Profile() { ProfileId = 5, FirstName = "Rebecca", LastName = "Martinez", Email = "rebeccamartinez@hotmail.com", PhoneNumber = "4529876543", ProfileType = new Models.ProfileType() { type = Models.AccountType.Landlord} });
            context.SaveChanges();

            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 1, ProfileId = 1, UnitId = 2, ReservationStartDate = DateTime.Parse("2022-09-22"), ReservationEndDate = DateTime.Parse("2022-09-23") });
            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 2, ProfileId = 2, UnitId = 3, ReservationStartDate = DateTime.Parse("2022-09-23"), ReservationEndDate = DateTime.Parse("2022-09-24") });
            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 3, ProfileId = 1, UnitId = 1, ReservationStartDate = DateTime.Parse("2022-10-02"), ReservationEndDate = DateTime.Parse("2022-10-05") });
            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 4, ProfileId = 2, UnitId = 1, ReservationStartDate = DateTime.Parse("2022-11-02"), ReservationEndDate = DateTime.Parse("2022-11-04") });
            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 5, ProfileId = 3, UnitId = 4, ReservationStartDate = DateTime.Parse("2022-11-09"), ReservationEndDate = DateTime.Parse("2022-11-12") });
            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 6, ProfileId = 1, UnitId = 1, ReservationStartDate = DateTime.Parse("2022-11-13"), ReservationEndDate = DateTime.Parse("2022-11-15") });
            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 7, ProfileId = 4, UnitId = 4, ReservationStartDate = DateTime.Parse("2022-11-22"), ReservationEndDate = DateTime.Parse("2022-11-23") });
            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 8, ProfileId = 3, UnitId = 2, ReservationStartDate = DateTime.Parse("2022-11-24"), ReservationEndDate = DateTime.Parse("2022-11-25") });
            context.Reservations.AddOrUpdate(n => n.ReservationId, new Reservation() { ReservationId = 9, ProfileId = 2, UnitId = 4, ReservationStartDate = DateTime.Parse("2022-11-29"), ReservationEndDate = DateTime.Parse("2022-12-01") });
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
