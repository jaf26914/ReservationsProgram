using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationsProgram
{
    class Reservation
    {
        public Reservation(string na, string ad, string ph, string em, int rt, int ex, int dr, double tr, double st, double tc)
        {
            name = na;
            address = ad;
            phone = ph;
            email = em;
            typeRoom = rt;
            typeExtras = ex;
            DurationDays = dr;
            taxRate = tr;
            subTotal = st;
            totalCost = tc;
        }

        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int typeRoom { get; set; }
        public int typeExtras { get; set; }
        public int DurationDays { get; set; }
        public double taxRate { get; set; }
        public double subTotal { get; set; }
        public double totalCost { get; set; }

        
    }
}
