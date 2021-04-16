using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCollector : MonoBehaviour
{
    private int count;
    public Text scoreText;
    public Text allPointsText;
    [SerializeField] AudioClip triggerClip;

    void Start(){
        count = 0;
        setScoreText();
        allPointsText.text = "";
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Point")){
            AudioSource.PlayClipAtPoint(triggerClip, other.transform.position);
            Destroy(other.gameObject);
            count++;
            setScoreText();
            
        }
    }

    void setScoreText(){
        scoreText.text = "Score: " + count.ToString();
        if(count >= 11){
            allPointsText.text = "YOU GOT ALL POINTS!";
        }
    }
}
