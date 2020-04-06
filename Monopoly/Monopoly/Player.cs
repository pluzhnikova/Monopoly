using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Monopoly
{
    public class Player
    {
        public string name;
        public int diceValue;
        public Board board = new Board();
        private Die[] dice = new Die[2];
        public List<int> own = new List<int>();
        public Queue<Square> PlayersStreets = new Queue<Square>();
        private Dictionary<string, int> districts = new Dictionary<string, int>();
        public string added = null;
        public bool hasNewFileal = false;
        public bool hasNewCompany = false;
      
        private const decimal StartingMoney = 1500;
        public decimal Money { get; set; } = StartingMoney;
        public decimal GivenMoney { get; set; } = 0;
        public bool AbleToSpend(decimal amount)
        {
            if (amount > Money)
                return false;
            return true; 
        }
        public void Gain(decimal amount)
        {
            Money += amount;
        }
        public void Spend(decimal amount)
        {
            Money -= amount;
        }
        public void TakeTurn(Piece piece)
        {
            Square oldLoc = piece.getLocation();
            diceValue = rollDice();
            Square newLoc = board.getSquare(piece.getLocation(), diceValue);
            piece.setLocation(newLoc);
            if (newLoc.sell < oldLoc.sell) PassedGo();
            if (newLoc.sell == 4)
            {
                Spend(400m); return;
            }
            if (newLoc.sell == 38)
            {
                Spend(100m); return;
            }
            if (newLoc.sell == 30)
            {
                GoToJail(piece);
                return;
            }
            if (newLoc.sell == 10 || newLoc.sell == 20  || newLoc.sell == 0)
            {
                return;
            }
            if (newLoc.sell == 2 || newLoc.sell == 7 || newLoc.sell == 17 || newLoc.sell == 22 || newLoc.sell == 33 || newLoc.sell == 36)
            {
                TakeAChance(); return;
            }
            if (!own.Contains(newLoc.sell))
            {
                if (board.owned.Contains(newLoc.sell)) { Spend(newLoc.rent); GivenMoney = newLoc.rent; return; }
                if (!board.owned.Contains(newLoc.sell))
                {
                    if (AbleToSpend(newLoc.Cost)) 
                    { 
                        own.Add(newLoc.sell); Spend(newLoc.Cost); board.owned.Add(newLoc.sell); added = newLoc.name;
                        PlayersStreets.Enqueue(newLoc);
                        if (newLoc.color != null)
                        {
                            if (districts.ContainsKey(newLoc.color))
                                districts[newLoc.color] += 1;
                            else
                                districts.Add(newLoc.color, 1);
                        }
                    }
                    return;
                }
                if (newLoc.color != null)
                {
                    if (newLoc.company == false && newLoc.amountOfFileals < 4 && ((districts[newLoc.color] == 2 && (newLoc.color == "brown") || (newLoc.color == "dark blue")) || (districts[newLoc.color] == 3 && (newLoc.color != "brown" || newLoc.color != "dark blue"))))
                    {
                        newLoc = new Filial(newLoc);
                        newLoc.amountOfFileals++;
                    }
                    else
                    {
                        if (newLoc.company == false && (districts[newLoc.color] == 2 && (newLoc.color == "brown") || (newLoc.color == "dark blue")) || (districts[newLoc.color] == 3 && (newLoc.color != "brown" || newLoc.color != "dark blue")))
                        {
                            newLoc = new Company(newLoc);
                            newLoc.company = true;
                            newLoc.amountOfFileals = 0;
                        }
                    }
                }
                    return;
            }

            return;
        }
        public void GoToJail(Piece piece)
        {
            piece.setLocation(board.getSquare(piece.getLocation(), 20));
            Spend(50);
        }
        public void TakeAChance()
        {
            Random rng = new Random();
            int chance = rng.Next(1, 4);
            switch (chance)
            {   case 1: Gain(100m); break;

                case 2: Spend(250m); break;

                case 3: Gain(25m); break;

                case 4: Spend(25m); break;
            }
        }
        public void PassedGo()
        {
            Gain(200m);
        }
        private int rollDice()
        {
            int rollTotal = 0;

            dice[0] = new Die();
            dice[1] = new Die();
            for (int i = 0; i < dice.Length; i++)
            {
                rollTotal += dice[i].getFaceValue();
            }
            return rollTotal;
        }
    }
}