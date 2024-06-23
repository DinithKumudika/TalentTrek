
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TalentTrek.Api.Models;

namespace TalentTrek.Api.Filters
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

                if (_serviceProvider.GetService(validatorType) is IValidator validator)
                {
                    var validationContext = new ValidationContext<object>(arg);
                    var result = validator.Validate(validationContext);

                    if (!result.IsValid)
                    {

                        context.Result = new BadRequestObjectResult(
                            new ReponseErrorModel
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                Description = "invalid request payload",
                                Errors = result.Errors
                            }
                        );
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

    }
}