using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreFive_MVC_Project.Controllers
{
    //localhost:http://localhost:58255/about/index
    public class AboutController : Controller
    {

        public async Task Index()
        {
            await Response.HttpContext.Response.WriteAsync("<h1 style='text-align:center;color:red;font-Family:verdana;'>Hi, welcome the About Controller!</h1>");

        }
    }
}
