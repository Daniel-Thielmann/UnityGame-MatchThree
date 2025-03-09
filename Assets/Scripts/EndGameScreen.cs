using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    public Text scoreText; // Referência ao texto que exibirá o score

    void Start()
    {
        // Recupera o score salvo no PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        // Exibe o score na tela
        if (scoreText != null)
        {
            scoreText.text = "Score: " + finalScore.ToString();
        }
    }
}