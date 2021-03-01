using DotNetCoreFive_MVC_Project.Models;
using DotNetCoreFive_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotNetCoreFive_MVC_Project.Controllers
{
    //Testing this class
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Education { get; set; }
        private static List<Person> _listPerson;
        static Person()
        {
            List<Person> p = new List<Person>()
            {
                new Person(){ID = 1, Name = "iamtuse", Occupation = "developer", Education = "Bsc IT"},
                new Person(){ID = 2, Name = "mike", Occupation = "developer", Education = "Bsc CS"},
            };
            _listPerson = new List<Person>(p);
        }
        public static Person GetPerson(int id)
        {
            var p = _listPerson.FirstOrDefault((p) => p.ID == id);
            if (p != null)
            {
                return p;
            }
            return null;
        }

    }
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger _logger;

        public HomeController(ICustomerRepository customerRepository,
            IWebHostEnvironment webHostEnvironment,
            ILogger<HomeController> logger)
        {
            _customerRepository = customerRepository;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _customerRepository.GetListOfCustomers();
            return View(model);
        }
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            
            _logger.LogTrace("Log Trace");
            _logger.LogDebug("Log Debug");
            _logger.LogInformation("Log Inforamtion");
            _logger.LogWarning("Log Warning");
            _logger.LogError("Log Error");
            _logger.LogCritical("Log Critical");
            //throw new Exception("Error occured on the Details page, threw by the developer!");
            Customer customer = _customerRepository.GetCustomer(id.Value);
            if (customer == null)
            {
                Response.StatusCode = 404;
                ViewBag.Title = "404 Error";
                return View("CustomerNotFound", id);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Customer = customer,
                PageTitle = "Customer Information!"
            };
            ViewBag.Title = "Customer Details";
            return View(homeDetailsViewModel);

        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Title = "Create New Customer";
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Customer customer = new Customer()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Agent = model.Agent,
                    PhotoPath = uniqueFileName
                };
                Customer newCustomer = _customerRepository.Create(customer);
                return RedirectToAction("details", new { id = newCustomer.ID });
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer customer = _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                Response.StatusCode = 404;
                ViewBag.Title = "404 Error";
                return View("CustomerNotFound", id);
            }
            EditCustomerViewModel editCustomerViewModel = new EditCustomerViewModel()
            {
                Id = customer.ID,
                Name = customer.Name,
                Email = customer.Email,
                Agent = customer.Agent,
                ExistingPhotoPath = customer.PhotoPath
            };

            ViewBag.Title = "Edit Customer";
            return View(editCustomerViewModel);
        }
        [HttpPost]
        public ActionResult Edit(EditCustomerViewModel model)
        {
            Customer updatedCustomer = _customerRepository.GetCustomer(model.Id);
            updatedCustomer.Name = model.Name;
            updatedCustomer.Email = model.Email;
            updatedCustomer.Agent = model.Agent;
            if (model.Photos != null)
            {
                if (model.ExistingPhotoPath != null)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                    System.IO.File.Delete(path);
                }

                model.ExistingPhotoPath = ProcessUploadedFile(model);
                updatedCustomer.PhotoPath = model.ExistingPhotoPath;
            }


            _customerRepository.Update(updatedCustomer);
            return RedirectToAction("Index");
        }
        private string ProcessUploadedFile(CustomerCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile file in model.Photos)
                {
                    string rootDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid() + "_" + model.Photos.Single().FileName;
                    string filePath = Path.Combine(rootDirectory, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }

            }

            return uniqueFileName;
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customer findCustomer = _customerRepository.GetCustomer(id);
            if (findCustomer == null)
            {
                Response.StatusCode = 404;
                ViewBag.Title = "404 Error";
                return View("CustomerNotFound", id);
            }

            ViewBag.Title = "Delete Customer";
            return View(findCustomer);

        }
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            Customer deleteCustomer = _customerRepository.Delete(customer.ID);
            if (deleteCustomer != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return NotFound();
        }
        //Testing this Data Method
        //As an Api Service!!
        public ObjectResult Data()
        {
            return new ObjectResult(Person.GetPerson(2));
        }
        public IEnumerable<string> ApiData()
        {
            return StringsApi;
        }
        public string Search()
        {
            return "iamtuseTheProgrammertech.com";
        }
        public static string[] StringsApi
        {
            get
            {
                string[] listOfNames = { "Hello World", "Programming is awesome!", "I love writing applications!" };
                return listOfNames;
            }
            private set { StringsApi = value; }
        }

    }
}
