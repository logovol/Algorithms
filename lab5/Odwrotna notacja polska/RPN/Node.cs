using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class Node
    {
        public double digit { get; set; }
        public string sign { get; set; }
        public string bracket { get; set; }
        public int priority { get; set; }
        public string type { get; set; }
    }
}
