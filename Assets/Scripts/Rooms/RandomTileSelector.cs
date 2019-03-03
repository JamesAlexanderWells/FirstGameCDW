using System;
using System.Collections.Generic;
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

            // We're going to get a little more perf running a for loop over
            // using LINQ here.
            float minXPosition = float.MaxValue, minYPosition = float.MaxValue, 
                maxXPosition = float.MinValue, maxYPosition = float.MinValue;

            foreach (var tile in tileSpace)
            {
                var tilePosition = tile.transform.position;

                if (tilePosition.x < minXPosition)
                    minXPosition = tilePosition.x;

                if (tilePosition.y < minYPosition)
                    minYPosition = tilePosition.y;

                if (tilePosition.x > maxXPosition)
                    maxXPosition = tilePosition.x;

                if (tilePosition.y > maxYPosition)
                    maxYPosition = tilePosition.y;
            }
            var xCoordinate = UnityRandom.Range(minXPosition, maxXPosition);
            var yCoordinate = UnityRandom.Range(minYPosition, maxYPosition);
            return new Vector3(xCoordinate, yCoordinate);
        }
    }
}
