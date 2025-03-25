using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importante adicionar esta linha

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Verifica se há inimigos próximos ao player no eixo X
        CheckEnemiesNearby();
    }

    void CheckEnemiesNearby()
    {
        // Encontra todos os objetos com a tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemies)
        {
            // Verifica se o inimigo está na mesma posição X (com margem de -1)
            if (enemy.transform.position.x <= -4.5f)
            {
                // Inimigo está muito próximo no eixo X!
                GameOver();
                return;
            }
        }
    }

    // Detecta colisões físicas usando triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Colisão com inimigo
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}