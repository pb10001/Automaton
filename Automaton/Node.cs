using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.Core
{
    public class Node
    {
        /// <summary>
        /// privateコンストラクタ
        /// </summary>
        private Node() { }
        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="node"></param>
        public Node(Node node)
        {
            ID = node.ID;
            Value = node.Value;
        }
        private static int count = 0;
        public int ID { get; private set; }
        public double Value { get; set; }
        public static Node NewNode(double initValue)
        {
            var node = new Node();
            node.ID = count++;
            node.Value = initValue;
            return node;
        }
    }
}
