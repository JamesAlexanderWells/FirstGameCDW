using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Assets.Scripts.Rooms
{
    public class BaseRoom : MonoBehaviour
    {
        public List<GameObject> DoorTiles;

        public List<GameObject> FloorTiles;

        public List<GameObject> WallTiles;

        public List<GameObject> PrefabObjects;

        public GameObject Player;

        public float Width { get; set; }

        public float Height { get; set; }

        public BaseRoom()
        {
            DoorTiles = new List<GameObject>();
            FloorTiles = new List<GameObject>();
            WallTiles = new List<GameObject>();
            PrefabObjects = new List<GameObject>();
        }

        // Use this for initialization
        void Start()
        {
            Vector3 initialPosition;
            var tileSize = GetTileSize();

            var renderPosition = SetInitialRenderPosition(tileSize, out initialPosition);
            BuildRoom(renderPosition, tileSize, initialPosition);
        }

        public Vector3 SetInitialRenderPosition(Vector3 tileSize, out Vector3 initialPosition)
        {
            var playerPosition = Player.transform.position;
            initialPosition = GetInitialPosition(tileSize, playerPosition);
            return initialPosition;
        }

        public virtual Vector3 GetInitialPosition(Vector3 tileSize, Vector3 playerPosition)
        {
            return new Vector3(playerPosition.x - 0.5f * (Width * tileSize.x),
                playerPosition.y - 0.5f * (Height * tileSize.y), 0);
        }

        public Vector3 GetTileSize()
        {
            var tileRenderer = FloorTiles[0].GetComponent<Renderer>();
            var tileSize = tileRenderer.bounds.size;
            return tileSize;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void BuildRoom(Vector3 renderPosition, Vector3 tileSize, Vector3 initialPosition)
        {
            for (float x = 0; x < Width; x++)
            {
                for (float y = 0; y < Height; y++)
                {
                    Instantiate(FloorTiles[0], renderPosition, Quaternion.identity);
                    renderPosition += new Vector3(0, tileSize.y, 0);
                }
                renderPosition.x += tileSize.x;
                renderPosition.y = initialPosition.y;
            }
        }
    }
}
