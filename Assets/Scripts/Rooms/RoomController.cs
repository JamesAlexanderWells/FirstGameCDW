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
            baseRoom.Width = Random.Range(10, 20);
            baseRoom.Height = Random.Range(10, 20);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
