using System;

namespace Maze
{
    internal class Room : MapSite
    {
        private int _roomNumber;
        private readonly MapSite[] _sides = new MapSite[4];

        public Room(int roomNumber)
        {
            _roomNumber = roomNumber;
        }

        public MapSite this[Directions direction]
        {
            get { return _sides[(int) direction]; }
            set { _sides[(int) direction] = value; }
        }

        #region Overrides of MapSite

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}