using System;
using System.Collections.Generic;
using Assets.Scripts.Enumerations;
using Assets.Scripts.Rooms.Models;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Rooms
{
    public class RoomBuilder
    {
        public const float Tolerance = 0.0001f;

        private float widthBound;

        private float heightBound;

        private Vector3 tileSize;

        private Vector3 initialPosition;

        private Vector3 renderPosition;

        private RoomAssetSet assets;

        private GameObject parentRoom;

        public RoomBuilder(float widthBound, float heightBound, Vector3 tileSize,
            Vector3 initialPosition, Vector3 renderPosition, RoomAssetSet assets,
            string roomName)
        {
            this.widthBound = widthBound;
            this.heightBound = heightBound;
            this.tileSize = tileSize;
            this.initialPosition = initialPosition;
            this.renderPosition = renderPosition;
            this.assets = assets;
            this.parentRoom = GameObject.Find(roomName);
        }

        public void Build()
        {
            for (int x = 0; x < widthBound; x++)
            {
                for (int y = 0; y < heightBound; y++)
                {
                    if (DetectDoorCases(x, y))
                    {
                        AddDoorTiles();
                        continue;
                    }

                    if (x == 0 || y == 0 || IsRoomEnd(x - (widthBound - 1)) || IsRoomEnd(y - (heightBound - 1)))
                    {
                        AddRoomTile(new RandomTileSelector(assets.WallTiles).GetRandomTile(), ref renderPosition);
                        continue;
                    }
                    AddRoomTile(new RandomTileSelector(assets.FloorTiles).GetRandomTile(), ref renderPosition);
                }
                renderPosition.x += tileSize.x;
                renderPosition.y = initialPosition.y;
            }
            AddRandomPrefabs();
        }

        private void AddDoorTiles()
        {
            var selector = new RandomTileSelector(assets.DoorTiles);
            if (selector.GetProbabilisticChoice(0.5f))
                AddRoomTile(selector.GetRandomTile(), ref renderPosition);

            else
            {
                selector.Tiles = assets.WallTiles;
                AddRoomTile(selector.GetRandomTile(), ref renderPosition);
            }
        }

        private void AddRandomPrefabs()
        {
            Random.InitState(Guid.NewGuid().GetHashCode());
            var noOfRandomPrefabs = Random.Range(1, 6);

            for (int i = 0; i < noOfRandomPrefabs; i++)
            {
                var selector = new RandomTileSelector(assets.PrefabTiles);
                var newPrefab = Object.Instantiate(selector.GetRandomTile(),
                    selector.GetRandomVectorInSpace(GameObject.FindGameObjectsWithTag("Floor")), Quaternion.identity);
                newPrefab.transform.parent = parentRoom.transform;
            }
        }

        private void AddRoomTile(GameObject tile, ref Vector3 renderPosition)
        {
            var newTile = Object.Instantiate(tile, renderPosition, Quaternion.identity);
            newTile.transform.parent = parentRoom.transform;
            renderPosition += new Vector3(0, tileSize.y);
        }

        private bool DetectDoorCases(int x, int y)
        {
            var leftDoor = x == 0 && IsRoomEnd(y - (heightBound - 1) / 2f);
            var bottomDoor = y == 0 && IsRoomEnd(x - (widthBound - 1) / 2f);
            var rightDoor = IsRoomEnd(x - (widthBound - 1)) && IsRoomEnd(y - (heightBound - 1) / 2f);
            var topDoor = IsRoomEnd(y - (heightBound - 1)) && IsRoomEnd(x - (widthBound - 1) / 2f);
            return leftDoor || bottomDoor || rightDoor || topDoor;
        }

        private bool IsRoomEnd(float expression)
        {
            return Math.Abs(expression) < Tolerance;
        }
    }
}
