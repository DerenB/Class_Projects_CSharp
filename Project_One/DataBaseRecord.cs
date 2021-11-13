using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One {
    public class DataBaseRecord {
        public String fName { get; set; }
        public String lName { get; set; }
        public String id {get; set; }

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