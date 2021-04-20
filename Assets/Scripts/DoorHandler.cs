using UnityEngine;
using UnityEngine.Events;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private int id;
    private void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("buttonPressed", false);
    }
    public void openDoor(int id)
    {
        if (this.id == id)
        {
            gameObject.GetComponent<Animator>().SetBool("buttonPressed", true);
        }
    }
    
}
