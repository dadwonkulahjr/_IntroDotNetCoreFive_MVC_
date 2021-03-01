using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetCoreFive_MVC_Project.HelperResource
{
    public static class LayoutHelper
    {
        public static string MenuHelper(this IHtmlHelper htmlHelper, string action=null, string controller=null)
        {
            const string cssClass = "active";
            var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            var currentController = (string)htmlHelper.ViewContext.RouteData.Values["controller"];

            if (string.IsNullOrEmpty(action))
                action = currentAction;
            if (string.IsNullOrEmpty(controller))
                controller = currentController;

            return controller == currentController && action == currentAction ? cssClass : string.Empty;
        }
    }
}
