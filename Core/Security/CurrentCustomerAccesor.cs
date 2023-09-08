using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Security
{
    public class CurrentCustomerAccesor : ICurrentCustomerAccesor
    {
        public CurrentCustomerAccesor(IHttpContextAccessor context)
        {
            if (context.HttpContext?.User?.FindFirstValue("CustomerId") == null || context.HttpContext?.User?.FindFirstValue("CardNumber") == null)
                throw new ArgumentNullException(nameof(context));

            CustomerId = int.Parse(context.HttpContext?.User?.FindFirstValue("CustomerId") ?? "0");
            CardNumber = int.Parse(context.HttpContext?.User?.FindFirstValue("CardNumber") ?? "0");
        }
        public int CustomerId { get; }
        public int CardNumber { get; }
    }
}
