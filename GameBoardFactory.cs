using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera_BattleShip
{
    // Factory Method Pattern
    public abstract class GameBoardFactory
    {
        // Metoden som behöver implementeras av underklasser
        public abstract GameBoard CreateGameBoard(int size, int numShips);
    }
}
