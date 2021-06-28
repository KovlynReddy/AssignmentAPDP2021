using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data;
using WebTemplate02.Data.DataModels;
using WebTemplate02.Data.DataModels.Social;
using WebTemplate02.Data.Interfaces;
using WebTemplate02.Data.Repositories;
using MyDLL01.DataAccess.Excel;
using WebTemplate02.Models;
using WebTemplate02.Data.DataModels.BookingModels;
using WebTemplate02.Data.DataModels.ProfileModels;
using Microsoft.CodeAnalysis;
using WebTemplate02.Data.DataModels.InternalModels;

namespace WebTemplate02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookingRepository bookingRepo;
        private readonly IUserRepository userRepo;

        public HomeController(ILogger<HomeController> logger, IBookingRepository bookingRepo , IUserRepository UserRepo)
        {
            _logger = logger;
            userRepo = UserRepo;
            this.bookingRepo = bookingRepo;
        }

        [HttpGet]
        public IActionResult AdminConsole() {

            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = userRepo.GetUserProfile();
            var matchingUsers = users.Where(m => m.UserEmail == User.Identity.Name).ToList();
            if (matchingUsers.Count == 0  )
            {
                return View("CreateNewUser");
            }

            var posts = userRepo.GetPosts();

            List<PostViewModel> postsvm = new List<PostViewModel>();

            foreach (var post in posts)
            {
                PostViewModel pvm = new PostViewModel();
                pvm.ToPostView(post);
                postsvm.Add(pvm);


            }   

            return View(postsvm);
        }

        [HttpPost]
        public IActionResult AddNewProfile(UserProfile newUser) 
        {
            newUser.UserId = Guid.NewGuid().ToString();
            newUser.UserEmail = User.Identity.Name;

            var newAccount = new UserAccount();
            newAccount.UserId = newUser.UserId;
            newAccount.AccountId = Guid.NewGuid().ToString();
            newAccount.Balance = 0;

            userRepo.AddUserAccount(newAccount);
            userRepo.AddUserProfile(newUser);

           return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CreateUser(AlphaUser newUser ) {

            return View();
        }

        public IActionResult Test(string id) {

            return View("/Index");
        }
        
        [HttpGet("/TestConn")]
        public async Task<IActionResult> TestConn(string id) {

            //var newUser = userRepo.AddUser(user);

            //List<AlphaUser> Users = userRepo.GetAllUsers();

            //List<AlphaUser> Users = new List<AlphaUser>();
            //Users.Add(user);

            //MyDLL01.DataAccess.Excel.ExcelDataReader reader = new MyDLL01.DataAccess.Excel.ExcelDataReader(@"C:\Users\User\Documents\Projects\TestingGen\Demo.xlsx");
            //await reader.SaveData<AlphaUser>(Users,"Users");
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

            return View("AdminConsole", AdminViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ViewProfile() {

            ProfileViewModel profileModel = new ProfileViewModel();
            profileModel.MyProfile = userRepo.GetUserProfileById(User.Identity.Name);
            profileModel.BookingHistory = bookingRepo.GetBookingsByUserId(profileModel.MyProfile.UserEmail);
            profileModel.userAccount = userRepo.GetUserAccountById(profileModel.MyProfile.UserId);
            var ListHotelIds = profileModel.BookingHistory.Select(m => m.HotelId).ToList();
            var FlightIdList = profileModel.BookingHistory.Select( m => m.InFlightId ).ToList();
            FlightIdList.AddRange(profileModel.BookingHistory.Select( m => m.OutFlightId ).ToList());

            foreach (var item in FlightIdList)
            {
                profileModel.FlightHistory.Add(bookingRepo.GetFlightById(item));
            }
            foreach (var item in ListHotelIds)
            {
                var hotel = bookingRepo.GetHotelById(item);
              profileModel.HotelHistory.Add(hotel);
                profileModel.VisitHistory.Add(bookingRepo.GetLocationById(hotel.HotelLocationId));
            }


            return View(profileModel);
        }

        [HttpGet]
        public IActionResult Search() {

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

            return View(AdminViewModel);
        }
        [HttpGet]
        public IActionResult AboutUs() {

            return View();
        }

      

        public IActionResult GetUnReadMessages() {

            return View();
        }
    }
}
