using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private int levelId = 0;
    [SerializeField] private AudioClip exitSound;
    [SerializeField] private AudioClip levelStartSound;
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private GameObject player;
    [SerializeField] private int maxLevelId = 2;
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
        nextLevelId = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(waitForLevelExit(2));
    }

    public void ReloadLevelInstant(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadLevel()
    {
        nextLevelId = (SceneManager.GetActiveScene().buildIndex+1 <= maxLevelId) ? SceneManager.GetActiveScene().buildIndex+1 : 0 ;
        StartCoroutine(waitForLevelExit(2));
    }

    public void LoadMainMenu(){
        levelId = 0;
        SceneManager.LoadScene(levelId);
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

    public void fadeBgMusic()
    {
        StartCoroutine(StartFade(bgMusic, 2, 0));
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
