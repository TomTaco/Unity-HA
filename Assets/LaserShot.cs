using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserShot : MonoBehaviour
{
    [SerializeField] private AudioClip laserSound;

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(laserSound, transform.position);
    }
}
