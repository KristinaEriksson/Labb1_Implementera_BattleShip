using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera_BattleShip
{
    // Observer pattern, implementation av ISubject interface och representerar spelbrädet för spelet Skänka Skepp. 
    // Implementerar Observer Pattern och observers-listan används för att hantera observer-objekt. 
    public class GameBoard : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private char[,] board; // brädet som användaren ser
        private bool[,] shipBoard; // brädet som skeppen placeras på 
        private int _numShips;
        private int _shipsRemaining;
        



        public int Size { get; private set; }
        public int NumShips { get { return _numShips; } }
        public int ShipsRemaining { get { return _shipsRemaining; } }



        // Konstruktor som skapar en ny instans av GameBoard med angiven storlek och antal skepp.
        public GameBoard(int size, int numShips)
        {
            Size = size;
            _numShips = numShips;
            _shipsRemaining = numShips;
            

            board = new char[size, size];
            shipBoard = new bool[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = '-';
                    shipBoard[i, j] = false;
                }
            }
            
        }
        // Metod som krävs av ISubject interface.
        // Lägger till en ny observer till listan observers som "övervakar" just detta ämne.
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        // Metod som krävs av ISubject interface
        // Tar bort observer från listan observers som "övervakar" händelser från detta ämne.
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        // Metod som krävs av ISubject interface
        // Meddelar alla observers om en händelse genom att anropa deras Update-metoder med det meddelandet som skickas.
        public void Notify(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
        

        

        public bool IsShipPlaced(int x, int y)
        {
            return shipBoard[x, y];
        }
        public void PlaceShip(int x, int y)
        {
            if (!shipBoard[x, y])
            {
                shipBoard[x, y] = true;
                board[x, y] = '-';
            }
        }

        public void Fire(int x, int y)
        {

            if (shipBoard[x, y])
            {
                shipBoard[x, y] = false;
                board[x, y] = 'X';
                _shipsRemaining--;
                Console.ForegroundColor = ConsoleColor.Green;
                Notify($"Hit! Ships remaining: {_shipsRemaining}");
                Console.ResetColor();
            }
            else if (board[x, y] == '-')
            {
                board[x, y] = 'O';
                Notify("Miss!");
            }

            if (_shipsRemaining == 0)
            {
                Notify("Congratulations! You won! You have sunk all the ships!");
            }
        }

        public void DisplayBoard()
        {

            // Visa radrubrik med siffror för koordinater
            Console.Write("  ");
            for (int i = 0; i < Size; i++)
            {
                Console.Write((i + 1) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < Size; i++)
            {
                // Visa kolumnrubrik med bokstäver för koordinater
                Console.Write((char)('A' + i) + " ");

                for (int j = 0; j < Size; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
