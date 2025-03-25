using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; 
    public GUISkin layout;
    public float enemySpeedMultiplier = 1.0f;
    public string victorySceneName = "Scene2"; // Nome da sua cena de vitória
    public int scoreToWin = 200; // Pontuação necessária para vencer
    private bool hasWon = false; // Controle para evitar chamadas múltiplas

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Fase1")
        {
            PlayerScore1 = 0;
            hasWon = false;
        }
        else
        {
            // Carrega a pontuação salva
            PlayerScore1 = PlayerPrefs.GetInt("PlayerScore", 0);
        }
    }

    void Update()
    {
        // Verifica se o jogador atingiu a pontuação necessária para vencer
        if (PlayerScore1 >= scoreToWin && !hasWon)
        {
            hasWon = true; // Evita que o código execute várias vezes
            Victory();
        }
    }

    // Método para dar créditos ao jogador
    public void AddScore(int points)
    {
        PlayerScore1 += points;
        
        // Salva a pontuação atual
        PlayerPrefs.SetInt("PlayerScore", PlayerScore1);
        PlayerPrefs.Save();
    }

    // Método para chamar a tela de vitória
    void Victory()
    {
        SceneManager.LoadScene(2);
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 200 - 12, 40, 100, 100), "Score: " + PlayerScore1);
    }

}