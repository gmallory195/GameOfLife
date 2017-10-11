using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Grid
    {
        int width;
        int height;

        bool[,] cells;

        public Grid(bool[,] startingPosition)
        {
            this.width = startingPosition.GetLength(0);
            this.height = startingPosition.GetLength(1);

            this.cells = startingPosition;
        }

        /// <summary>
        /// Updates the grid to the new state.
        /// </summary>
        public void UpdateState()
        {
            //
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int neighbors = CountNeighboringTiles(i, j);

                    //in the case where 2 neighbors exist, the game takes the existing state, since it never changes the state of a particular cell.
                    bool nextState = cells[i,j];

                    //if less than 2 neighbors or more than 3, the cell dies.
                    if(neighbors < 2 || neighbors > 3)
                    {
                        nextState = false;
                    }
                    //if exactly 3 the cell will always be alive.
                    else if(neighbors == 3)
                    {
                        nextState = true;
                    }

                    cells[i, j] = nextState;
                }
            }
        }

        /// <summary>
        /// Returns a number of neighbors, used to determine whether a cell is born, survives, or dies.
        /// </summary>
        /// <param name="xPosition">The X position of the grid that you want the game to find the number of neighbors.</param>
        /// <param name="yPosition">The Y position of the grid that you want the game to find the number of neighbors.</param>
        /// <returns></returns>
        public int CountNeighboringTiles(int xPosition, int yPosition)
        {
            int neighbors = 0;
            for (int i = -1; i < 1; i++)
            {
                int newX = xPosition + i;
                for (int j = -1; j < 1; j++)
                {
                    int newY = yPosition + j;
                    //need to make sure position in bounds
                    if((newX < 0) || (newX > width) || (newY < 0) || (newY > height))
                    {
                        //one of the coordinates was out of bounds
                        continue;
                    }
                    else
                    {
                        if (cells[newX, newY])
                        {
                            neighbors++;
                        }
                    }
                }
            }
            return neighbors;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DisplayGrid()
        {
            string result = "";

            for(var y = 0; y <= height; y++)
            {
                for(var x=0; x <= width; x++)
                {
                    string cell = "";

                    if (x== width)
                    {
                        cell = "\n";
                    }
                    else
                    {
                        if (cells[x, y])
                        {
                            cell = "X";

                        }
                        else
                        {
                            cell = ".";
                        }
                    }
                    result += cell;
                }
            }

            //adds another extra blank line at the end to help with readability
            result += "\n";

            return result;
        }
    }
}
