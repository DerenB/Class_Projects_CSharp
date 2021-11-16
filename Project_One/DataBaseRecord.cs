using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One {
    public class DataBaseRecord {
        // Variables
        private string fName;
        private string lName;
        private string id;

        public string getFName() {
            return fName;
        }

        public void setFName(string fName) {
            this.fName = fName;
        }

        public string getLName() {
            return lName;
        }

        public void setLName(string lName) {
            this.lName = lName;
        }

        public string getID() {
            return id;
        }

        public void setID(string id) {
            this.id = id;
        }

        public DataBaseRecord(String f, String l, String i) {
            fName = f;
            lName = l;
            id = i;
        }
        
        public String toString() {
            return $"{fName} {lName} {id}";
        }

    }
}