using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour
{
    [SerializeField]
    private int levelId = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetComponent<PointCollector>().getCount() >= 11))
        {
            other.gameObject.GetComponent<Movement>().disableMovement();
            StartCoroutine(waitForLevelExit());
        }
    }

    IEnumerator waitForLevelExit()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelId);
    }
}
