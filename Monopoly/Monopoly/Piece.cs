using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
   public class Piece
    {
        public string name;
        public int X, Y;
        Square Location = new Square();
        public void setLocation(Square newLoc) 
        {
            Location = newLoc;
            X = Location.X;
            Y = Location.Y;
        }
        public Square getLocation() => Location;
    }
}
