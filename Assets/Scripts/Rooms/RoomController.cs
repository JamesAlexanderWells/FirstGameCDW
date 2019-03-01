using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Rooms
{
    public class RoomController : MonoBehaviour
    {
        public GameObject CurrentRoomGameObject;

        public BaseRoom CurrentRoom { get; set; }

        public void OnEnable() { Door.OnEnterDoor += DoorEntered; }

        public void OnDisable() { Door.OnEnterDoor -= DoorEntered; }

        void Start()
        {
            CurrentRoomGameObject = Instantiate(CurrentRoomGameObject);
            CurrentRoom = CurrentRoomGameObject.GetComponent<BaseRoom>();
            InitialiseRoom();
        }

        private void InitialiseRoom()
        {
            CurrentRoom.Player = GameObject.Find("dummyPlayer");

            Random.InitState(Guid.NewGuid().GetHashCode());
            var roomWidth = Random.Range(10, 40);
            var roomHeight = Random.Range(10, 40);

            CurrentRoom.Width = (roomWidth % 2) != 0 ? roomWidth : roomWidth - 1;
            CurrentRoom.Height = (roomHeight % 2) != 0 ? roomHeight : roomHeight - 1;
        }

        private void DoorEntered()
        {
            var currentRoom = CurrentRoomGameObject.GetComponent<BaseRoom>();
            Destroy(CurrentRoomGameObject);

            var normalRoomPrefab = GameObject.FindGameObjectWithTag("NormalRoom");
            var normalComponent = normalRoomPrefab.AddComponent<NormalRoom>();

            CurrentRoom = normalComponent;
            InitialiseRoom();

            CurrentRoom.Assets = currentRoom.Assets;
            CurrentRoom.ExitDoor = currentRoom.ExitDoor;
        }
    }
}
