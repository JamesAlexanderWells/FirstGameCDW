using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;
using UnityRandom = UnityEngine.Random;

namespace Assets.Scripts.Rooms
{
    public class RandomTileSelector
    {
        public List<GameObject> Tiles { get; set; }

        public Random Random { get; set; }

        public RandomTileSelector(List<GameObject> tiles)
        {
            Random = new Random(Guid.NewGuid().GetHashCode());
            Tiles = tiles;
        }

        public GameObject GetRandomTile()
        {
            var index = Random.Next(Tiles.Count);
            return Tiles[index];
        }

        public bool GetProbabilisticChoice(float threshold)
        {
            var generate = (float)Random.NextDouble();
            return generate > threshold;
        }

        public Vector3 GetRandomVectorInSpace(GameObject[] tileSpace)
        {
            UnityRandom.InitState(Guid.NewGuid().GetHashCode());
            var minXPosition = tileSpace.Min(x => x.transform.position.x);
            var maxXPosition = tileSpace.Max(x => x.transform.position.x);

            var minYPosition = tileSpace.Min(x => x.transform.position.y);
            var maxYPosition = tileSpace.Max(x => x.transform.position.y);

            var xCoordinate = UnityRandom.Range(minXPosition, maxXPosition);
            var yCoordinate = UnityRandom.Range(minYPosition, maxYPosition);
            return new Vector3(xCoordinate, yCoordinate);
        }
    }
}
