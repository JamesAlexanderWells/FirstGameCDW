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
            var playerPosition = Player.transform.position;

            var tileRenderer = FloorTiles[0].GetComponent<Renderer>();
            var tileSize = tileRenderer.bounds.size;

            var initialPosition = new Vector3(playerPosition.x - 0.5f * (Width * tileSize.x),
                playerPosition.y - 0.5f * (Height * tileSize.y), 0);
            var renderPosition = initialPosition;

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

        // Update is called once per frame
        void Update()
        {

        }

    }
}
