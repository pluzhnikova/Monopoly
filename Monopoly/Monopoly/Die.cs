using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Die
    {
        public int getFaceValue()
        {
            Random rng = new Random();
           
            return rng.Next(1, 6);
        }

    }
}
