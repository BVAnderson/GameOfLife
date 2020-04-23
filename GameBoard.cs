using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class GameBoard
    {
        public int[,] Board { get; set; }

        public static int boardSize = 40;

        public GameBoard()
        {
            this.Board = new int[boardSize,boardSize];
        }

        public void SetEmptyBoard()
        {
            for (int i = 0; i<boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    this.Board[i, j] = 0;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder boardString = new StringBuilder();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    boardString.Append(Board[i, j].ToString());
                }
                boardString.AppendLine();
            }
            return boardString.ToString();
        }

        public void SetIntitialShape()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    var rand = new Random();
                    this.Board[i, j] = rand.Next(0,2);
                }
            }
        }

    }
}
