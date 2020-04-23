using System;

namespace GameOfLife
{
    class Program
    {
        static bool alive;
        static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.SetEmptyBoard();
            GameBoard tempBoard = new GameBoard();
            gameBoard.SetIntitialShape();
            Console.WriteLine(gameBoard);
            Console.ReadLine();
            bool inPlay = true;
            
            while (inPlay == true)
            {
                alive = false;
                
                tempBoard.SetEmptyBoard();
                for (int i = 0; i < GameBoard.boardSize; i++)
                {
                    for (int j = 0; j < GameBoard.boardSize; j++)
                    {
                        tempBoard.Board[i, j] = CellCheck(gameBoard, i, j);
                    }
                }
                gameBoard.Board = (int[,])tempBoard.Board.Clone();
                Console.Clear();
                Console.WriteLine(gameBoard);
                Console.ReadLine();
                if (alive == false)
                {
                    Console.WriteLine("everything is dead. Hit any key to start over");
                    Console.ReadLine();
                    gameBoard.SetIntitialShape();    
                }
            }
        }

        public static int CellCheck(GameBoard board, int x, int y )
        {
            int cellScore = 0;
            int initialState = board.Board[x, y];
            int xless = (x - 1) > 0 ? (x - 1) : 0;
            int xmore = (x + 1) < GameBoard.boardSize ? (x + 1) : GameBoard.boardSize-1;
            int yless = (y - 1) > 0 ? (y - 1) : 0;
            int ymore = (y + 1) < GameBoard.boardSize ? (y + 1) : GameBoard.boardSize-1;
            for (int i = xless; i < xmore+1 ; i++)
            {
                for (int j = yless; j < ymore+1; j++)
                {
                    cellScore = cellScore + board.Board[i, j];
                }
            }
            if (initialState == 1)
            {
                if (cellScore-1 == 2 || cellScore-1 == 3)
                {
                    alive = true;
                    return 1;
                }
                else
                {
                    
                    return 0;
                }
                
            }
            if (initialState == 0)
            {
                if (cellScore == 3)
                {
                    alive = true;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            
            
        }
    }
}
