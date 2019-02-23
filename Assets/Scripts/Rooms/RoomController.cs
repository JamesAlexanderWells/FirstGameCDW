using Assets.Scripts.Rooms.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Rooms
{
    public class RoomController : MonoBehaviour {

        private readonly IRoom _currentRoom;

        public RoomController(IRoom currentRoom)
        {
            _currentRoom = currentRoom;
        }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
