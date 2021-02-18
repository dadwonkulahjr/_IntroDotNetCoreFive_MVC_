using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreFive_MVC_Project.Controllers
{
    //localhost:http://localhost:58255/hey/index
    public class HeyController : Controller
    {
        public async Task Index()
        {
            await Response.HttpContext.Response.WriteAsync("<h1 style='text-align:center;color:red;font-Family:verdana;'>Hi, welcome the Hey Controller!</h1>");

        }
    }
}
