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
            Dictionary<string, Func<List<dynamic>, dynamic>> functions = new Dictionary<string, Func<List<dynamic>, dynamic>>();

            functions.Add("+", (listOfArguments) =>
            {
                int count = 0;
                foreach (string x in listOfArguments)
                {
                    count += int.Parse(x);
                };
                return count;
            });

            functions.Add("-", (listOfArguments) =>
            {
                int count = listOfArguments == null ? 0 : 2 * int.Parse(listOfArguments[0]);
                foreach (string x in listOfArguments)
                {
                    count -= int.Parse(x);
                };
                return count;
            });

            Console.WriteLine(parseSingleFunction("(+ 3 6 ayy)", functions));
            Console.ReadLine();

        }

        static dynamic parseSingleFunction(string input, Dictionary<string, Func<List<dynamic>, dynamic>> functions)
        {
            var inputComponents = input.Substring(1, input.Length-2).Split(' ');

            int numArguments = inputComponents.Length - 1;
            List<dynamic> listOfArguments = new List<dynamic>();

            string functionID = inputComponents[0];

            for (int i = 1; i <= numArguments; i++)
            {
                listOfArguments.Add(inputComponents[i]);
            }

            try
            {
                return functions[functionID](listOfArguments);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR! You probably didn't obey the contract for one of the functions you used.\nYou fucker.");
                Console.WriteLine("\n\nMessage: \n" + e.Message);
                Console.WriteLine("\n\nStack Trace: \n" + e.StackTrace);
                return "";
            }
        }
    }
}
