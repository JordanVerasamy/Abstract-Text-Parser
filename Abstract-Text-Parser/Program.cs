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
            Dictionary<string, Func<int, int, int>> functions = new Dictionary<string, Func<int, int, int>>();

            functions.Add("+", (x, y) => x + y);
            functions.Add("-", (x, y) => x - y);
            functions.Add("*", (x, y) => x * y);
            functions.Add("/", (x, y) => x / y);
            functions.Add("bs-some-shit", (x, y) => new Random().Next(1, 10));

            Console.WriteLine(parseString("(+ 3 5)", functions));
            Console.ReadLine();

        }

        static int parseString(string input, Dictionary<string, Func<int, int, int>> functions)
        {
            string functionID;
            functionID = input.Substring(1, input.Length-2).Split(' ')[0];

            int arg1 = int.Parse(input.Substring(1, input.Length - 2).Split(' ')[1]);
            int arg2 = int.Parse(input.Substring(1, input.Length - 2).Split(' ')[2]);

            return functions[functionID](arg1, arg2);
        }
    }
}
