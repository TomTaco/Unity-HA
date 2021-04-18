using UnityEngine;

public class WallTriggerHandler : MonoBehaviour
{
    public GameEvent wallHitEvent;


    private void OnTriggerEnter(Collider other)
    {
        wallHitEvent.Raise();
    }
}
