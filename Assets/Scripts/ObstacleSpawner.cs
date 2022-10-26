using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject obstacle;
    public float maxTime;
    private float timer;
    public float maxY;
    public float minY;
    private float randomY;

    void Start()
    {
        InstasiataObstable();
    }

   
    void Update()
    {

        if (GameManager.gameOver == false)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstasiataObstable();
                timer = 0;
            }
        }
        
    }

    public void InstasiataObstable()
    {
        GameObject newGameObject = Instantiate(obstacle);
        newGameObject.transform.position = new Vector2(transform.position.x, randomY);
    }
}
