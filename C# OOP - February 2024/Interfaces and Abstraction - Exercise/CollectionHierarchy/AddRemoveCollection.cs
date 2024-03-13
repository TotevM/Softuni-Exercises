using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : ICollection
    {
        public List<string> Collection { get; set ; }
        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }
        public int Add(string element)
        {
            Collection.Insert(0, element);
            return 0;
        }

        public string Remove() 
        {
            string toReturn = Collection.Last();
            Collection.RemoveAt(Collection.Count - 1);
            return toReturn;
        }
    }
}
