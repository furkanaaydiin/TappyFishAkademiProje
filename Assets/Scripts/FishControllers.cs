using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class FishControllers : MonoBehaviour
{
     private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed;
    private int angle;
    private int maxangle = 20;
    private int minangle = -60;
    private bool toucheGround;
    public Sprite fishDied;
    private SpriteRenderer sp;
    private Animator anim;
    
    
    public Skor skor;
    public GameManager _gamemeneger;
    
    
    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        FishSwim();
        
    }

    private void FixedUpdate()
    {
        FishRotation();
    }


    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, speed);
        }
    }

    void FishRotation()
    {
        if (_rigidbody2D.velocity.y > 0)
        {
            if (angle <= maxangle)
            {
                angle = angle + 4;
            }
            
        }
        else if (_rigidbody2D.velocity.y < 0)
        {
            if (angle >= minangle)
            {
                angle = angle - 1;
            }
            
        }

        if (toucheGround == false)
        {
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            skor.Scored();
        }
        else if (col.CompareTag("colon"))
        {
            //game over
            _gamemeneger.GameOver();
            
        }
    }

    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                //gameover
                _gamemeneger.GameOver();
                GameOver();
            }
            else
            {
                //game over 
                _gamemeneger.GameOver();
                GameOver();
            }
        }
    }

    void GameOver()
    {
        toucheGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}
