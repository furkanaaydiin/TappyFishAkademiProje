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
    [SerializeField] private AudioSource swim, hit, point;
   
    
    
    public Skor skor;   //değişecek
    public GameManager _gamemeneger;
    public ObstacleSpawner obstacleSpawner;


    public UIAnimation uıAnimation;
    
    
    

   private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

   private void Update()
    { 
        FishSwim();
        
    }

    private void FixedUpdate()
    {
        FishRotation();
    }


   private void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            uıAnimation.GetReadyAnim();
            if (!GameManager.gameStared)
            {
                swim.Play();
                _rigidbody2D.gravityScale = 4f;
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, speed);
                obstacleSpawner.InstasiataObstable();
                _gamemeneger.GameHasStared();
                
            }
            else
            {
                swim.Play();
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, speed);
            }
            
        }
    }

   private void FishRotation()
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

        if (!toucheGround)
        {
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            skor.Scored();
            point.Play();
        }
        else if (col.CompareTag("colon") && !GameManager.gameOver)
        {
            //game over
            _gamemeneger.GameOver();
            FinishDiedEffect();
            
            
        }
    }

    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            if (!GameManager.gameOver)
            {
                //gameover
                _gamemeneger.GameOver();
                GameOver();
                FinishDiedEffect();
                
            }
            else
            {
                //game over 
                _gamemeneger.GameOver();
                GameOver();
               // FinishDiedEffect();
            }
        }
    }

   private void FinishDiedEffect()
    {
        
        hit.Play();
    }

   private void GameOver()
    {
        toucheGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}
