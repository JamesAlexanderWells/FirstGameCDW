using Assets.Scripts.Enumerations;
using Assets.Scripts.Rooms;
using UnityEngine;

public class Door : MonoBehaviour
{

    public delegate void EnterDoor();
    public static event EnterDoor OnEnterDoor;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var parent = GetComponentInParent<BaseRoom>();
        parent.ExitDoor = SetExitDoor();
        if (OnEnterDoor != null)
        {
            OnEnterDoor();
        }
    }

    private PreviousDoor SetExitDoor()
    {
        if (Input.GetKey(KeyCode.W))
            return PreviousDoor.Top;

        if (Input.GetKey(KeyCode.A))
            return PreviousDoor.Left;

        if (Input.GetKey(KeyCode.D))
            return PreviousDoor.Right;

        if (Input.GetKey(KeyCode.S))
            return PreviousDoor.Bottom;
        return PreviousDoor.Top;
    }
}
