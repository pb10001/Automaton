using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton
{
    class Program
    {
        static void Main(string[] args)
        {
            //有限オートマトン
            List<Graph> result = new List<Graph>();
            Console.Write("File path: ");
            var path = Console.ReadLine();
            var automaton = new Graph(path);
            Console.Write("Number of Generation: ");
            var generation = int.Parse(Console.ReadLine());
            for (int i = 0; i < generation; i++)
            {
                Console.WriteLine("Gen: {0}", i);
                automaton = automaton.SimulateOneStep();
                result.Add(new Graph(automaton));
                foreach (var item in automaton.CurrentState())
                {
                    Console.WriteLine(item);
                }
            }
            using (var writer = new System.IO.StreamWriter("result.csv"))
            {
                int count = 0;
                foreach (var item in result)
                {
                    writer.Write("{0},",count++);
                    writer.WriteLine(string.Join(",", item.CurrentState()));
                }
            }
            Console.ReadKey();
        }
    }
}
