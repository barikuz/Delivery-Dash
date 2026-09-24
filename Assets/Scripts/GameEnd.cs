using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{   
    [SerializeField] TMP_Text gameResultText;
    
    [SerializeField] Button restartButton;


    public bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameResultText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void endGame(string result)
    {
        isGameOver = true;
        gameResultText.text = result;
        gameResultText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
