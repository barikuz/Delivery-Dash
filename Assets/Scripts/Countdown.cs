using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] float remainingTime = 60f;

    [SerializeField] TMP_Text timerText;
    
    [SerializeField] GameEnd gameEnd;

    // Update is called once per frame
    void Update()
    {
        if(remainingTime <= 0f)
        {
            timerText.text = "Time's Up!";
            gameEnd.endGame("Game OVER!");
            return;
        }
        else if(!gameEnd.isGameOver)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = "Time: " + remainingTime.ToString("0");
        }

    }


}
