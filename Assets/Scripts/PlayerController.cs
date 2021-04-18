using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Text allPointsText;
    [SerializeField] AudioClip pickUpClip;
    [SerializeField] AudioClip bladeHitClip;
    private Vector3 originalPos;

    void Start(){
        score = 0;
        setScoreText();
        allPointsText.text = "";
        originalPos = gameObject.transform.position;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Point")){
            AudioSource.PlayClipAtPoint(pickUpClip, other.transform.position);
            other.gameObject.SetActive(false);
            score++;
            setScoreText();
        }
        if(other.gameObject.CompareTag("Blade")){
            AudioSource.PlayClipAtPoint(bladeHitClip, other.transform.position);
            resetLevel();
        }
    }

    void setScoreText(){
        scoreText.text = "Score: " + score.ToString();
        if(score >= 11){
            allPointsText.text = "YOU GOT ALL POINTS!";
        }
    }

    void resetLevel(){
        gameObject.transform.position = originalPos;
        score = 0;
        GameObject points = GameObject.Find("Food");
        foreach(Transform child in points.transform){
            child.gameObject.SetActive(true);
        }
    }

    public int  getCount()
    {
        return this.score;
    }
}
