using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace testTalent
{
    public class CheckIdMiddleware : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = context.ActionArguments["id"];

            if (id != null)
            {
                if (id.ToString() == "2")
                {
                    context.Result = new BadRequestObjectResult("مقدار شناسه  2 باشد .");
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Executed after the action method is called
        }
    }
}
