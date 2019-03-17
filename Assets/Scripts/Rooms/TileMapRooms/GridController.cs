using System;
using Assets.Scripts.Rooms.TileMapRooms;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Rooms
{
    public class GridController : MonoBehaviour
    {
        public Tilemap GroundMap;

        public Tilemap WallMap;

        public Tilemap DoorMap;

        public BaseTileSet tileSet;

        public BaseGridRoom GridRoom { get; set; }

        public void OnEnable() { DoorCollider.OnEnterDoor += DoorEntered; }

        public void OnDisable() { DoorCollider.OnEnterDoor -= DoorEntered; }

        void Start()
        {
            var gridGameObject = new GameObject("BaseGridRoom");
            gridGameObject.transform.parent = transform;

            GridRoom = gridGameObject.AddComponent<BaseGridRoom>();
            InitialiseRoom();
        }

        private void InitialiseRoom()
        {
            var seed = Guid.NewGuid().GetHashCode();
            Random.InitState(seed);

            GridRoom.RoomWidth = Random.Range(5, 10);
            GridRoom.RoomHeight = Random.Range(5, 10);
        }

        private void DoorEntered()
        {
            GroundMap.ClearAllTiles();
            WallMap.ClearAllTiles();
            DoorMap.ClearAllTiles();
            InitialiseRoom();
            GridRoom.InitRoom();
        }
    }
}
