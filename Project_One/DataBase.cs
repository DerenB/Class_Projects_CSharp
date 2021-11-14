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

                }




                Console.WriteLine($"First name: {student[0]}");
                Console.WriteLine($"Last name: {student[1]}");
                Console.WriteLine($"ID: {student[2]}");
                Console.WriteLine("");
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

    }
}