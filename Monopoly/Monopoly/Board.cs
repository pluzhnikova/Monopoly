using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Monopoly
{
    public class Board
    {
        Square[] squares = new Square[41];
        public List<int> owned = new List<int>();
        public Square getSquare(Square currentLocation, int count)
        {
            Square[] squares = GetSquares();
            return squares[(currentLocation.sell + count) % 40];
        }
      
        private static Square[] GetSquares()
        {
            return new[]
                        { new Square{X = 525, Y = 525, sell = 0 },
              new Square{X = 477, Y = 525, sell = 1, name ="Mediterranian avenue", Cost = 60, rent = 30, color = "brown" },
              new Square{X = 429, Y = 525, sell = 2 },
              new Square{X = 381, Y = 525, sell = 3,name = "Baltic Avenue", Cost = 60, rent = 30, color = "brown"  },
              new Square{X = 333, Y = 525, sell = 4 },
              new Square{X = 285, Y = 525, sell = 5, name = "Reading Railroad", Cost = 200, rent = 100 },
              new Square{X = 237, Y = 525, sell = 6, name = "Oriental Avenue", Cost = 100, rent = 50, color  = "light blue"  },
              new Square{X = 189, Y = 525, sell = 7 },
              new Square{X = 141, Y = 525, sell = 8, name = "Vermont Avenue", Cost = 100, rent = 50, color  = "light blue"  },
              new Square{X = 93, Y = 525, sell = 9, name = "Connecticut Avenue", Cost = 120, rent = 60, color  = "light blue"  },
              new Square{X = 30, Y = 525, sell = 10},
              new Square{X = 30, Y = 477, sell = 11, name = "St. Charles Place", Cost = 140, rent = 70, color  = "pink"  },
              new Square{X = 30, Y = 429, sell = 12, name = "Electric Company", Cost = 150, rent =  75 },
              new Square{X = 30, Y = 381, sell = 13, name = "States Avenue", Cost = 140, rent = 70, color  = "pink" },
              new Square{X = 30, Y = 333, sell = 14, name = "Virginia Avenue", Cost = 160, rent =  80, color  = "pink" },
              new Square{X = 30, Y = 285, sell = 15, name = "Pennsylvania Railroad", Cost = 200, rent = 100 },
              new Square{X = 30, Y = 237, sell = 16, name = "St. James Place", Cost = 180, rent = 90, color  = "orange"  },
              new Square{X = 30, Y = 189, sell = 17},
              new Square{X = 30, Y = 135, sell = 18, name = "Tennessee Avenue", Cost = 180,rent = 90, color  = "orange"  },
              new Square{X = 30, Y = 93, sell = 19, name =  "New York Avenue", Cost = 200,rent = 100, color  = "orange"  },
              new Square{X = 30, Y = 30, sell = 20},
              new Square{X = 93, Y = 15, sell = 21, name = "Kentucky Avenue", Cost = 220, rent = 110, color  = "red"  },
              new Square{X = 141, Y = 15, sell = 22 },
              new Square{X = 189, Y = 15, sell = 23, name = "Indiana Avenue", Cost = 220, rent = 110, color  = "red"  },
              new Square{X = 237, Y = 15, sell = 24, name = "Illinois Avenue", Cost = 240, rent =  120, color  = "red" },
              new Square{X = 285, Y = 15, sell = 25, name = "B. & O. Railroad", Cost = 200, rent = 100  },
              new Square{X = 333, Y = 15, sell = 26, name = "Atlantic Avenue", Cost = 260, rent = 180, color  = "yellow" },
              new Square{X = 381, Y = 15, sell = 27, name = "Ventnor Avenue", Cost = 260, rent = 180, color  = "yellow"  },
              new Square{X = 429, Y = 15, sell = 28 },
              new Square{X = 477, Y = 15, sell = 29, name = "Marvin Gardens", Cost = 280, rent = 140, color  = "yellow"  },
              new Square{X = 525, Y = 50, sell = 30 },
              new Square{X = 525, Y = 93, sell = 31, name = "Pacific Avenue", Cost = 300, rent = 150, color  = "green"  },
              new Square{X = 525, Y = 135, sell = 32, name = "North Carolina Avenue", Cost = 300, rent =  150, color  = "green" },
              new Square{X = 525, Y = 189, sell = 33 },
              new Square{X = 525, Y = 237, sell = 34, name = "Pennsylvania Avenue", Cost = 320, rent =  160, color  = "green" },
              new Square{X = 525, Y = 285, sell = 35, name = "Short Line", Cost = 200, rent =  100 },
              new Square{X = 525, Y = 333, sell = 36 },
              new Square{X = 525, Y = 381, sell = 37, name = "Park Place", Cost = 350, rent = 175, color  = "dark blue" },
              new Square{X = 525, Y = 429, sell = 38 },
              new Square{X = 525, Y = 477, sell = 39, name = "Boardwalk", Cost = 400, rent = 200, color  = "dark blue"},
            };
        }
    }
}
