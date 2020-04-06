using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Square
    {
        public string name = null;
        public string color = null;
        public int sell;
        public int X, Y;
        public int amountOfFileals = 0;
        public bool company = false;
        public decimal Cost { get; set; } = 0;
        public decimal rent = 0;
    }
    abstract class SquareDecorator: Square
    {
        protected Square square;
    }
    class Filial : SquareDecorator 
    {
        //cost increases
        public Filial(Square square) 
        { 
            square.Cost *= 1.2m; 
        }
    }
    class Company : SquareDecorator 
    {
        //cost increases
        public Company(Square square) 
        { 
            square.Cost *= 1.2m; 
        }
    }
}
