using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Rooms
{
    public class RoomController : MonoBehaviour
    {
        public GameObject CurrentRoom;

        public void OnEnable() { Door.OnEnterDoor += DoorEntered; }

        public void OnDisable() { Door.OnEnterDoor -= DoorEntered; }

        void Start()
        {
            CurrentRoom = Instantiate(CurrentRoom);
            var baseRoom = CurrentRoom.GetComponent<BaseRoom>();

            baseRoom.Player = GameObject.Find("dummyPlayer");

            Random.InitState(Guid.NewGuid().GetHashCode());
            var roomWidth = Random.Range(10, 40);
            var roomHeight = Random.Range(10, 40);

            baseRoom.Width = (roomWidth % 2) != 0 ? roomWidth : roomWidth - 1;
            baseRoom.Height = (roomHeight % 2) != 0 ? roomHeight : roomHeight - 1;
        }

        private void DoorEntered()
        {
            Debug.Log("Door Hit!");
        }
    }
}
