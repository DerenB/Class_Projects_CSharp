using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One {
    public class DataBase {
        private DataBaseRecord[] data;
        private int nextDBRecord;
        Index firstIndex, lastIndex, idIndex;

        //Main Constructor, sets size to 100 by refault and reads the data file
        public DataBase() {
            data = new DataBaseRecord[100];
            nextDBRecord = 0;
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

        public DataBase(int sz) {
            data = new DataBaseRecord[sz];
            nextDBRecord = 0;
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

        public void addIt() {
            string firstName, lastName, id;

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
            DataBaseRecord newStudent = new DataBaseRecord(fin,lin,iin);
            data[nextDBRecord] = newStudent;

            firstIndex.insert(new IndexRecord(fin,nextDBRecord),nextDBRecord);
            lastIndex.insert(new IndexRecord(lin,nextDBRecord),nextDBRecord);
            idIndex.insert(new IndexRecord(iin,nextDBRecord),nextDBRecord);
            nextDBRecord++;
        }

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

        public void findIt() {
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

        public void deleteIt() {
            Console.WriteLine("Enter an ID of the student to delete: ");
            string key = Console.ReadLine();

            if(idenLength(key)) {
                return;
            }

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
        }

    }
}