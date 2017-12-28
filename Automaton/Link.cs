using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.Core
{
    public class Link
    {
        public Link() { }
        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="link"></param>
        public Link(Link link)
        {
            From = link.From;
            To = link.To;
            Weight = link.Weight;
        }
        public Node From { get; set; }
        public Node To { get; set; }
        public double Weight { get; set; }
    }
}
