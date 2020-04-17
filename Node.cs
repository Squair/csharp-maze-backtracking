namespace maze
{
    class Node
    {
        public Node(bool wall)
        {
            this.wall = wall;
        }
        public bool wall { get; set; }
        public bool visited { get; set; }
    }
}
