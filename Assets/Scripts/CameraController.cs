using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float timeValue;
    private Vector3 offset;
    private Animator anim;
    public Text skipText;
    private bool flyingBy;
    private float animLength;
    private string animName;
    void Start()
    {
        offset = transform.position - player.transform.position;
        anim = GetComponent<Animator>();
        skipText.text = "Press SPACE to SKIP";
        flyingBy = true;
        animName = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        animLength = anim.GetCurrentAnimatorStateInfo(0).length;
        timeValue = animLength;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(flyingBy && timeValue > 0){
            timeValue -= Time.deltaTime;
            if(Input.GetKeyDown("space")){
                anim.speed = 0f;
                anim.Play(animName,0,animLength);
                timeValue = 0;
                
            }
        }else{
            flyingBy = false;
            skipText.text = "";
            transform.position = player.transform.position + offset;
        }
        
    }


}
