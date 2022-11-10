using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteeres.Models
{
    public class Volunteer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool active{ get; set; }
        public List<bool> days { get; set; }


    }
}
