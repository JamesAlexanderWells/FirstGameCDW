using Assets.Scripts.Rooms.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Rooms
{
    public class BaseRoom : MonoBehaviour, IRoom {

        public GameObject[] DoorTiles { get; set; }

        public GameObject[] FloorTiles { get; set; }

        public GameObject[] WallTiles { get; set; }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

    }
}
