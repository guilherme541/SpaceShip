using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour {
    private float length;
    private float movingSpeed = 5f;
    public GameObject cam;
    public float parallaxEffect;
    
    public static float SLOWMO = 1;
    
    private GameObject backgroundCopy;
    private Transform myTransform;
    
    void Start() {
        myTransform = transform;
        
        // Get the length of the sprite
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
        // Create a duplicate background and position it directly next to the original
        backgroundCopy = Instantiate(gameObject, myTransform.parent);
        
        // Remove the script from the copy to prevent infinite loops
        Destroy(backgroundCopy.GetComponent<paralax>());
        
        // Position the copy right next to the original
        backgroundCopy.transform.position = new Vector3(
            myTransform.position.x + length,
            myTransform.position.y,
            myTransform.position.z
        );
    }
    
    void Update() {
        // Move both backgrounds
        float moveAmount = Time.deltaTime * movingSpeed * parallaxEffect * SLOWMO;
        myTransform.Translate(Vector3.left * moveAmount);
        backgroundCopy.transform.Translate(Vector3.left * moveAmount);
        
        // Check if the original background has moved completely off-screen
        if (myTransform.position.x <= -length) {
            // Move it back to the right of the copy
            myTransform.position = new Vector3(
                backgroundCopy.transform.position.x + length,
                myTransform.position.y,
                myTransform.position.z
            );
        }
        
        // Check if the copy has moved completely off-screen
        if (backgroundCopy.transform.position.x <= -length) {
            // Move it back to the right of the original
            backgroundCopy.transform.position = new Vector3(
                myTransform.position.x + length,
                backgroundCopy.transform.position.y,
                backgroundCopy.transform.position.z
            );
        }
    }
}