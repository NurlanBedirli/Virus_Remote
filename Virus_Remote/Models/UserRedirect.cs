using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virus_Remote.Models
{
    public class UserRedirect
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Redirect Redirect { get; set; }
        public int RedirectId { get; set; }
        public DateTime RedirectDate { get; set; }
    }
}
