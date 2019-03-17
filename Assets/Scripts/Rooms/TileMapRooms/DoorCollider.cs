using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Rooms.TileMapRooms
{
    public class DoorCollider : MonoBehaviour
    {
        public delegate void EnterDoor();
        public static event EnterDoor OnEnterDoor;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (OnEnterDoor != null)
            {
                var groundMap = GameObject.Find("Ground").GetComponent<Tilemap>();
                Vector3 center = groundMap.CellToWorld(new Vector3Int(0, 0, 0));

                collision.gameObject.transform.position = center; 
                OnEnterDoor();
            }
        }
    }
}
