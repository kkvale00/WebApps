using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _06___DragonBallAPI.Models
{
    public class Character : Entity
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public DateTime Dob { get; set; }

        //public string Data{ get { return Dob.ToShortDateString(); }  }


    }
}
