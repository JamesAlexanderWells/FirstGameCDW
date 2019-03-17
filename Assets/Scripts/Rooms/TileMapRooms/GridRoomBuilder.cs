using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;
using Tile = UnityEngine.Tilemaps.Tile;

namespace Assets.Scripts.Rooms.TileMapRooms
{
    public class GridRoomBuilder
    {
        private Tilemap groundMap;
        private Tilemap wallMap;
        private Tilemap doorMap;
        private BaseTileSet tileSet;
        private int roomWidth;
        private int roomHeight;

        public GridRoomBuilder(Tilemap groundMap, Tilemap wallMap, Tilemap doorMap, 
            BaseTileSet tileSet, int roomWidth, int roomHeight)
        {
            this.groundMap = groundMap;
            this.doorMap = doorMap;
            this.wallMap = wallMap;
            this.tileSet = tileSet;
            this.roomWidth = roomWidth;
            this.roomHeight = roomHeight;
        }

        public void Build(int roomStartX, int roomStartY)
        {
            for (var x = roomStartX; x <= roomWidth; x++)
            {
                for (var y = roomStartY; y <= roomHeight; y++)
                {
                    AddGroundTile(x, y);
                    AddWallTile(x, y, roomStartX, roomStartY);
                }
            }
            AddDoorTiles();
        }

        private void AddDoorTiles()
        {
            doorMap.SetTile(new Vector3Int(roomWidth * -1, 0, 0), tileSet.LevelDoors[2]);
            doorMap.SetTile(new Vector3Int(roomWidth, 0, 0),  tileSet.LevelDoors[3]);
            doorMap.SetTile(new Vector3Int(0, roomHeight * -1, 0), tileSet.LevelDoors[1]);
            doorMap.SetTile(new Vector3Int(0, roomHeight, 0), tileSet.LevelDoors[0]);
        }

        private void AddWallTile(int x, int y, int roomStartX, int roomStartY)
        {
            var position = new Vector3Int(x, y, 0);
            var wallCase = (x == roomStartX) || (y == roomStartY) || (x == roomWidth) || (y == roomHeight);

            if (wallCase)
                wallMap.SetTile(position, tileSet.LevelWalls[0]);
        }

        private void AddGroundTile(int x, int y)
        {
            var position = new Vector3Int(x, y, 0);
            groundMap.SetTile(position, tileSet.LevelFloors[0]);
        }
    }
}
