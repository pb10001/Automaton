using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.Core
{
    public class Graph
    {
        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name=""></param>
        public Graph(Graph graph)
        {
            nodeList = graph.nodeList.Select(x=>new Node(x)).ToList();
            linkList = graph.linkList.Select(x=>new Link(x)).ToList();
        }
        public Graph(string path)
        {
            using (var reader = new System.IO.StreamReader(path, Encoding.GetEncoding("shift_jis")))
            {
                double tmp;
                var nodes = reader.ReadLine().Split(',');
                foreach (var item in nodes)
                {
                    if (double.TryParse(item, out tmp))
                    {
                        var n = Node.NewNode(tmp);
                        nodeList.Add(n);

                    }
                }
                while (reader.Peek() > -1)
                {
                    var link = reader.ReadLine().Split(',');
                    var l = new Link()
                    {
                        From = nodeList.Single(x => x.ID == int.Parse(link[0])),
                        To = nodeList.Single(x => x.ID == int.Parse(link[1])),
                        Weight = double.Parse(link[2])
                    };
                    linkList.Add(l);
                }
            }
        }
        List<Node> nodeList = new List<Node>();
        List<Link> linkList = new List<Link>();
        public Graph SimulateOneStep()
        {
            var diffArray = new double[nodeList.Count];
            foreach (var item in linkList)
            {
                var diff = item.From.Value * item.Weight;
                diffArray[item.From.ID] -= diff;
                diffArray[item.To.ID] += diff;
            }
            for (int i = 0; i < nodeList.Count; i++)
            {
                nodeList[i].Value += diffArray[i];
            }
            return this;
        }
        public IEnumerable<double> CurrentState()
        {
            foreach (var item in nodeList)
            {
                yield return item.Value;
            }
        }
    }
}
