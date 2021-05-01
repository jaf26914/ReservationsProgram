using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationsProgram
{
    class RoomType
    {
        public RoomType(string line)
        {
            var split = line.Split(','); //Reading from CSV file, each column is separated by a comma. This tells it to split at the comma
            RoomTypeID = Convert.ToInt32(split[0]);//starts as string, ID is a number so we convert to INT here
            RoomTypeName = split[1];//no need to convert because this column of data is still a string 
            RoomView = split[2]; //Again, a string
            RoomCost = Convert.ToDouble(split[3]);//Convert to double here because money. Tax percentage being applied to total makes this necessary
        }

        public int RoomTypeID { get; set; }

        public string RoomTypeName { get; set; }

        public string RoomView { get; set; }

        public double RoomCost { get; set; }
    }
}
