using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{

    class ValueList: List<Tuple<string, string>>
    {
    }

    class HT
    {
        ValueList[] valueListAr;
        int capacity;

        public HT(int capacity)
        {
            this.capacity = capacity;
            valueListAr = new ValueList[capacity];
        }

        public int GetHashOf(string key)
        {
            return Math.Abs(key.GetHashCode()) % capacity;
        }

        private Tuple<string,bool> GetTup(string key)
        {
            var hashIndex = GetHashOf(key);
            if (valueListAr[hashIndex] == null)
                return new Tuple<string, bool>(null,false);

            foreach (var item in valueListAr[hashIndex])
                if (item.Item1 == key)
                    return new Tuple<string, bool>(item.Item2, true); 
            return new Tuple<string, bool>(null, false);
        }


        public string Get(string key)
        {
            return GetTup(key).Item1;
        }

        public bool ContainsKey(string key)
        {
            return GetTup(key).Item2;
        }


        public bool Add(string key, string value)
        {
            if (ContainsKey(key))
                return false;

            var hashIndex = GetHashOf(key);

            if (valueListAr[hashIndex] == null)
                valueListAr[hashIndex] = new ValueList();

            valueListAr[hashIndex].Add(new Tuple<string, string>(key, value));
            return true;
        }


        public void Print()
        {
            foreach (var item in valueListAr)
                if(item != null)
                    foreach (var innerItem in item)
                        Console.WriteLine(innerItem.Item1 + " - " + innerItem.Item2);          
        }
    }
}
