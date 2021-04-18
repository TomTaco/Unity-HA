using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int levelId = 0;
    [SerializeField]
    private AudioClip exitSound;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int maxLevelId = 2;
    private int nextLevelId;

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
}
