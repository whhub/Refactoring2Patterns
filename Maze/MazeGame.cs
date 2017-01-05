namespace Maze
{
    class MazeGame
    {
        public static Maze CreateMaze()
        {
            var maze = new Maze();
            var r1 = new Room(1);
            var r2 = new Room(2);
            var door = new Door(r1, r2);

            maze.AddRoom(r1);
            maze.AddRoom(r2);

            r1[Directions.North] = new Wall();
            r1[Directions.East] = door;
            r1[Directions.South] = new Wall();
            r1[Directions.West] = new Wall();

            r2[Directions.North] = new Wall();
            r2[Directions.East] = new Wall();
            r2[Directions.South] = new Wall();
            r2[Directions.West] = door;

            return maze;
        }
    }
}
