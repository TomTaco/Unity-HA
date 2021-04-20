using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private int id;

    private void Start()
    {
        GetComponent<Animator>().SetBool("buttonPressed", false);
    }

    public void openDoor(int id)
    {
        if(id == this.id)
        {
           GetComponent<Animator>().SetBool("buttonPressed", true);
        }
    }
}
