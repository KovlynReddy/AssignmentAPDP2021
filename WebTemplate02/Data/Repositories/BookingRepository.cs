using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.BookingModels;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.Interfaces;

namespace WebTemplate02.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public ApplicationDbContext _Db { get; set; }
        public BookingRepository(ApplicationDbContext db)
        {
            this._Db = db;
        }
        public AActivity AddActivity(AActivity newAccount)
        {
            throw new NotImplementedException();
        }

        public Task<AActivity> AddActivityAsync(AActivity newAccount)
        {
            throw new NotImplementedException();
        }

        public BookingPackage AddBooking(BookingPackage newAccount)
        {
            this._Db.Packages.Add(newAccount);
            _Db.SaveChanges();

            return GetBooking(newAccount);

        }

        public Task<BookingPackage> AddBookingAsync(BookingPackage newAccount)
        {
            throw new NotImplementedException();
        }

        public Flight AddFlight(Flight newAccount)
        {
            this._Db.Flights.Add(newAccount);
            _Db.SaveChanges();

            return GetFlight(newAccount);
        }

        public Task<Flight> AddFlightAsync(Flight newAccount)
        {
            throw new NotImplementedException();
        }

        public Hotel AddHotel(Hotel newAccount)
        {
            this._Db.Hotels.Add(newAccount);
            _Db.SaveChanges();

            return GetHotel(newAccount);
        }

        public Task<Hotel> AddHotelAsync(Hotel newAccount)
        {
            throw new NotImplementedException();
        }

        public Location AddLocation(Location newAccount)
        {
            this._Db.Locations.Add(newAccount);

            _Db.SaveChanges();

            return GetLocation(newAccount);
        }

        public Task<Location> AddLocationAsync(Location newAccount)
        {
            throw new NotImplementedException();
        }

        public Reservation AddReservation(Reservation newAccount)
        {
            this._Db.Reservations.Add(newAccount);
            _Db.SaveChanges();

            return GetReservation(newAccount);
        }

        public Task<Reservation> AddReservationAsync(Reservation newAccount)
        {
            throw new NotImplementedException();
        }

        public AActivity DeleteActivity(AActivity Account)
        {
            throw new NotImplementedException();
        }

        public Task<AActivity> DeleteActivityAsync(AActivity Account)
        {
            throw new NotImplementedException();
        }

        public BookingPackage DeleteBooking(BookingPackage Account)
        {
            throw new NotImplementedException();
        }

        public Task<BookingPackage> DeleteBookingAsync(BookingPackage Account)
        {
            throw new NotImplementedException();
        }

        public Flight DeleteFlight(Flight Account)
        {
            throw new NotImplementedException();
        }

        public Task<Flight> DeleteFlightAsync(Flight Account)
        {
            throw new NotImplementedException();
        }

        public Hotel DeleteHotel(Hotel Account)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> DeleteHotelAsync(Hotel Account)
        {
            throw new NotImplementedException();
        }

        public Location DeleteLocation(Location Account)
        {
            throw new NotImplementedException();
        }

        public Task<Location> DeleteLocationAsync(Location Account)
        {
            throw new NotImplementedException();
        }

        public Reservation DeleteReservation(Reservation Account)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> DeleteReservationAsync(Reservation Account)
        {
            throw new NotImplementedException();
        }

        public AActivity GetActivity(AActivity Account)
        {
            throw new NotImplementedException();
        }

        public Task<AActivity> GetActivityAsync(AActivity Account)
        {
            throw new NotImplementedException();
        }

        public AActivity GetActivityById(string AccountId)
        {
            throw new NotImplementedException();
        }

        public Task<AActivity> GetActivityByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }

        public List<AActivity> GetAllActivity()
        {
            var foundUser = _Db.Tours.ToList();

            return foundUser;
        }
        
        public List<BookingPackage> GetBookingsById(string id)
        {
            var foundUser = _Db.Packages.Where(b => b.UserId == id).ToList();

            return foundUser;
        }
           public List<BookingPackage> GetBookingsByUserId(string id)
        {
            var foundUser = _Db.Packages.Where(b => b.UserId == id).ToList();

            return foundUser;
        }

        public Task<List<AActivity>> GetAllActivitysAsync()
        {
            throw new NotImplementedException();
        }

        public List<BookingPackage> GetAllBookings()
        {
            var foundUser = _Db.Packages.ToList();

            return foundUser;
        }

        public Task<List<BookingPackage>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetAllFlight()
        {
            var foundUser = _Db.Flights.ToList();

            return foundUser;
        }

        public Task<List<Flight>> GetAllFlightsAsync()
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotels()
        {
            var foundUser = _Db.Hotels.ToList();

            return foundUser;
        }

        public Task<List<Hotel>> GetAllHotelsAsync()
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllReservation()
        {
            var foundUser = _Db.Reservations.ToList();

            return foundUser;
        }

        public Task<List<Reservation>> GetAllReservationsAsync()
        {
            throw new NotImplementedException();
        }

        public BookingPackage GetBooking(BookingPackage Account)
        {
            return _Db.Packages.Where(m => m.BookingId == Account.BookingId).FirstOrDefault();
        }

        public Task<BookingPackage> GetBookingAsync(BookingPackage Account)
        {
            throw new NotImplementedException();
        }

        public BookingPackage GetBookingById(string AccountId)
        {
            return _Db.Packages.Where( m => m.BookingId == AccountId).FirstOrDefault();
        }        
        
        public List<BookingPackage> GetBookingByUserId(string AccountId)
        {
            return _Db.Packages.Where( m => m.UserId == AccountId).ToList();
        }

        public Task<BookingPackage> GetBookingByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }

        public Flight GetFlight(Flight Account)
        {
            return _Db.Flights.Where(m => m.FlightId == Account.FlightId).FirstOrDefault();
        }

        public Task<Flight> GetFlightAsync(Flight Account)
        {
            throw new NotImplementedException();
        }

        public Flight GetFlightById(string AccountId)
        {
            return _Db.Flights.Where(m => m.FlightId == AccountId).FirstOrDefault();
        }  
        

        public Task<Flight> GetFlightByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }

        public Hotel GetHotel(Hotel Account)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetHotelAsync(Hotel Account)
        {
            throw new NotImplementedException();
        }

        public Hotel GetHotelById(string AccountId)
        {
            return _Db.Hotels.Where(m => m.HotelId == AccountId).FirstOrDefault();
        }

        public Task<Hotel> GetHotelByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(Location Account)
        {
            return _Db.Locations.Where(m => m == Account).FirstOrDefault();
        }

        public List<Location> GetLocations()
        {
            var foundUser = _Db.Locations.ToList();

            return foundUser;
        }

        public Task<Location> GetLocationAsync(Location Account)
        {
            throw new NotImplementedException();
        }

        public Task<List<Location>> GetLocationAsync()
        {
            throw new NotImplementedException();
        }

        public Location GetLocationById(string AccountId)
        {
            return _Db.Locations.Where(m => m.LocationId == AccountId).FirstOrDefault();
        }

        public Task<Location> GetLocationByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservation(Reservation Account)
        {
            return _Db.Reservations.Where(m => m.ReservationId == Account.ReservationId).FirstOrDefault();
        }

        public Task<Reservation> GetReservationAsync(Reservation Account)
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationById(string AccountId)
        {
            return _Db.Reservations.Where(m => m.ReservationId == AccountId).FirstOrDefault();
        }   
        public List<Reservation> GetReservationByUserId(string AccountId)
        {
            return _Db.Reservations.Where(m => m.UserProfileId == AccountId).ToList();
        }

        public Task<Reservation> GetReservationByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }
    }
}
