using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Services;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewComponents
{
    [ViewComponent(Name = "SequrityInfo")]
    public class SequrityInfoComponent : ViewComponent
    {
        private readonly IRequestService _requestService;

        public SequrityInfoComponent(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
