using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera_BattleShip
{
    // Observer Pattern, implementation av IObserver interface och används för att visa meddelanden i konsolen.
    public class ConsoleDisplay : IObserver
    {
        // Update metoden som anropas när en förändring sker.
        // Metoden skriver ut det meddelande som skickat från det specifika "stället" till konsolen. 
        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }
}
