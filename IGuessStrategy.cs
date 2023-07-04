using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera_BattleShip
{
    // Interface som representerar en gissningstrategi
    public interface IGuessStrategy
    {
        // Metod för att göra en gissning i spelet
        void Guess(GameBoard board);
    }
}
