using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.Models
{
    public class AddComment
    {
        public string body { get; set; }
        public Visibility visibility { get; set; }
    }

    public class Visibility
    {
        public string type { get; set; }
        public string value { get; set; }
    }
}
