using System.Collections.Generic;
using System;

namespace maze
{
    class Program
    {
        static void Main(string[] args)
        {
            //'t' are walls, 'f' are postions that can be moved to.
            string[,] grid = new string[,]{{"t", "t", "t"},
                                          {"f", "f", "f"},
                                          {"f", "t", "f"},
                                          {"f", "f", "f"}};
            var maze = new Maze();
            maze.map = new Node[grid.GetLength(1), grid.GetLength(0)];
            
            //Map grid to nodes 
            for (int y = 0; y < grid.GetLength(0); y++){
                for (int x = 0; x < grid.GetLength(1); x++){
                    bool wall = grid[y,x] == "t" ? true : false;
                    maze.map[x,y] = new Node(wall);
                }
            }
            maze.minDist = int.MaxValue;
            //Start bottom left (2, 3) and try to reach top middle (1, 1)
            maze.traverse(2, 3, 1, 1);

            //If minimum distance is never set lower than int.maxValue we know no route is availible
            if (maze.minDist < int.MaxValue){
                Console.WriteLine("Distance:" + maze.minDist);
            } else {
                Console.WriteLine("No route");
            }
        }
    }
}

