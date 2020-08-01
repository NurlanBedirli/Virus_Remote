using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virus_Remote.Models
{
    public class Redirect
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int LoopTime { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
