using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioClip pickUpClip;
    [SerializeField] AudioClip bladeHitClip;
    public GameEvent playerDeathEvent;
    public GameEvent levelEndEvent;
    public GameEvent PointCollectEvent;
    private bool alive = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            AudioSource.PlayClipAtPoint(pickUpClip, other.transform.position);
            other.gameObject.SetActive(false);
            PointCollectEvent.Raise();
        }
        if (other.gameObject.CompareTag("Blade"))
        {
            AudioSource.PlayClipAtPoint(bladeHitClip, other.transform.position);
            killPlayer();
        }
    }

    public void explodePlayer()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }

    private void killPlayer()
    {
        if (alive)
        {
            playerDeathEvent.Raise();
            alive = false;
        }
    }



    /*
    private int score;
    public Text scoreText;
    public Text allPointsText;
    [SerializeField] AudioClip pickUpClip;
    [SerializeField] AudioClip bladeHitClip;
    private Vector3 originalPos;
    public GameEvent playerDeathEvent;
    public GameEvent levelEndEvent;
    private bool alive = true;

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
            //resetLevel();
            killPlayer();
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

    public void pointCheck()
    {
        if (score == 11)
        {
            levelEndEvent.Raise();
        }
    }

    public void explodePlayer()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }

    private void killPlayer()
    {
        if (alive)
        {
            playerDeathEvent.Raise();
            alive = false;
        }
    }*/

}
