using ThirdPartyDbWebAPI.ModelsView;
using ThirdPartyDbWebAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Http;

namespace ThirdPartyDbWebAPI.Controllers
{
    public class BookingsInfoController : ApiController
    {

        public List<BookingMini> GetBookings()
        {

            // call : http://localhost:57100/api/BookingsInfo/GetBookings


            // only the bookings with a travel date superior or equal to today need to be displayed because in theory the full cycle of a booking should have been completed by the travel date (cancellation or confirmation are unlikely after the travel date )

            List<BookingMini> listBookingMini = BookingsExtraction.ExtractBookingsFutureTravelling();
            return listBookingMini;

        }



        public List<BookingMini> GetBookingsPeriodSelected(string FromDate, string ToDate)
        {

            //  format for the date passed should be 2015-01-31
            //  API call : http://localhost:57100/api/BookingsInfo/GetBookingsPeriodSelected?FromDate=2015-01-31&ToDate=2015-05-06


            DateTime fDT = DateTime.ParseExact(FromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime tDT = DateTime.ParseExact(ToDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return BookingsExtraction.ExtractBookingsPeriodSelected(fDT, tDT);
        }



    }




}
