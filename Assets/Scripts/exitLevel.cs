using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitLevel : MonoBehaviour
{
    /*public AudioClip exitSound;
    //private bool wasTouched = false;*/
    public GameObject flagge;
    public GameEvent ReqCheck;
    private bool isEnabled= false;

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(!wasTouched && other.CompareTag("Player") && (other.GetComponent<PlayerController>().getCount() >= 11))
        {
            isEnabled = true;
            AudioSource.PlayClipAtPoint(exitSound, other.transform.position);
            wasTouched = true;
        }
    }
    */

    void Update()
    {
        if (isEnabled)
        {
            putDownFlag();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ReqCheck.Raise();
    }

    public void setEnabled()
    {
        isEnabled = true;
    }

    private void putDownFlag()
    {
        if ((flagge.transform.position.y - transform.position.y) > -0.33)
            flagge.transform.Translate(Vector3.down * 1.7f * Time.deltaTime);
    }





}
