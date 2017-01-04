using System;

namespace Maze
{
    internal class Door : MapSite
    {
        private bool _isOpen;
        private Room _room1;
        private Room _room2;

        public Door(Room room1, Room room2)
        {
            _room1 = room1;
            _room2 = room2;
        }

        #region Overrides of MapSite

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        #endregion

        public Room OtherSideFrom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}