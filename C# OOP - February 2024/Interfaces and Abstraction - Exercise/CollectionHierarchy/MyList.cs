using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class MyList : ICollection
    {
        public List<string> Collection { get ; set ; }
        public MyList()
        {
            Collection = new List<string>();
        }
        public int Used =>Collection.Count;

        public int Add(string element)
        {
            Collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string toReturn = Collection.First();
            Collection.RemoveAt(0);
            return toReturn;
        }


    }
}
