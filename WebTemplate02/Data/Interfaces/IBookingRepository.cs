using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.DataModels.BookingModels;

namespace WebTemplate02.Data.Interfaces
{
    public interface IBookingRepository
    {
        #region Locations

        Location AddLocation(Location newAccount);
        Location DeleteLocation(Location Account);
        Location GetLocation(Location Account);
        Location GetLocationById(string AccountId);
        List<Location> GetLocations();

        Task<Location> AddLocationAsync(Location newAccount);
        Task<Location> DeleteLocationAsync(Location Account);
        Task<Location> GetLocationAsync(Location Account);
        Task<Location> GetLocationByIdAsync(string AccountId);
        Task<List<Location>> GetLocationAsync();

        #endregion  
        
        #region Reservation

        Reservation AddReservation(Reservation newAccount);
        Reservation DeleteReservation(Reservation Account);
        Reservation GetReservation(Reservation Account);
        Reservation GetReservationById(string AccountId);
        List<Reservation> GetAllReservation();

        Task<Reservation> AddReservationAsync(Reservation newAccount);
        Task<Reservation> DeleteReservationAsync(Reservation Account);
        Task<Reservation> GetReservationAsync(Reservation Account);
        Task<Reservation> GetReservationByIdAsync(string AccountId);
        Task<List<Reservation>> GetAllReservationsAsync();

        #endregion

        #region Flights

        Flight AddFlight(Flight newAccount);
        Flight DeleteFlight(Flight Account);
        Flight GetFlight(Flight Account);
        Flight GetFlightById(string AccountId);
        List<Flight> GetAllFlight();

        Task<Flight> AddFlightAsync(Flight newAccount);
        Task<Flight> DeleteFlightAsync(Flight Account);
        Task<Flight> GetFlightAsync(Flight Account);
        Task<Flight> GetFlightByIdAsync(string AccountId);
        Task<List<Flight>> GetAllFlightsAsync();

        #endregion

        #region Activity

        AActivity AddActivity(AActivity newAccount);
        AActivity DeleteActivity(AActivity Account);
        AActivity GetActivity(AActivity Account);
        AActivity GetActivityById(string AccountId);
        List<AActivity> GetAllActivity();

        Task<AActivity> AddActivityAsync(AActivity newAccount);
        Task<AActivity> DeleteActivityAsync(AActivity Account);
        Task<AActivity> GetActivityAsync(AActivity Account);
        Task<AActivity> GetActivityByIdAsync(string AccountId);
        Task<List<AActivity>> GetAllActivitysAsync();

        #endregion

        #region Hotel

        Hotel AddHotel(Hotel newAccount);
        Hotel DeleteHotel(Hotel Account);
        Hotel GetHotel(Hotel Account);
        Hotel GetHotelById(string AccountId);
        List<Hotel> GetAllHotels();

        Task<Hotel> AddHotelAsync(Hotel newAccount);
        Task<Hotel> DeleteHotelAsync(Hotel Account);
        Task<Hotel> GetHotelAsync(Hotel Account);
        Task<Hotel> GetHotelByIdAsync(string AccountId);
        Task<List<Hotel>> GetAllHotelsAsync();

        #endregion
        
        #region Booking

        BookingPackage AddBooking(BookingPackage newAccount);
        BookingPackage DeleteBooking(BookingPackage Account);
        BookingPackage GetBooking(BookingPackage Account);
        BookingPackage GetBookingById(string AccountId);
        List<BookingPackage> GetBookingsById(string id);
        List<BookingPackage> GetBookingsByUserId(string id);
        List<BookingPackage> GetAllBookings();

        Task<BookingPackage> AddBookingAsync(BookingPackage newAccount);
        Task<BookingPackage> DeleteBookingAsync(BookingPackage Account);
        Task<BookingPackage> GetBookingAsync(BookingPackage Account);
        Task<BookingPackage> GetBookingByIdAsync(string AccountId);
        Task<List<BookingPackage>> GetAllBookingsAsync();

        #endregion

    }
}
