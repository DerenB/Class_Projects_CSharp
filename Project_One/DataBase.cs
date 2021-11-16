using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One {
    public class DataBase {
        private DataBaseRecord[] data; //Array for the database records
        private int nextDBRecord; //Counts the number of items added
        private int deletions; //Counts the number of items deleted
        Index firstIndex, lastIndex, idIndex; 

        //Main Constructor, sets size to 100 by refault and reads the data file
        public DataBase() {
            //Variables
            data = new DataBaseRecord[100];
            nextDBRecord = 0;
            deletions = 0;
            firstIndex = new Index();
            lastIndex = new Index();
            idIndex = new Index();

            //Reads in the data
            string[] dataRead = System.IO.File.ReadAllLines(@"C:\Users\dboze\Documents\Local-Repos\CS-Projects\Class_Projects_CSharp\Project_One\DataSet.txt");
            //string[] dataRead = System.IO.File.ReadAllLines("Project_One/DataSet.txt");

            foreach(string line in dataRead) {
                string[] student = line.Split(' ');

                string firstName = student[0];
                string lastName = student[1];
                string id = student[2];

                //Checks if a duplicate is found
                if(duplicate(id)) {
                    Console.WriteLine($"Student {firstName} {lastName} has a duplicate ID. Not adding to database.");
                } else {
                    addThem(firstName,lastName,id);
                }
            }
            Console.WriteLine("");
        }

        public DataBase(int sz) {
            //Variables
            data = new DataBaseRecord[sz];
            nextDBRecord = 0;
            deletions = 0;
            firstIndex = new Index();
            lastIndex = new Index();
            idIndex = new Index();

            //Reads in the data
            string[] dataRead = System.IO.File.ReadAllLines(@"C:\Users\dboze\Documents\Local-Repos\CS-Projects\Class_Projects_CSharp\Project_One\DataSet.txt");

            foreach(string line in dataRead) {
                string[] student = line.Split(' ');

                string firstName = student[0];
                string lastName = student[1];
                string id = student[2];

                //Checks if a duplicate is found
                if(duplicate(id)) {
                    Console.WriteLine($"Student {firstName} {lastName} has a duplicate ID. Not adding to database.");
                } else {
                    addThem(firstName,lastName,id);
                }
            }
            Console.WriteLine("");
        }

        //Method to prompt users to add new students to the database
        public void addIt() {
            //Variables
            string firstName, lastName, id;

            //Reads in user input for new student
            Console.WriteLine("Enter the new student's information (First, Last, ID): ");
            firstName = Console.ReadLine();
            lastName = Console.ReadLine();
            id = Console.ReadLine();

            //Check ID Length
            if(idenLength(id)) {
                return;
            }

            //Checks if ID is a duplicate of something already in the system
            if(duplicate(id)) {
                Console.WriteLine($"The ID of {id} is already in the system. Try again");
            } else {
                addThem(firstName,lastName,id);
            }
        }

        public void addThem(string fin, string lin, string iin) {
            //Creates a new database record entry for new student
            DataBaseRecord newStudent = new DataBaseRecord(fin,lin,iin);
            data[nextDBRecord] = newStudent;

            //Inserts the new student into the indexes
            firstIndex.insert(new IndexRecord(fin,nextDBRecord),nextDBRecord);
            lastIndex.insert(new IndexRecord(lin,nextDBRecord),nextDBRecord);
            idIndex.insert(new IndexRecord(iin,nextDBRecord),nextDBRecord);
            nextDBRecord++;
        }

        // Method to check if the ID key is a duplicate
        public bool duplicate(String key) {
            bool duped = false;
            for(int i = nextDBRecord; i > 0; i--) {
                if ((key.CompareTo(data[i-1].getID())) == 0) {
                    duped = true;
                    break;
                }
            }
            return duped;
        }

        // Method to check if the ID key is the right length
        public bool idenLength(string key) {
            bool output = false;
            int leng = key.Length;
            string errorType = "";
            if (leng != 5) {
                if (leng > 5) errorType = "long";
                if (leng < 5) errorType = "short";
                Console.WriteLine($"User ID is too {errorType}, it needs to be 5 characters. Try again.");
                Console.WriteLine("");
            }
            return output;
        }

        // Method to find the user's query
        public void findIt() {
            //Prompts the user for an ID key
            Console.WriteLine("Enter the ID of the student: ");
            string key = Console.ReadLine();
            if(idenLength(key)) {
                return;
            }
            int queryIndex = idIndex.find(key);
            if(queryIndex == -1) {
                Console.WriteLine("ID not found, try again.");
            } else {
                string fName = firstIndex.retVal(queryIndex);
                string lName = lastIndex.retVal(queryIndex);
                string iid = idIndex.retVal(queryIndex);
                Console.WriteLine($"Found {fName} {lName} {iid}.");
            }
        }

        //Various Printing Methods
        public void ListByFirstAscending() {
            // Prints by First Name in Ascending order
            print("up","first");
        }

        public void ListByFirstDescending() {
            // Prints by First Name in Descending order
            print("down","first");
        }

        public void ListByLastAscending() {
            // Prints by Last Name Ascending order
            print("up","last");
        }

        public void ListByLastDescending() {
            // Prints by Last Name Descending
            print("down","last");
        }

        public void ListByIDAscending() {
            // Prints by ID Ascending
            print("up","id");
        }

        public void ListByIDDescending() {
            // Prints by ID Descending
            print("down","id");
        }
        
        //Method to Print in various directions
        public void print(String direction, String type) {
            int rover,position;
            String firstName, lastName, id;
            if (direction.Equals("up")) {
                switch (type) {
                    case "first":
                        for (rover = 0; rover < nextDBRecord; rover++) {
                            position = firstIndex.indexSpot(rover);
                            firstName = firstIndex.print(rover);
                            lastName = lastIndex.retVal(position);
                            id = idIndex.retVal(position);
                            Console.WriteLine($"{firstName} {lastName} {id}");
                        }
                        break;
                    case "last":
                        for (rover = 0; rover < nextDBRecord; rover++) {
                            position = lastIndex.indexSpot(rover);
                            firstName = firstIndex.retVal(position);
                            lastName = lastIndex.print(rover);
                            id = idIndex.retVal(position);
                            Console.WriteLine($"{firstName} {lastName} {id}");                    
                        }
                        break;
                    case "id":
                        for (rover = 0; rover < nextDBRecord; rover++) {
                            position = idIndex.indexSpot(rover);
                            firstName = firstIndex.retVal(position);
                            lastName = lastIndex.retVal(position);
                            id = idIndex.print(rover);
                            Console.WriteLine($"{firstName} {lastName} {id}");
                        }
                        break;
                    default:
                        Console.WriteLine("Error in printing. Try again.");
                        break;
                }
            } else {
                switch (type) {
                    case "first":
                        for (rover = nextDBRecord-1; rover >= 0; rover--) {
                            position = firstIndex.indexSpot(rover);
                            firstName = firstIndex.print(rover);
                            lastName = lastIndex.retVal(position);
                            id = idIndex.retVal(position);
                            Console.WriteLine($"{firstName} {lastName} {id}");
                        }
                        break;
                    case "last":
                        for (rover = nextDBRecord-1; rover >= 0; rover--) {
                            position = lastIndex.indexSpot(rover);
                            firstName = firstIndex.retVal(position);
                            lastName = lastIndex.print(rover);
                            id = idIndex.retVal(position);
                            Console.WriteLine($"{firstName} {lastName} {id}");
                        }
                        break;
                    case "id":
                        for (rover = nextDBRecord-1; rover >= 0; rover--) {
                            position = idIndex.indexSpot(rover);
                            firstName = firstIndex.retVal(position);
                            lastName = lastIndex.retVal(position);
                            id = idIndex.print(rover);
                            Console.WriteLine($"{firstName} {lastName} {id}");
                        }
                        break;
                    default:
                        Console.WriteLine("Error in printing. Try again.");
                        break;
                }
            }
            Console.WriteLine("");
        }

        // Method to delete student
        public void deleteIt() {
            // Prompts the user
            Console.WriteLine("Enter an ID of the student to delete: ");
            string key = Console.ReadLine();

            // Checks if the user entry is the right length
            if(idenLength(key)) {
                return;
            }

            // Looks for the student 
            int where = idIndex.find(key);

            if(where == -1) {
                Console.WriteLine("ID not found, try again.");
            } else {
                string fName = firstIndex.retVal(where);
                string lName = lastIndex.retVal(where);
                string iid = idIndex.retVal(where);

                Console.WriteLine($"Do you want to delete: {fName} {lName}? Y/N");
                string response = Console.ReadLine();
                if(response.Equals("y")) {
                    firstIndex.delete(new IndexRecord(fName,where));
                    lastIndex.delete(new IndexRecord(lName,where));
                    idIndex.delete(new IndexRecord(iid,where));
                    nextDBRecord--;
                    Console.WriteLine("Student Deleted");
                } else {
                    Console.WriteLine("Not Deleting.");
                }
            }
            deletions++;
        }

    }
}