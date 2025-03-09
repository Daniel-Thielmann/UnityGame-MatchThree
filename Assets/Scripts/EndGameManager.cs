using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public Text finalScoreText; // Referência ao texto da pontuação

    void Start()
    {
        // Obtém a pontuação final salva no PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Pontos: " + finalScore; // Exibe a pontuação final
    }
    public void ExitGame()
    {
        Debug.Log("Saindo do jogo...");

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; // Para testes no Unity Editor
#else
        Application.Quit(); // Fecha a aplicação na versão compilada
#endif
    }
}