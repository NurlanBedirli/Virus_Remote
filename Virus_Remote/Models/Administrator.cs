using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virus_Remote.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
