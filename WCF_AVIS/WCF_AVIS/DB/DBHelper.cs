using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_AVIS
{
    public class DBHelper
    {
        IDB DataBase = new WCF_AVIS.DB.FakeDB();

        public string GenerateReservationNumber()
        {
            string newReservationNumber = "";
            DataBase.GetReservations();
            // SOMETHING THAT I CAN'T FIGURE OUT
            return newReservationNumber;
        }

        public bool Search(string s1, string s2)
        {
            if (CompareStrings(s1, s2) || CompareStrings(s2, s1))
            {
                return true;
            }
            return false;
        }

        private bool CompareStrings(string s1, string s2)
        {
            string s1Up = s1.ToUpper();
            string s2Up = s2.ToUpper();
            string tester = "";
            for (int i = 0; i < s1Up.Length - 3; i++)
            {
                try
                {
                    tester = s1Up[i].ToString() + s1Up[i + 1].ToString() + s1Up[i + 2].ToString() +
                             s1Up[i + 3].ToString();
                    if (s2Up.Contains(tester))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

    }
}