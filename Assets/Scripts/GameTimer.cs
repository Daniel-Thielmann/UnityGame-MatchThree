using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f;
    private float timeRemaining;
    private bool gameOver = false;

    public Text timeText;
    public ShapesManager shapesManager; // Referência ao ShapesManager para pegar a pontuação

    void Start()
    {
        timeRemaining = totalTime;
        UpdateTimeDisplay();
    }

    void Update()
    {
        if (gameOver) return;

        timeRemaining -= Time.deltaTime;
        UpdateTimeDisplay();

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            gameOver = true;
            EndGame();
        }
    }

    private void UpdateTimeDisplay()
    {
        if (timeText != null)
            timeText.text = "Time: " + Mathf.RoundToInt(timeRemaining).ToString();
    }

    private void EndGame()
    {
        gameOver = true; // Marca que o jogo acabou
        Debug.Log("Tempo esgotado! Indo para a tela final...");

        // Salva a pontuação final antes de carregar a tela de fim de jogo
        if (shapesManager != null)
        {
            PlayerPrefs.SetInt("FinalScore", shapesManager.GetScore());
            PlayerPrefs.Save(); // Garante que o score seja salvo imediatamente
        }

        // Carrega a cena final
        SceneManager.LoadScene("EndGameScene");
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

}

