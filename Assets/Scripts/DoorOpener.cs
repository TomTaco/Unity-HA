using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{

    private Animator anim;
    public GameObject door;
    private GameObject sphere;
    private bool isPressed;
    public AudioClip buttonClickClip;
    void Start()
    {
        anim = door.gameObject.GetComponent<Animator>();
        sphere = gameObject.transform.GetChild(1).gameObject;
        isPressed = false;
        anim.SetBool("buttonPressed",false);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(!isPressed){
                AudioSource.PlayClipAtPoint(buttonClickClip, other.transform.position);
                sphere.transform.Translate(Vector3.down*0.06f);
                sphere.GetComponent<Renderer>().material.SetColor("_Color",Color.green);
                anim.SetBool("buttonPressed",true);
                isPressed = true;
            }
        }
    }
    
}
