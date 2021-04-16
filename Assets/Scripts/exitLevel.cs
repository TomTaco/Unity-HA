using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitLevel : MonoBehaviour
{
    public AudioClip exitSound;

    private bool wasTouched = false;
    private bool isEnabled= false;

    private void OnTriggerEnter(Collider other)
    {
        if(!wasTouched && other.CompareTag("Player"))
        {
            isEnabled = true;
            //AudioSource.PlayClipAtPoint(levelExitSound, Camera.main.transform.position);
            wasTouched = true;
        }
    }

    void Update()
    {
        if (isEnabled)
        {
            transform.Rotate(Vector3.up * 1f, Space.World);
        }
    }
}
