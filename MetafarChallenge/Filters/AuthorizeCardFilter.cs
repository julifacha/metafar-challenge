using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace MetafarChallenge.Filters
{
    public class AuthorizeCardFilter : IAuthorizationFilter
    {
        private readonly ICurrentCustomerAccesor _currentCustomerAccesor;
        public AuthorizeCardFilter(ICurrentCustomerAccesor currentCustomerAccesor)
        {
            _currentCustomerAccesor = currentCustomerAccesor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int cardNumberFromRequest = Convert.ToInt32(context.HttpContext.Request.RouteValues["cardNumber"]);
            int cardNumberFromToken = _currentCustomerAccesor.CardNumber;

            if (cardNumberFromRequest != cardNumberFromToken)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }

    public class AuthorizeCardAttribute : TypeFilterAttribute
    {
        public AuthorizeCardAttribute() : base(typeof(AuthorizeCardFilter))
        {
        }
    }
}
