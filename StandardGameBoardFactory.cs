using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera_BattleShip
{
    // Singleton pattern, instance variabeln och den privata konstruktorn används för att säkerställa att det endast finns en instans av StandardGameBoardFactory
    public class StandardGameBoardFactory : GameBoardFactory
    {
        private static StandardGameBoardFactory instance;

        private StandardGameBoardFactory() { }

        public static StandardGameBoardFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StandardGameBoardFactory();
                }
                return instance;
            }
        }

        public override GameBoard CreateGameBoard(int size, int numShips)
        {
            return new GameBoard(size, numShips);
        }


    }
}
