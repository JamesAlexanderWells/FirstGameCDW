using Assets.Scripts.Enumerations;
using Assets.Scripts.Rooms.Models;
using UnityEngine;

namespace Assets.Scripts.Rooms
{
    public class BaseRoom : MonoBehaviour
    {
        public RoomAssetSet Assets;

        public GameObject Player;

        public PreviousDoor ExitDoor;


        public float Width { get; set; }

        public float Height { get; set; }

        public Vector3 TileSize { get; set; }

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
            var tileRenderer = Assets.FloorTiles[0].GetComponent<Renderer>();
            var tileSize = tileRenderer.bounds.size;
            return tileSize;
        }

        private void BuildRoom(Vector3 renderPosition, Vector3 initialPosition)
        {
            var builder = new RoomBuilder(Width, Height, TileSize, initialPosition,
                renderPosition, Assets, this.name);
            builder.Build();
        }
    }
}
