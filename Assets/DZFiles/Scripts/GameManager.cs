using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float levelTime = 300;
    [SerializeField] public TextMeshProUGUI timeText;

    private GameObject currentRespawn;

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

    WaitForSeconds delay = new WaitForSeconds(3);
    //Tracks current respawn point & respawns players
    IEnumerator DelayRespawn()
    {
        FindRespawn();
        yield return delay;
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
        Debug.Log("GameOver");
    }

    public void Respawn()
    {
        StartCoroutine("DelayRespawn");
    }

    public void FindRespawn()
    {
        Debug.Log("Respawn Found");
    }
}