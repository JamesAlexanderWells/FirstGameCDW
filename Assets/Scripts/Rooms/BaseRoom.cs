using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Assets.Scripts.Rooms
{
    public class BaseRoom : MonoBehaviour
    {
        public const float Tolerance = 0.0001f;


        public List<GameObject> DoorTiles;

        public List<GameObject> FloorTiles;

        public List<GameObject> WallTiles;

        public List<GameObject> PrefabObjects;

        public GameObject Player;


        public float Width { get; set; }

        public float Height { get; set; }

        public Vector3 TileSize { get; set; }

        public BaseRoom()
        {
            DoorTiles = new List<GameObject>();
            FloorTiles = new List<GameObject>();
            WallTiles = new List<GameObject>();
            PrefabObjects = new List<GameObject>();
        }

        void Start()
        {
            Vector3 initialPosition;
            TileSize = GetFloorTileSize();

            var renderPosition = SetInitialRenderPosition(out initialPosition);
            BuildRoom(renderPosition, initialPosition);
        }

        public Vector3 SetInitialRenderPosition(out Vector3 initialPosition)
        {
            var playerPosition = Player.transform.position;
            initialPosition = GetInitialPosition(playerPosition);
            return initialPosition;
        }

        public virtual Vector3 GetInitialPosition(Vector3 playerPosition)
        {
            return new Vector3(playerPosition.x - 0.5f * (Width * TileSize.x),
                playerPosition.y - 0.5f * (Height * TileSize.y), 0);
        }

        public Vector3 GetFloorTileSize()
        {
            var tileRenderer = FloorTiles[0].GetComponent<Renderer>();
            var tileSize = tileRenderer.bounds.size;
            return tileSize;
        }

        private void BuildRoom(Vector3 renderPosition, Vector3 initialPosition)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if ((x == 0 && IsRoomEnd(y - (Height - 1) / 2f) ||
                        (y == 0 && IsRoomEnd(x - (Width - 1) / 2f)) ||
                        (IsRoomEnd(x - (Width - 1)) && IsRoomEnd(y - (Height - 1) / 2f)) ||
                        (IsRoomEnd(y - (Height - 1)) && IsRoomEnd(x - (Width - 1) / 2f))))
                    {
                        AddTile(new RandomTileSelector(DoorTiles).GetRandomTile(), ref renderPosition);
                        continue;
                    }

                    if (x == 0 || y == 0 || IsRoomEnd(x - (Width - 1)) || IsRoomEnd(y - (Height - 1)))
                    {
                        AddTile(new RandomTileSelector(WallTiles).GetRandomTile(), ref renderPosition);
                        continue;
                    }
                    AddTile(new RandomTileSelector(FloorTiles).GetRandomTile(), ref renderPosition);
                }
                renderPosition.x += TileSize.x;
                renderPosition.y = initialPosition.y;
            }
        }

        private bool IsRoomEnd(float expression)
        {
            return Math.Abs(expression) < Tolerance;
        }

        private void AddTile(GameObject tile, ref Vector3 renderPosition)
        {
            Instantiate(tile, renderPosition, Quaternion.identity);
            renderPosition += new Vector3(0, TileSize.y);
        }
    }
}
