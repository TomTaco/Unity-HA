using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float timeValue;
    private Vector3 offset;
    private Animator anim;
    public Text skipText;
    private bool flyingBy;
    void Start()
    {
        offset = transform.position - player.transform.position;
        anim = GetComponent<Animator>();
        skipText.text = "Press SPACE to SKIP";
        flyingBy = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(flyingBy && timeValue > 0){
            timeValue -= Time.deltaTime;
            if(Input.GetKeyDown("space")){
                anim.speed = 0f;
                anim.Play("FlyByCam",0,9);
                timeValue = 0;
                
            }
        }else{
            flyingBy = false;
            skipText.text = "";
            transform.position = player.transform.position + offset;
        }
        
    }


}
