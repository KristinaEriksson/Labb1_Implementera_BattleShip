namespace Labb1_Implementera_BattleShip
{
    internal class Program
    {
        // Kristina Eriksson .NET22

        // Använder Factory Method Pattern för att skapa ett GameBoard-objeket med hjälp av GameBoardFactory som är en abstrakt klass och StandardGameBoardFactory. 
        // Singleton Pattern används för att säkerställa att det bara finns en instans av StandardGameBoardFactory. 
        // Observer Pattern används för att avisera om händelser i spelet genom att skicka meddelanden till observern ConsoleDisplay när spelstatusen ändras. 
        // ConsoleDisplay implementerar IObserver varje gång något händer i GameBoard. 
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                bool gameOver = false;
                // Factory Method Pattern , singleton pattern  (jag blev lite osäker här, vet inte om det är det ena eller det andra, då de verkar vävas ihop) 
                // Factory Method skapar en instans av GameBoardFactory och Singleton säkerställer att det bara finns en enda instans av StandardGameBoardFactory
                GameBoardFactory factory = StandardGameBoardFactory.Instance;

                Console.WriteLine("Welcome to Battleship!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Choose difficulty level:");
                Console.WriteLine("1. Easy (5x5 board, 3 ships)");
                Console.WriteLine("2. Medium (8x8 board, 5 ships)");
                Console.WriteLine("3. Hard (10x10 board, 7 ships)");
                Console.WriteLine();
                Console.WriteLine("Enter your choice: ");
                
                int choice = Convert.ToInt32(Console.ReadLine());

                int boardSize = 0;
                int numShips = 0;
                

                switch (choice)
                {
                    case 1:
                        boardSize = 5;
                        numShips = 3;
                        break;
                    case 2:
                        boardSize = 8;
                        numShips = 5;
                        break;
                    case 3:
                        boardSize = 10;
                        numShips = 7;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Exiting the game.");
                        return;
                }

                // Skapar spelbräde och placerar ut skepp slumpmässigt på spelplanen
                // Skapar en instans av RandomShipPlacementStrategy
                IShipsPlacementStategy shipPlacementStrategy = new RandomShipPlacementStrategy();
                // Skapar en instans av GameBoard med vald storlek och antal skepp
                GameBoard gameBoard = factory.CreateGameBoard(boardSize, numShips);

                //  Observer pattern, bifogar observer till gameBoard
                IObserver display = new ConsoleDisplay();
                gameBoard.Attach(display);

                //  Placerar  skepp på spelbrädet
                shipPlacementStrategy.PlaceShips(gameBoard);
                Console.Clear();
                gameBoard.DisplayBoard();

                while (!gameOver)
                {
                    
                    Console.WriteLine();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("Enter coordinates to fire (e.g., A1, B2, C3) or enter 'q' to quit:");
                    
                    string input = Console.ReadLine().ToUpper();

                    if (input == "Q")
                        break;

                    if (input.Length != 2 || !char.IsLetter(input[0]) || !char.IsDigit(input[1]))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        continue;
                    }

                    int x = input[0] - 'A';
                    int y = input[1] - '1';

                    if (x < 0 || x >= boardSize || y < 0 || y >= boardSize)
                    {
                        Console.WriteLine("Invalid coordinates. Please try again.");
                        continue;
                    }

                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    gameBoard.Fire(x, y);
                    
                    gameBoard.DisplayBoard();
                    

                    // Kontrollerar om alla skepp har sänkts för att avgöra om spelet är slut.
                    if (gameBoard.ShipsRemaining == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Do you want to play again? (Y/N");
                string userInput = Console.ReadLine().ToUpper();
                playAgain = (userInput == "Y");
                Console.Clear();
            }

            Console.WriteLine("Thank you for playing Battleship! Goodbye!");
        }
    }
}