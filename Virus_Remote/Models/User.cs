using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virus_Remote.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MACAddress { get; set; }
        public bool IsOnline { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
