using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Rooms.Interfaces
{
    public interface IRoom
    {
        GameObject[] DoorTiles { get; set; }

        GameObject[] FloorTiles { get; set; }

        GameObject[] WallTiles { get; set; }
    }
}
