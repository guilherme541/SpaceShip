using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.W;  // Movimento para a Cima
    public KeyCode moveLeft = KeyCode.S;   // Movimento para a Baixo
    public float speed = 10.0f;

    // Limites de movimento
    public float boundY = 5.0f;
    private Rigidbody2D rb2d;

    // Parâmetros para o tiro
    public GameObject projectilePrefab;    // Prefab do projétil
    public Transform Firee;                // Ponto de origem do tiro
    public float projectileSpeed = 10.0f;  // Velocidade do projétil


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // audioSource = GetComponent<AudioSource>();  // Obtém o componente de áudio
    }

    void Update()
    {
        // Movimento horizontal do player
        var vel = rb2d.velocity;

        if (Input.GetKey(moveRight))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveLeft))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        rb2d.velocity = vel;

        var pos = transform.position;

        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }

        transform.position = pos;

        // Atirar quando a tecla Espaço for pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Slowmotion();
        }
    }


    void Slowmotion()
    {
        var inimigos = GameObject.FindGameObjectsWithTag("Enemy");
        var projeteis = GameObject.FindGameObjectsWithTag("pipoco");
        if(paralax.SLOWMO == 1){
            paralax.SLOWMO = 0.5f;
        } else {
            paralax.SLOWMO = 1f;
        }

        for (int i=0; i<projeteis.Length; i++){
            Rigidbody2D rbProjectile = projeteis[i].GetComponent<Rigidbody2D>();
            rbProjectile.velocity = Vector2.right * projectileSpeed * paralax.SLOWMO;
        }
        for (int i=0; i<inimigos.Length; i++){
            Rigidbody2D rbEnemy = inimigos[i].GetComponent<Rigidbody2D>();
            rbEnemy.velocity = Vector2.right * SpawnEnemy.inimigoSpeed * paralax.SLOWMO *-1f;
        }

    }
    void Shoot()
    {
        // Instanciar o projétil no Firee e adicionar força para ele se mover para cima
        GameObject projectile = Instantiate(projectilePrefab, Firee.position, Quaternion.identity);
        Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
        rbProjectile.velocity = Vector2.right * projectileSpeed * paralax.SLOWMO;  // Movimenta o projétil para o lado

    }
}
