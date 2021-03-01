using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreFive_MVC_Project.Controllers
{
    //localhost:http://localhost:58255/hey/index
    public class HeyController : Controller
    {
        public ViewResult Greetings()
        {
            ViewBag.Data = "Hello World";
            ViewBag.Say = "I love computer programming!";
            return View("SayHi");

        }
    }
}
