using ThirdPartyDbWebAPI.ModelThirdPartyDb;
using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyDbWebAPI.ModelsView;

namespace ThirdPartyDbWebAPI.Utilities
{
    public static class BookingsExtraction
    {

        public static List<BookingMini> ExtractBookingsFutureTravelling()
        {
            using (TourplaniSEntities te = new TourplaniSEntities())
            {
                DateTime startTravelDate = DateTime.Today;
                IEnumerable<BHD> BkgsSelected = te.BHDs
                    .Where(b => b.TRAVELDATE >= startTravelDate)
                    .OrderBy(b => b.DATE_ENTERED);

                // projection and then send
                return BkgsSelected.Select(b => ProjectToBookingMini(b)).ToList();
            }
        }


        public static List<BookingMini> ExtractBookingsPeriodSelected(DateTime FromDate, DateTime ToDate)
        {
            using (TourplaniSEntities te = new TourplaniSEntities())
            {
                var bhdList = te.BHDs.Where(bhd => bhd.DATE_ENTERED >= FromDate && bhd.DATE_ENTERED <= ToDate)
                    .OrderBy(bhd => bhd.DATE_ENTERED)
                    .ToList();
                return bhdList.Select(bhd => ProjectToBookingMini(bhd)).ToList();
            }
        }


        public static BookingMini ProjectToBookingMini(BHD bTP)
        {
            BookingMini bm = new BookingMini() { };
            bm.FullReference = bTP.FULL_REFERENCE.Trim();
            bm.Status = bTP.STATUS.Trim();
            bm.Consultant = bTP.CONSULTANT.Trim();
            bm.Date_Entered = bTP.DATE_ENTERED;
            bm.Sales_Update = bTP.UDTEXT5.Trim();
            bm.BHD_ID = bTP.BHD_ID;

            return bm;
        }
    }




}
