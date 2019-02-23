using UnityEngine;

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

            baseRoom.Width = Random.Range(3, 10);
            baseRoom.Height = Random.Range(3, 10);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
