using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inimigoPrefab;    // Prefab do projétil
    public static float inimigoSpeed = 1.0f;
    public float maxWaitTime = 5f;
    private float timer = 0f;
    void Start()
    {
    
        
    }
    void SpawnarInimigo(){
        var escolha = Random.Range(-3.0f,3.0f);
        
        GameObject inimigo = Instantiate(inimigoPrefab, transform.position + (transform.up * escolha), Quaternion.identity);
        
        // Randomiza o tamanho do inimigo
        float tamanhoAleatorio = Random.Range(0.8f, 1.5f); // Valores entre 0.8 e 1.5
        inimigo.transform.localScale = new Vector3(tamanhoAleatorio, tamanhoAleatorio, 1f);
        
        Rigidbody2D rbInimigo = inimigo.GetComponent<Rigidbody2D>();
        rbInimigo.velocity = Vector2.right * inimigoSpeed * paralax.SLOWMO * -1f;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>= maxWaitTime){
            SpawnarInimigo();
            timer = 0f;
        }
        
    }


}
