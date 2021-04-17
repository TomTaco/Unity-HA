using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float timeValue;
    public Camera cam1;
    public Camera cam2;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
        timeValue = 9;
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        timeValue -= Time.deltaTime;
        if(timeValue < 0 ){
            cam2.enabled = true;
            cam1.enabled = false;
        }
    }
}
