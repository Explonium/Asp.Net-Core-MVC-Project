using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Services;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewComponents
{
    [ViewComponent(Name = "ContactInfo")]
    public class ContactInfoComponent : ViewComponent
    {
        private readonly IRequestService _requestService;

        public ContactInfoComponent(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
