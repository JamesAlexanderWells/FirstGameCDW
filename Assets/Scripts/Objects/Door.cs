using UnityEngine;

public class Door : MonoBehaviour {

    public delegate void EnterDoor();
    public static event EnterDoor OnEnterDoor;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (OnEnterDoor != null)
        {
            OnEnterDoor();
        }
    }
}
