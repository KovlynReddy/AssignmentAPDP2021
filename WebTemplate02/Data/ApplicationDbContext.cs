using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebTemplate02.Data.DataModels.BookingModels;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.DataModels.ProfileModels;
using WebTemplate02.Data.DataModels.Social;

namespace WebTemplate02.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Seed();

            //builder.Entity<UserProfile>();
            //builder.Entity<DM>();
            //builder.Entity<Post>();
            //builder.Entity<Group>();

            //builder.Entity<UserAccount>();

            //builder.Entity<Contractor>();

            //builder.Entity<Location>();

            //builder.Entity<Hotel>();

            //builder.Entity<Flight>();
            //builder.Entity<AActivity>();
            //builder.Entity<BookingPackage>();
            //builder.Entity<Reservation>();
            //builder.Entity<DataModels.InternalModels.Transaction>();

            base.OnModelCreating(builder);
            
        }

        #region DBSets

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<AActivity> Tours { get; set; }
        public DbSet<BookingPackage> Packages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<DM> DMs { get; set; }

        #endregion
    
    }
        #region CompoundClasses
        public class UserDetails
        {
            public List<UserAccount> Accounts { get; set; } = new List<UserAccount>();
            public List<UserProfile> Profiles { get; set; } = new List<UserProfile>();

        }
        public class CountryDetails
        {

            public List<Flight> FlightDetails { get; set; } = new List<Flight>();
            public List<Hotel> HotelDetails { get; set; } = new List<Hotel>();
            public List<Contractor> Managers { get; set; } = new List<Contractor>();
            public List<UserAccount> Accounts { get; set; } = new List<UserAccount>();

        }
        public class RawLocation
        {

            public string country { get; set; }
            public string geonameid { get; set; }
            public string name { get; set; }
            public string subcountry { get; set; }

            public static (Location, Location, Location) LocationProccessor(RawLocation _rawLocation)
            {

                Location _newLocationCountry = new Location();

                _newLocationCountry.Country = _rawLocation.country;
                _newLocationCountry.City = _rawLocation.subcountry;
                _newLocationCountry.LocationName = _rawLocation.name;
                _newLocationCountry.LocationId = Guid.NewGuid().ToString();
                _newLocationCountry.Code = 1;

                Location _newLocationCity = new Location();

                _newLocationCity.Country = _rawLocation.country;
                _newLocationCity.City = _rawLocation.subcountry;
                _newLocationCity.LocationName = _rawLocation.name;
                _newLocationCity.LocationId = Guid.NewGuid().ToString();
                _newLocationCity.Code = 2;

                Location _newLocationStreet = new Location();

                _newLocationStreet.Country = _rawLocation.country;
                _newLocationStreet.City = _rawLocation.subcountry;
                _newLocationStreet.LocationName = _rawLocation.name;
                _newLocationStreet.LocationId = Guid.NewGuid().ToString();
                _newLocationStreet.Code = 3;

                return (_newLocationCountry, _newLocationCity, _newLocationStreet);
            }

        }
    #endregion

        #region Model Builder Extension
    public static class ModelBuilderExtensions
    {
        public static List<RawLocation> _Locations = new List<RawLocation>();
        public static List<Contractor> Contractors = new List<Contractor>();

        public static void Seed(this ModelBuilder builder)
        {
            var countries = GetCountries();
            var details = GetDetailsFromCountries(countries);
            var userDetails = GetSeededUsers();
            var Drivers = GetDrivers(countries);

            #region Id Pop

            foreach (var item in Drivers)
            {
                Contractors.Add(item.Item1);
                userDetails.Accounts.Add(item.Item2);
            }

            Contractors.AddRange(details.Managers);
            userDetails.Accounts.AddRange(details.Accounts);

            for (int i = 0; i < Contractors.Count; i++)
            {
                Contractors[i].Id = i + 1;
            }

            for (int i = 0; i < userDetails.Accounts.Count; i++)
            {
                userDetails.Accounts[i].Id = i + 1;
            }

            for (int i = 0; i < userDetails.Profiles.Count; i++)
            {
                userDetails.Profiles[i].Id = i + 1;
            }

            for (int i = 0; i < countries.Count; i++)
            {
                countries[i].Id = i + 1;
            }

            #endregion

            #region Entity Pop

            builder.Entity<UserProfile>().HasData(userDetails.Profiles.ToArray());

            builder.Entity<UserAccount>().HasData(userDetails.Accounts.ToArray());

            builder.Entity<Contractor>().HasData(Contractors.ToArray());

            builder.Entity<Location>().HasData(countries.ToArray());

            builder.Entity<Hotel>().HasData(details.HotelDetails.ToArray());

            builder.Entity<Flight>();

            builder.Entity<AActivity>().HasData(new AActivity { Id = 1, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "WetnWild", ActivityDesciption = "WetnWild" },
                                            new AActivity { Id = 2, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "RollerCoaster", ActivityDesciption = "RollerCoaster" },
                                            new AActivity { Id = 3, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "Mall", ActivityDesciption = "Mall" },
                                            new AActivity { Id = 4, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "Monument", ActivityDesciption = "Monument" },
                                            new AActivity { Id = 5, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "Wild Life Reseverve", ActivityDesciption = "Wild Life Reseverve" },
                                            new AActivity { Id = 6, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "Mini Town", ActivityDesciption = "Mini Town" },
                                            new AActivity { Id = 7, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "Aquarium", ActivityDesciption = "Aquarium" },
                                            new AActivity { Id = 8, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "Zoo", ActivityDesciption = "Zoo" },
                                            new AActivity { Id = 9, BookingId = "", ReservationId = "", TourGuideId = "", ActivityId = "Observatory", ActivityDesciption = "Observatory" }
                                          );

            builder.Entity<BookingPackage>().HasData(new BookingPackage { Id = 1, BookingId = "TestBookingId1", HotelId = details.HotelDetails[0].HotelLocationId, InFlightId = details.FlightDetails[0].FlightId, OutFlightId = details.FlightDetails[1].FlightId, UserId = "TestUserId1", DurationDays = 3 }
                                                    );

            builder.Entity<Reservation>().HasData(new Reservation { Id = 1, BookingId = "TestBookingId1", Notes = "To AirPort", ReservationId = "TestReservationId1", EndLocationId = countries[3].LocationId, TransactionId = "", StartLocationId = countries[4].LocationId, EndDateTime = new DateTime().Date, StartDateTime = new DateTime().Date.AddDays(10).Date, UserProfileId = "TestUserId1" },
                                                  new Reservation { Id = 2, BookingId = "TestBookingId1", Notes = "To Hotel", ReservationId = "TestReservationId2", EndLocationId = countries[4].LocationId, TransactionId = "", StartLocationId = countries[7].LocationId, EndDateTime = new DateTime().Date, StartDateTime = new DateTime().Date.AddDays(10).Date, UserProfileId = "TestUserId1" },
                                                  new Reservation { Id = 3, BookingId = "TestBookingId1", Notes = "To AirPort", ReservationId = "TestReservationId3", EndLocationId = countries[7].LocationId, TransactionId = "", StartLocationId = countries[4].LocationId, EndDateTime = new DateTime().Date, StartDateTime = new DateTime().Date.AddDays(10).Date, UserProfileId = "TestUserId1" },
                                                  new Reservation { Id = 4, BookingId = "TestBookingId1", Notes = "To Residence", ReservationId = "TestReservationId4", EndLocationId = countries[4].LocationId, TransactionId = "", StartLocationId = countries[3].LocationId, EndDateTime = new DateTime().Date, StartDateTime = new DateTime().Date.AddDays(10).Date, UserProfileId = "TestUserId1" }
                                                  );

            builder.Entity<DataModels.InternalModels.Transaction>().HasData(new DataModels.InternalModels.Transaction { Id = 1, Amount = 0, RecipientId = Contractors[2].ContractorId, SenderId = "AccountId1", TimePayment = new DateTime().Date, ContractorId = Contractors[2].ContractorId, UserProfileId = "TestUserId1" },
                                                                              new DataModels.InternalModels.Transaction { Id = 2, Amount = 0, RecipientId = Contractors[4].ContractorId, SenderId = "AccountId1", TimePayment = new DateTime().Date, ContractorId = Contractors[4].ContractorId, UserProfileId = "TestUserId1" },
                                                                              new DataModels.InternalModels.Transaction { Id = 3, Amount = 0, RecipientId = Contractors[5].ContractorId, SenderId = "AccountId1", TimePayment = new DateTime().Date, ContractorId = Contractors[5].ContractorId, UserProfileId = "TestUserId1" }
                                                                           );
            builder.Entity<DM>();
            builder.Entity<Post>().HasData(new Post { Id = 1 , Description = "This is a testing message" , Message = "Hello" , PostId = "PostId1" , SenderId = "TestUser1" , TimeSend = new DateTime()});
            builder.Entity<Group>();


            #endregion

        }

        public static List<Location> GetCountries()
        {

            List<RawLocation> Countries = MyDLL01.DataAccess.Excel.JsonReader._download_serialized_json_data<RawLocation>("https://raw.githubusercontent.com/lutangar/cities.json/master/cities.json");

            List<(Location, Location, Location)> ListsOfLocations = new List<(Location, Location, Location)>();

            foreach (var loc in Countries)
            {
                ListsOfLocations.Add(RawLocation.LocationProccessor(loc));
            }

            List<Location> CountriyDetails = new List<Location>();
            List<Location> CityDetails = new List<Location>();
            List<Location> StreetDetails = new List<Location>();

            foreach (var item in ListsOfLocations)
            {
                CountriyDetails.Add(item.Item1);
                CityDetails.Add(item.Item2);
                StreetDetails.Add(item.Item3);
            }

            for (int i = 0; i < CityDetails.Count; i++)
            {
                CityDetails[i].Id = i + 1;
            }

            var CountryGroups =  (CityDetails.GroupBy( m =>  m.Country ));

            List<Location> CutCityDetails = new List<Location>();

            int CountryCount = 0;
            int CountryLimit = 20 ;

            foreach (var entry in CountryGroups)
            {
                CutCityDetails.AddRange(entry.Take(3));
                CountryCount++;

                if (CountryCount > CountryLimit)
                {
                    break;
                }
            }
                


            return CutCityDetails;

        }

        public static CountryDetails GetDetailsFromCountries(List<Location> _locations)
        {

            CountryDetails details = new CountryDetails();

            List<(Flight, Hotel, Reservation)> Details = new List<(Flight, Hotel, Reservation)>();

            List<Flight> FlightsForNow = new List<Flight>();
            List<Hotel> Hotels = new List<Hotel>();
            List<Contractor> Managers = new List<Contractor>();
            List<UserAccount> AirlineAccounts = new List<UserAccount>();

            foreach (var loc1 in _locations)
            {
                var NumHotels = new Random().Next(1, 3);

                for (int i = 0; i < NumHotels; i++)
                {

                    Contractor hotelManager = new Contractor();
                    hotelManager.Post = 2;
                    hotelManager.PostDescription = "Hotel Manager";
                    hotelManager.ContractorId = $"{loc1.LocationName}HotelManagerId{i}";

                    UserAccount HotelAccount = new UserAccount();
                    HotelAccount.AccountId = $"{loc1.LocationName}HotelAccountId{i}";
                    HotelAccount.UserId = hotelManager.ContractorId;

                    hotelManager.AccountId = HotelAccount.AccountId;
                    // create an contractor account for hotel
                    Hotel newHotel = new Hotel();
                    newHotel.HotelAccountId = HotelAccount.AccountId;
                    newHotel.HotelId = $"{loc1.LocationName}HotelId{i}";
                    newHotel.HotelLocationId = loc1.LocationId;
                    newHotel.HotelName = $"{loc1.LocationName}Hotel{i}";
                    newHotel.HotelReservationId = "";
                    newHotel.HotelRoomCode = 1;
                    newHotel.Id = i;

                    AirlineAccounts.Add(HotelAccount);
                    Hotels.Add(newHotel);

                    Managers.Add(hotelManager);
                }


                Contractor AirLineContractor = new Contractor();
                AirLineContractor.Post = 3;
                AirLineContractor.PostDescription = "Luxary Airliner";
                AirLineContractor.ContractorId = $"{loc1.LocationName}AirlinerContractorId{AirLineContractor.Id}";

                UserAccount AccountDetails = new UserAccount();
                AccountDetails.AccountId = $"{loc1.LocationName}AirlinesContractorAccountId{AirLineContractor.Id}";
                AccountDetails.UserId = AirLineContractor.ContractorId;


                AirLineContractor.AccountId = AccountDetails.AccountId;
                AirLineContractor.ContractorName = $"{loc1.LocationName}Airlines{AirLineContractor.Id}";

                Managers.Add(AirLineContractor);
                AirlineAccounts.Add(AccountDetails);



                foreach (var loc2 in _locations)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        int RandomAirline = new Random().Next(0, AirlineAccounts.Count);

                        Flight newFlight = new Flight();
                        newFlight.FlightId = $"{loc2.LocationName}FlightID{i}";
                        newFlight.FlightAccountId = AirlineAccounts[Math.Abs(RandomAirline)].AccountId;




                        Reservation flightDetails = new Reservation();
                        flightDetails.EndLocationId = loc1.LocationId;
                        flightDetails.StartLocationId = loc2.LocationId;

                        flightDetails.StartDateTime = DateTime.Now.AddHours(i);

                        FlightsForNow.Add(newFlight);
                    }

                }
            }
            for (int i = 0; i < FlightsForNow.Count; i++)
            {
                FlightsForNow[i].Id = i + 1;

            }

            for (int i = 0; i < Hotels.Count; i++)
            {
                Hotels[i].Id = i + 1;
            }

            details.FlightDetails = FlightsForNow;
            details.HotelDetails = Hotels;
            details.Managers = Managers;
            details.Accounts.AddRange(AirlineAccounts);


            return details;
        }

        public static List<(Contractor, UserAccount)> GetDrivers(List<Location> Cities)
        {

            List<(Contractor, UserAccount)> Drivers = new List<(Contractor, UserAccount)>();

            foreach (var city in Cities)
            {
                var NumDrivers = new Random().Next(15, 20);

                for (int i = 0; i < NumDrivers; i++)
                {


                    Contractor newDriver = new Contractor();
                    newDriver.Post = 1;
                    newDriver.PostDescription = "Driver Taxi";
                    newDriver.ContractorId = $"{city.LocationName}Driver{i}";
                    newDriver.ContractorName = $"{city.LocationName}Driver{i}";

                    UserAccount newAccount = new UserAccount();
                    newAccount.AccountId = $"{city.LocationName}DriverAccountID{i}";
                    newAccount.UserId = newDriver.ContractorId;

                    newDriver.AccountId = newAccount.AccountId;

                    Drivers.Add((newDriver, newAccount));

                }

            }

            return Drivers;
        }

        public static UserDetails GetSeededUsers()
        {

            List<UserAccount> Accounts = new List<UserAccount>();
            List<UserProfile> Profiles = new List<UserProfile>();

            for (int i = 0; i < 20; i++)
            {
                UserProfile newProfile = new UserProfile();

                UserAccount newAccount = new UserAccount();
                newAccount.Id = i;

                newProfile.UserName = $"TestUserName{i}";
                newProfile.UserId = $"TestUserId{i}";
                newProfile.NationalId = $"TestNationalId{i}";
                newProfile.PassportId = $"TestPassportId{i}";
                newProfile.UserEmail = $"Test{i}@gmal.com";
                newProfile.Id = i;

                newAccount.AccountId = $"AccountId{newAccount.Id}";
                newAccount.UserId = newProfile.UserId;

                Accounts.Add(newAccount);
                Profiles.Add(newProfile);
            }

            return new UserDetails { Accounts = Accounts, Profiles = Profiles };
        }
    }

    #endregion
}
