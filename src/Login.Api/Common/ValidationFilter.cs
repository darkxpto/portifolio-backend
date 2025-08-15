using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Login.Api.Common
{
    public class ValidationFilter : IActionFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var arg in context.ActionArguments.Values)
            {
                if (arg == null) continue;

                var validatorType = typeof(IValidator<>).MakeGenericType(arg.GetType());
                var validator = _serviceProvider.GetService(validatorType);

                if (validator is IValidator val)
                {
                    var validationResult = val.Validate(new ValidationContext<object>(arg));

                    if (!validationResult.IsValid)
                    {
                        context.Result = new BadRequestObjectResult(validationResult.Errors);
                        return;
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
