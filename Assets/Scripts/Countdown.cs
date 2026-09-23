using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] float remainingTime = 60f;

    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text gameOverText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime <= 0f)
        {
            timerText.text = "Time's Up!";
            gameOverText.gameObject.SetActive(true);
            return;
        }
        else
        {
            remainingTime -= Time.deltaTime;
            timerText.text = "Time: " + remainingTime.ToString("0");
        }

    }
}
