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
            WriteLine("Please Select a User: \n");
            WriteLine("1. Front Desk \n2. Admin");
            List<Reservation> reservation = new List<Reservation>();
            int userType = Convert.ToInt32(ReadLine());

            if (userType == 1)
            {
                WriteLine("Password: \n");
                string fdPassword = ReadLine();
                if (fdPassword == "You123")
                {
                    //FrontDesk
                    //char moreReservs = 'y';
                    int counter = 0;

                    WriteLine("What would you like to do?");
                    WriteLine("1. Create a new reservation\n2. View current reservations");
                    int fdChoice = Convert.ToInt32(ReadLine());
                    if (fdChoice == 1)
                    {
                        char moreReservs = 'y';
                        while (moreReservs == 'y')
                        {
                            //The example line in the video was
                            //WriteLine("Let's get the items for item {0}"), counter ++1
                            WriteLine("Please make your reservation selection", counter + 1); //increase the counter by one on this loop

                            //create the method call for collect order - in this case for choosing room, possibly making reservation - double check this!!
                            MakeReservation(ref reservation);

                            WriteLine("Would you like to make another reservation? y/n");
                            moreReservs = Convert.ToChar(ReadLine());

                        }

                    }
                    else if (fdChoice == 2)
                    {
                        char moreViews = 'y';
                        while (moreViews == 'y')
                        {
                            WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}", "Name", "Subtotal", "Tax", "Grand Total");
                            foreach (Reservation r in reservation)
                            {
                                counter = 0;
                                WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}{4,-20}", counter, r.name, r.subTotal.ToString("C"), r.taxRate.ToString("C"), r.totalCost.ToString("C"));
                                counter++;
                            }
                            WriteLine("Which reservation would you like to view?");
                            //output the selected reservation here

                            WriteLine("Would you like to view another reservation? y/n");
                            fdChoice = Convert.ToChar(ReadLine());
                        }
                    }
                    WriteLine("What would you like to do?");
                    WriteLine("1. Create a new reservation\n2. View current reservations\n3. Change Users");
                    fdChoice = Convert.ToInt32(ReadLine());
                    if(fdChoice== 3)
                    {
                        WriteLine("Please Select a User: \n");
                        WriteLine("1. Front Desk \n2. Admin");
                        userType = Convert.ToInt32(ReadLine());
                    }
                    
                }
                
            }
            else if (userType == 2)
            {
                WriteLine("Password: \n");
                string adminPassword = ReadLine();
                if (adminPassword == "Rock456")
                {
                    //Admin
                    WriteLine("What would you like to do?");
                    WriteLine("1. View reservations\n2. Edit reservation\n3. Complete End of Day process");
                    int adminChoice = Convert.ToInt32(ReadLine());

                    if(adminChoice == 1)
                    {
                        int counter;
                        WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}", "Name", "Subtotal", "Tax", "Grand Total");
                        foreach (Reservation r in reservation)
                        {
                            counter = 0;
                            WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}{4,-20}", counter, r.name, r.subTotal.ToString("C"), r.taxRate.ToString("C"), r.totalCost.ToString("C"));
                            counter++;
                        }
                        WriteLine("Which reservation would you like to view?");
                        //output the selected reservation here
                        WriteLine("What would you like to do?");
                        WriteLine("1. View reservations\n2. Edit reservation\n3. Complete End of Day process");
                        adminChoice = Convert.ToInt32(ReadLine());
                    }
                    else if(adminChoice == 2)
                    {
                        WriteLine("Which reservation would you like to edit?");
                        //select reservation to edit
                        //edit reservation

                        WriteLine("What would you like to do?");
                        WriteLine("1. View reservations\n2. Edit reservation\n3. Complete End of Day process");
                        adminChoice = Convert.ToInt32(ReadLine());
                    }
                    else if(adminChoice == 3)
                    {
                        int counter;
                        foreach (Reservation r in reservation)
                        {
                            counter = 0;
                            WriteLine("{0,-10}{1,-10}{2,-20}{3,-20}{4,-20}", counter, r.name, r.subTotal.ToString("C"), r.taxRate.ToString("C"), r.totalCost.ToString("C"));
                            counter++;
                            //sum the totals of all reservations and display out.
                        }
                    }
                    else
                    {
                        WriteLine("Please enter a valid selection.");
                        WriteLine("What would you like to do?");
                        WriteLine("1. View reservations\n2. Edit reservation\n3. Complete End of Day process");
                        adminChoice = Convert.ToInt32(ReadLine());
                    }


                }
                else
                {
                    WriteLine("You have entered an incorrect password. Please try again.");
                    WriteLine("Password: \n");
                    adminPassword = ReadLine();
                }

            }
            else
            {
                WriteLine("Please make a valid selection.");
                WriteLine("1. Front Desk \n2. Admin");
                userType = Convert.ToInt32(ReadLine());

            }

            //from video on reading CSVs
            //char moreItems = 'y';
            //int counter = 0;          //not sure if we need to use a counter or not in actual program, but good to have just in case. 
            //while(moreItems == 'y') 
            //{
            //  WriteLine(Let's get the items for item{0}", counter+1);
            //create a method call for collecting order
            //  collectOrder(ref orders); 
            //pass this by reference
            //  counter ++;
            //writeline("would you like to continue y/n");
            //  moreItems = convert.toChar(readLine());
            //}
           
            //to show out orders, inside of the main, we are using a for loop to show out each order in the list.
            //Can we turn this into a module to be used by Front Desk and Admin? 
            //We also need to decide where an appropriate place for this is. First iteration is living in the frontDesk() to make sure it works. 

            ReadKey();
        }//end main

        public static void frontDesk()
        {
            //Front desk will enter Name, Address, phone, email, room type, extras, and length of stay
            //use object data for menus
            //View existing reservations, but can not update, only admin can update
            //In the view it should show subtotal, tax (6%), and grand total for the room.
            //Loop until done or need to switch users

            

            List<Reservation> reservation = new List<Reservation>();
            char moreReservs = 'y';
            int counter = 0;

            WriteLine("What would you like to do?");
            WriteLine("1. Create a new reservation\n2. View current reservations");
            int fdChoice = Convert.ToInt32(ReadLine());

            while (moreReservs == 'y')
            {
                //The example line in the video was
                //WriteLine("Let's get the items for item {0}"), counter ++1
                WriteLine("Please make your reservation selection", counter + 1); //increase the counter by one on this loop

                //create the method call for collect order - in this case for choosing room, possibly making reservation - double check this!!
                MakeReservation(ref reservation);

                WriteLine("Would you like to make another reservation? y/n");
                moreReservs = Convert.ToChar(ReadLine());

            }
            WriteLine("What would you like to do?");
            WriteLine("1. Create a new reservation\n2. View current reservations");
            fdChoice = Convert.ToInt32(ReadLine());

           






            //don't forget to add a heading before this output, wherever it ends up
            //Hopefully we can make this the View module, but that may or may not be possible.
            //If not, use a decision and variable to fork this off




        }
        public static void Admin()
        {
            //able to see resevations and select one to view
            //Can update any part of reservation
            //At end of day, print all reservations and show grand total of everything
            //Loop until admin is done and then return to main menu.
            

        }

        public static void MakeReservation(ref List<Reservation> r )
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
            foreach(RoomType rt in listOfRoomTypes)
            {
                WriteLine($"{rt.RoomTypeID}\t{rt.RoomTypeName}\t{rt.RoomView}\t{rt.RoomCost}");
            }

            int roomIdSelect = Convert.ToInt32(ReadLine());//this variable is literally the room ID number, chosen by user
            string roomTypeSelect = listOfRoomTypes[roomIdSelect - 1].RoomTypeName;//this is the type of room, string name form
            string roomViewSelect = listOfRoomTypes[roomIdSelect - 1].RoomView;
            double roomCostSelect = listOfRoomTypes[roomIdSelect - 1].RoomCost;//Cost of room to use for calculations
                        
            WriteLine("Extras: ");
            foreach(Extras ex in listOfExtras)
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
