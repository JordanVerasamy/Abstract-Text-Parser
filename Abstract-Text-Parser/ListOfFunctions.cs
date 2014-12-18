using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Text_Parser
{
    class ListOfFunctions : Dictionary<string, Func<List<string>, dynamic>>
    {
        public ListOfFunctions()
        {
        }

        public void getFunctions()
        {
            // (listof int) => int
            this.Add("+", (listOfArguments) =>
            {
                int count = 0;
                foreach (string x in listOfArguments)
                {
                    count += int.Parse(x);
                };
                return count;
            });

            // (listof int) => int
            this.Add("-", (listOfArguments) =>
            {
                int count = listOfArguments == null ? 0 : 2 * int.Parse(listOfArguments[0]);
                foreach (string x in listOfArguments)
                {
                    count -= int.Parse(x);
                };
                return count;
            });

            // (listof int) => boolean
            this.Add("int-equals?", (listOfArguments) =>
            {
                int pivot = listOfArguments == null ? 0 : int.Parse(listOfArguments[0]);

                foreach (string x in listOfArguments)
                {
                    if (int.Parse(x) != pivot)
                    {
                        return false;
                    }
                }
                return true;
            });
        }
    }
}
