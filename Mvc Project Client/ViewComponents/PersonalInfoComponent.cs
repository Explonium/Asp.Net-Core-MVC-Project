using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewComponents
{
    [ViewComponent(Name = "PersonalInfo")]
    public class PersonalInfoComponent : ViewComponent
    {
        private readonly IRequestService _requestService;

        public PersonalInfoComponent(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var info = await _requestService.Get<UserProfilePersonalInfo>("MyInformation");

            return View(info);
        }
    }
}
