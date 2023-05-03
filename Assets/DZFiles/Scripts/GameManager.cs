using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float levelTime = 300;
    [SerializeField] public TextMeshProUGUI timeText;

    //Runs timer game loop for game
    IEnumerator Countdown()
    {
        float timeLimit = levelTime;
        while (timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;
            DisplayTime(timeLimit);
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Countdown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayTime(float timeLeft)
    {
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        timeText.text = minutes.ToString() + ":" + seconds.ToString();
    }
}