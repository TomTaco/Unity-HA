using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private GameObject sphere;
    private bool isPressed;
    public AudioClip buttonClickClip;
    public GameEvent ButtonPressEvent;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(!isPressed){
                ButtonPressEvent.Raise();
                AudioSource.PlayClipAtPoint(buttonClickClip, other.transform.position);
                sphere = gameObject.transform.GetChild(1).gameObject; //Sphere
                sphere.transform.Translate(Vector3.down*0.06f);
                sphere.GetComponent<Renderer>().material.SetColor("_Color",Color.green);
                isPressed = true;
            }
        }
    }
    
}
