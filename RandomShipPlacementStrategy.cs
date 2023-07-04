using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera_BattleShip
{
    // Strategy Pattern
    // Implementerar IShipPlacementStrategy interface som representerar en specifik strategi för slumpmässigt placera ut skepp på spelplanen.
    public class RandomShipPlacementStrategy : IShipsPlacementStategy
    {
        public void PlaceShips(GameBoard board)
        {

            Random random = new Random();

            for (int i = 0; i < board.NumShips; i++)
            {
                int x = random.Next(board.Size);
                int y = random.Next(board.Size);
                

                while (board.IsShipPlaced(x, y))
                {
                    x = random.Next(board.Size);
                    y = random.Next(board.Size);
                }
                board.PlaceShip(x, y);
            }
        }
    }
}
