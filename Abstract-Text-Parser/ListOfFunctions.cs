using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Text_Parser
{
    class ListOfFunctions : Dictionary<string, Func<List<string>, dynamic>>
    {
        // Sets up which functions the parser will be able to... well... parse
        // Note that the arguments are passed as strings, so any required conversion must occur in-function
        public ListOfFunctions()
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
            this.Add("*", (listOfArguments) =>
            {
                int count = 1;
                foreach (string x in listOfArguments)
                {
                    count *= int.Parse(x);
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

            // (listof int) => int
            this.Add("/", (listOfArguments) =>
            {
                int count = listOfArguments == null ? 0 : (int)Math.Pow(double.Parse(listOfArguments[0]), 2);
                foreach (string x in listOfArguments)
                {
                    count /= int.Parse(x);
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

            // (listof boolean) => boolean
            this.Add("or", (listOfArguments) =>
            {
                foreach (string x in listOfArguments)
                {
                    if (x == "True" || x == "true")
                    {
                        return true;
                    }
                }
                return false;
            });

            // (listof boolean) => boolean
            this.Add("and", (listOfArguments) =>
            {
                foreach (string x in listOfArguments)
                {
                    if (x == "False" || x == "false")
                    {
                        return false;
                    }
                }
                return true;
            });

            // boolean => boolean
            this.Add("not", (listOfArguments) =>
            {
                return (listOfArguments[0] == "True" || listOfArguments[0] == "true") ? false : true;
            });
        }
    }
}
