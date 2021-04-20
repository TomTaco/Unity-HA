using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private GameObject sphere;
    private bool isPressed;

    public AudioClip buttonClickClip;
    public GameEvent OnButton1Press;
    void Start()
    {
        sphere = gameObject.transform.GetChild(1).gameObject;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(!isPressed){
                AudioSource.PlayClipAtPoint(buttonClickClip, other.transform.position);
                sphere.transform.Translate(Vector3.down*0.06f);
                sphere.GetComponent<Renderer>().material.SetColor("_Color",Color.green);
                isPressed = true;
                OnButton1Press.Raise();
            }
        }
    }
    
}
