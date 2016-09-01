using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesGame
{
    public class Mines
    {
        public class UserPoints
        {
            string name;
            int points;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Points
            {
                get { return points; }
                set { points = value; }
            }

            public UserPoints() { }

            public UserPoints(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] gameField = InitializeGameBoard();
            char[,] minesPosition = InitializeMines();
            int counter = 0;
            bool isMineFound = false;
            List<UserPoints> users = new List<UserPoints>(6);
            int row = 0;
            int column = 0;
            bool isGameInBeignState = true;
            const int MaxPoints = 35;
            bool isGameFinishedWithNoMineFound = false;

            do
            {
                if (isGameInBeignState)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawGameBoard(gameField);
                    isGameInBeignState = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintUserRatng(users);
                        break;
                    case "restart":
                        gameField = InitializeGameBoard();
                        minesPosition = InitializeMines();
                        DrawGameBoard(gameField);
                        isMineFound = false;
                        isGameInBeignState = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (minesPosition[row, column] != '*')
                        {
                            if (minesPosition[row, column] == '-')
                            {
                                SetAdjacentMinesCount(gameField, minesPosition, row, column);
                                counter++;
                            }

                            if (MaxPoints == counter)
                            {
                                isGameFinishedWithNoMineFound = true;
                            }
                            else
                            {
                                DrawGameBoard(gameField);
                            }
                        }
                        else
                        {
                            isMineFound = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isMineFound)
                {
                    DrawGameBoard(minesPosition);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", counter);
                    string username = Console.ReadLine();
                    UserPoints t = new UserPoints(username, counter);
                    if (users.Count < 5)
                    {
                        users.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].Points < t.Points)
                            {
                                users.Insert(i, t);
                                users.RemoveAt(users.Count - 1);
                                break;
                            }
                        }
                    }

                    users.Sort((UserPoints r1, UserPoints r2) => r2.Name.CompareTo(r1.Name));
                    users.Sort((UserPoints r1, UserPoints r2) => r2.Points.CompareTo(r1.Points));
                    PrintUserRatng(users);

                    gameField = InitializeGameBoard();
                    minesPosition = InitializeMines();
                    counter = 0;
                    isMineFound = false;
                    isGameInBeignState = true;
                }

                if (isGameFinishedWithNoMineFound)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawGameBoard(minesPosition);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string username = Console.ReadLine();
                    UserPoints userPoints = new UserPoints(username, counter);
                    users.Add(userPoints);
                    PrintUserRatng(users);
                    gameField = InitializeGameBoard();
                    minesPosition = InitializeMines();
                    counter = 0;
                    isGameFinishedWithNoMineFound = false;
                    isGameInBeignState = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintUserRatng(List<UserPoints> users)
        {
            Console.WriteLine("\nTo4KI:");
            if (users.Count > 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, users[i].Name, users[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void SetAdjacentMinesCount(char[,] GameBoard, char[,] Mines, int row, int column)
        {
            char minesCount = CountAdjacentMines(Mines, row, column);
            Mines[row, column] = minesCount;
            GameBoard[row, column] = minesCount;
        }

        private static void DrawGameBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int column = 0; column < columns; column++)
                {
                    Console.Write(string.Format("{0} ", board[row, column]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] InitializeGameBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] InitializeMines()
        {
            int rows = 5;
            int columns = 10;
            char[,] board = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int number = random.Next(50);
                if (!randomNumbers.Contains(number))
                {
                    randomNumbers.Add(number);
                }
            }

            foreach (int number in randomNumbers)
            {
                int column = (number / columns);
                int row = (number % columns);
                if (row == 0 && number != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                board[column, row - 1] = '*';
            }

            return board;
        }

        private static char CountAdjacentMines(char[,] board, int row, int column)
        {
            int minesCount = 0;
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, column] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, column] == '*')
                {
                    minesCount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (board[row, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (column + 1 < columns)
            {
                if (board[row, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (board[row - 1, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (board[row - 1, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (board[row + 1, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (board[row + 1, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}
