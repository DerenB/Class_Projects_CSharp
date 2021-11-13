using System;

namespace Project_One {
    class Driver {
        static void Main(string[] args) {
            //DataBase d = new DataBase();
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
                    switch(response) {
                        case 1:
                            Console.WriteLine("TODO: Option 1");
                            break;
                        case 2:
                            Console.WriteLine("TODO: Option 2");
                            break;
                        case 3:
                            Console.WriteLine("TODO: Option 3");
                            break;
                        case 4:
                            Console.WriteLine("TODO: Option 4");
                            break;
                        case 5:
                            Console.WriteLine("TODO: Option 5");
                            break;
                        case 6:
                            Console.WriteLine("TODO: Option 6");
                            break;
                        case 7:
                            Console.WriteLine("TODO: Option 7");
                            break;
                        case 8:
                            Console.WriteLine("TODO: Option 8");
                            break;
                        case 9:
                            Console.WriteLine("TODO: Option 9");
                            break;
                        case 0:
                            Console.WriteLine("");
                            Console.WriteLine("Quitting Program. Goodbye");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Not a valid input. Try again or enter 0 to exit.");
                            break;
                    }
                } else {
                    response = -1;
                    Console.WriteLine("Input is not a number, try again.");
                }
            } while (response != 0);




            //response++;

            //Console.WriteLine($"You entereed {response} plus 1");
        }
    }
}
