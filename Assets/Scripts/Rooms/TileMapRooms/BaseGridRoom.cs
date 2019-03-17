using Assets.Scripts.Rooms;
using Assets.Scripts.Rooms.TileMapRooms;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseGridRoom : MonoBehaviour
{

    public Tilemap GroundMap { get; set; }

    public Tilemap WallMap { get; set; }

    public Tilemap DoorMap { get; set; }

    public int RoomWidth { get; set; }

    public int RoomHeight { get; set; }

	void Start ()
    {
        InitRoom();
    }

    public void InitRoom()
    {
        var controller = this.transform.parent.GetComponent<GridController>();
        GroundMap = controller.GroundMap;
        WallMap = controller.WallMap;
        DoorMap = controller.DoorMap;
        BuildRoom(controller.tileSet);
    }

    private void BuildRoom(BaseTileSet controllerTileSet)
    {
        var roomBuilder = new GridRoomBuilder(GroundMap, WallMap, DoorMap, controllerTileSet, RoomWidth, RoomHeight);
        roomBuilder.Build(RoomWidth * -1, RoomHeight * -1);
    }
}
