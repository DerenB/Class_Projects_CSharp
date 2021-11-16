using System;

namespace Project_One {
    class Driver {
        static void Main(string[] args) {
            DataBase d = new DataBase();
            int response;

            do {
                // Options for user to pick
                Console.WriteLine("");
                Console.WriteLine("1: Add a new Student");
                Console.WriteLine("2: Delete a Student");
                Console.WriteLine("3: Find a student by ID");
                Console.WriteLine("4: List Students: Ascending ID");
                Console.WriteLine("5: List Students: Ascending First Name");
                Console.WriteLine("6: List Students: Ascending Last Name");
                Console.WriteLine("7: List Students: Descending ID");
                Console.WriteLine("8: List Students: Descending First Name");
                Console.WriteLine("9: List Students: Descending Last Name");
                Console.WriteLine("");
                Console.WriteLine("0: Exit Program");

                // Gets the user's input choice
                Console.WriteLine("Enter a number to pick a choice: ");
                var input = Console.ReadLine();

                // Tests if the user's input is valid
                if(int.TryParse(input, out response)) {
                    //Switch statement to select user's choice
                    switch(response) {
                        case 1:
                            d.addIt();
                            break;
                        case 2:
                            d.deleteIt();
                            break;
                        case 3:
                            d.findIt();
                            break;
                        case 4:
                            d.ListByIDAscending();
                            break;
                        case 5:
                            d.ListByFirstAscending();
                            break;
                        case 6:
                            d.ListByLastAscending();
                            break;
                        case 7:
                            d.ListByIDDescending();
                            break;
                        case 8:
                            d.ListByFirstDescending();
                            break;
                        case 9:
                            d.ListByLastDescending();
                            break;
                        case 0:
                            Console.WriteLine("");
                            Console.WriteLine("Quitting Program. Goodbye");
                            Environment.Exit(0);
                            break;
                        default:
                            //Output if the user does not enter an interger between 0-9
                            Console.WriteLine("Not a valid input. Try again or enter 0 to exit.");
                            break;
                    }
                } else {
                    //Output if the user does not enter an integer
                    response = -1;
                    Console.WriteLine("Input is not a number, try again.");
                }
            } while (response != 0);
        }
    }
}
