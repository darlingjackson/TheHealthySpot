using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using TheHealthySpot.Data;
using TheHealthySpot.Services;
using TheHealthySpot.ViewModels;

namespace TheHealthySpot.Controllers
{
    public class AppController : Controller //Make sure you add that this class derices form Controllers and add the name space
    {
        //Adding constructor to inject the service
        private readonly IMailServices _mailService;//initialize 
        private readonly IHealthyRepository _repository;
        public AppController(IMailServices mailService, IHealthyRepository repository)//pass in the services
        {
            _mailService = mailService;
            _repository = repository;
        }




        //this is called an action
        public IActionResult Index() //this is a method that retuns action result (ation result know how to map)
        {
            return View();//it will return your index view
        }
        
        [HttpGet("Contact")]//this allows you to have the defult route in startup but also have exceptions
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost("Contact")]//tells MVC what kind of request is coming in // this is being called post because the form is called post.
       public IActionResult Contact(ContactViewModel model) //The ContactViewModel model accept payloads from the contact page
        {
            if (ModelState.IsValid) //makes sure that the rules in the view model are being fallowed
            {
                //send the email
                _mailService.SendMessage("shawn@wildermuth.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");

                //Show that we sent the mail
                ViewBag.USerMessage = "Mail sent";

                //this is how to clear the form once the message is sent
                ModelState.Clear();
            }

            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }
    }
}
