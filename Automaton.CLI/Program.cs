using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaton.Core;

namespace Automaton.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //有限オートマトン
            List<double[]> result = new List<double[]>();
            Console.Write("Path of input file: ");
            var path = Console.ReadLine();
            var automaton = new Graph(path);
            Console.Write("Number of Generation: ");
            var generation = int.Parse(Console.ReadLine());
            Console.Write("Path of output file: ");
            path = Console.ReadLine();
            for (int i = 0; i <= generation; i++)
            {
                Console.WriteLine("Gen: {0}", i);
                var current = automaton.CurrentState();
                foreach (var item in current)
                {
                    Console.WriteLine(item);
                }
                result.Add(current.ToArray());
                automaton = automaton.SimulateOneStep();
            }
            using (var writer = new System.IO.StreamWriter(path))
            {
                int count = 0;
                foreach (var item in result)
                {
                    writer.Write("{0},", count++);
                    writer.WriteLine(string.Join(",", item));
                }
            }
        }
    }
}
