using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class GameofLife2
    {
        public static void Process()
        {
            bool endgame = false;
            int[,] grid = new int[,]
            {
                { 1, 0, 0, 0},
                { 0, 0, 1, 0},
                { 0, 1, 1, 0},
                { 0, 1, 0, 0},
            };
            gridconstructor gameoflife = new gridconstructor();
            while (endgame == false)
            {
                Console.WriteLine("Welcome to my Game of life simulator!");
                Console.WriteLine("To begin enter 1 , to quit enter 2:");
                Console.WriteLine();
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    gameoflife.activegird(grid);
                }
                else
                {
                    Environment.Exit(1);
                }
            }
        }

    }

    class gridconstructor
    {
        int[,] livegrid;
        int[,] oldgrid;

        // Method to carry out grid copy and checks
        public void activegird(int[,] grid)
        {
            // Copy of grid
            livegrid = (int[,])grid.Clone();

            // Get number of rows/columns in grid
            int gridcol = livegrid.GetLength(0);
            int gridrow = livegrid.GetLength(1);

            // Nested loop to itterate through grid
            for (int i = 0; i < gridcol; i++)
            {
                for (int j = 0; j < gridrow; j++)
                {
                    // get number live cells around position on grid
                    int livecellcount = cellchecker(i, j);

                    // if already live logic
                    if (livegrid[i, j] == 1)
                    {
                        if (livecellcount <= 1)
                        {
                            livegrid[i, j] = 0;
                        }
                        else if (livecellcount == 2 || livecellcount == 3)
                        {
                            livegrid[i, j] = 1;
                        }
                        else
                        {
                            livegrid[i, j] = 0;
                        }
                    }
                    // if dead logic
                    else
                    {
                        if (livecellcount == 3)
                        {
                            livegrid[i, j] = 1;
                        }
                        else
                        {
                            livegrid[i, j] = 0;
                        }
                    }
                }
            }
            // Calling method to display changes and repeat cycle.
            oldgrid = (int[,])livegrid.Clone();
            displaygrid(livegrid);
            Console.WriteLine("If you wish to continue enter y: ");
            string checkkey = Console.ReadLine();
            checkkey = checkkey.ToLower();
            if (checkkey == "y")
            {
                activegird(oldgrid);
            }

            else
            {
                return;
            }

        }



        // Method to check surrounding cells of a position on grid
        public int cellchecker(int x, int y)
        {

            // int var to hold number live cells 
            int livecells = 0;

            // checks +1 and +1
            if (x < 3 && y < 3)
            {
                if (livegrid[x + 1, y + 1] == 1)
                {
                    livecells++;
                }
            }

            // checks +1 and 0
            if (x < 3)
            {
                if (livegrid[x + 1, y] == 1)
                {
                    livecells++;
                }
            }
            // checks 0 and +1
            if (y < 3)
            {
                if (livegrid[x, y + 1] == 1)
                {
                    livecells++;
                }

            }
            // checks -1 and -1
            if (x > 0 && y > 0)
            {
                if (livegrid[x - 1, y - 1] == 1)
                {
                    livecells++;
                }
            }
            // checks 0 and -1
            if (y > 0)
            {
                if (livegrid[x, y - 1] == 1)
                {
                    livecells++;
                }
            }
            // checks -1 and 0
            if (x > 0)
            {
                if (livegrid[x - 1, y] == 1)
                {
                    livecells++;
                }
            }
            // checks 1 and -1
            if (x < 3 && y > 0)
            {
                if (livegrid[x + 1, y - 1] == 1)
                {
                    livecells++;
                }
            }
            // checks -1 and 1
            if (x > 0 && y < 3)
            {
                if (livegrid[x - 1, y + 1] == 1)
                {
                    livecells++;
                }
            }
            // returns total number of live cells
            return livecells;

        }

        public void displaygrid(int[,] livegrid)
        {
            int gridcol = livegrid.GetLength(0);
            int gridrow = livegrid.GetLength(1);

            for (int i = 0; i < gridcol; i++)
            {
                for (int j = 0; j < gridrow; j++)
                {
                    Console.Write("{0,2}", livegrid[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}