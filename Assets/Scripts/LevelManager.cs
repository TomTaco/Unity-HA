using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int levelId = 0;
    [SerializeField]
    private AudioClip exitSound;
    [SerializeField]
    private AudioClip levelStartSound;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int maxLevelId = 2;
    private int nextLevelId;
    private int score = 0;
    private int bonks = 0;

    public Text scoreText;
    public Text allPointsText;
    public Text bonkAmountText;
    public GameEvent levelEndEvent;

    private void Start()
    {
        updateScoreText();
        bonkAmountText.text = "";
        allPointsText.text = "";
        //AudioSource.PlayClipAtPoint(levelStartSound, player.transform.position);
    }

    public void ReloadLevel()
    {
        /*Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);*/
        nextLevelId = levelId;
        StartCoroutine(waitForLevelExit(2));
    }

    public void LoadLevel()
    {
        nextLevelId = (levelId + 1) % maxLevelId;
        StartCoroutine(waitForLevelExit(2));
    }

    IEnumerator waitForLevelExit(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(nextLevelId);
    }

    public void playlevelExitSound()
    {
        AudioSource.PlayClipAtPoint(exitSound, player.transform.position);
    }

    public void stopPlayer()
    {
        player.GetComponent<Movement>().disableMovement();
    }

    public void updateScore()
    {
        score++;
    }

    public void updateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void updateAllPointsText()
    {
        allPointsText.text = "All Points collected!";
    }

    public void updateBonks()
    {
        bonks++;
    }

    //"Bonk Amount: " + bonks.ToString()

    public void updateBonkAmountText()
    {
        bonkAmountText.text = "Bonk Amount: " + bonks.ToString();
    }

    public void pointCheck()
    {
        if (score == 11)
        {
            levelEndEvent.Raise();
        }
    }

}
