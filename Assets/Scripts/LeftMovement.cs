using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Build.Content;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{

    public float speed;

    private BoxCollider2D box;

    private float obstableWidth;

   float graundWiht;
    
    void Start()
    {
        if(gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            graundWiht = box.size.x;
        }
        else if(gameObject.CompareTag("Obstacle"))
        {
            obstableWidth = GameObject.FindGameObjectWithTag("colon").GetComponent<BoxCollider2D>().size.x;
        }

        
        
       
    }

    
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        
        
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -graundWiht)
            {
                transform.position = new Vector2(transform.position.x + 2 * graundWiht, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.buttonLeft.x- obstableWidth)
            {
                Destroy(gameObject);
            }
        }
          
        
    }
}
