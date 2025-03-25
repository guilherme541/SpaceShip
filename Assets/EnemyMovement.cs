using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;         // Velocidade de movimento
    public float rotationSpeed = 30f; // Velocidade de rotação

    void Update()
    {
        // Move para a esquerda
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        // Faz girar o asteroide
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        
        // Destroi o inimigo quando sair da tela
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}