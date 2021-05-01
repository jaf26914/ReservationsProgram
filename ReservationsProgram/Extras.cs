using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationsProgram
{
    class Extras
    {
        public Extras(string line)
        {
            var split = line.Split(',');
            ExtrasID = Convert.ToInt32(split[0]);
            ExtrasName = split[1];
            ExtrasCost = Convert.ToDouble(split[2]);
        }

        public int ExtrasID { get; set; }

        public string ExtrasName { get; set; }

        public double ExtrasCost { get; set; }
    }
}
