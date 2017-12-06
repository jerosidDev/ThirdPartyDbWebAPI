using System.Collections.Generic;
using System.Web.Mvc;
using ThirdPartyDbWebAPI.ModelsView;
using ThirdPartyDbWebAPI.Utilities;


namespace ThirdPartyDbWebAPI.Controllers
{
    public class BookingsInfoMVCController : Controller
    {
        // GET: BookingsInfoMVC
        public ActionResult Index()
        {
            List<BookingMini> listBookingMini = BookingsExtraction.ExtractBookingsFutureTravelling();

            return View(listBookingMini);

        }


    }
}