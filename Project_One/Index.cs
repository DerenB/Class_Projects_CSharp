using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One {
    public class Index {
        private IndexRecord[] data;
        private int nElems;

        public Index() {
            data = new IndexRecord[100];
            nElems = 0;
        }

        public Index(int sz) {
            data = new IndexRecord[sz];
            nElems = 0;
        }

        //Insertion Loop Method
        public void insert(IndexRecord newVal, int position) {
            int rover;
            for (rover = nElems - 1; rover >= 0; rover--) {
                if (newVal.compareTo(data[rover]) > 0) break;
                data[rover + 1] = data[rover];
            }
            data[rover + 1] = newVal;
            nElems++;
        }

        //Find String value in IndexRecord



    }
}