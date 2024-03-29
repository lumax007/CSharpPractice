﻿//using System;
//using System.Security.Cryptography;
//using System.Text;

//namespace CSharpPractice
//{
//    public class GameOfLife
//    {
//        public enum State
//        {
//            D,
//            A,
//        }
//        const int Rows = 4;
//        const int Columns = 4;

//        public static void Process()
//        {
//            var grid = new State[Rows, Columns];
//            for (var row = 0; row < Rows; row++)
//            {
//                for (var column = 0; column < Columns; column++)
//                {
//                    grid[row, column] = (State)RandomNumberGenerator.GetInt32(0, 2);
//                }
//            }

//            for (int i = 0; i < 1000; i++)
//            {
//                Display(grid);
//                grid = NextGrid(grid);
//            }
//        }

//        private static State[,] NextGrid(State[,] currentGrid)
//        {
//            var nextGrid = new State[Rows, Columns];
//            for (var row = 1; row < Rows - 1; row++)
//            {
//                for (var column = 1; column < Columns - 1; column++)
//                {
//                    var aliveNeighbors = 0;

//                    for (int i = -1; i < 2; i++)
//                    {
//                        for (int j = -1; j < 2; j++)
//                        {
//                            aliveNeighbors += currentGrid[row + i, column + j] == State.A ? 1 : 0;
//                        }
//                    }

//                    var currentCell = (State)currentGrid[row, column];
//                    aliveNeighbors -= currentCell == State.A ? 1 : 0;

//                    if (currentCell == State.A && aliveNeighbors < 2)
//                    {
//                        nextGrid[row, column] = State.D;
//                    }
//                    else if (currentCell == State.A && aliveNeighbors > 3)
//                    {
//                        nextGrid[row, column] = State.D;
//                    }
//                    else if (currentCell == State.D && aliveNeighbors == 3)
//                    {
//                        nextGrid[row, column] = State.A;
//                    }
//                    else
//                    {
//                        nextGrid[row, column] = (State)currentCell;
//                    }
//                }
//            }
//            return nextGrid;
//        }

//        private static void Display(State[,] next)
//        {
//            var stringBuilder = new StringBuilder();
//            for (var row = 0; row < Rows; row++)
//            {
//                for (var column = 0; column < Columns; column++)
//                {
//                    var cell = next[row, column];
//                    stringBuilder.Append(cell == State.A ? " A " : " D ");
//                }
//                stringBuilder.Append("\n");
//            }
//            Console.WriteLine(stringBuilder.ToString());
//        }
//    }
//}

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace CSharpPractice
{
    static class GameOfLife
    {
        const int Rows = 4;
        const int Columns = 4;

        static bool runSimulation = true;

        public static void Process()
        {
            var grid = new Status[Rows, Columns];

            // randomly initialize our grid
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    grid[row, column] = (Status)RandomNumberGenerator.GetInt32(0, 2);
                }
            }

            Console.CancelKeyPress += (sender, args) =>
            {
                runSimulation = false;
                Console.WriteLine("\n👋 Ending simulation.");
            };

            // let's give our console
            // a good scrubbing
            Console.Clear();

            // Displaying the grid 
            while (runSimulation)
            {
                Print(grid);
                grid = NextGeneration(grid);
            }
        }

        private static Status[,] NextGeneration(Status[,] currentGrid)
        {
            var nextGeneration = new Status[Rows, Columns];

            // Loop through every cell 
            for (var row = 1; row < Rows - 1; row++)
                for (var column = 1; column < Columns - 1; column++)
                {
                    // find your alive neighbors
                    var aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            aliveNeighbors += currentGrid[row + i, column + j] == Status.Alive ? 1 : 0;
                        }
                    }

                    var currentCell = currentGrid[row, column];

                    // The cell needs to be subtracted 
                    // from its neighbors as it was  
                    // counted before 
                    aliveNeighbors -= currentCell == Status.Alive ? 1 : 0;

                    // Implementing the Rules of Life 

                    // Cell is lonely and dies 
                    if (currentCell == Status.Alive && aliveNeighbors < 2)
                    {
                        nextGeneration[row, column] = Status.Dead;
                    }

                    // Cell dies due to over population 
                    else if (currentCell == Status.Alive && aliveNeighbors > 3)
                    {
                        nextGeneration[row, column] = Status.Dead;
                    }

                    // A new cell is born 
                    else if (currentCell == Status.Dead && aliveNeighbors == 3)
                    {
                        nextGeneration[row, column] = Status.Alive;
                    }
                    // stays the same
                    else
                    {
                        nextGeneration[row, column] = currentCell;
                    }
                }
            return nextGeneration;
        }

        private static void Print(Status[,] future, int timeout = 500)
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var cell = future[row, column];
                    stringBuilder.Append(cell == Status.Alive ? " L " : " D ");
                }
                stringBuilder.Append("\n");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder.ToString());
            Thread.Sleep(timeout);
        }
    }

    public enum Status
    {
        Dead,
        Alive,
    }
}