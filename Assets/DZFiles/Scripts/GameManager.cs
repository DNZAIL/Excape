using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float levelTime = 300;
    [SerializeField] public TextMeshProUGUI timeText;

    [SerializeField] GameObject currentRespawn; //CHANGE TO A PRIVATE VARIABLE LATER; CURRENTLY 1 RESPAWN POINT FOR PLAYTESTING PURPOSES

    //Runs timer game loop for game
    IEnumerator Countdown()
    {
        float timeLimit = levelTime;
        while (timeLimit > 1) //1 instead of 0 to avoid timer from reaching negative time
        {
            timeLimit -= Time.deltaTime;
            DisplayTime(timeLimit);
            yield return null;
        }

        if(timeLimit <= 1)
        {
            GameOver();
            yield break;
        }
    }

    IEnumerator DelayRespawn(GameObject player)
    {
        FindRespawn();
        player.transform.position = currentRespawn.transform.position;
        player.SetActive(false);
        yield return new WaitForSeconds(2);
        player.SetActive(true);
        //player.transform.position = currentRespawn.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Countdown");
    }

    public void DisplayTime(float timeLeft)
    {
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        timeText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
        Debug.Log("GameOver");
    }

    public void Respawn(GameObject player)
    {
        StartCoroutine("DelayRespawn", player);
    }

    public void FindRespawn()
    {
        Debug.Log("Respawn Found");
    }
}