using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;


namespace ReservationsProgram
{
    class Program
    {
        static void Main(string[] args)
        {



            WriteLine("********Welcome to the Hotel Reservation System********");
            WriteLine("=======================================================\n");

            List<Reservation> reservation = new List<Reservation>();

            char menu = 'y';
            while (menu == 'y')
            {
                WriteLine("Please Select a User: \n");
                WriteLine("1. Front Desk \n2. Admin");
                int userType = Convert.ToInt32(ReadLine());

                if (userType == 1)
                {
                    WriteLine("Password: \n");
                    string fdPassword = ReadLine();

                    if (fdPassword == "You123")
                    {
                        WriteLine("What would you like to do?");
                        WriteLine("1. Create a new reservation\n2. View current reservations");
                        int fdChoice = Convert.ToInt32(ReadLine());

                        if (fdChoice == 1)
                        {
                            char moreReservs = 'y';
                            while (moreReservs == 'y')
                            {
                                WriteLine("Please enter the reservation information as prompted.");
                                MakeReservation(ref reservation);

                                WriteLine("Do you want to create another reservation? y/n");
                                moreReservs = Convert.ToChar(ReadLine());
                            }

                            WriteLine("Reservation entry complete. Here is a list of current reservations: ");
                            WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}", "Name", "Subtotal", "Tax", "Grand Total");

                            foreach (Reservation r in reservation)
                            {
                                WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}", r.name, r.subTotal.ToString("C"), r.taxRate.ToString("C"), r.totalCost.ToString("C"));

                            }
                        }//end if fdChoice==1
                        else if (fdChoice == 2)
                        {
                            WriteLine("Here is a list of current reservations: ");
                            WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}", "Name", "Subtotal", "Tax", "Grand Total");

                            foreach (Reservation r in reservation)
                            {
                                WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}", r.name, r.subTotal.ToString("C"), r.taxRate.ToString("C"), r.totalCost.ToString("C"));

                            }
                        }//end if choice2
                        else
                        {
                            WriteLine("Invalid Selection");
                        }
                    }//end if fdPassword=="you123"

                }//end if usertype==1
                else if (userType == 2)
                {
                    char adminControl = 'y';
                    while(adminControl== 'y')
                    {
                        WriteLine("Would you like to:\n1. View a reservation\n2. Modify a reservation");
                        int modChoice = Convert.ToInt32(ReadLine());

                        if (modChoice == 1)
                        {
                            int viewChoice = 0;
                            WriteLine("Please enter the number of the reservation you want to view.");
                            for (int z = 0; z < reservation.Count; z++)
                            {
                                WriteLine(z + 1 + " " + reservation[z].name);
                            }
                            viewChoice = Convert.ToInt32(ReadLine());
                            WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,10}", reservation[viewChoice - 1].name, reservation[viewChoice - 1].address, reservation[viewChoice - 1].phone, reservation[viewChoice - 1].email, reservation[viewChoice - 1].typeRoom, reservation[viewChoice - 1].typeExtras, reservation[viewChoice - 1].DurationDays);
                        }//endmodChoice1
                        else if (modChoice == 2)
                        {
                            WriteLine("Please enter the number of the reservation you want to modify.");
                            for (int z = 0; z < reservation.Count; z++)
                            {
                                WriteLine(z + 1 + " " + reservation[z].name);

                            }
                            int editChoice = Convert.ToInt32(ReadLine());
                            WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,10}", reservation[editChoice - 1].name, reservation[editChoice - 1].address, reservation[editChoice - 1].phone, reservation[editChoice - 1].email, reservation[editChoice - 1].typeRoom, reservation[editChoice - 1].typeExtras, reservation[editChoice - 1].DurationDays);

                            WriteLine("Which part of the reservation would you like to modify?");
                            WriteLine("1. Name\n2. Address\n3. Phone Number\n4. Email Address\n5. Room Type\n6. Extras\n7. Stay Duration");
                            int resChange = Convert.ToInt32(ReadLine());

                            switch (resChange)
                            {
                                case 1:
                                    WriteLine("What is the correct name for this reservation?");
                                    string newName = ReadLine();
                                    reservation[editChoice-1].name= newName;
                                    break;
                                case 2:
                                    WriteLine("What is the correct address for this reservation?");
                                    string newAddress = ReadLine();
                                    reservation[editChoice - 1].address = newAddress;
                                    break;
                                case 3:
                                    WriteLine("What is the correct phone number for this reservation?");
                                    string newPhone = ReadLine();
                                    reservation[editChoice - 1].phone = newPhone;
                                    break;
                                case 4:
                                    WriteLine("What is the correct email address for this reservation?");
                                    string newEmail = ReadLine();
                                    reservation[editChoice - 1].email = newEmail;
                                    break;
                                case 5:
                                    WriteLine("What is the correct room type for this reservation?");
                                    int newRoom = Convert.ToInt32(ReadLine());
                                    reservation[editChoice - 1].typeRoom = newRoom;
                                    break;
                                case 6:
                                    WriteLine("What is the correct type of extra for this reservation?");
                                    int newExtra = Convert.ToInt32(ReadLine());
                                    reservation[editChoice - 1].typeExtras = newExtra;
                                    break;
                                case 7:
                                    WriteLine("What is the correct duration for this reservation?");
                                    int newDuration = Convert.ToInt32(ReadLine());
                                    reservation[editChoice - 1].DurationDays = newDuration;
                                    break;
                            }//endswitch
                        }//endif modchoice 2

                    }WriteLine("Would you like to do view or modify additional reservations? y/n");
                    adminControl = Convert.ToChar(ReadLine());
                }
                else
                {
                    WriteLine("Invalid Selection.");
                }

                WriteLine("Back to menu? y/n");
              
            }//endwhile

           

            ReadKey();
                    
        }//end main

        public static void MakeReservation(ref List<Reservation> r)
        {

            //Here is where we are reading in a file
            //We are reading in a file and creating an object
            var listOfRoomTypes = File.ReadLines("RoomType.csv").Select(line => new RoomType(line)).ToList();
            // One line above this one is reading from the RoomType csv file and turning it into a list
            var listOfExtras = File.ReadLines("Extras.csv").Select(line => new Extras(line)).ToList();

            WriteLine("Customer Name: ");
            string name = ReadLine();
            WriteLine("Customer Address: ");
            string address = ReadLine();
            WriteLine("Customer Phone Number: ");
            string phone = ReadLine();
            WriteLine("Customer Email: ");
            string email = ReadLine();
            WriteLine("Room Type: ");
            //to print out a list of these objects, we can use a for each loop
            foreach (RoomType rt in listOfRoomTypes)
            {
                WriteLine($"{rt.RoomTypeID}\t{rt.RoomTypeName}\t{rt.RoomView}\t{rt.RoomCost}");
            }

            int roomIdSelect = Convert.ToInt32(ReadLine());//this variable is literally the room ID number, chosen by user
            string roomTypeSelect = listOfRoomTypes[roomIdSelect - 1].RoomTypeName;//this is the type of room, string name form
            string roomViewSelect = listOfRoomTypes[roomIdSelect - 1].RoomView;
            double roomCostSelect = listOfRoomTypes[roomIdSelect - 1].RoomCost;//Cost of room to use for calculations

            WriteLine("Extras: ");
            foreach (Extras ex in listOfExtras)
            {
                WriteLine($"{ex.ExtrasID}\t{ex.ExtrasName}\t{ex.ExtrasCost}");
            }

            int extraIdSelect = Convert.ToInt32(ReadLine());//this is the extra ID number that the user chooses
            string extraNameSelect = listOfExtras[extraIdSelect - 1].ExtrasName;
            double extraCostSelect = listOfExtras[extraIdSelect - 1].ExtrasCost;//Cost of extra to use for calculations

            WriteLine("Duration of Stay: ");
            int durationStay = Convert.ToInt32(ReadLine());

            double taxRate = 0.06;

            double subTotal = (roomCostSelect + extraCostSelect) * durationStay;

            double totalCost = (taxRate * subTotal) + subTotal;

            r.Add(new Reservation(name, address, phone, email, roomIdSelect, extraIdSelect, durationStay, taxRate, subTotal, totalCost));


        }//method

        public static void modifyReservation(ref Reservation m)
        {
            WriteLine("Which part of the reservation would you like to modify?");
            WriteLine("1. Name\n2. Address\n3. Phone Number\n4. Email Address\n5. Room Type\n6. Extras\n7. Stay Duration");

            int choice = Convert.ToInt32(ReadLine());
            switch (choice)
            {
                case 1:
                    WriteLine("What is the correct name for this reservation?");
                    string newName = ReadLine();//Read choice into a variable
                    m.name = newName;//Tell the program that we are modifying the [name] of the reservation to be the value stored in newName
                    break;

                case 2:
                    WriteLine("What is the correct address for this reservation?");
                    string newAddress = ReadLine();
                    m.address = newAddress;
                    break;

                case 3:
                    WriteLine("What is the correct phone number for this reservation?");
                    string newPhone = ReadLine();
                    m.phone = newPhone;
                    break;

                case 4:
                    WriteLine("What is the correct email address for this reservation?");
                    string newEmail = ReadLine();
                    m.email = newEmail;
                    break;

                case 5:
                    WriteLine("What is the correct room type for this reservation?");//we are dealing with the ID number corresponding to room type, it lives in the Reservation class as typeRoom = rt
                    int newRoomID = Convert.ToInt32(ReadLine());
                    m.typeRoom = newRoomID;

                    break;

                case 6:
                    WriteLine("What is the correct Extra for this reservation?");//same as room type - dealing with an ID number
                    int newExtraID = Convert.ToInt32(ReadLine());
                    m.typeExtras = newExtraID;
                    break;

                case 7:
                    WriteLine("What is the correct stay duration for this reservation?");
                    int newDuration = Convert.ToInt32(ReadLine());
                    m.DurationDays = newDuration;
                    break;

            }//switch

        }//method
    } 
}
