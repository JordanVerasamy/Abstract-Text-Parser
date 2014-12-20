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
            ListOfFunctions functions = new ListOfFunctions();

            string input;
            while (true)
            {
                input = Console.ReadLine();
                Console.WriteLine(parseString(input, functions));
            }
        }

        // consumes a function of the form (operator argument argument ... argument) and 
        // returns what it evaluates to
        static dynamic parseSingleFunction(string input, ListOfFunctions functions)
        {
            var inputComponents = input.Substring(1, input.Length-2).Split(' ');
            
            string functionID = inputComponents[0];
            int numArguments = inputComponents.Length - 1;

            List<string> listOfArguments = new List<string>();

            for (int i = 1; i <= numArguments; i++)
            {
                listOfArguments.Add(inputComponents[i]);
            }

            try
            {
                return functions[functionID](listOfArguments);
            }
            #region Handle Errors
            catch (Exception e)
            {
                Console.WriteLine("ERROR! You probably didn't obey the contract for one of the functions you used.\nYou fucker.");
                Console.WriteLine("\n\nMessage: \n" + e.Message);
                Console.WriteLine("\n\nStack Trace: \n" + e.StackTrace);
                return "";
            }
            #endregion
        }

        // recursively applies parseSingleFunction to every function in the input, 
        // starting from the inside and working outward
        static dynamic parseString(string input, ListOfFunctions functions)
        {
            if ((input.IndexOf("(") == input.LastIndexOf("(")) && (input.IndexOf(")") == input.LastIndexOf(")")))
            {
                return parseSingleFunction(input, functions);
            }

            List<int> endpoints = getEndpointsOfInnermostFunction(input);

            string innermostFunction = input.Substring(endpoints[0], endpoints[1] - endpoints[0] + 1);
            dynamic functionReturn = parseSingleFunction(innermostFunction, functions);

            return parseString(input.Replace(innermostFunction, functionReturn.ToString()), functions);
        }

        // finds the first function (starting from the left) which does not contain any more function calls,
        // and returns the indexes of its opening and closing brackets
        static List<int> getEndpointsOfInnermostFunction(string input)
        {
            List<int> endpoints = new List<int>();

            int firstEndingBracket = input.IndexOf(")");

            input = input.Substring(0, firstEndingBracket);

            int matchingBeginningBracket = input.LastIndexOf("(");

            endpoints.Add(matchingBeginningBracket);
            endpoints.Add(firstEndingBracket);

            return endpoints;
        }
    }
}
