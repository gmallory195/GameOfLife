using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;

            Console.Write("Welcome to the game of life.\nHow many lines high would you like to make your grid?: ");
            string heightString = Console.ReadLine();
            int height;
            bool error = false;
            if (!int.TryParse(heightString, out height))
            {
                error = true;
            }

            while (repeat)
            {


                //height parsed correctly
                if (!error)
                {
                    Console.WriteLine("\nCreate your grid line by line.\nUse X for alive cells, all other cells will be considered dead.\nEach row will be padded to the length of the longest row with empty cells.\n\n");
                    List<string> lines = new List<string>();
                    for (var i = 0; i < height; i++)
                    {
                        string line = Console.ReadLine();
                        lines.Add(line);
                    }
                    bool[,] testboolarray = new bool[2, 2];
                    Grid grid = new Grid(ConvertToGridArray(lines));
                    //Grid testgrid = new Grid(testboolarray);
                    Console.Clear();
                    Console.WriteLine(grid.DisplayGrid());
                    grid.UpdateState();
                    Console.WriteLine(grid.DisplayGrid());
                    Console.ReadLine();
                }

            }

        }

        public static bool[,] ConvertToGridArray(List<string> strings)
        {
            int width = 0;
            //set the padding for the grid
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i].Length > width)
                {
                    width = strings[i].Length;
                }
            }

            //now we're actually building the grid
            bool[,] grid = new bool[width, strings.Count];


            for (int y = 0; y < strings.Count; y++)
            {

                for(int x = 0; x < strings[y].Length; x++)
                {

                    grid[x, y] = strings[y][x].ToString().ToUpper() == "X";
                    
                }
            }



            return grid;
        }
    }
}
