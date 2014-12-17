using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Text_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<List<int>, int>> functions = new Dictionary<string, Func<List<int>, int>>();

            functions.Add("+", (listOfArguments) =>
            {
                int count = 0;
                foreach (int x in listOfArguments)
                {
                    count += x;
                };
                return count;
            });


            functions.Add("-", (listOfArguments) =>
            {
                int count = listOfArguments == null ? 0 : 2 * listOfArguments[0];
                foreach (int x in listOfArguments)
                {
                    count -= x;
                };
                return count;
            });

            Console.WriteLine(parseSingleFunction("(- 3 6 8)", functions));
            Console.ReadLine();

        }

        static int parseSingleFunction(string input, Dictionary<string, Func<List<int>, int>> functions)
        {
            var inputComponents = input.Substring(1, input.Length-2).Split(' ');

            int numArguments = inputComponents.Length - 1;
            List<int> listOfArguments = new List<int>();

            string functionID = inputComponents[0];

            for (int i = 1; i <= numArguments; i++)
            {
                listOfArguments.Add(int.Parse(inputComponents[i]));
            }

            return functions[functionID](listOfArguments);
        }
    }
}
