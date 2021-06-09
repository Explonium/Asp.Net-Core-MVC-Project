using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Services;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewComponents
{
    [ViewComponent(Name = "Payment")]
    public class PaymentComponent : ViewComponent
    {
        private readonly IRequestService _requestService;

        public PaymentComponent(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
