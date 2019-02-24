using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Rooms
{
    public class RoomController : MonoBehaviour
    {
        public GameObject CurrentRoom;

        // Use this for initialization
        void Start()
        {
            CurrentRoom = Instantiate(CurrentRoom);
            var baseRoom = CurrentRoom.GetComponent<BaseRoom>();

            baseRoom.Player = GameObject.Find("dummyPlayer");

            Random.InitState(DateTime.Now.Millisecond);
            var roomWidth = Random.Range(10, 20);
            var roomHeight = Random.Range(10, 20);

            baseRoom.Width = (roomWidth % 2) != 0 ? roomWidth : roomWidth - 1;
            baseRoom.Height = (roomHeight % 2) != 0 ? roomHeight : roomHeight - 1;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
