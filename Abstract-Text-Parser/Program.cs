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
            functions.getFunctions();

            Console.WriteLine(parseSingleFunction("(int-equals? 3 3 3)", functions));
            Console.ReadLine();
        }

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
    }
}
