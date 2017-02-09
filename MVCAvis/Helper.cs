using MVCAvis.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAvis
{
    public class Helper
    {
        public Reservation calcReservationPrize(Reservation res)
        {
            
            
            int days = (res.EndDate - res.StartDate).Days;

            switch (res.BilCat.ID)
            {
                case 'A':
                    res.TotalPrize = 100 * days;
                    break;
                case 'B':
                    res.TotalPrize = 200 * days;
                    break;
                case 'C':
                    res.TotalPrize = 300 * days;
                    break;
                case 'I':
                    res.TotalPrize = 500 * days;
                    break;
                case 'O':
                    res.TotalPrize = 250 * days;
                    break;
                default:
                    res.TotalPrize = 1 * days;
                    break;
            }
            return res;
        }

        public string AssignReservationNumber(Reservation assignRes )
        {
            List<int> reservationNumbers = new List<int>();
            foreach (Reservation reservation in  new WcfService.AVISserviceClient().GetReservations())
            {
                string tempNum = reservation.Reservationsnummer.Substring(0, 6) + reservation.Reservationsnummer.Substring(8);
                int num = int.Parse(tempNum);
                reservationNumbers.Add(num);
            }
            reservationNumbers.Sort();
            int nextReservationnumber = reservationNumbers.Last() + 1;
            string returnstring = nextReservationnumber.ToString().Substring(0, 6) + "DK" + nextReservationnumber.ToString().Substring(6);

            return returnstring;


        }
    }
}
