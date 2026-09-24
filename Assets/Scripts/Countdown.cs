using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] float remainingTime = 60f;

    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text gameOverText;

    [SerializeField] Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime <= 0f)
        {
            timerText.text = "Time's Up!";
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            return;
        }
        else
        {
            remainingTime -= Time.deltaTime;
            timerText.text = "Time: " + remainingTime.ToString("0");
        }

    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
