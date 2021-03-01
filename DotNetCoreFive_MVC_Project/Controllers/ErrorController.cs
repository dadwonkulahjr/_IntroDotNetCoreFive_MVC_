using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace DotNetCoreFive_MVC_Project.Controllers
{
    [Route(template:"Error/{statusCode}")]
    public class ErrorController : Controller
    {
        private readonly ILogger _loggerService;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _loggerService = logger;
        }
        public ActionResult HandleStatuseCodeResponse(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "The url does not match any route in this application.\nPlease click the link below.";
                    _loggerService.LogError($"404 Error occured. Path = {statusCodeResult.OriginalPath}" +
                        $"The query strings = " + statusCodeResult.OriginalQueryString);
                    break;
                 default:
                    break;
                        
            }
            return View("NotFound");
        }

        [AllowAnonymous]
        [Route("/Error")]
        public ActionResult Error()
        {
            var result = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ErrorMessage = "An error occur please be patience our IT staff are working on the fix!";
            _loggerService.LogWarning($"An error occured. Full Path = {result.Path}" +
                $"Error = " + result.Error + $"Stack Trace = {result.Error.StackTrace}");
            return View("Error");
        }
    }
}
