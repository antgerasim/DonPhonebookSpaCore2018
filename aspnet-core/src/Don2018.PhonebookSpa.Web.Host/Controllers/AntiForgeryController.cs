using Microsoft.AspNetCore.Antiforgery;
using Don2018.PhonebookSpa.Controllers;

namespace Don2018.PhonebookSpa.Web.Host.Controllers
{
    public class AntiForgeryController : PhonebookSpaControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
