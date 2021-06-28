using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data;
using WebTemplate02.Data.DataModels.BookingModels;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.DataModels.ProfileModels;
using WebTemplate02.Data.Interfaces;
using WebTemplate02.Models;

namespace WebTemplate02.Controllers
{

    public class AdminController : Controller
    {
        private readonly IBookingRepository bookingRepo;
        private readonly IUserRepository userRepo;

        public AdminController(ILogger<HomeController> logger, IBookingRepository bookingRepo, IUserRepository UserRepo)
        {
            this.bookingRepo = bookingRepo;
            userRepo = UserRepo;
        }


        public IActionResult AdminConsole() {

            return View();
        }

        public IActionResult ViewLocations() {

            return View();
        }
        public IActionResult Index()
        {
            List<Data.DataModels.InternalModels.Location> locations = bookingRepo.GetLocations();
            List<Flight> flights = bookingRepo.GetAllFlight();
            List<Hotel> hotels = bookingRepo.GetAllHotels();
            List<Contractor> contractors = userRepo.GetAllContractors();
            List<Reservation> reservations = bookingRepo.GetAllReservation();
            List<AActivity> activities = bookingRepo.GetAllActivity();

            TempAdminViewModel AdminViewModel = new TempAdminViewModel();
            AdminViewModel.locations = locations;
            AdminViewModel.flights = flights;
            AdminViewModel.hotels = hotels;
            AdminViewModel.contractors = contractors;
            AdminViewModel.activities = activities;
            AdminViewModel.reservations = reservations;


            foreach (var User in userRepo.GetUserProfile())
            {
                ContractViewModelAdmin model = new ContractViewModelAdmin();
                var MyProfile = userRepo.GetUserProfileById(User.UserEmail);
                var AllDms = userRepo.GetDMs();
                var MyDms = AllDms.Where(m => m.RecipientId == MyProfile.UserId || m.SenderId == MyProfile.UserId).ToList();

                if (MyDms.Count > 0)
                {
                    var UnReadMessages = MyDms.Where(m => m.TimeRead == null || m.TimeRead == new DateTime().Date).ToList();
                    MyDms.OrderBy(m => m.TimeSend);

                model.Username = User.UserEmail;
                model.Conversation = MyDms;
                model.LastMessageSent = MyDms[0].Message;
                model.TimeLastMessageSent = MyDms[0].TimeSend;
                AdminViewModel.adminDms.Add(model);
                }

            }

            return View("AdminConsole", AdminViewModel);
        }


        public IActionResult AddSpecial(TempAdminViewModel model) {

            Post newPost = new Post();
            newPost.Description = model.GetDescription();
            newPost.Message = model.NewSpecial;
            newPost.PostId = Guid.NewGuid().ToString();
            newPost.SenderId = User.Identity.Name ;
            newPost.TimeSend = DateTime.Now;


            userRepo.AddPosts(newPost);

            return View("Home/Index");
        }


        [HttpGet]
        public IActionResult TextClient(string id) {

            ConversationAdmin model = new ConversationAdmin();
            var MyProfile = userRepo.GetUserProfileById(id);
            var AllDms = userRepo.GetDMs();
            var MyDms = AllDms.Where(m => m.RecipientId == MyProfile.UserId || m.SenderId == MyProfile.UserId).ToList();

            if (MyDms.Count > 0)
            {
                var UnReadMessages = MyDms.Where(m => m.TimeRead == null || m.TimeRead == new DateTime().Date).ToList();
                MyDms.OrderBy(m => m.TimeSend);

            }
            var AgentProfile = userRepo.GetUserProfileById(User.Identity.Name);
            model.UserName = AgentProfile.UserId;
            model.Conversation = MyDms;
            model.ClientName = MyProfile.UserEmail;
            model.UserId = MyProfile.UserId;

            return View(model);
        }

        [HttpPost]
        public IActionResult TextClientSend(ConversationAdmin model) {

            var MyProfile = userRepo.GetUserProfileById(model.ClientName);
            var AgentProfile = userRepo.GetUserProfileById(User.Identity.Name);
            DM newDM = new DM();

            newDM.Message = model.Message;
            newDM.TimeSend = DateTime.Now;
            newDM.SenderId = AgentProfile.UserId;
            newDM.RecipientId = MyProfile.UserId;
            newDM.DMId = Guid.NewGuid().ToString();
            userRepo.AddDMs(newDM);

            var AllDms = userRepo.GetDMs();
            var MyDms = AllDms.Where(m => m.RecipientId == MyProfile.UserId || m.SenderId == MyProfile.UserId).ToList();

            if (MyDms.Count > 0)
            {
                var UnReadMessages = MyDms.Where(m => m.TimeRead == null || m.TimeRead == new DateTime().Date).ToList();
                MyDms.OrderBy(m => m.TimeSend);


            }
            model.Conversation = MyDms;
 
            model.UserId = AgentProfile.UserEmail;
            model.ClientName = MyProfile.UserEmail;
            model.UserName = AgentProfile.UserId;


            return View("TextClient",model);
        }
    }
}
