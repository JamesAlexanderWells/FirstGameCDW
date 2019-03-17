using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Rooms.TileMapRooms;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseTileSet : MonoBehaviour
{
    public List<Tile> LevelWalls;

    public List<Tile> LevelFloors;

    public List<Tile> LevelDoors;
}
