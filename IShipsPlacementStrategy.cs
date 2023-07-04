using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera_BattleShip
{
    // Strategy Pattern, IShipPlacementStrategy interface
    public interface IShipsPlacementStategy
    {
        void PlaceShips(GameBoard board);
    }
}
