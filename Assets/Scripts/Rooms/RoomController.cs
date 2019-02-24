using UnityEngine;

namespace Assets.Scripts.Rooms
{
    public class RoomController : MonoBehaviour
    {
        public GameObject CurrentRoom;

        // Use this for initialization
        void Start()
        {
            // Lets find another way some day.
            var getBaseRoom = Resources.Load("BaseRoom") as GameObject;
            var getDirt = Resources.Load("Dirt") as GameObject;
            var getWall = Resources.Load("Wall") as GameObject;

            CurrentRoom = Instantiate(getBaseRoom);
            var baseRoom = CurrentRoom.GetComponent<BaseRoom>();

            baseRoom.Player = GameObject.Find("dummyPlayer");
            baseRoom.Width = Random.Range(10, 20);
            baseRoom.Height = Random.Range(10, 20);

            baseRoom.FloorTiles.Add(getDirt);
            baseRoom.WallTiles.Add(getWall);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
