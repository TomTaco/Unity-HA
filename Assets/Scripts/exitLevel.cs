using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitLevel : MonoBehaviour
{
    public AudioClip exitSound;
    public GameObject flagge;

    private bool wasTouched = false;
    private bool isEnabled= false;

    private void OnTriggerEnter(Collider other)
    {
        if(!wasTouched && other.CompareTag("Player") && (other.GetComponent<PointCollector>().getCount() >= 11))
        {
            isEnabled = true;
            AudioSource.PlayClipAtPoint(exitSound, Camera.main.transform.position);
            wasTouched = true;
        }
    }

    void Update()
    {
        if (isEnabled)
        {
            if((flagge.transform.position.y - transform.position.y) > - 0.33)
                flagge.transform.Translate(Vector3.down * 1.7f * Time.deltaTime);
        }
    }
}
