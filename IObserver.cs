using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera_BattleShip
{
    // Interface för observersobjekt
    public interface IObserver
    {
        void Update(string message);
    }
}
