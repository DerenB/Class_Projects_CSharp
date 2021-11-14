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
        public int find(String key) {
            int low = 0, mid = 0;
            int high = nElems - 1;

            while(low <= high) {
                mid = (low + high) / 2;
                if (data[mid].getValue().CompareTo(key)==0) break;
                if (key.CompareTo(data[mid].getValue()) < 0) {
                    high = mid - 1;
                } else {
                    low = mid + 1;
                }
            }
            return (low <= high ? data[mid].getPosition() : -1);
        }

        // Checks for duplicate IDs
        public bool duplicate(string key) {
             bool duped = false;
             for(int i = nElems; i > 0; i--) {
                 if(key.CompareTo(data[i-1].getValue()) == 0) {
                     duped = true;
                     break;
                 }
             }
             return duped;
        }

        //Find IndexRecord in Index
        public int find(IndexRecord key) {
            int low = 0, mid = 0;
            int hight = nElems - 1;
        }
    }
}