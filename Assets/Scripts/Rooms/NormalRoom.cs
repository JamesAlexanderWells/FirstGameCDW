using Assets.Scripts.Enumerations;
using UnityEngine;

namespace Assets.Scripts.Rooms
{
    public class NormalRoom : BaseRoom
    {
        public override Vector3 GetInitialPosition(Vector3 playerPosition)
        {
            switch (ExitDoor)
            {
                case PreviousDoor.Bottom:
                    return new Vector3(0.5f * (Width * TileSize.x),
                        Height * TileSize.y, 0);
                case PreviousDoor.Left:
                    return new Vector3((Width * TileSize.x),
                        0.5f * (Height * TileSize.y), 0);
                case PreviousDoor.Right:
                    return new Vector3(1 * TileSize.x,
                        0.5f * (Height * TileSize.y), 0);
                case PreviousDoor.Top:
                    return new Vector3(0.5f * (Width * TileSize.x),
                        1 * TileSize.y, 0);
                default:
                    return base.GetInitialPosition(playerPosition);
            }
        }
    }
}
