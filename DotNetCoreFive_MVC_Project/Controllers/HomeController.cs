using DotNetCoreFive_MVC_Project.Models;
using DotNetCoreFive_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    public class HomeController : Controller
    {
        private ICustomerRepository _customerRepository;

        public HomeController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public ViewResult Index()
        {
            var model = _customerRepository.GetListOfCustomers();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Customer = _customerRepository.GetCustomer(id??101),
                PageTitle = "Customer Details"
            };
            return View(homeDetailsViewModel);
         
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
