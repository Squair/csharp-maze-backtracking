using System;

namespace maze
{
    class Maze
    {
        public Node[,] map { get; set; }
        public int dist { get; set; }
        public int minDist { get; set; }

        //Find shortest distance from one point in matrix to another using backtracking
        public void traverse(int x, int y, int endX, int endY)
        {
            //If end reached, compare journey with previous and take the minimum
            if (x == endX && y == endY)
            {
                this.minDist = Math.Min(dist, minDist);
                return;
            }
            //Mark visited squares as being visited
            map[x, y].visited = true;

            //Moving right
            if (inBounds(x + 1, y) && !isWallOrVisited(x + 1, y))
            {
                //Increase distance for each move and keep calling traverse
                this.dist++;
                traverse(x + 1, y, endX, endY);
                //Decrease distance when stack unwinding as backtracking happens
                this.dist--;
            }

            //Moving Left
            if (inBounds(x - 1, y) && !isWallOrVisited(x - 1, y))
            {
                //Increase distance for each move and keep calling traverse
                this.dist++;
                traverse(x - 1, y, endX, endY);
                //Decrease distance when stack unwinding as backtracking happens
                this.dist--;
            }

            //Moving Up
            if (inBounds(x, y - 1) && !isWallOrVisited(x, y - 1))
            {
                //Increase distance for each move and keep calling traverse
                this.dist++;
                traverse(x, y - 1, endX, endY);
                //Decrease distance when stack unwinding as backtracking happens
                this.dist--;
            }
            //Moving Down
            if (inBounds(x, y + 1) && !isWallOrVisited(x, y + 1))
            {
                //Increase distance for each move and keep calling traverse                
                this.dist++;
                traverse(x, y + 1, endX, endY);
                //Decrease distance when stack unwinding as backtracking happens
                this.dist--;
            }

            //If no movement can be made, set the square to not visited as backtracking
            map[x, y].visited = false;
        }

        //Checks square is within bounds of array
        private bool inBounds(int x, int y)
        {
            return (x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1));
        }

        //Check sqaure is a wall or has been visited
        private bool isWallOrVisited(int x, int y)
        {
            if (map[x, y].wall || map[x, y].visited == true)
                return true;
            else
                return false;
        }
    }
}
