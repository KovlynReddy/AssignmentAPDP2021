using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.BookingModels;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.Interfaces;
using WebTemplate02.Models;

namespace WebTemplate02.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IUserRepository _userRepo;

        public BookingController(IBookingRepository bookingRepo, IUserRepository UserRepo)
        {
            this._bookingRepo = bookingRepo;
            _userRepo = UserRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Agent() {
            AgentChatModel model = new AgentChatModel();
            var MyProfile = _userRepo.GetUserProfileById(User.Identity.Name);
            var AllDms = _userRepo.GetDMs();
            var MyDms = AllDms.Where( m => m.RecipientId == MyProfile.UserId || m.SenderId == MyProfile.UserId ).ToList();

            if (MyDms.Count > 0 )
            {
            var UnReadMessages = MyDms.Where( m => m.TimeRead == null || m.TimeRead ==  new DateTime().Date ).ToList();
            MyDms.OrderBy(m => m.TimeSend);

            }
            model.Conversation = MyDms;
            model.Image = "";
            model.AgentName = "Agent 1 ";
            model.UserId = MyProfile.UserId;
            return View("AgentDM",model);

        }
        public IActionResult SendMessage(AgentChatModel model)
        {
            var MyProfile = _userRepo.GetUserProfileById(User.Identity.Name);
            DM newDM = new DM();
            string AgentId;
            if (model.Conversation.Count == 0)
            {
            AgentId = Guid.NewGuid().ToString();
            }
            else { 
            AgentId = (model.Conversation.First().RecipientId == newDM.SenderId) ? model.Conversation.First().SenderId : model.Conversation.First().RecipientId;
            }

            newDM.Message = model.Message;
            newDM.TimeSend = DateTime.Now;
            newDM.SenderId = MyProfile.UserId;
            newDM.RecipientId = AgentId;
            newDM.DMId = Guid.NewGuid().ToString();
            _userRepo.AddDMs(newDM);
            
            var AllDms = _userRepo.GetDMs();
            var MyDms = AllDms.Where(m => m.RecipientId == MyProfile.UserId || m.SenderId == MyProfile.UserId).ToList();

            if (MyDms.Count > 0)
            {
                var UnReadMessages = MyDms.Where(m => m.TimeRead == null || m.TimeRead == new DateTime().Date).ToList();
                MyDms.OrderBy(m => m.TimeSend);


            }
            model.Conversation = MyDms;
            model.Image = "";
            model.AgentName = "Agent 1 ";
            model.UserId = MyProfile.UserId;
            return View("AgentDM", model);
        }
        [HttpGet]
        public IActionResult Custom()
        {
            var hotels = _bookingRepo.GetAllHotels();
            var locations = _bookingRepo.GetLocations();
            var flights = _bookingRepo.GetAllFlight();
            var reservations = _bookingRepo.GetAllReservation();


            var hotelIds = hotels.Select(m => m.HotelId).ToList();
            var locationIds = locations.Select(m => m.LocationId).ToList();
           

            BaseBookingViewModel model = new BaseBookingViewModel();
          
            model.ListLocations = locations;
            model.ListHotels = hotels;

            model.ListReservations = reservations;

            return View("CustomBooking",model);

        }

        [HttpPost]
        public IActionResult BaseBooking(BaseBookingViewModel newBaseBooking) {

            var ListHotels = _bookingRepo.GetAllHotels();
            var ListLocations = _bookingRepo.GetLocations();

            newBaseBooking.ListLocations = ListLocations;

            if (newBaseBooking.HotelId == null)
            {
                newBaseBooking.ListHotels = ListHotels.Where(h => h.HotelLocationId == newBaseBooking.LocationOutId).ToList();
                return View("CustomBooking", newBaseBooking);
            }
            else {
                BookingPackage packageBase = new BookingPackage();
                packageBase.DurationDays = newBaseBooking.Duration;
                packageBase.HotelId = newBaseBooking.HotelId; 
                packageBase.BookingId = Guid.NewGuid().ToString(); 
                packageBase.InFlightId = newBaseBooking.LocationInId; 
                packageBase.OutFlightId = newBaseBooking.LocationOutId;
                packageBase.UserId = User.Identity.Name;


                Reservation FlightIn = new Reservation();
                FlightIn.StartLocationId = newBaseBooking.LocationInId ;
                FlightIn.ReservationId = Guid.NewGuid().ToString();
                FlightIn.UserProfileId = User.Identity.Name;
                FlightIn.StartDateTime = newBaseBooking.TimeIn;

                Reservation FlightOut = new Reservation();
                FlightOut.StartLocationId = newBaseBooking.LocationOutId;
                FlightOut.ReservationId = Guid.NewGuid().ToString();
                FlightOut.UserProfileId = User.Identity.Name;
                FlightOut.StartDateTime = newBaseBooking.TimeIn.AddDays(newBaseBooking.Duration);


                Flight InFlight = new Flight();
                InFlight.FlightAccountId = User.Identity.Name;
                InFlight.FlightId = Guid.NewGuid().ToString() ;
                InFlight.FlightReservationId = FlightOut.ReservationId; 
               
                Flight OutFlight = new Flight();
                OutFlight.FlightAccountId = User.Identity.Name;
                OutFlight.FlightId = Guid.NewGuid().ToString();
                OutFlight.FlightReservationId = FlightIn.ReservationId;

                packageBase.InFlightId = InFlight.FlightId;
                packageBase.OutFlightId = OutFlight.FlightId;

                _bookingRepo.AddFlight(InFlight);
                _bookingRepo.AddFlight(OutFlight);
              
                _bookingRepo.AddReservation(FlightIn);
                _bookingRepo.AddReservation(FlightOut);
                packageBase = _bookingRepo.AddBooking(packageBase);

                AddActivityToBaseBookingViewModel addmodel = new AddActivityToBaseBookingViewModel();
                addmodel.ListActivity = _bookingRepo.GetAllActivity();
                addmodel.baseModel = packageBase;
             
                addmodel.Total = 100 ;


                return View("AddActivities",addmodel);  
            }
           


        }

        [HttpGet]
        public IActionResult EditBaseBooking(BaseBookingViewModel model)
        {

            return View(model);
        }

        [HttpPost]
        public IActionResult AddActivities(AddActivityToBaseBookingViewModel activities) {
            var MyProfile = _userRepo.GetUserProfileById(User.Identity.Name);
            var booking = _bookingRepo.GetBookingById(activities.BookingId);
            var FlightOut = _bookingRepo.GetFlightById(booking.OutFlightId);
            var ReservationOut = _bookingRepo.GetReservationById(FlightOut.FlightReservationId);
            var LocationOut = _bookingRepo.GetLocationById(ReservationOut.StartLocationId);
            
            for (int i = 0; i < activities.DaysActivities.Length; i++)
            {
                var item = activities.DaysActivities[i];
            
               var Activity = _bookingRepo.GetActivityById(item);
                var newActivity = new AActivity();
                newActivity.BookingId = activities.BookingId;
                newActivity.ActivityId = Activity.ActivityId ;
                newActivity.ActivityDesciption = Activity.ActivityDesciption;
                var newReservation = new Reservation();
                newReservation.UserProfileId = MyProfile.UserId;
                newReservation.StartLocationId =  LocationOut.LocationName;
                newReservation.ReservationId = Guid.NewGuid().ToString();
                newReservation.StartDateTime = ReservationOut.StartDateTime.AddDays(i);
                newReservation.Notes = Activity.ActivityDesciption;
                newReservation.BookingId = booking.BookingId;

                newActivity.ReservationId = newReservation.ReservationId;
                newActivity.TourGuideId = "Sant Julià de LòriaDriver0";
                activities.Days.Add(newActivity);

                _bookingRepo.AddReservation(newReservation);
                _bookingRepo.AddActivity(newActivity);
            }

            return View();
        }
 
    }
}
