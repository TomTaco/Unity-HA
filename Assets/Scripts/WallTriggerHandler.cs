using UnityEngine;

public class WallTriggerHandler : MonoBehaviour
{
    public GameEvent wallHitEvent;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            wallHitEvent.Raise();
        }
    }
}
