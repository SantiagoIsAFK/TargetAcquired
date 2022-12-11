using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{
    public NaveTopDownCore Core;

    public GameObject finishGameMenu;

    public TextMeshProUGUI txtScore, txtHighScore;

    private void Awake()
    {
        Core.OnUpdateScore.AddListener(UpdateScore);
        Core.OnFinishGame.AddListener(FinishGame);

        txtHighScore.text = "Máxima: " + Core.highScore.ToString();
    }

    public void UpdateScore()
    {
        txtScore.text = "Puntuación: " + Core.currentScore.ToString();
    }

    public void FinishGame()
    {
        finishGameMenu.SetActive(true);

        txtScore.text = "Puntuación: "+Core.currentScore.ToString();
        txtHighScore.text = "Máxima: "+Core.highScore.ToString();
    }

    public void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
