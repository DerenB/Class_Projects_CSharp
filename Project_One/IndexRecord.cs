using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One
{
    public class IndexRecord
    {
        public String value { get; set; }
        public int position { get; set; }

        public IndexRecord(String f, int p)
        {
            value = new string(f);
            position = p;
        }

        public IndexRecord(IndexRecord otherIndex)
        {
            value = new string(otherIndex.value);
            position = otherIndex.position;
        }

        public string toString()
        {
            return $"{value} {position}";
        }

        public int compareTo(IndexRecord otherIndex)
        {
            return (value.CompareTo(otherIndex.value));
        }
    }
}