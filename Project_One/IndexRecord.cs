using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One {
    public class IndexRecord {
        private string value;
        private int position;

        public IndexRecord(String f, int p) {
            value = new string(f);
            position = p;
        }

        public IndexRecord(IndexRecord otherIndex) {
            value = new string(otherIndex.value);
            position = otherIndex.position;
        }

        public string toString() {
            return $"{value} {position}";
        }

        public int compareTo(IndexRecord otherIndex) {
            return (value.CompareTo(otherIndex.value));
        }

        public string getValue() {
            return value;
        }

        public void setValue(string value) {
            this.value = value;
        }

        public int getPosition() {
            return position;
        }

        public void setPosition(int position) {
            this.position = position;
        }
    }
}