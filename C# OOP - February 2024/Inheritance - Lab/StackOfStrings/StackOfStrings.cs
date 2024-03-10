using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        private Stack<string> st = new();
        public bool IsEmpty()
        {
            return !st.Any();
        }

        public void AddRange(IEnumerable<string> elements)
        {
            foreach (var item in elements)
            {
                Push(item);
            }
        }
    }
}
