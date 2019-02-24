using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Rooms
{
    public class RandomTileSelector
    {
        public List<GameObject> Tiles { get; set; }

        public RandomTileSelector(List<GameObject> tiles)
        {
            Tiles = tiles;
        }

        public GameObject GetRandomTile()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var index = random.Next(Tiles.Count);
            return Tiles[index];
        }
    }
}
